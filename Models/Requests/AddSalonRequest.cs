namespace Webapi.Models.Requests
{
    public class AddSalonRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string? WebsiteURL { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<DayHours> OpenHours { get; set; }
    }
}
