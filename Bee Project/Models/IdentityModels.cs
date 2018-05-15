using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bee_Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //add tables here to generate them to database
        public DbSet<ServiceProvider> ServicesProviders { set; get; }
        public DbSet<Service> Services { set; get; }
        public DbSet<Appointment> Appointments { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Addresse> Addresses { set; get; }
        public DbSet<ServiceType> ServiceTypes { set; get; }
        public DbSet<Country> Countrys { set; get; }
        public DbSet<City> Cities { set; get; }
        public DbSet<AppointmentStatus> AppointmentStatus { set; get; }
        public DbSet<MetaData> MetaData { set; get; }

        public DbSet<UserActivations> UserActivations { set; get; }


        public DbSet<ServiceMetaDatas> ServiceMetaDatas { set; get; }

        public DbSet<SearchLogs> SearchLogs { get; set; }

        public DbSet<SearchMetaDatas> SearchMetaDatas { get; set; }
        public DbSet<UserAppointment> UserAppointment { get; set; }
        public DbSet<userAppointmentLog> userAppointmentLog { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}