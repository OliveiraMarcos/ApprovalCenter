using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ApprovalCenter.Infra.CrossCutting.Identity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly IHostEnvironment _env;

        public ApplicationDbContext(
                    DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_env = env;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // get the configuration from the app settings
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(_env.ContentRootPath)
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    // define the database to use
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
    }
}
