using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using prototype.Models;
using prototype.Models.Register;
using prototype.Models.Registrar;
using prototype.Models.Student;
using prototype.Models.Registrar;
using System.Collections.Generic;

namespace prototype.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly define LogId as the primary key
            modelBuilder.Entity<LoginLog>()
                .HasKey(log => log.LogId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }  // This line remains unchanged
        public DbSet<AccountCreationModel> Accounts { get; set; } // Maps to USERS table
                                                                  // Define DbSet for each model
        public DbSet<BasicInformation> BASIC_INFORMATION { get; set; }
        public DbSet<PersonalInformation> PERSONAL_INFORMATION { get; set; }
        public DbSet<Educations> EDUCATION { get; set; }
        public DbSet<Family> FAMILY { get; set; }

        public DbSet<EmergencyContact> PERSON_INCASEOF_EMERGENCY { get; set; }

        public DbSet<StudentEnlistment> STUDENT_ENLISTMENT { get; set; }

        public DbSet<StudentYrScreening> StudentYrScreenings { get; set; }
        public DbSet<StudentGrading> StudentGradings { get; set; }

        public DbSet<StudentReference> StudentReferences { get; set; }
            public DbSet<Schedule> SCHEDULE { get; set; }

        public DbSet<Section> Sections { get; set; }
        public DbSet<BuildingRooms> BuildingRooms { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; } // Add this line

    }
}

