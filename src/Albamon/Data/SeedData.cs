﻿using Albamon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace Albamon.Data
{
    public static class SeedData
    {
        //public static void Initialize(UserManager<ApplicationUser> userManager,
        //            RoleManager<IdentityRole> roleManager)
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var role = serviceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();


            List<string> rolesNames = new List<string> { "Administrator", "Employee", "Customer" };

            SeedRoles(roleManager, rolesNames);
            SeedUsers(userManager, rolesNames);

            DirectoryInfo directoryData = new DirectoryInfo(".\\Data");

            // Se obtienen todos los ficheros localizados en .\Albamon\Data que contienen un ".sql" en su nombre
            foreach (FileInfo item in directoryData.GetFiles().Where(m => m.Name.Contains(".sql")))
            {
                try
                {
                    // Se lee el contenido del fichero ".sql"
                    string commandSQL = item.OpenText().ReadToEnd();


                    // Se ejecuta el contenido del fichero ".sql"
                    dbContext.Database.ExecuteSqlRaw(commandSQL);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager, List<string> roles)
        {

            foreach (string roleName in roles)
            {
                //it checks such role does not exist in the database 
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    role.NormalizedName = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }

        }

        public static void SeedUsers(UserManager<IdentityUser> userManager, List<string> roles)
        {
            //first, it checks the user does not already exist in the DB
            if (userManager.FindByNameAsync("elena@uclm.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Id = "1";
                user.UserName = "elena@uclm.com";
                user.Email = "elena@uclm.com";
                user.Wallet = "0xfffaaaooo";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Password1234%").Result;

                if (result.Succeeded)
                {
                    //administrator role
                    userManager.AddToRoleAsync(user, roles[0]).Wait();
                }
            }

            if (userManager.FindByNameAsync("gregorio@uclm.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Id = "2";
                user.UserName = "gregorio@uclm.com";
                user.Email = "gregorio@uclm.com";
                user.Wallet = "0xfffaaaooe";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "APassword1234%").Result;

                if (result.Succeeded)
                {
                    //employee role
                    userManager.AddToRoleAsync(user, roles[1]).Wait();
                }
            }

            if (userManager.FindByNameAsync("peter@uclm.com").Result == null)
            {
                //A customer class has been defined because it has different attributes (purchase, rental, etc.)
                Usuario user = new Usuario();
                user.Id = "3";
                user.UserName = "peter@uclm.com";
                user.Email = "peter@uclm.com";
                user.Nombre = "Peter";
                user.Apellidos = "Jackson";
                user.Wallet = "0xffs4aaooe";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "OtherPass12$").Result;

                if (result.Succeeded)
                {
                    //customer role
                    userManager.AddToRoleAsync(user, roles[2]).Wait();

                }
            }

        }


    }

}