using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacV1
{
    public class Figura
    {
       protected char caracter;

        public char Caracter { get => caracter; set => caracter = value; }
        public Figura(char caracter)
        {
            this.caracter = caracter;
        }
        public void mostrar()
        {
            Console.Write(caracter);
        }
        public static void mostrarOpcionesFiguras()
        {
            Console.WriteLine("INGRESE LA OPCION CON LA QUE DESEA JUGAR:");
            Console.WriteLine("1) X");
            Console.WriteLine("2) O");

        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Figura))
            {
                return false;
            }

            Figura otraFigura = (Figura)obj;
            return this.caracter==otraFigura.caracter;
        }
    }
}
