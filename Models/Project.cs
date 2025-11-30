namespace ProjectWebCV.Models
{
    public class Project
    {
        public int Id { get; set; }

        public int CvId { get; set; }
        public CvModel Cv { get; set; } = null!;

        public string? TitleBg { get; set; }
        public string? TitleEn { get; set; }

        public string? DescriptionBg { get; set; }
        public string? DescriptionEn { get; set; }

        public string? Links { get; set; } // един или повече линкове
    }
}
