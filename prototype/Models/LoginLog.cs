using prototype.Models.Register;
using prototype.Models.Student;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace prototype.Models
    {
        public class LoginLog
        {
            public int LogId { get; set; }
            public string Email { get; set; }
            public DateTime LoginTime { get; set; }
            public bool IsSuccessful { get; set; }
            public DateTime? LogoutTime { get; set; } // Nullable DateTime for logout time
        public string Student_ID { get; set; }

    }
}
