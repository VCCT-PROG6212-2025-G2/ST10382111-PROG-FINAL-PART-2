# 📋 CMCS — Claim Management and Coordination System

CMCS is a web-based application built with ASP.NET Core MVC that streamlines the submission, tracking, verification, and approval of lecturer claims. It supports a multi-role workflow involving Lecturers, Coordinators, and Managers, and is designed for clarity, usability, and real-time interaction.

---

## 🚀 Features

- ✅ Submit claims with document uploads (PDF, DOCX, XLSX)
- ✅ Track submitted claims in real time
- ✅ Coordinator view to verify or reject pending claims
- ✅ Manager view to approve or reject verified claims
- ✅ In-memory data storage (no database required)
- ✅ Responsive UI with Bootstrap
- ✅ Unit tests for core business logic

---

## 🛠️ Tech Stack

- **Framework**: ASP.NET Core MVC (.NET 6+)
- **Language**: C#
- **Frontend**: Razor Views, Bootstrap 5
- **Storage**: In-memory (via singleton service)
- **Testing**: xUnit

---

## 📁 Project Structure

CMCS/
├── Controllers/ │
├── ClaimsController.cs │ ├── CoordinatorController.cs │ ├── ManagerController.cs │ └── HomeController.cs
├── Models/ │ └── Claim.cs
├── Services/ │ └── ClaimService.cs 
├── Views/ │ ├── Claims/ │ │ ├── Submit.cshtml │ │ └── Track.cshtml │ ├── Coordinator/ │ │ └── Index.cshtml │ ├── Manager/ │ │ └── Index.cshtml │
└── Shared/ │ └── _Layout.cshtml ├── wwwroot/ │ └── uploads/ ├── Program.cs ├── appsettings.json └── README.md

