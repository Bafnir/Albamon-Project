﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Albamon.Controllers;
using Albamon.Data;
using Albamon.Models;


namespace Albamon.UT.PurchasesController_test
{
    public class Details_test
    {
        private DbContextOptions<ApplicationDbContext> _contextOptions;
        private ApplicationDbContext context;
        Microsoft.AspNetCore.Http.DefaultHttpContext purchaseContext;

        public Details_test()
        {
            //Initialize the Database
            _contextOptions = Utilities.CreateNewContextOptions();
            context = new ApplicationDbContext(_contextOptions);
            context.Database.EnsureCreated();

            // Seed the database with test data.
            UtilitiesForPurchases.InitializeDbPurchasesForTests(context);


            //how to simulate the connection of a user
            System.Security.Principal.GenericIdentity user = new("peter@uclm.com");
            System.Security.Claims.ClaimsPrincipal identity = new(user);
            purchaseContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
            purchaseContext.User = identity;

        }


        public static IEnumerable<object[]> TestCasesFor_Purchase_notfound_withoutId()
        {
            var allTests = new List<object[]>
            {
                new object[] {null },
                new object[] {100},
            };

            return allTests;
        }

        [Theory]
        [MemberData(nameof(TestCasesFor_Purchase_notfound_withoutId))]
        [Trait("LevelTesting", "Unit Testing")]
        public async Task Details_Purchase_notfound(int? id)
        {
            // Arrange
            using (context)
            {
                var controller = new PurchasesController(context);
                controller.ControllerContext.HttpContext = purchaseContext;


                // Act
                var result = await controller.Details(id);

                //Assert
                var viewResult = Assert.IsType<NotFoundResult>(result);

            }
        }

        [Fact]
        [Trait("LevelTesting", "Unit Testing")]
        public async Task Details_Purchase_found()
        {
            // Arrange
            using (context)
            {
                var expectedPurchase = UtilitiesForPurchases.GetPurchases(0, 1).First();
                var controller = new PurchasesController(context);
                controller.ControllerContext.HttpContext = purchaseContext;

                // Act
                var result = await controller.Details(expectedPurchase.PurchaseId);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);

                var model = viewResult.Model as Purchase;
                Assert.Equal(expectedPurchase, model);

            }
        }
    }
}