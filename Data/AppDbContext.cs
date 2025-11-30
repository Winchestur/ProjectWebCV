using ProjectWebCV.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebCV.Data
{
    /// Основният клас за достъп до базата данни.
    /// Управлява таблиците (DbSet) и връзката към SQL Server чрез EF Core.
    public class AppDbContext : DbContext
    {
        /// Конструкторът получава опции за конфигурация (като connection string),
        /// зададени в Program.cs. Това позволява EF Core да знае към коя база да се свърже.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        /// Таблица за CV модела — съдържа един ред с информация за твоето CV
        /// (име, имейл, умения, образование, опит, интереси и т.н.)
        public DbSet<CvModel> Cv { get; set; }

        /// Таблица със сертификати — всеки сертификат е отделен ред,
        /// свързан с CvModel чрез CvId (one-to-many).
        /// Съдържа заглавие и снимка.
        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<Project> Projects { get; set; }

    }
}
