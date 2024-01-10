using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Domain.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LexiconLMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<Activity> Activity { get; set; } = default!;
        public DbSet<LexiconLMS.Domain.Entities.Module> Module { get; set; } = default!;
    }
}
