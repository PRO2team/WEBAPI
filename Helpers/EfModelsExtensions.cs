using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
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
                .Include(e => e.Amentities)
                .Include(e => e.OpenHours)
                .Include(e => e.Address);
        } 
        
        public static IQueryable<Appointment> IncludeAll(this IQueryable<Appointment> query)
        {
            return query
                .Include(e => e.AppointmentType)
                .Include(e => e.User);
        }  
        
        public static IQueryable<User> IncludeAll(this IQueryable<User> query)
        {
            return query
                .Include(e => e.UserCredentials)
                .Include(e => e.ProfilePicture);
        } 
        
        public static IQueryable<Review> IncludeAll(this IQueryable<Review> query)
        {
            return query
                .Include(e => e.Appointment);
        }   
    }
}
