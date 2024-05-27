using System;
using System.Threading;
using static System.Console;

namespace knighs_tour
{
    class Program
    {
        public static int[,] board = new int[8, 8];

        public static void Main(string[] args)
        {
            KnightsTourSolve();
        }

        public static void KnightsTourSolve()
        {
            // Inicializa todas las casillas del tablero como no visitadas
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = -1;
                }
            }

            int moveNum = 0;
            int moveX = 0;
            int moveY = 0;

            // Marca la primera posición del caballo como 0
            board[moveX, moveY] = moveNum;

            // Inicia la búsqueda recursiva
            KnightsTourNextMove(moveX, moveY, moveNum + 1);
        }

        public static bool KnightsTourNextMove(int x, int y, int move)
        {
            if (move == board.Length)
            {
                return true;
            }

            // Recorre los 8 posibles movimientos del caballo
            for (int i = 0; i < 8; i++)
            {
                // Obtener los posibles movimientos en x y y del caballo
                int nextX = NextX(x, i);
                int nextY = NextY(y, i);

                // Valida si en x y y tiene un -1 y si las posiciones en la matriz da -1
                if (nextX != -1 && nextY != -1 && board[nextX, nextY] == -1)
                {
                    // Asigna el valor de x y y a la posición
                    board[nextX, nextY] = move;

                    // Imprimir el tablero con el número moviéndose en verde
                    PrintBoardWithHighlightedMove(nextX, nextY);

                    // Espera un momento para visualizar el movimiento
                    //Thread.Sleep(10);

                    // Limpia la pantalla antes de imprimir el siguiente movimiento
                    Clear();

                    // Invoca a la función recursiva hasta que move se igual a la logitud del tablero
                    if (KnightsTourNextMove(nextX, nextY, move + 1))
                    {
                        return true;
                    }
                    // Si el movimiento no lleva a una solución, retrocede y marca la casilla como no visitada
                    board[nextX, nextY] = -1;
                }
            }
            return false;
        }

        public static int NextX(int x, int move)
        {
            // Posibles movimientos en x 
            int[] MoveX = { 2, 1, -1, -2, -2, -1, 1, 2 };
            // Suma la posición actual de x en el arreglo y la suma al número que tenga asignado según los 8 posibles movimientos
            int nextX = x + MoveX[move];
            // Comprueba si la suma en x no se sale del tablero si no se sale devuelve la suma y si no devuelve -1 
            if (nextX >= 0 && nextX < board.GetLength(0))
            {
                return nextX;
            }
            else
            {
                return -1;
            }
        }

        public static int NextY(int y, int move)
        {
            // Posibles movimientos en y
            int[] MoveY = { 1, 2, 2, 1, -1, -2, -2, -1 };
            // Suma la posición actual de y en el arreglo y la suma al número que tenga asignado según los 8 posibles movimientos
            int nextY = y + MoveY[move];
            // Comprueba si la suma en y no se sale del tablero si no se sale devuelve la suma y si no devuelve -1 
            if (nextY >= 0 && nextY < board.GetLength(1))
            {
                return nextY;
            }
            else
            {
                return -1;
            }
        }

        public static void PrintBoardWithHighlightedMove(int moveX, int moveY)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // Si la posición coincide con la del movimiento actual, imprime en verde
                    if (i == moveX && j == moveY)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        Write(board[i, j].ToString().PadLeft(2) + " ");
                    }
                    else
                    {
                        // Si no, imprime en blanco
                        ForegroundColor = ConsoleColor.White;
                        Write(board[i, j].ToString().PadLeft(2) + " ");
                    }
                }
                WriteLine("");
            }
        }
    }
}
