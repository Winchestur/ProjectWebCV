using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebCV.Data;
using ProjectWebCV.Models;
using Microsoft.Playwright;

namespace ProjectWebCV.Controllers
{
    // Основният контролер, който управлява:
    // - визуализация на CV
    // - редакция
    // - сертификати
    // - проекти (много)
    // - генериране на PDF
    public class CvController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CvController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ======================== INDEX ========================
        public async Task<IActionResult> Index(string lang = "bg")
        {
            var cv = await _context.Cv.FirstOrDefaultAsync();
            if (cv == null) return NotFound();

            cv.Language = lang;

            // Зареждаме сертификати
            var certificates = await _context.Certificates
                .Where(c => c.CvId == cv.Id)
                .ToListAsync();
            ViewBag.Certificates = certificates;

            // Зареждаме ПРОЕКТИ (много)
            var projects = await _context.Projects
                .Where(p => p.CvId == cv.Id)
                .ToListAsync();
            ViewBag.Projects = projects;

            return View(cv);
        }

        // ======================== GET EDIT ========================
        public async Task<IActionResult> Edit()
        {
            var cv = await _context.Cv.FirstOrDefaultAsync();
            if (cv == null)
            {
                cv = new CvModel();
                _context.Cv.Add(cv);
                await _context.SaveChangesAsync();
            }

            // Сертификати
            var certificates = await _context.Certificates
                .Where(c => c.CvId == cv.Id)
                .ToListAsync();
            ViewBag.Certificates = certificates;

            // ПРОЕКТИ
            var projects = await _context.Projects
                .Where(p => p.CvId == cv.Id)
                .ToListAsync();
            ViewBag.Projects = projects;

            return View(cv);
        }

        // ======================== POST EDIT ========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            CvModel model,
            IFormFile? photo,
            int[]? certIds,
            string[]? certTitlesBg,
            string[]? certTitlesEn,

