using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Jugada
    {
        public string palabraHardcodeada;
        public string estado;
        public string nombreJugador;
        public string dificultad;
        public char[] palabraParcial;
        public List<char> letrasIngresadas = new List<char>();
        public List<string> opcionesPalabras = new List<string>() { "gato", "perro", "barco", "casa", "pelota" };
        public int cantidadFallos = 0;

        public Jugada()
        {
            IngresoJugador();
            SeleccionarDificultad();
            palabraHardcodeada = GenerarPalabraRandom();
        }

        public void IngresoJugador()
        {
            nombreJugador = "Anónimo";
        }

        public void SeleccionarDificultad()
        {
            dificultad = "SinDificultad";
        }

        public string GenerarPalabraRandom()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, opcionesPalabras.Count);
            return opcionesPalabras[index];
        }

        public string GenerarPalabra()
        {
            return palabraHardcodeada;
        }

        public bool PerteneceLetraPalabra(string letra)
        {
            if (String.IsNullOrEmpty(letra))
            {
                return false;
            }
            else if (palabraHardcodeada.Contains(letra))
            {
                return true;
            }
            return false;
        }

        public char[] MostrarPalabra()
        {
            char[] palabraParcial = new char[palabraHardcodeada.Length];
            foreach (var letra in letrasIngresadas)
            {
                int minIndex = 0;
                if (palabraHardcodeada.Contains(letra))
                {
                    do
                    {
                        minIndex = palabraHardcodeada.IndexOf(letra, minIndex);
                        if (minIndex != -1)
                        {
                            palabraParcial[minIndex] = letra;
                            minIndex++;
                        }
                    } while (minIndex != -1);
                }
                else
                {
                    cantidadFallos = cantidadFallos + 1;
                }
            }
            return palabraParcial;
        }

        public string TerminarPartida(char[] parcial)
        {
            estado = "En curso";
            if (new String(parcial) == palabraHardcodeada)
                estado = "Terminado";
            return estado;
        }

        public List<char> ListaLetrasIngresadas()
        {
            return letrasIngresadas;
        }

        public int CantidadFallos()
        {
            return cantidadFallos;
        }
    }
}
