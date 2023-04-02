
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TicTacV1
{
    public class Tablero
    {
        private Casilla[,] matrizCasillas;
        private int filas;
        private int columnas;
        public Tablero(int filas,int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            matrizCasillas = new Casilla[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matrizCasillas[i, j] = null;
                }
            }

        }
        public bool validarCasillaEnPosDesOcupada(int fila,int columna)
        {
            return matrizCasillas[fila, columna]==null;
        }
        public void ponerCasillaEnPosDesOcupada(int fila,int col,Casilla casilla)
        {
            matrizCasillas[fila,col] = casilla;
        }
        public int Filas { get => filas; set => filas = value; }
        public int Cols { get => columnas; set => columnas = value; }

        public void dibujar()
        {
            Console.WriteLine($"  1 2 3");
            for (int i = 0; i < filas; i++)
            {
                Console.WriteLine($" +-+-+-+");
                Console.Write(i + 1);
                for (int j = 0; j < columnas; j++)
                {
                    char caracter = ' ';
                    if (matrizCasillas[i, j] != null)
                    {
                        caracter = matrizCasillas[i, j].Figura.Caracter;
                    }
                    Console.Write($"|{caracter}");
                    if (j == Cols - 1) Console.WriteLine("|");
                }

            }
            Console.WriteLine($" +-+-+-+");

        }
        public void mostrarTablero()
        {
            Console.Clear();
            dibujar();
        }
        internal bool verificarDiagonalPrincipal(Casilla casilla)
        {
            for (int i = 0; i < filas; i++)
            {
                if (!(casilla.Equals(matrizCasillas[i, i])))
                {
                    return false;
                }
            }
            return true;
        }
        internal bool verificarDiagonalSecundaria(Casilla casilla)
        {
            for (int i = 0; i < columnas; i++)
            {
                if (!(casilla.Equals(matrizCasillas[i, (Cols - i - 1)])))
                {
                    return false;
                }
            }
            return true;

        }
        internal bool verificarCols(Casilla casilla,int fila)
        {
            for (int i = 0; i < columnas; i++)
            {
                if (!(casilla.Equals(matrizCasillas[fila, i])))
                {
                    return false;
                }
            }
            return true;

        }
        internal bool verificarFilas(Casilla casilla, int columna)
        {
            for (int i = 0; i < filas; i++)
            {
                if (!(casilla==matrizCasillas[i,columna]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool verificarGanador(int fila,int col,Casilla casilla)
        {
            return verificarDiagonalPrincipal(casilla) || verificarDiagonalSecundaria(casilla) || verificarCols(casilla,fila) || verificarFilas(casilla,col);
        }
        public void IngresarPosicionesDeCasilla(Casilla casilla,out int fila,out int columna)
        {

            while (true)
            {
                Console.WriteLine($"TURNO:{casilla.Figura.Caracter}");
                Console.WriteLine("INGRESE LA POSICION DE LA FILA:");
                string celdaUno = Console.ReadLine();
                Console.WriteLine("INGRESE LA POSICION DE LA COLUMNA:");
                string celdaDos = Console.ReadLine();
                try
                {
                    if (!(int.TryParse(celdaUno, out fila) && int.TryParse(celdaDos, out columna)))
                    {
                        throw new Exception("PORFAVOR INGRESE SOLO NUMEROS ENTEROS!!");
                    }
                    if (fila > filas || columna > columnas)
                    {
                        throw new Exception("INGRESE UNA POSICION CORRECTA!!");
                    }
                    else if (!validarCasillaEnPosDesOcupada(fila - 1, columna - 1))
                    {
                        throw new Exception("LA POSICION ESTA OCUPADA!!");
                    }
                    break;
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine(excepcion.Message);
                    Console.WriteLine("PRESIONA UNA TECLA PARA CONTINUAR");
                    Console.ReadKey();
                    mostrarTablero();
                }

            }
            ponerCasillaEnPosDesOcupada(fila-1,columna-1,casilla);

        }
    }
}


