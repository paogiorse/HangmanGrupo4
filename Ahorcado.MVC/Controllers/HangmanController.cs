using Ahorcado.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahorcado.MVC.Controllers
{
    public class HangmanController : Controller
    {
        public static Juego Juego { get; set; }

        // GET: Hangman
        public ActionResult Index()
        {
            return View(new Hangman());
        }

        [HttpPost]
        public JsonResult InsertWordToGuess(Hangman model)
        {
            Juego = new Juego(model.WordToGuess);
            model.ChancesLeft = Juego.ChancesRestantes;
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(Hangman model)
        {
            Juego.insertarLetra(Convert.ToChar(model.LetterTyped));
            model.Win = Juego.ValidarPalabra();
            model.ChancesLeft = Juego.ChancesRestantes;
            model.WrongLetters = string.Empty;
            foreach (var wLetter in Juego.LetrasErradas)
            {
                model.WrongLetters += wLetter +  ",";
            }
            model.GuessingWord = string.Empty;
            foreach (var rLetter in Juego.PalabraIngresada)
            {
                model.GuessingWord += rLetter + " ";
            }
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}