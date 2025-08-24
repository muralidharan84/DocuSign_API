DocuSign API Integration (Job Contract System)

This repository contains a .NET Core Web API backend and an Angular frontend for generating and sending job contracts using DocuSign API.

🚀 Backend (.NET Core API) Setup
Step 1: Clone the repository
git clone https://github.com/muralidharan84/DocuSign_API.git

Step 2: Extract the files

Unzip the project if downloaded manually.

Step 3: Open Solution

Double click Docusign.JobContract.API.sln to open the solution in Visual Studio.

Step 4: Rebuild the Application

From Visual Studio, select Build → Rebuild Solution.

Step 5: Update Database Connection

Navigate to the Docusign.JobContract.WebApi project and update the DefaultConnection string in appsettings.json to point to your database.

Step 6: Configure DocuSign

Create a DocuSign Developer Account if you don’t already have one:
👉 Create Sandbox Account

Step 7: Login to DocuSign Developer Account
Step 8: Get API Keys

Navigate to 👉 Apps and Keys
 and copy the required credentials.

Step 9: Create App (if not exists)

If no app is listed, click Add App and Integration Key.

Step 10: Edit App Settings

Click Actions → Edit on your app.

Step 11: Generate RSA Key

If you need a new key pair, click Generate RSA and download it.

Step 12: Save Private Key

Copy the private key including header/footer:

-----BEGIN RSA PRIVATE KEY-----
...
-----END RSA PRIVATE KEY-----


Save it as private.key in the root of the WebAPI project.

Step 13: Set Callback URL

Provide callback URL:

https://ABC/ds/callback


Replace ABC with your server’s domain.

Step 14: Configure CORS

Enable required HTTP methods.

Step 15: Update Credentials

Replace the placeholders in appsettings.json with your values:

AccountId

IntegrationKey

UserId

Step 16: Run EF Migrations

Open Package Manager Console:
Tools → NuGet Package Manager → Package Manager Console

Select Default Project → Docusign.JobContract.API.Infrastructure

Run:

add-migration Initial
update-database

🌐 Frontend (Angular App) Setup
Step 1: Open Project

Navigate to docusign-offer-app folder in VS Code or any editor.

Step 2: Install Dependencies
npm install

Step 3: Build Angular Project
ng build

Step 4: Run Angular App
ng serve

Step 5: Generate Offer

Fill out the job contract details in the form.

Click Generate Offer → PDF preview appears on the right.

Step 6: Send for Signature

Click Send for Signature.

Step 7: Sign in DocuSign

Login at 👉 DocuSign Send

You will find the contract ready for signature and download.

✅ Features

Generate job contracts dynamically

Preview contract as PDF

Send contracts via DocuSign API

Track signing workflow

🛠 Tech Stack

Backend: ASP.NET Core Web API, EF Core, SQL Server

Frontend: Angular

Authentication: DocuSign API with JWT + RSA private key
