namespace Webapi.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }
        public string CalendarAppointmentURL { get; set; }
    }
}