            // ПРОЕКТИ
            int[]? projectIds,
            string[]? projectTitlesBg,
            string[]? projectTitlesEn,
            string[]? projectDescriptionsBg,
            string[]? projectDescriptionsEn,
            string[]? projectLinks
        )
        {
            var cv = await _context.Cv.FirstAsync();

            // ------- Обновяване на базови CV полета -------
            cv.FullName = model.FullName;
            cv.FullNameEn = model.FullNameEn;
            cv.Email = model.Email;
            cv.Phone = model.Phone;
            cv.SummaryBg = model.SummaryBg;
            cv.SummaryEn = model.SummaryEn;
            cv.SkillsBg = model.SkillsBg;
            cv.SkillsEn = model.SkillsEn;
            cv.ExperienceBg = model.ExperienceBg;
            cv.ExperienceEn = model.ExperienceEn;
            cv.EducationBg = model.EducationBg;
            cv.EducationEn = model.EducationEn;
            cv.City = model.City;
            cv.Country = model.Country;
            cv.FacebookUrl = model.FacebookUrl;
            cv.InstagramUrl = model.InstagramUrl;
            cv.StudiedLanguagesBg = model.StudiedLanguagesBg;
            cv.StudiedLanguagesEn = model.StudiedLanguagesEn;
            cv.InterestsBg = model.InterestsBg;
            cv.InterestsEn = model.InterestsEn;

            // ------- Профилна снимка -------
            if (photo != null && photo.Length > 0)
            {
                if (!string.IsNullOrEmpty(cv.PhotoPath))
                    DeletePhysicalFile(cv.PhotoPath);

                var folder = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(folder);

                var filename = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var path = Path.Combine(folder, filename);

                using (var fs = new FileStream(path, FileMode.Create))
                    await photo.CopyToAsync(fs);

                cv.PhotoPath = "/images/" + filename;
            }

            await _context.SaveChangesAsync();


            // ======================== СЕРТИФИКАТИ ========================
            certIds ??= Array.Empty<int>();
            certTitlesBg ??= Array.Empty<string>();
            certTitlesEn ??= Array.Empty<string>();

            var files = Request.Form.Files;
            var existingCerts = await _context.Certificates
                .Where(c => c.CvId == cv.Id)
                .ToListAsync();

            for (int i = 0; i < certIds.Length; i++)
            {
                int id = certIds[i];
                string bg = i < certTitlesBg.Length ? certTitlesBg[i] : "";
                string en = i < certTitlesEn.Length ? certTitlesEn[i] : "";
                IFormFile? img = files.FirstOrDefault(f => f.Name == $"certImages[{i}]");

                bool hasText = !string.IsNullOrWhiteSpace(bg) || !string.IsNullOrWhiteSpace(en);
                bool hasNewImage = img != null && img.Length > 0;
                bool deleteImg = Request.Form[$"deleteCertImage[{i}]"] == "true";

                if (id == 0 && !hasText && !hasNewImage)
                    continue;

                Certificate cert;

                if (id != 0)
                {
                    cert = existingCerts.First(c => c.Id == id);

                    if (!hasText && !hasNewImage)
                    {
                        if (!string.IsNullOrEmpty(cert.ImagePath))
                            DeletePhysicalFile(cert.ImagePath);

                        _context.Certificates.Remove(cert);
                        continue;
                    }
                }
                else
                {
                    cert = new Certificate { CvId = cv.Id };
                    _context.Certificates.Add(cert);
                }

                cert.TitleBg = bg;
                cert.TitleEn = en;

                if (deleteImg && !string.IsNullOrEmpty(cert.ImagePath))
                {
                    DeletePhysicalFile(cert.ImagePath);
                    cert.ImagePath = null;
                }

                if (hasNewImage)
                {
                    if (!string.IsNullOrEmpty(cert.ImagePath))
                        DeletePhysicalFile(cert.ImagePath);

                    var folder = Path.Combine(_env.WebRootPath, "certificates");
                    Directory.CreateDirectory(folder);

                    var fn = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    var p = Path.Combine(folder, fn);

                    using var fs2 = new FileStream(p, FileMode.Create);
                    await img.CopyToAsync(fs2);

                    cert.ImagePath = "/certificates/" + fn;
                }
            }


            // ======================== ПРОЕКТИ ========================
            projectIds ??= Array.Empty<int>();
            projectTitlesBg ??= Array.Empty<string>();
            projectTitlesEn ??= Array.Empty<string>();
            projectDescriptionsBg ??= Array.Empty<string>();
            projectDescriptionsEn ??= Array.Empty<string>();
            projectLinks ??= Array.Empty<string>();

            var existingProjects = await _context.Projects
                .Where(p => p.CvId == cv.Id)
                .ToListAsync();

            for (int i = 0; i < projectIds.Length; i++)
            {
                int id = projectIds[i];

                string titleBg = projectTitlesBg[i] ?? "";
                string titleEn = projectTitlesEn[i] ?? "";
                string descBg = projectDescriptionsBg[i] ?? "";
                string descEn = projectDescriptionsEn[i] ?? "";
                string links = projectLinks[i] ?? "";

                bool hasContent =
                    !string.IsNullOrWhiteSpace(titleBg) ||
                    !string.IsNullOrWhiteSpace(titleEn) ||
                    !string.IsNullOrWhiteSpace(descBg) ||
                    !string.IsNullOrWhiteSpace(descEn) ||
                    !string.IsNullOrWhiteSpace(links);

                if (id == 0 && !hasContent)
                    continue;

                Project proj;

                if (id != 0)
                {
                    proj = existingProjects.First(p => p.Id == id);

                    if (!hasContent)
                    {
                        _context.Projects.Remove(proj);
                        continue;
                    }
                }
                else
                {
                    proj = new Project { CvId = cv.Id };
                    _context.Projects.Add(proj);
                }

                proj.TitleBg = titleBg;
                proj.TitleEn = titleEn;
                proj.DescriptionBg = descBg;
                proj.DescriptionEn = descEn;
                proj.Links = links;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ======================== PDF GENERATOR ========================
        public async Task<IActionResult> DownloadPdf(string lang = "bg")
        {
            var cv = await _context.Cv.FirstOrDefaultAsync();
            if (cv == null) return NotFound();

            cv.Language = lang;
            await _context.SaveChangesAsync();

            var url = $"{Request.Scheme}://{Request.Host}/Cv/index?lang={lang}";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });

            var page = await browser.NewPageAsync();
            await page.GotoAsync(url);

            var pdf = await page.PdfAsync(new() { Format = "A4", PrintBackground = true });

            return File(pdf, "application/pdf", $"CV_{lang}.pdf");
        }

        // ======================== DELETE FILE ========================
        private void DeletePhysicalFile(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            try
            {
                var fullPath = Path.Combine(
                    _env.WebRootPath,
                    relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)
                );

                if (System.IO.File.Exists(fullPath))
                    System.IO.File.Delete(fullPath);
            }
            catch
            {
                // игнор – да не блокира редакцията
            }
        }
    }
}
