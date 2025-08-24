using Docusign.JobContract.API.Application.DocuSign;
using Docusign.JobContract.API.Core.Common;
using Docusign.JobContract.API.Core.Entities;
using Docusign.JobContract.API.Core.Models;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;
using Microsoft.Extensions.Configuration;
using MyApp.Core.Interfaces;
using PuppeteerSharp;
using PuppeteerSharp.Media;
//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Infrastructure.Services
{


    public class DocuSignService : IDocuSignApiClient
    {
        private readonly IConfiguration _config;

        private readonly HttpClient _httpClient;

        private readonly DocuSignJWTHelper _docuSignJWTHelper;
        private readonly IEnvelopeLogRepository _envelopeRepo;
        private readonly IErrorLogRepository _errorRepo;

        public DocuSignService(HttpClient httpClient, IConfiguration config, DocuSignJWTHelper docuSignJWTHelper, IEnvelopeLogRepository envelopeRepo,
        IErrorLogRepository errorRepo)
        {
            _httpClient = httpClient;
            _config = config;
            _docuSignJWTHelper = docuSignJWTHelper;
            _envelopeRepo = envelopeRepo;
            _errorRepo = errorRepo;
        }

        public async Task<EnvelopeLog> SendStringDocumentForSigningAsync(
            string recipientEmail, string recipientName, string content, string fileName)
        {
            //var pdfBytes = ConvertStringToPdf(content);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "GeneratedReports", $"{fileName}.pdf");
            byte[] pdfBytes = File.ReadAllBytes(filePath);

            // Convert to Base64
            string base64Pdf = Convert.ToBase64String(pdfBytes);


            var apiClient = _docuSignJWTHelper.GetApiClient();
            var envelopesApi = new EnvelopesApi(apiClient);

            var document = new DocuSign.eSign.Model.Document
            {
                DocumentBase64 = Convert.ToBase64String(pdfBytes),
                Name = fileName.EndsWith(".pdf") ? fileName : fileName + ".pdf",
                FileExtension = "pdf",
                DocumentId = "1"
            };

            var signer = new Signer
            {
                Email = recipientEmail,
                Name = recipientName,
                RecipientId = "1",
                RoutingOrder = "1",
                Tabs = new Tabs
                {
                    SignHereTabs = new List<SignHere>
                {
                    new SignHere
                    {
                        DocumentId = "1",
                        PageNumber = "1",
                        XPosition = "100",  // pixels from left
                        YPosition = "500"   // pixels from top
                    }
                }
                }
            };

            var envelopeDefinition = new EnvelopeDefinition
            {
                EmailSubject = "Please sign this document",
                Documents = new List<DocuSign.eSign.Model.Document> { document },
                Recipients = new Recipients { Signers = new List<Signer> { signer } },
                Status = "sent"
            };
            try
            {
                var results = await envelopesApi.CreateEnvelopeAsync(_config["DocuSign:AccountId"], envelopeDefinition);
                // Save log to DB
                var envelopelog= new EnvelopeLog
                {
                    EnvelopeId = results.EnvelopeId,
                    RecipientEmail = recipientEmail,
                    RecipientName = recipientName,
                    Status = results.Status,
                };
                await _envelopeRepo.AddEnvelopeLogAsync(envelopelog);
                return envelopelog;
            }
            catch (Exception ex)
            {
                await _errorRepo.AddErrorLogAsync(new ErrorLog
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                });

                throw; // rethrow for higher-level handling
            }
        }

        public async Task<string> GetEnvelopeStatusAsync(string envelopeId)
        {
            var apiClient = _docuSignJWTHelper.GetApiClient();
            var envelopesApi = new EnvelopesApi(apiClient);

            var envelope = await envelopesApi.GetEnvelopeAsync(_config["DocuSign:AccountId"], envelopeId);
            return envelope.Status;
        }

        public async Task<string> GetOfferLetterPDFAsync(JobOfferModel doc) //, string htmlContent, string fileName)
        {
            // Ensure Chromium is available (downloads on first run)
            await new BrowserFetcher().DownloadAsync();

            // Launch Chromium in headless mode
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" }
            });

            // Open a new page
            using var page = await browser.NewPageAsync();



            var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.png");
            var logoBytes = File.ReadAllBytes(logoPath);
            var base64Logo = Convert.ToBase64String(logoBytes);

            // Then inject into HTML
            var html = $@"<html>
                              <body>
                                <div style='text-align:center;margin-bottom:30px;'>
                                  <img src='data:image/png;base64,{base64Logo}' alt='Logo' style='max-width:150px;'/>
                                  <h1>Job Offer Letter</h1>
                                </div>
                                <p><strong>Candidate:</strong> {doc.CandidateName}</p>
                                <p>{doc.content}</p>
                              </body>
                            </html>";


            // Set HTML content
            await page.SetContentAsync(html);//doc.content);

            // Build file path
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "GeneratedReports");
            Directory.CreateDirectory(folder);
            var filePath = Path.Combine(folder, $"JobOffer_{doc.CandidateName}.pdf");

            // Generate PDF
            await page.PdfAsync(filePath, new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                MarginOptions = new MarginOptions
                {
                    Top = "20px",
                    Right = "20px",
                    Bottom = "20px",
                    Left = "20px"
                }
            });

            return filePath; // absolute path on server
        }
    }
}
