using LexiconLMS.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Server.Extensions
{
    public static class WebApplicationExtension
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

                await db.Database.EnsureDeletedAsync();
                await db.Database.MigrateAsync();

                try
                {
                    await SeedData.InitAsync(db, serviceProvider);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
