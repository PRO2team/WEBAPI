using System.ComponentModel.DataAnnotations;

namespace Webapi.Models
{
    public class AppointmentType
    {
        public int AppointmentTypeID { get; set; }
        public string Name { get; set; }
        [Range(0, 1440)]
        public int LengthMinutes { get; set; }
        [Range(0, 10000)]
        public decimal Price { get; set; }
        public Promotion? Promotion { get; set; }
    }
}
