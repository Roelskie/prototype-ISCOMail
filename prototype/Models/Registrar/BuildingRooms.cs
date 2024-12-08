using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Registrar
{
    public class BuildingRooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity for auto-incremented columns
        public int Building_ID { get; set; }

        public string? Building_Name { get; set; }
        public string? Building_Codes { get; set; }
        public int Room_ID { get; set; }
        public string? Room_No { get; set; }
        public string? Room_Code { get; set; }
        public string? Building_Code { get; set; }
        public int? Room_Available_Slot { get; set; }

    }
}

