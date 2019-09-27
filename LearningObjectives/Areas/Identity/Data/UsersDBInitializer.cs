//Author:    Jonathan Beutler
//Partner:   None
//Date:      September 25, 2019
//Course:    CS 4540, University of Utah, School of Computing
//Copyright: CS 4540 and Jonathan Beutler - This work may not be copied for use in Academic Coursework.

//I, Jonathan Beutler, certify that I wrote this code from scratch and did not copy it in part or whole from
//another source.  Any references used in the completion of the assignment are cited in my README file.

//File Contents

//   This page is used to seed the User Roles database.  The code is largely templated
//   off of the code from this tutorial: https://romansimuta.com/blogs/blog/authorization-with-roles-in-asp.net-core-mvc-web-application
//   The tutorial is also referenced in the README


using EFGetStarted.AspNetCore.NewDb.Models;
using LearningObjectives.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Data
{
    public static class UsersDBInitializer
    {
        public static async Task InitializeAsync(UsersDB context,
       IServiceProvider serviceProvider)
        {
            context.Database.Migrate();

            // Use dependency injection to get the Role Manager from the service provider
            var RoleManager = serviceProvider
               .GetRequiredService<RoleManager<IdentityRole>>();
            
            // If the roles are not already in the DB, seed them
            if (!context.Roles.Any())
            {
                // Iterate through role names.  If they don't already exist, add them.
                string[] roleNames = { "Instructor", "Admin", "Chair" };
                int roleID = 1;
                foreach (var roleName in roleNames)
                {
                    await RoleManager.CreateAsync(new IdentityRole { Name = roleName, Id = roleID.ToString() });
                    roleID++;
                }
            }            

            if (! context.Users.Any())
            {
                string plainTextPassword = "123ABC!@#def";  // TODO:  Use user secrets to hide this password
                
                var userManager = serviceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                AddUserWithRole(userManager, 1, "professor_mary@cs.utah.edu", plainTextPassword, "Instructor").Wait();
                AddUserWithRole(userManager, 2, "professor_danny@cs.utah.edu", plainTextPassword, "Instructor").Wait();
                AddUserWithRole(userManager, 3, "professor_jim@cs.utah.edu", plainTextPassword, "Instructor").Wait();
                AddUserWithRole(userManager, 4, "chair_whitaker@cs.utah.edu", plainTextPassword, "Chair").Wait();
                AddUserWithRole(userManager, 5, "admin_erin@cs.utah.edu", plainTextPassword, "Admin").Wait();
            }
            
            await context.SaveChangesAsync();
        }

        // Helper method adds an IdentityUser with the specified role.  
        private static async Task AddUserWithRole(UserManager<IdentityUser> userManager, int id, string email, string password, string role)
        {
            var user = new IdentityUser { Id = id.ToString(), UserName = email, Email = email };

            var createUser = await userManager.CreateAsync(user, password);
            if (createUser.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
