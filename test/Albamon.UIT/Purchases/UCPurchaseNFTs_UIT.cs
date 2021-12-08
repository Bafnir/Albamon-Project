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
        //The code for your test Methods goes here
        public UCPurchaseNFTs_UIT(){
            //Opciones para cargar la página y aceptar certificados no seguros
            var optionsc = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };
            //Instancia el controlador de Chrome
            // Nota: para usar otros navegadores consulta el proyecto de ejemplo
            _driver = new ChromeDriver(optionsc);
            //Tiempo máximo del controlador para cargar el servicio //Ver el ejemplo de tarjeta de crédito
            _driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(50);
            //URI de la aplicación, sustitúyelo por el tuyo
            _URI = "https://localhost:44367/";
        }

        [Fact]
        public void initial_step_opening_the_web_page()
        {
            //Arrange
            string expectedTitle = "Albamon Home Page - Albamon";
            string expectedText = "marketplace";
            //Act
            //El navegador cargará la URI indicada
            _driver.Navigate().GoToUrl(_URI);
            //Assert
            //Comprueba que el título coincide con el esperado
            Assert.Equal(expectedTitle, _driver.Title);
            //Comprueba si la página contiene el string indicado
            Assert.Contains(expectedText, _driver.PageSource);
        }





        void IDisposable.Dispose(){
            //To close and release all the resources allocated by the web driver 
            _driver.Close();
            _driver.Dispose();
        }
    }
}
