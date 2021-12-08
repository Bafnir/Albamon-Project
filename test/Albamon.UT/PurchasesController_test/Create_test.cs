using Albamon.Controllers;
using Albamon.Data;
using Albamon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Albamon.Models.PurchaseViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;
using System.Runtime.ExceptionServices;
using Albamon.Models.NFTViewModels;
using Albamon.UT.NftsController_test;
using Albamon.UT.PurchasesController_test;

namespace Albamon.UT.PurchasesController_test
{
    public class Create_test
    {

        private DbContextOptions<ApplicationDbContext> _contextOptions;
        private ApplicationDbContext context;
        Microsoft.AspNetCore.Http.DefaultHttpContext purchaseContext;


        public Create_test()
        {
            //Initialize the Database
            _contextOptions = Utilities.CreateNewContextOptions();
            context = new ApplicationDbContext(_contextOptions);
            context.Database.EnsureCreated();

            // Seed the database with test data.
            UtilitiesForNfts.InitializeDbNftsForTests(context);


            //how to simulate the connection of a user
            System.Security.Principal.GenericIdentity user = new("peter@uclm.com");
            System.Security.Claims.ClaimsPrincipal identity = new(user);
            purchaseContext = new Microsoft.AspNetCore.Http.DefaultHttpContext
            {
                User = identity
            };

        }

        [Fact]
        [Trait("LevelTesting", "Unit Testing")]
        public void Create_Get_WithSelectedNfts()
        {
            using (context)
            {

                // Arrange
                var controller = new PurchasesController(context);
                //simulate user's connection
                controller.ControllerContext.HttpContext = purchaseContext;

                String[] ids = new string[1] { "1" };
                SelectedNftsForPurchaseViewModel Nfts = new() { IdsToAdd = ids };
                NFT expectedNft = UtilitiesForNfts.GetNfts(0, 1).First();
                Usuario expectedCustomer = Utilities.GetUsers(0, 1).First() as Usuario;

                IList<PurchaseNFTViewModel> expectedPurchaseNfts = new PurchaseNFTViewModel[1] {
                    new PurchaseNFTViewModel {Quantity=0, NftId = expectedNft.NftId, Name = expectedNft.Name,
                        Price = expectedNft.Price, TypeNFT = expectedNft.TypeNFT.Name} };
                PurchaseCreateViewModel expectedPurchase = new() { PurchaseNFTs = expectedPurchaseNfts, Nombre = expectedCustomer.Nombre, Apellidos = expectedCustomer.Apellidos };

                // Act
                var result = controller.Create(Nfts);

                //Assert
                ViewResult viewResult = Assert.IsType<ViewResult>(result);
                PurchaseCreateViewModel currentPurchase = viewResult.Model as PurchaseCreateViewModel;

                Assert.Equal(currentPurchase, expectedPurchase);
            }

        }


        [Fact]
        [Trait("LevelTesting", "Unit Testing")]
        public void Create_Get_WithoutNft()
        {
            using (context)
            {

                // Arrange
                var controller = new PurchasesController(context);
                //simulate user's connection
                controller.ControllerContext.HttpContext = purchaseContext;
                Usuario usuario = Utilities.GetUsers(0, 1).First() as Usuario;
                SelectedNftsForPurchaseViewModel nfts = new();

                PurchaseCreateViewModel expectedPurchase = new()
                {
                    Nombre = usuario.Nombre,
                    Apellidos = usuario.Apellidos,
                    PurchaseNFTs= new List<PurchaseNFTViewModel>()
                };


                // Act
                var result = controller.Create(nfts);

                //Assert

                ViewResult viewResult = Assert.IsType<ViewResult>(result);
                PurchaseCreateViewModel currentPurchase = viewResult.Model as PurchaseCreateViewModel;
                var error = viewResult.ViewData.ModelState.Values.First().Errors.First();
                Assert.Equal(currentPurchase, expectedPurchase);
                Assert.Equal("You should select at least a NFT to be purchased, please", error.ErrorMessage);
            }
        }

