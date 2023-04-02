using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacV1
{
    public class Jugador
    {
        protected string nombre;
        private Figura figura;

        public Figura Figura { get => figura; set => figura = value; }

        public Jugador(string nombre,Figura figura)
        {
            this.nombre = nombre;
            this.Figura = figura;
        }


        public  void Mostrar()
        {
           
            Console.WriteLine($"Jugador:{nombre} \nFigura:{Figura.Caracter}");
        }
}
}
