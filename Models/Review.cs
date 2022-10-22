using System.ComponentModel.DataAnnotations;

namespace Webapi.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public Appointment Appointment { get; set; }
        public DateTime PostedTimestamp { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
