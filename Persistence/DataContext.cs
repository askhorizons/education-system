using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Persistence.Configurations;

namespace Persistence
{
    public partial class DataContext : IdentityDbContext<AppUser, AppRole, string,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IConfiguration _config;

        public DataContext(
            DbContextOptions<DataContext> options, 
            IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public virtual DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ASP.NET Core Identity
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());

            // Admissions
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
        }
    }
}
