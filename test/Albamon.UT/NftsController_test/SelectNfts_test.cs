using Albamon.Controllers;
using Albamon.Data;
using Albamon.Models;
using Albamon.Models.NFTViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albamon.UT.NftsController_test
{
    public class SelectNfts_test
    {
        private DbContextOptions<ApplicationDbContext> _contextOptions;
        private ApplicationDbContext context;
        Microsoft.AspNetCore.Http.DefaultHttpContext purchaseContext;

        public SelectNfts_test()
        {
            //Initialize the Database
            _contextOptions = Utilities.CreateNewContextOptions();
            context = new ApplicationDbContext(_contextOptions);
            context.Database.EnsureCreated();

            // Seed the InMemory database with test data.
            UtilitiesForNfts.InitializeDbNftsForTests(context);

            //how to simulate the connection of a user
            System.Security.Principal.GenericIdentity user = new System.Security.Principal.GenericIdentity("peter@uclm.com");
            System.Security.Claims.ClaimsPrincipal identity = new System.Security.Claims.ClaimsPrincipal(user);
            purchaseContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
            purchaseContext.User = identity;

        }
        public static IEnumerable<object[]> TestCasesForSelectNftsForPurchase_get()
        {
            var allTests = new List<object[]>
            {
                  new object[] { UtilitiesForNfts.GetNfts(0,2), UtilitiesForNfts.GetTypeNfts(0,2),"FIRE",0},
                  new object[] { UtilitiesForNfts.GetNfts(0,4), UtilitiesForNfts.GetTypeNfts(0,2), null, 0},
                  new object[] { UtilitiesForNfts.GetNfts(0,1), UtilitiesForNfts.GetTypeNfts(0,2), "FIRE", 9},
            };

            return allTests;
        }

        [Theory]
        [MemberData(nameof(TestCasesForSelectNftsForPurchase_get))]
        public async Task SelectNftsForPurchase_Get(List<NFT> expectedNfts, List<TypeNFT> expectedTypeNfts, string filterTypeNft, Double filterPrice)
        {
            using (context)
            {
                // Arrange
                var controller = new NFTsController(context);
                controller.ControllerContext.HttpContext = purchaseContext;

                var expectedTypeNftsNames = expectedTypeNfts.Select(g => new { nameofTypeNft = g.Name });

                // Act
                var result = controller.SelectNftsForPurchase(filterTypeNft, filterPrice);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result); // Check the controller returns a view
                SelectNftsForPurchasesViewModel model = viewResult.Model as SelectNftsForPurchasesViewModel;

                // Check that both collections (expected and result returned) have the same elements with the same name
                // You must implement Equals in Nft, otherwise Assert will fail
                Assert.Equal(expectedNfts, model.NFTS);
                //check that both collections (expected and result) have the same names of Genre
                var modelTypeNfts = model.TypeNFTs.Select(g => new { nameofTypeNft = g.Text });

                Assert.True(expectedTypeNftsNames.SequenceEqual(modelTypeNfts));
            }
        }
    }
}
