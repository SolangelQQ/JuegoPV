using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacV1
{
    public class Casilla
    {
        private Figura figura;

        public Casilla( Figura figura)
        {

            this.figura = figura;
        }

        public Figura Figura { get => figura; set => figura = value; }
     
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Casilla))
            {
                return false;
            }

            Casilla otraCasilla = (Casilla)obj;
            return this.figura.Equals(otraCasilla.Figura);
        }
    }
}
