using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TestProjectLaboratorio8
{
  public class Selenium
  {
    IWebDriver driver;
    [SetUp]
    public void startBrowser()
    {
      driver = new ChromeDriver();
    }

    [Test]
    public void PruebaIngresoCrearPaises()
    { 
      string URL = "https://localhost:5001/";
      driver.Manage().Window.Maximize();
      driver.Url = URL;
      driver.Navigate().GoToUrl("https://localhost:5001/Paises/CrearPais");

      // Find elements
      WebElement name = (WebElement)driver.FindElement(By.Id("Nombre"));
      WebElement continent = (WebElement)driver.FindElement(By.Id("Continente"));
      WebElement languaje = (WebElement)driver.FindElement(By.Id("Idioma"));

      // Fill form
      name.SendKeys("Dinamarca");
      continent.SendKeys("Europa");
      languaje.SendKeys("Ingles");

      // Send form
      WebElement submitButton = (WebElement)driver.FindElement(By.CssSelector(".btn.btn-success"));
      submitButton.Submit();

      // Verify country created successfully
      WebElement successMessage = (WebElement)driver.FindElement(By.CssSelector(".alert-success"));
      Assert.AreEqual("El pais Dinamarca fue creado con exito.", successMessage.Text);

      Assert.IsNotNull(driver);
    }
  }
}
