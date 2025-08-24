using Docusign.JobContract.WebApi;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


builder.Services.AddAppDI(builder.Configuration);

//// Tell QuestPDF which license type you are using
//QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();
//app.MapHub<EnvelopeStatusHub>("/hubs/envelopeStatus");

app.Run();
