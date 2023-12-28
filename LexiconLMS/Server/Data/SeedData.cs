using LexiconLMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Data
{
    public class SeedData
    {
        private static UserManager<ApplicationUser> _userManager = default!;
        private static RoleManager<IdentityRole> _roleManager = default!;


        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var activityTypes = AddActivityType();
            var courses = AddCourses();
            var modules = AddModules(courses);
            var activities = AddActivities(activityTypes, modules);

            await context.AddRangeAsync(activityTypes);
            await context.AddRangeAsync(courses);
            await context.AddRangeAsync(modules);
            await context.AddRangeAsync(activities);
            await context.SaveChangesAsync(); // Save changes for courses, modules, and activities

            if (context.Roles.Any()) return;

            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Student" };
            await AddRolesAsync(roles);

            var users = AddUsers(context.Courses.ToList()).ToList();

            var adminPassword = "P@ssw0rd";
            var adminCourseId = courses.First(c => c.Name == ".Net").Id; // Retrieve course ID from the database

            var studentPassword = "P@ssw0rd";
            var studentCourseId = courses.First(c => c.Name == "Java").Id; // Retrieve course ID from the database

            var admin = await AddAccountAsync(users[0], adminPassword, adminCourseId);
            var user = await AddAccountAsync(users[1], studentPassword, studentCourseId);

            await AddUserToRoleAsync(admin, roles[0]);
            await AddUserToRoleAsync(user, roles[1]);
        }

        private static IEnumerable<ApplicationUser> AddUsers(IEnumerable<Course> courses)
        {

            var roles = new[] { "Admin", "Student" };

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Email = "admin@lms.com",
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new ApplicationUser()
                {
                    Email = "student@lms.com",
                    FirstName = "John",
                    LastName = "Smith"
                }
            };

            foreach (var user in users)
            {
                foreach (var course in courses)
                {
                    user.CourseId = course.Id;
                }
            }

            return users;
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

        private static async Task<ApplicationUser?> AddAccountAsync(ApplicationUser userToAdd, string password, Guid courseId)
        {
            var user = await _userManager.FindByEmailAsync(userToAdd.Email);
            if (user != null) return null;

            var newUser = new ApplicationUser
            {
                UserName = userToAdd.Email,
                FirstName = userToAdd.FirstName,
                LastName = userToAdd.LastName,
                Email = userToAdd.Email,
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
        private static IEnumerable<ActivityType> AddActivityType()
        {
            var activityTypes = new List<ActivityType>
            {
                new ActivityType
                {
                    Id = Guid.NewGuid(),
                    Name = "Assignment"
                },
                new ActivityType
                {
                    Id = Guid.NewGuid(),
                    Name = "E-learning"
                },
                new ActivityType
                {
                    Id = Guid.NewGuid(),
                    Name = "Lecture"

                },
                new ActivityType
                {
                    Id = Guid.NewGuid(),
                    Name = "Practice"
                },
            };
            return activityTypes;
        }

        private static IEnumerable<Activity> AddActivities(IEnumerable<ActivityType> activityTypes, IEnumerable<Module> modules)
        {
            var activities = new List<Activity>
            {
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Name = "Assignment OOD",
                    Description = "Learn about inheritance and polymorphism",
                    StartTime = new DateTime(2023, 11, 11, 13, 0, 0),
                    EndTime = new DateTime(2023, 11, 18, 13, 0, 0)
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Name = "Project Blazor",
                    Description = "Group project using Blazor",
                    StartTime = new DateTime(2023, 12, 20, 13, 0, 0),
                    EndTime = new DateTime(2024, 01, 12, 1, 0, 0)
                }
            };

            foreach (var activity in activities)
            {
                foreach (var type in activityTypes)
                {
                    activity.ActivityTypeId = type.Id;
                }
                foreach (var module in modules)
                {
                    activity.ModuleId = module.Id;
                }
            }

            return activities;
        }

        private static IEnumerable<Module> AddModules(IEnumerable<Course> courses)
        {
            var modules = new List<Module>
            {
                new Module
                {
                    Id = Guid.NewGuid(),
                    Name = "C# Basic",
                    StartDate = new DateTime(2023, 12, 30, 14, 30, 0),
                    EndDate = new DateTime(2024, 01, 04, 14, 30, 0),
                    Description = "C# For Beginners"
                },
                new Module
                {
                    Id = Guid.NewGuid(),
                    Name = "Java Basic",
                    StartDate = new DateTime(2024, 01, 30, 14, 30, 0),
                    EndDate = new DateTime(2024, 01, 15, 14, 30, 0),
                    Description = "Java For Beginners"
                },
            };

            // Iterate through modules and courses and assign CourseId to each module
            foreach (var (module, course) in modules.Zip(courses, (m, c) => (m, c)))
            {
                module.CourseId = course.Id;
            }

            return modules;
        }

        private static IEnumerable<Course> AddCourses()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Id = Guid.NewGuid(),
                    Name = ".Net",
                    StartDate = new DateTime(2023,12,30, 14,30,0),
                    EndDate = new DateTime(2024,01,15, 14,30,0),
                    Description = "C# Object Oriented"
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Name = "Java",
                    StartDate = new DateTime(2024,01,30, 14,30,0),
                    EndDate = new DateTime(2024,02,20, 14,30,0),
                    Description = "Spring Boot"
                },
            };

            return courses;
        }
    }
}

