using System.ComponentModel.DataAnnotations;

namespace Webapi.Models.Requests
{
    public class AddReviewRequest
    {
        public int AppointmentID { get; set; }
        public DateTime PostedTimestamp { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
