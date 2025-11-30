\# ProjectWebCV  

\### Dynamic CV Web Application (ASP.NET Core MVC + EF Core)



---



\## 🇬🇧 English Description



\*\*ProjectWebCV\*\* is a personal CV website built with \*\*ASP.NET Core MVC\*\*, allowing full visual editing of all content, bilingual support, certificate management, project listings and PDF generation using Playwright.



\### ✨ Features

\- 🌍 Fully bilingual (BG/EN)  

\- 📝 Edit every CV field directly inside the website  

\- 🖼 Certificate management (upload / replace / delete)  

\- 📸 Profile photo upload with auto-cleanup of old files  

\- 💼 Projects section with title, description, links  

\- 📄 PDF export with Playwright (A4 layout, keeps colors \& design)  

\- 🎨 Responsive Bootstrap 5 UI



\### 🧰 Tech Stack

\- ASP.NET Core MVC 8  

\- Entity Framework Core  

\- SQL Server  

\- Playwright (PDF generation)  

\- Bootstrap 5  

\- HTML5 / CSS3  



---



\## 🇧🇬 Описание на български



\*\*ProjectWebCV\*\* е персонален уеб сайт за CV, изграден с \*\*ASP.NET Core MVC\*\*, който позволява пълно редактиране на съдържанието, двуезична поддръжка, управление на сертификати, проекти и генериране на PDF, който изглежда като оригиналната страница.



\### ✨ Функционалности

\- 🌍 Двуезична поддръжка (BG/EN)  

\- 📝 Пълно редактиране на всички секции на CV-то  

\- 🖼 Управление на сертификати (качване / подмяна / изтриване)  

\- 📸 Качване на профилна снимка с автоматично изтриване на старата  

\- 💼 Секция „Проекти“ (заглавия, описания, линкове)  

\- 📄 Генериране на PDF чрез Playwright (A4, запазва цветовете и стила)  

\- 🎨 Модерен responsive интерфейс с Bootstrap 5  



---



\## 📦 Installation \& Run



1\. Clone the repository  

2\. Configure `appsettings.json` (SQL Server connection string)  

3\. Apply migrations:

&nbsp;  ```bash

&nbsp;  dotnet ef database update

&nbsp;  ```

4\. Run the app:

&nbsp;  ```bash

&nbsp;  dotnet run

&nbsp;  ```

5\. Open:  

&nbsp;  \*\*http://localhost:5000/cv/index\*\*



---



\## 📂 Project Structure



```

ProjectWebCV/

&nbsp;├── Controllers/

&nbsp;├── Models/

&nbsp;├── Views/

&nbsp;├── wwwroot/

&nbsp;│     ├── images/

&nbsp;│     ├── certificates/

&nbsp;│     └── css/

&nbsp;├── Data/

&nbsp;├── appsettings.json

&nbsp;├── Program.cs

&nbsp;└── README.md

```



---



\## 📄 License

MIT License



