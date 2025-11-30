using System.ComponentModel.DataAnnotations;

namespace ProjectWebCV.Models
{
    /// Основният модел за CV съдържащ цялата информация,
    /// която се визуализира в сайта и PDF-а.
    /// Поддържа двуезичност (BG/EN) за всички текстови секции.
    public class CvModel
    {
        /// Уникален идентификатор (Primary Key).
        /// В таблицата има само един ред, който представлява твоето CV.
        public int Id { get; set; }

        /// Относителен път към снимката на профила (пример: "/images/photo123.png").
        public string? PhotoPath { get; set; }

        /// Пълно име на български. Полето е задължително.
        [Required]
        public string? FullName { get; set; }

        /// Пълно име на английски.
        public string? FullNameEn { get; set; }

        /// Имейл адрес за контакт.
        public string? Email { get; set; }

        /// Телефонен номер.
        public string? Phone { get; set; }

        // ======================== SUMMARY ========================

        /// Кратко резюме / Objective на български.
        public string? SummaryBg { get; set; }

        /// Кратко резюме / Objective на английски.
        public string? SummaryEn { get; set; }

        // ======================== SKILLS ========================

        /// Списък с умения на български (разделени по нов ред).
        public string? SkillsBg { get; set; }

        /// Списък с умения на английски.
        public string? SkillsEn { get; set; }

        // ======================== EXPERIENCE ========================

        /// Професионален опит, описан на български език.
        /// Съдържа текст, разделен по нов ред (всяка точка = отделен ред).
        /// Не е ограничено само до работа — може да включва стажове или учебни проекти.
        public string? ExperienceBg { get; set; }

        /// Същият професионален опит, но преведен на английски.
        /// Използва се когато CV-то се превключи в English режим.
        public string? ExperienceEn { get; set; }

        // ======================== EDUCATION ========================

        /// Образование на български — училище, курс, академия, сертификати, обучения.
        /// Може да съдържа няколко реда текст.
        public string? EducationBg { get; set; }

        /// Образование на английски — превод на Education секцията.
        public string? EducationEn { get; set; }


        // ======================== STUDIED LANGUAGES ========================

        /// Езици, които владееш на български (нов ред = нов елемент).
        public string? StudiedLanguagesBg { get; set; }

        /// Езици, които владееш на английски.
        public string? StudiedLanguagesEn { get; set; }

        // ======================== INTERESTS ========================

        /// Лични интереси и хобита, описани на български език.
        /// Всеки интерес може да бъде на нов ред.
        public string? InterestsBg { get; set; }

        /// Същата секция "Interests", но преведена на английски.
        /// Използва се при превключване на CV-то в English режим.
        public string? InterestsEn { get; set; }

        // ======================== PROJECTS SECTION ========================

        /// Заглавие на секцията "Проекти" на български.
        /// Например: "CV WEB приложение", "Учебен проект" и т.н.
        public string ProjectsTitleBg { get; set; }

        /// Заглавие на секцията за проекти на английски.
        public string ProjectsTitleEn { get; set; }

        /// Описание на проекта/проектите на български.
        /// Поддържа много редове текст.
        public string ProjectsDescriptionBg { get; set; }

        /// Описание на проектите на английски.
        public string ProjectsDescriptionEn { get; set; }

        /// Един или няколко линка към GitHub / Live demo / други сайтове.
        /// Записват се разделени с нов ред.
        public string ProjectsLinks { get; set; }

        // ======================== CONTACT INFO ========================
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }

        // ======================== LANGUAGE STATE ========================

        /// Текущо избран език за визуализиране на CV-то ("bg" или "en").
        /// Използва се за превключване на текстовете.
        public string Language { get; set; } = "bg";
    }
}