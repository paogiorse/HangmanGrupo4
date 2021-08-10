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
        public static Jugada Juego { get; set; }

        // GET: Hangman
        public ActionResult Index()
        {
            return View(new Hangman());
        }

        [HttpPost]
        public JsonResult InsertWordToGuess(Hangman model)
        {
            Juego = new Jugada();
            model.WordToGuess = Juego.palabraHardcodeada;
            model.ChancesLeft = 7;
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(Hangman model)
        {
            Juego.letrasIngresadas.Add(Convert.ToChar(model.LetterTyped));
            Juego.cantidadFallos = 0;
            var palabraParcial = Juego.MostrarPalabra();
            string estado = Juego.TerminarPartida(palabraParcial);
            if(estado.Equals("Terminado"))
            {
                model.Win = true;
            }
            model.ChancesLeft = 7 - Juego.CantidadFallos();
            model.WrongLetters = string.Empty;
            model.GuessingWord = string.Empty;
            foreach (var letter in Juego.ListaLetrasIngresadas())
            {
                if(!Juego.PerteneceLetraPalabra(letter.ToString()))
                {
                    model.WrongLetters += letter + ",";
                }
            }
            model.GuessingWord = string.Empty;
            foreach (var letter in palabraParcial)
            {
                model.GuessingWord += letter + " ";
            }
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}