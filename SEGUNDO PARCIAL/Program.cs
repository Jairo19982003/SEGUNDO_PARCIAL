using System;

class BattleshipGame
{
    static int[,] tablero = new int[5, 5];
    static int intentos = 0;
    static int barcosRestantes = 4;
    static void Main(string[] args)
    {
        try
        {
            paso1creartablero();
            paso2colocarbarcos();
            paso3imprimir();
            paso4ingresocordenadas();

            Console.WriteLine("Felicitaciones, has hundido todos los barcos en {0} intentos.", intentos);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ha ocurrido un error: " + ex.Message);
        }
    }

    static void paso1creartablero()
    {
        try
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    tablero[f, c] = 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error en paso1creartablero: " + ex.Message);
        }
    }

    static void paso2colocarbarcos()
    {
        try
        {
            Random rand = new Random();
            int num_barcos = 4;

            while (num_barcos > 0)
            {
                int fila = rand.Next(0, 5);
                int columna = rand.Next(0, 5);

                if (tablero[fila, columna] != 1)
                {
                    tablero[fila, columna] = 1;
                    num_barcos--;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error en paso2colocarbarcos: " + ex.Message);
        }
    }

    static void paso3imprimir()
    {
        try
        {
            Console.Clear();
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    switch (tablero[f, c])
                    {
                        case 0:
                            Console.Write("'_'");
                            break;
                        case 1:
                            Console.Write("'_'");
                            break;
                        case -1:
                            Console.Write("X ");
                            break;
                        case -2:
                            Console.Write("* ");
                            break;
                        default:
                            Console.Write("~ ");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            throw new Exception("Error en paso3imprimir: " + ex.Message);
        }
    }

    static void paso4ingresocordenadas()
    {
        try
        {
            int fila, columna;
            do
            {
                Console.Write("Ingresa la fila: ");
                fila = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingresa la columna: ");
                columna = Convert.ToInt32(Console.ReadLine());

                if (tablero[fila, columna] == 1)
                {
                    Console.Beep();
                    Console.WriteLine("¡Golpeaste un barco!");
                    tablero[fila, columna] = 2;
                    barcosRestantes--;
                }
                else
                {
                    Console.WriteLine("Fallaste.");
                    tablero[fila, columna] = -1;
                }
                intentos++;
                paso3imprimir();
            } while (barcosRestantes > 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ha ocurrido un error: " + ex.Message);
        }
    }
}







