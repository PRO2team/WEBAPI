using System.ComponentModel.DataAnnotations;

namespace Webapi.Models
{
    public class AppointmentType
    {
        public int AppointmentTypeID { get; set; }
        public string Name { get; set; }
        public int LengthMinutes { get; set; }
        public decimal Price { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
