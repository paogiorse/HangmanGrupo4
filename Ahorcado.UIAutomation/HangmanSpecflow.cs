﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Ahorcado.UIAutomation
{
    [Binding]
    public class HangmanSpecflow
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

        #region Loose The Game
        [Given(@"I have generated the wordToGuess")]
        public void GivenIHaveEnteredAhorcadoAsTheWordToGuess()
        {
            j = new Jugada();
            driver.Navigate().GoToUrl(baseURL);
            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);
        }
               
        [When(@"I enter X as the typedLetter seven times")]
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
            bool condicionPerdido = false;
            var win = driver.FindElement(By.Id("winLabel"));
            if (win.Text == "Perdiste!")
                condicionPerdido = true;
            Assert.IsTrue(condicionPerdido);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Assert.IsTrue(loss);
        }
        #endregion

        #region Win The Game Without Erros
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
        public void WhenIEnterLettersGatoAsTheTypedLetter()
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

        [Then(@"I Should be told that I Won and without errors")]
        public void ThenIShouldBeToldThatIWonWithoutErrors()
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
        #endregion

        #region Win The Game With Erros
        [When(@"I enter letters x, x, g, a, t and o as the typedLetter")]
        public void WhenIEnterLettersXxgatoAsTheTypedLetter()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            letterTyped.SendKeys("x");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            letterTyped.SendKeys("x");
            btnInsertLetter.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
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

        [Then(@"I Should be told that I Won and with errors")]
        public void ThenIShouldBeToldThatIWonWithErrors()
        {
            bool condicionJugada = false;
            var win = driver.FindElement(By.Id("winLabel"));
            if (win.Text == "Ganaste!")
                condicionJugada = true;
            Assert.IsTrue(condicionJugada);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var conErrores = Convert.ToInt32(chancesLeft.GetAttribute("value")) != 7;
            Assert.IsTrue(conErrores);
        }
        #endregion

        #region Reset
        [When(@"I enter letters g, a, t and o as the typedLetter and click on Resetear button")]
        public void WhenIEnterLettersGatoAsTheTypedLetterAndClickReset()
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
            var reset = driver.FindElement(By.Id("btnResetGame"));
            reset.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        [Then(@"I Should see Empezar Juego button enabled and Resetear button disabled")]
        public void ThenIShouldSeeEmpezarJuegoEnabledResetearDisabled()
        {
            var insertWord = driver.FindElement(By.Id("btnInsertWord"));
            Assert.IsTrue(insertWord.Enabled);
            var reset = driver.FindElement(By.Id("btnResetGame"));
            Assert.IsFalse(reset.Enabled);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var resetearChances = string.IsNullOrEmpty(chancesLeft.GetAttribute("value"));
            Assert.IsTrue(resetearChances);
        }
        #endregion

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
