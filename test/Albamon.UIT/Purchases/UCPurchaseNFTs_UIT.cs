using Albamon.UIT;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
//Needed to find elements in ICollection or IList
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;


namespace Albamon.UIT.Purchases
{
    public class UCPurchaseNFTs_UIT : IDisposable
    {
        IWebDriver _driver;
        string _URI;

        void IDisposable.Dispose()
        {
            //To close and release all the resources allocated by the web driver 
            _driver.Close();
            _driver.Dispose();
            GC.SuppressFinalize(this);
        }

        public UCPurchaseNFTs_UIT()
        {
            UtilitiesUIT.SetUp_UIT(out _driver, out _URI);
            initial_step_opening_the_web_page();
            //it is needed to run the scripts for udpating the database 
        }


        public void initial_step_opening_the_web_page()
        {
            //Arrange
            //string expectedTitle = "Albamon Home Page - Albamon";
            //string expectedText = "marketplace";
            //Act
            //El navegador cargará la URI indicada
            _driver.Navigate().GoToUrl(_URI);
            //Assert
            //Comprueba que el título coincide con el esperado
            //Assert.Equal(expectedTitle, _driver.Title);
            //Comprueba si la página contiene el string indicado
            //Assert.Contains(expectedText, _driver.PageSource);
        }

        public void Precondition_perform_login()
        {
            _driver.Navigate().GoToUrl(_URI +
            "Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email"))
            .SendKeys("peter@uclm.com");
            _driver.FindElement(By.Id("Input_Password"))
            .SendKeys("OtherPass12$");
            _driver.FindElement(By.Id("login-submit"))
            .Click();
        }

        private void First_step_accessing_purchases()
        {
            _driver.FindElement(By.Id("PurchaseController")).Click();

        }

        private void Third_filter_nfts_byPrice(string PriceFilter)
        {
            _driver.FindElement(By.Id("Price")).SendKeys(PriceFilter);

            _driver.FindElement(By.Id("filterbyPriceType")).Click();
        }

        private void Third_filter_nfts_byTypeNFT(string TypeNFTSelected)
        {

            var TypeNFT = _driver.FindElement(By.Id("TypeNFTSelected"));

            //create select element object 
            SelectElement selectElement = new SelectElement(TypeNFT);
            //select Action from the dropdown menu
            selectElement.SelectByText(TypeNFTSelected);

            _driver.FindElement(By.Id("filterbyPriceType")).Click();

        }

        private void Third_select_nfts_and_submit()
        {

            _driver.FindElement(By.Id("Nft_2")).Click();
            _driver.FindElement(By.Id("Nft_4")).Click();
            _driver.FindElement(By.Id("nextButton")).Click();

        }

        private void Third_alternate_not_selecting_movies()
        {

            _driver.FindElement(By.Id("nextButton")).Click();

        }

        private void Fourth_fill_in_information_and_press_create(string Fee, string quantityNft1,
            string quantityNft2)
        {
            _driver.FindElement(By.Id("Fee")).Clear();
            _driver.FindElement(By.Id("Fee")).SendKeys(Fee);

            _driver.FindElement(By.Id("Nft_Quantity_2")).Clear();
            _driver.FindElement(By.Id("Nft_Quantity_2")).SendKeys(quantityNft1);

            _driver.FindElement(By.Id("Nft_Quantity_4")).Clear();
            _driver.FindElement(By.Id("Nft_Quantity_4")).SendKeys(quantityNft2);

            _driver.FindElement(By.Id("CreateButton")).Click();
        }


        [Theory]
        [ClassData(typeof(PurchaseNftsTestDataGeneratorBasicFlow))]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_1_1_basic_flow(string Fee, string quantityNft1,
            string quantityNft2)
        {
            //Arrange
        
            string[] expectedText = { "Details - Albamon","Details",
                "Purchase","Peter","Jackson","Purchase date:","Gas fee:","5",
                "Total price:","15","CHIK","5",
                "CHOK","10"};

            //Act
            Precondition_perform_login();
            First_step_accessing_purchases();
            Third_select_nfts_and_submit();
            Fourth_fill_in_information_and_press_create(Fee, quantityNft1,
            quantityNft2);

            //Assert
            foreach (string expected in expectedText)
                Assert.Contains(expected, _driver.PageSource);

        }


        //(Skip = "As precondition, first execute script dbo.nft.NoNfts to remove nfts")
        [Fact(Skip = "As precondition, first execute script dbo.nft.NoNfts to remove nfts")]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_2_alternate_flow_1_NoNftsAvailable()
        {
            //Arrange
            string expectedText = "There are no NFTS available";

            //Act
            Precondition_perform_login();
            First_step_accessing_purchases();

            var movieRow = _driver.FindElement(By.Id("NoNFTS"));

            //checks the expected row exists
            Assert.NotNull(movieRow);
            Assert.Equal(expectedText, movieRow.Text);
        }


        [Theory]
        [InlineData("CHIK", "9", "FIRE", "Price")]
        [InlineData("CHOK", "0", "WATER", "TypeNFT")]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_3_UC1_4_alternate_flow_2_filteringbyPrice(string Nombre, string price,
            string TypeNFT, string filter)
        {

            //Arrange
            string[] expectedText = { Nombre, TypeNFT };
            //Act
            Precondition_perform_login();
            First_step_accessing_purchases();
            if (filter.Equals("Price")) {
                Third_filter_nfts_byPrice(price);
            }
            else {
                Third_filter_nfts_byTypeNFT(TypeNFT);
            }
            
            var movieRow = _driver.FindElements(By.Id("NFT_Name_" + Nombre));

            //checks the expected row exists
            Assert.NotNull(movieRow);

            //checks every column has the data as expected
            foreach (string expected in expectedText)
                Assert.NotNull(movieRow.First(l => l.Text.Contains(expected)));
        }


        [Fact]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_5_alternate_flow_3_moviesNotSelected()
        {
            //Arrange
            string expectedText = "You must select at least one nft";

            //Act
            Precondition_perform_login();
            First_step_accessing_purchases();
            Third_alternate_not_selecting_movies();
            //Assert
            var errorMessage = _driver.FindElement(By.Id("ModelErrors")).Text;

            Assert.Equal(expectedText, errorMessage);

            Assert.Contains(expectedText, _driver.PageSource);

        }

        [Theory]
        [InlineData("", "1", "1", "Please, set your gas fee")]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_6_UC1_6_15_alternate_flow_4_testingErrorsMandatorydata(string Fee, string quantityNft1,
            string quantityNft2, string expectedText)
        {

            //Act
            Precondition_perform_login();
            First_step_accessing_purchases();
            Third_select_nfts_and_submit();
            Fourth_fill_in_information_and_press_create(Fee, quantityNft1,
            quantityNft2);


            //Assert
            //the expected error is shown in the view
            Assert.Contains(expectedText, _driver.PageSource);


        }




        [Fact]
        [Trait("LevelTesting", "Funcional Testing")]
        public void UC1_7_not_logged_in()
        {
            //Arrange
            string expectedText = "Use a local account to log in.";

            //Act
            First_step_accessing_purchases();
            //Assert
            Assert.Contains(expectedText, _driver.PageSource);

        }



    }
}
