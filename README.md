# VideoGameRepo (Named it this then ... realised I had more than my classic games to sell...)

A basic, full-stack ASP.NET Core MVC web application designed to track, categorise, and manage all the stuff I put on trademe for sale

## Features

* Sort Items by column
* List or Grid view
* Image upload
* CRUD capability

## 🛠️ Tech Stack

* **Backend Framework:** C# (.NET 8.0 / 9.0)
* **Architecture:** Model-View-Controller (MVC)
* **Database Engine:** SQL Server
* **ORM:** Entity Framework Core (Code-First Migration workflows)
* **Frontend UI Layout:** Razor Views, Bootstrap 5, Custom CSS

## 💻 Installation & Setup

1. **Clone the Repository:**
   ```bash
   git clone <your-repository-url>
   ```

2. **Update Connection String:**
   Open `appsettings.json` and adjust the `DefaultConnection` string to point to your local SQL Server instance.

3. **Apply Database Migrations:**
   Open the Package Manager Console in Visual Studio and run:
   ```powershell
   Update-Database
   ```

4. **Run Application:**
   Press `Ctrl + F5` inside Visual Studio to build and launch the application locally.
