namespace ProjectWebCV.Models
{
    /// Представлява един сертификат, свързан с потребителското CV.
    /// Съдържа текст на два езика и път към качено изображение.
    public class Certificate
    {
        /// Уникален идентификатор на сертификата (Primary Key).
        public int Id { get; set; }

        /// Външен ключ към CV модела.
        /// Свързва сертификата към конкретното CV.
        public int CvId { get; set; }

        /// Навигационно свойство към CV.
        /// Позволява EF Core да прави релацията 1 → много.
        public CvModel Cv { get; set; } = null!;

        /// Заглавие/описание на сертификата на български.
        public string? TitleBg { get; set; }

        /// Заглавие/описание на английски.
        public string? TitleEn { get; set; }

        /// Път до каченото изображение на сертификата.
        /// Съхранява относителния път (пример: "/certificates/image123.png").
        public string? ImagePath { get; set; }
    }
}