        public static IEnumerable<object[]> TestCasesForPurchasesCreatePost_WithErrors()
        {
            //Las siguientes dos pruebas sustituyen a los métodos indicados usando Theory. No usar los métodos Fact.
            //The following two tests are subtitutes of the indicated facts methods using Theory instead of Fact. Please, do not use the Fact methods.
            //First error: Create_Post_WithoutEnoughMoviesToBePurchased

            NFT Nft = UtilitiesForNfts.GetNfts(0, 1).First();
            Usuario usuario = Utilities.GetUsers(0, 1).First() as Usuario;
            //  var payment1 = new PayPal { Email = customer.Email, Phone = customer.PhoneNumber, Prefix = "+34" };

            //Input values
            IList<PurchaseNFTViewModel> purchaseNftsViewModel1 = new PurchaseNFTViewModel[1] { new PurchaseNFTViewModel { Quantity = 10, NftId = Nft.NftId, Name = Nft.Name, TypeNFT = Nft.TypeNFT.Name, Price = Nft.Price } };
            PurchaseCreateViewModel purchase1 = new() { Nombre = usuario.Nombre, Apellidos = usuario.Apellidos, PurchaseNFTs= purchaseNftsViewModel1, Fee = 1};

            //Expected values
            IList<PurchaseNFTViewModel> expectedPurchaseItemsViewModel1 = new PurchaseNFTViewModel[1] { new PurchaseNFTViewModel { Quantity = 10, NftId = Nft.NftId, Name = Nft.Name, TypeNFT = Nft.TypeNFT.Name, Price = Nft.Price } };
            PurchaseCreateViewModel expectedPurchaseVM1 = new() { Nombre = usuario.Nombre, Apellidos = usuario.Apellidos, PurchaseNFTs = purchaseNftsViewModel1, Fee = 1 };
            string expetedErrorMessage1 = "The amount of fee introduced is not enough, please select more than 2";


            //Second error: Create_Post_WithQuantity0ForPurchase

            ////Input values
            //IList<PurchaseItemViewModel> purchaseItemsViewModel2 = new PurchaseItemViewModel[1] { new PurchaseItemViewModel { Quantity = 0, MovieID = movie.MovieID, Title = movie.Title, Genre = movie.Genre.Name, PriceForPurchase = movie.PriceForPurchase } };
            //PurchaseCreateViewModel purchase2 = new() { Name = customer.Name, FirstSurname = customer.FirstSurname, SecondSurname = customer.SecondSurname, PurchaseItems = purchaseItemsViewModel2, DeliveryAddress = "Albacete", Email = customer.Email, Phone = customer.PhoneNumber, Prefix = "+34" };

            ////expected values
            //IList<PurchaseItemViewModel> expectedPurchaseItemsViewModel2 = new PurchaseItemViewModel[1] { new PurchaseItemViewModel { Quantity = 0, MovieID = movie.MovieID, Title = movie.Title, Genre = movie.Genre.Name, PriceForPurchase = movie.PriceForPurchase } };
            //PurchaseCreateViewModel expectedPurchaseVM2 = new() { Name = customer.Name, FirstSurname = customer.FirstSurname, SecondSurname = customer.SecondSurname, PurchaseItems = expectedPurchaseItemsViewModel2, DeliveryAddress = "Albacete", Email = customer.Email, Phone = customer.PhoneNumber, Prefix = "+34" };
            //string expetedErrorMessage2 = "Please select at least a movie to be bought or cancel your purchase";

            var allTests = new List<object[]>
            {                  //Input values                                       // expected values
                new object[] { purchase1,  expectedPurchaseVM1, expetedErrorMessage1 }
                //,
                //new object[] { purchase2,  expectedPurchaseVM2, expetedErrorMessage2 }
            };
            return allTests;
        }




        [Theory]
        [MemberData(nameof(TestCasesForPurchasesCreatePost_WithErrors))]
        [Trait("LevelTesting", "Unit Testing")]
        public void Create_Post_WithErrors(PurchaseCreateViewModel purchase, PurchaseCreateViewModel expectedPurchaseVM, string errorMessage)
        {
            using (context)
            {
                // Arrange
                var controller = new PurchasesController(context);
                //simulate user's connection
                controller.ControllerContext.HttpContext = purchaseContext;

                // Act
                var result = controller.CreatePost(purchase);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result.Result);
                PurchaseCreateViewModel currentPurchase = viewResult.Model as PurchaseCreateViewModel;

                var error = viewResult.ViewData.ModelState.Values.First().Errors.First(); ;
                Assert.Equal(expectedPurchaseVM, currentPurchase);
                Assert.Equal(errorMessage, error.ErrorMessage);


            }

        }

        public static IEnumerable<object[]> TestCasesForPurchasesCreatePost_WithoutErrors()
        {
            //Substitución similar a la vista anteriormente.
            //Same substitution as the former two tests.

            //Purchase with CreditCard
            Purchase expectedPurchase1 = UtilitiesForPurchases.GetPurchases(0, 1).First();
            Usuario expectedCustomer1 = expectedPurchase1.User;
            var expectedFees1 = expectedPurchase1.Fees;
            PurchaseNFT expectedPurchaseItem1 = expectedPurchase1.PurchaseNFTS.First();
            IList<PurchaseNFTViewModel> purchaseNftsViewModel1 = new PurchaseNFTViewModel[1] { new PurchaseNFTViewModel {
                    Quantity = expectedPurchaseItem1.Quantity, NftId = expectedPurchaseItem1.NftId,
                    Name = expectedPurchaseItem1.NFT.Name, TypeNFT=expectedPurchaseItem1.NFT.TypeNFT.Name,
                    Price =expectedPurchaseItem1.NFT.Price} };

            PurchaseCreateViewModel purchase1 = new()
            {
                Nombre = expectedCustomer1.Nombre,
                Apellidos = expectedCustomer1.Apellidos,
                PurchaseNFTs = purchaseNftsViewModel1,
                Fee = expectedPurchase1.Fees
            };

            var allTests = new List<object[]>
            {                  //Input values   // expected values
                new object[] { purchase1,  expectedPurchase1},
            };
            return allTests;
        }






        [Theory]
        [MemberData(nameof(TestCasesForPurchasesCreatePost_WithoutErrors))]
        [Trait("LevelTesting", "Unit Testing")]
        public void Create_Post_WithoutErrors(PurchaseCreateViewModel purchase, Purchase expectedPurchase)
        {
            using (context)
            {

                // Arrange
                var controller = new PurchasesController(context);

                //simulate user's connection
                controller.ControllerContext.HttpContext = purchaseContext;

                // Act
                var result = controller.CreatePost(purchase);

                //Assert
                //we should check it is redirected to details
                var viewResult = Assert.IsType<RedirectToActionResult>(result.Result);
                Assert.Equal("Details", viewResult.ActionName);

                //we should check the purchase has been created in the database
                var actualPurchase = context.Purchase.Include(p => p.PurchaseNFTS).
                                    FirstOrDefault(p => p.PurchaseId == expectedPurchase.PurchaseId);

                Assert.Equal(expectedPurchase, actualPurchase);


            }

        }



    }
}