using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using TechTalk.SpecFlow;

namespace Ahorcado.UIAutomation
{
    [Binding]
    public class HangmanSpecflow
    {
        IWebDriver driver;
        String baseURL;
        Juego j;

        [BeforeScenario]
        public void TestInitialize()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
            InternetExplorerOptions capabilities = new InternetExplorerOptions();
            capabilities.IgnoreZoomLevel = true;
            driver = new InternetExplorerDriver(path, capabilities);
            baseURL = "http://localhost";
        }

        [Given(@"I have entered Ahorcado as the wordToGuess")]
        public void GivenIHaveEnteredAhorcadoAsTheWordToGuess()
        {
            j = new Juego("Ahorcado");
            driver.Navigate().GoToUrl(baseURL);
            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("Ahorcado");
            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);
        }
               
        [When(@"I enter X as the typedLetter five times")]
        public void WhenIEnterXAsTheTypedLetterFiveTimes()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            for (int i = 0; i < 7; i++)
            {
                letterTyped.SendKeys("X");
                btnInsertLetter.SendKeys(Keys.Enter);
            }
        }

        [Then(@"I should be told that I lost")]
        public void ThenIShouldBeToldThatILost()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Assert.IsTrue(loss);
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
