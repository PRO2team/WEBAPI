using Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Helpers
{
    public static class EfModelsExtensions
    {
        public static IQueryable<Salon> IncludeAll(this IQueryable<Salon> query)
        {
            return query
                .Include(e => e.AppointmentTypes)
                .Include(e => e.SalonPicture)
                .Include(e => e.Amentities).ThenInclude(a => a.Icon)
                .Include(e => e.OpenHours)
                .Include(e => e.Address);
        } 
        
        public static IQueryable<Appointment> IncludeAll(this IQueryable<Appointment> query)
        {
            return query
                .Include(e => e.AppointmentType)
                .Include(e => e.User).ThenInclude(u => u.ProfilePicture);
        }  
        
        public static IQueryable<User> IncludeAll(this IQueryable<User> query)
        {
            return query
                .Include(e => e.ProfilePicture);
        } 
        
        public static IQueryable<Review> IncludeAll(this IQueryable<Review> query)
        {
            return query
                .Include(e => e.Appointment).ThenInclude(a => a.AppointmentType)
                .Include(e => e.Appointment).ThenInclude(a => a.User).ThenInclude(u => u.ProfilePicture);
        }   
    }
}
