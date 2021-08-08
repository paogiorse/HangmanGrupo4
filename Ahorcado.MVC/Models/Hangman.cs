using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ahorcado.MVC.Models
{
    public class Hangman
    {
        [DisplayName("Letra")]
        public String LetterTyped { get; set; }
        [DisplayName("Palabra")]
        public String WordToGuess { get; set; }
        [DisplayName("Letras acertadas")]
        public String GuessingWord { get; set; }
        [DisplayName("Chances Restantes")]
        public Int32? ChancesLeft { get; set; }
        [DisplayName("Letras Erradas")]
        public String WrongLetters { get; set; }

        public Boolean Win { get; set; }

    }
}