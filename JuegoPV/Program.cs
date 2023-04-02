 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego ticTacToe=new Juego();
            ticTacToe.leerJugadores();
            ticTacToe.JugarEnTablero();
            ticTacToe.mostrarResultados();
        }
    }
}
