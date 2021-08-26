using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace Ahorcado.UIAutomation
{
    [Binding]
    public class WinGameSteps
    {
        IWebDriver driver;
        String baseURL;
        Jugada j;

        [BeforeScenario]
        public void TestInitialize()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
            InternetExplorerOptions capabilities = new InternetExplorerOptions();
            capabilities.IgnoreZoomLevel = true;
            driver = new InternetExplorerDriver(path, capabilities);
            baseURL = "http://localhost";
        }

        [Given(@"I have generated the wordToGuess gato")]
        public void GivenIHaveGeneratedTheWordToGuessGato()
        {
            driver.Navigate().GoToUrl(baseURL);
            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('WordToGuess').setAttribute('value', 'gato')");
        }

        [When(@"I enter letters g, a, t and o as the typedLetter")]
        public void WhenIEnterLettersGATAndOAsTheTypedLetter()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            letterTyped.SendKeys("g");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            letterTyped.SendKeys("a");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            letterTyped.SendKeys("t");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            letterTyped.SendKeys("o");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        [Then(@"I Should be told that I Won")]
        public void ThenIShouldBeToldThatIWon()
        {
            bool condicionJugada = false;
            var win = driver.FindElement(By.Id("winLabel"));
            if (win.Text == "Ganaste!")
                condicionJugada = true;
            Assert.IsTrue(condicionJugada);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var sinErrores = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 7;
            Assert.IsTrue(sinErrores);
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }

    }
}