# ProjectWebCV  
### Dynamic CV Web Application (ASP.NET Core MVC + EF Core)

---

## 🇬🇧 English Description

**ProjectWebCV** is a dynamic, fully editable personal CV website built with **ASP.NET Core MVC**, featuring bilingual content (BG/EN), certificate management, project section, and PDF generation using Playwright.  
All content—including text fields, skills, experience, projects, images, certificates and profile photo—can be edited directly from an admin interface.

---

## ✨ Features
- 🌍 Dual language support (Bulgarian / English)  
- 📝 Edit all CV content visually from the Edit page  
- 🖼 Certificate management (add, replace, delete) with image preview  
- 📸 Profile photo upload with automatic cleanup of old files  
- 💼 Projects section (title, description with bullet support, external links)  
- 📄 Playwright-based PDF generation (A4, keeps styles and colors)  
- 🎨 Responsive UI using Bootstrap 5  
- 🗂 Clean architecture using MVC + EF Core  
- 🧹 Automatic deletion of unused files (images/certificates)

---

## 🧰 Tech Stack
- **ASP.NET Core MVC 8**
- **Entity Framework Core**
- **SQL Server**
- **Playwright** (PDF generation)
- **Bootstrap 5**
- HTML5 / CSS3 / Razor Views

---

## 🇧🇬 Описание на български

**ProjectWebCV** е персонален уеб сайт за CV, разработен с **ASP.NET Core MVC**, който позволява пълно редактиране на съдържанието, двуезична поддръжка, управление на сертификати, проекти и генериране на PDF файл с оригиналния дизайн.  
Всички елементи се управляват удобно през специална страница за редакция.

---

✨ Функционалности
- 🌍 Двуезична поддръжка (BG / EN)  
- 📝 Пълно редактиране на всички секции на CV-то  
- 🖼 Управление на сертификати (добавяне / подмяна / изтриване)  
- 📸 Качване на профилна снимка с автоматично изтриване на старата  
- 💼 Секция „Проекти“ с описание, bullet точки и линкове  
- 📄 Генериране на PDF чрез Playwright (формат A4)  
- 🎨 Модерен responsive интерфейс (Bootstrap 5)  
- 🧹 Автоматично почистване на неизползвани файлове  

---

📦 Installation & Run

1️⃣ Clone repository
  
   git clone https://github.com/Winchestur/ProjectWebCV.git

2️⃣ Configure database connection
*(In appsettings.json update your SQL Server name:)*

   "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProjectWebCV;Trusted_Connection=True;"
}

*(Replace YOUR_SERVER with your local SQL Server instance.)*

3️⃣ Apply EF Core migrations

   dotnet ef database update

4️⃣ Run the application

   dotnet run

5️⃣ Open the project

   http://localhost:5000/cv/index

---

📂 Project Structure

ProjectWebCV/
 ├── Controllers/
 │     └── CvController.cs
 ├── Models/
 │     ├── CvModel.cs
 │     ├── Certificate.cs
 │     └── Project.cs
 ├── Views/
 │     ├── Cv/
 │     │    ├── Index.cshtml
 │     │    └── Edit.cshtml
 ├── Data/
 │     └── AppDbContext.cs
 ├── wwwroot/
 │     ├── images/
 │     ├── certificates/
 │     └── css/
 ├── appsettings.json
 ├── Program.cs
 └── README.md

--- 

🛠️ How to Run Locally (for other developers)

✔️ Database

 - Requires SQL Server

 - Automatic migrations supported

 - All data stored in SQL using EF Core

✔️ Static Files

(Images are stored in:)

wwwroot/images/
wwwroot/certificates/

(They are deleted and replaced automatically when updating.)

---

🧪 How PDF Generation Works (Playwright)

This project uses Microsoft.Playwright to generate a PDF from the live CV page.

How it works:

1️⃣ Opens /Cv/Index?lang=bg/en in a headless Chromium browser

2️⃣ Applies @media print CSS (hides footer, buttons, icons)

3️⃣ Renders into a perfect A4 PDF

4️⃣ Keeps full colors & curves of the header

5️⃣ Fits everything on a single page

var pdf = await page.PdfAsync(new() {
    Format = "A4",
    PrintBackground = true
});

---

🏗️ How Certificates Work

 - Each certificate has:

   1. BG title
   2. EN title
   3. optional image

 - Images stored in /wwwroot/certificates/

 - Old image is deleted when replaced

 - Certificates can be previewed in pop-up (modal)

 - Certificates are hidden in the PDF (print CSS)

---

🧱 How Projects Work

The CV supports a Projects section with:

 - Title BG / Title EN

 - Description BG / EN

 - Multiple links (one per line)

 - Dynamic bullet parsing
   1.Lines starting with - → shown as plain rows
   2.Other lines → bullet list

(All projects are automatically formatted in PDF and on the site.)

---

📄 License

MIT License