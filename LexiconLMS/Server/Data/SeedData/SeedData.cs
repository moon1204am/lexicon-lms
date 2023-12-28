using LexiconLMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Data.SeedData
{
    public class SeedData
    {
        private static UserManager<ApplicationUser> _userManager = default!;
        private static RoleManager<IdentityRole> _roleManager = default!;
        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            if (context.Roles.Any()) return;

            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Student" };
            var adminEmail = "admin@lms.com";
            var adminFirstName = "Jane";
            var adminLastName = "Doe";
            var adminPassword = "P@ssw0rd";
            var adminCourseId = new Guid();


            var studentEmail = "student@lms.com";
            var studentFirstName = "John";
            var studentLastName = "Smith";
            var studentPassword = "P@ssw0rd";
            var studentCourseId = new Guid();

            await AddRolesAsync(roles);

            var admin = await AddAccountAsync(adminEmail, adminFirstName, adminLastName, adminPassword, adminCourseId);
            var user = await AddAccountAsync(studentEmail, studentFirstName, studentLastName, studentPassword, studentCourseId);

            await AddUserToRoleAsync(admin, roles[0]);
            await AddUserToRoleAsync(user, roles[1]);
        }

        private static async Task AddRolesAsync(string[] roles)
        {
            foreach (var roleName in roles)
            {
                if (await _roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static async Task<ApplicationUser?> AddAccountAsync(string email, string firstName, string lastName, string password, Guid courseId)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) return null;

            var newUser = new ApplicationUser
            {
                UserName = email,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CourseId = courseId
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return newUser;
        }

        private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }

        }
    }
}
