using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Juego
    {
        public List<String> Palabras { get; set; }
        public String Palabra { get; set; }
        public List<char> LetrasAcertadas { get; set; }
        public List<char> LetrasUsadas { get; set; }
        public List<char> LetrasErradas { get; set; }
        public List<char> PalabraIngresada { get; set; }

        public int ChancesRestantes { get; set; }

        public Juego(String palabra)
        {
            Palabra = palabra.ToLower();
            PalabraIngresada = new List<char>();
            for (int i = 1; i <= palabra.Length; i++) {
                PalabraIngresada.Add('_');
            }
            LetrasAcertadas = new List<char>();
            LetrasUsadas = new List<char>();
            LetrasErradas = new List<char>();
            ChancesRestantes = 7;
        }

        public Boolean insertarLetra(char letra)
        {
            letra = Char.ToLower(letra);
            if (!LetrasUsadas.Contains(letra))
            {
               
                LetrasUsadas.Add(letra);
                if (Palabra.Contains(letra.ToString()))
                {
                    LetrasAcertadas.Add(letra);
                    char[] pal = Palabra.ToCharArray();
                    int pos=0;
                    foreach (char c in pal) {
                        if (c == letra) { PalabraIngresada[pos] = letra; }
                            pos++;
                    }

                    return true;
                }
                else
                {
                    LetrasErradas.Add(letra);
                    ChancesRestantes--;
                    return false;
                }
            }
            else if (Palabra.Contains(letra.ToString()))
            {
                return true;
            }
            else
            {
                ChancesRestantes--;
                return false;
            }
            
        }


        public bool IsGameOver()
        {
            if (ChancesRestantes == 0)
                return true;
            else
                return false;
        }

        public bool ValidarPalabra()
        {
            foreach (var letra in Palabra.ToCharArray())
            {
                if (!LetrasAcertadas.Contains(Char.ToLower(letra)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
