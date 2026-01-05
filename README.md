C
# 🧳 TravelBooking — Travel Booking Web Application

> **Academic Project – Built with ASP.NET Core MVC & SQLite**  
> Academic Year: 2025-2026  
> Technologies: .NET 8, ASP.NET Core MVC, Entity Framework Core, SQLite, Bootstrap 5  
> Duration: ~1 month  

---

## 📌 Table of Contents

- [🎯 Project Overview](#-project-overview)
- [✨ Key Features](#-key-features)
- [👥 User Roles](#-user-roles)
- [⚙️ Tech Stack](#️-tech-stack)
- [📦 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
- [🔑 Test Accounts](#-test-accounts)
- [📊 Admin Dashboard](#-admin-dashboard)
- [📚 Documentation](#-documentation)
- [🎓 Evaluation Criteria](#-evaluation-criteria)
- [💡 Possible Enhancements (Bonus)](#-possible-enhancements-bonus)
- [📧 Contact](#-contact)

---

## 🎯 Project Overview

**TravelBooking** is a full-featured web application for browsing and booking travel packages. Developed as part of an academic software engineering project, it enables customers to explore destinations, view available travel offers, and make secure reservations. Administrators can manage destinations, packages, and reservations through a dedicated dashboard.

The application follows the **Model-View-Controller (MVC)** architectural pattern and uses **Entity Framework Core** with **SQLite** for data persistence—ensuring a lightweight, file-based, and easily deployable database solution ideal for development and demonstration purposes.

---

## ✨ Key Features

- ✅ **User Authentication**: Register, login, logout, and profile management.
- ✅ **Public Catalog**: Browse travel packages with filters (destination, price range, duration).
- ✅ **Booking System**: Select travel dates, number of travelers, and complete reservations.
- ✅ **Admin Panel**: Full CRUD operations for destinations and travel packages.
- ✅ **Reservation Management**: View, update, or cancel bookings (user & admin views).
- ✅ **Admin Dashboard**: Key metrics—total bookings, revenue, popular destinations, active packages.
- ✅ **Responsive UI**: Mobile-friendly interface using **Bootstrap 5**.

---

## 👥 User Roles

| Role | Capabilities |
|------|--------------|
| **Visitor** | Browse packages, register, log in. |
| **Customer** | Make bookings, view booking history, edit profile. |
| **Administrator** | Manage destinations & packages, view/edit all bookings, access analytics dashboard. |

---

## ⚙️ Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 8)
- **Language**: C# 12
- **Database**: **SQLite** (via `Microsoft.Data.Sqlite`)
- **ORM**: Entity Framework Core (Code-First)
- **Frontend**: HTML5, CSS3, Bootstrap 5, Razor Views
- **Authentication**: ASP.NET Core Identity (customized)
- **Tools**: Visual Studio 2022 / VS Code, Git

---

## 📦 Project Structure (Simplified)

```
TravelBookingApp/
├── Controllers/          # MVC Controllers
├── Models/               # EF Core Models + Identity
├── Views/                # Razor Views (.cshtml)
├── Data/                 # DbContext and migrations
├── wwwroot/              # CSS, JS, images
├── appsettings.json      # Configuration (SQLite connection)
└── Program.cs            # App entry point
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Any code editor (Visual Studio 2022 recommended)

### Installation & Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/TravelBookingApp.git
   cd TravelBookingApp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Apply database migrations** (creates `travelbooking.db`)
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. Open your browser at:  
   👉 [https://localhost:5001](https://localhost:5001) (or `http://localhost:5000`)

> The SQLite database file (`travelbooking.db`) will be generated automatically in the project root upon first run.

---

## 🔑 Test Accounts

| Role | Email | Password |
|------|-------|--------|
| **Admin** | admin@travelapp.com | Admin123! |
| **Customer** | user@travelapp.com | User123! |

> You can register new customers during runtime. The admin account is seeded at first launch.

---

## 📊 Admin Dashboard

Access the admin dashboard after logging in as an administrator:  
**Navigation**: Top menu → *Dashboard* or *Manage Packages*

Includes:
- Total bookings & revenue (mock or calculated)
- List of active travel packages
- Quick actions: Add/Update/Delete destinations & offers

---

## 📚 Documentation

- Full project specifications: `CAHIER DES CHARGES.NET_project.docx`
- Database schema: Defined via EF Core models in `Models/`
- Screenshots & UI preview: See `screenshots/` folder or attached `image.png`

---

## 🎓 Evaluation Criteria (Academic Focus)

This project fulfills the following academic requirements:
- Clean MVC architecture
- Secure user authentication & role-based authorization
- Data validation (client + server side)
- Responsive and intuitive UI
- Proper use of Entity Framework Core with SQLite
- Complete CRUD functionality
- Adherence to provided functional specifications

---

## 💡 Possible Enhancements (Bonus Ideas)

- 📅 Calendar integration (e.g., full booking calendar)
- 💳 Payment gateway simulation (Stripe/PayPal mock)
- 📧 Email confirmation on booking
- 🌍 Multi-language support (i18n)
- 📱 Deploy to Azure App Service or Docker container

---

## 📧 Contact

Developed by: **Salma Chah**  
📧 Email: salma.chah26@gmail.com  
📱 Phone: +212 693-868607  
🎓 Institution: EMSI Casablanca – AI & Data Science Engineering Program

---

> ✨ **Happy travels—and happy coding!** ✨

--- 
