using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prototype.Models.Registrar
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity for auto-incremented columns
        [Column("SCHEDULE_ID")] // Match the actual column name in the database
        public int ScheduleId { get; set; }

        [Column("YEAR_SEM")] // Match the actual column name
        public string? YearSem { get; set; }

        [Column("SECTION")] // Match the actual column name
        public string? Section { get; set; }

        [Column("SUBJECT_CODE")] // Match the actual column name
        public string? SubjectCode { get; set; }

        [Column("SUBJECT_NAME")] // Match the actual column name
        public string? SubjectName { get; set; }

        [Column("TIME")] // Match the actual column name
        public string? Time { get; set; }

        [Column("DAY")] // Match the actual column name
        public string? Day { get; set; }

        [Column("TYPE")] // Match the actual column name
        public string? Type { get; set; }

        [Column("LECTURE_LAB")] // Match the actual column name
        public string? LectureLab { get; set; }

        [Column("ROOM")] // Match the actual column name
        public string? Room { get; set; }

        [Column("BUILDING")] // Match the actual column name
        public string? Building { get; set; }
    }
}