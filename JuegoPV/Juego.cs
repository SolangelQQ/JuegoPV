using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacV1
{
    public class Juego
    {
        private Jugador jugadorUno;
        private Jugador jugadorDos;
        private Jugador ganador;
        private Jugador perdedor;

        private Tablero tablero;
        public Juego()
        {
            tablero = new Tablero(3,3);
            jugadorUno = null;
            jugadorDos = null;
            ganador = null;
            perdedor=null;
        }
 
        public string leerJugadorNombre()
        {

            Console.WriteLine("INGRESE NOMBRE DEL JUGADOR:");
            string nombre = Console.ReadLine();
            return nombre;
        }
        public void mostrarResultados()
        {
            if (ganador == null)
                Console.WriteLine("EMPATE!!");
            else
            {
                Console.WriteLine("GANADOR:");
                ganador.Mostrar();
                Console.WriteLine("PERDEDOR:");
                perdedor.Mostrar();
            }
        }
        public Jugador leerJugador()
        {

            string nombre = leerJugadorNombre();
            Figura figura;
            while (true) {
                Figura.mostrarOpcionesFiguras();
                string entrada = Console.ReadLine();
                int numero;
                try
                {
                    if (!int.TryParse(entrada, out numero))
                    {
                        throw new Exception("INGRESE LA OPCION!!");
                    }
                    if (numero == 1)
                    {
                        figura = new Figura('X');

                    }
                    else
                    {
                        figura = new Figura('O');

                    }
                    break;
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine(excepcion.Message);
                    Console.WriteLine("PRESIONE ENTER PARA CONTINUAR");

                    Console.ReadKey();


                }
                finally
                {
                    Console.Clear();
                }
            }
            return new Jugador(nombre, figura);
        }
        public void leerJugadores()
        {
            jugadorUno=leerJugador();
            Figura figura;
            if (jugadorUno.Figura.Caracter == 'X')
                figura = new Figura('O');
            else
                figura = new Figura('X');
            string nombre = leerJugadorNombre();
            jugadorDos = new Jugador(nombre, figura);
        }

        public void JugarEnTablero()
        {
            int fila=-1, col=-1, contador = tablero.Filas * tablero.Cols;
            Figura figuraTurno =jugadorUno.Figura;
            Casilla casilla =null;
            tablero.mostrarTablero();
            while (contador > 0) {
                casilla = new Casilla(figuraTurno);
               tablero.IngresarPosicionesDeCasilla(casilla, out fila, out col);
                tablero.mostrarTablero();
                if (figuraTurno == jugadorUno.Figura) figuraTurno = jugadorDos.Figura;
                else figuraTurno = jugadorUno.Figura;
                if(tablero.verificarGanador(fila-1,col-1,casilla))
                {
                        ganador = jugadorUno;
                        perdedor = jugadorDos;
                        if (figuraTurno.Caracter == jugadorUno.Figura.Caracter) {
                            ganador = jugadorDos;
                            perdedor = jugadorUno;
                        }
                        break;
                }
            contador--;
            } 

        }
    }
}


