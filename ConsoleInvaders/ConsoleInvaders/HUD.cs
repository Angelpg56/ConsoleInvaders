using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class HUD
    {
        private string[] bordes = { "║", "═", "╔", "╗", "╚", "╝", "╠", "╣" };

        public void DibujarHUD(int xPantalla, int yPantalla)
        {
            Console.SetWindowSize(xPantalla + 2, yPantalla + 2);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i <= xPantalla; i++)
            {
                for (int j = 0; j <= yPantalla; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[2]);   //  ╔
                    }
                    else if ((i == 0 || i == xPantalla) && !(j == yPantalla || j == 0 || j == 25))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[0]);   //  ║
                    }
                    else if ((j == 0 || j == yPantalla || j == 25) && !(i == xPantalla || i == 0))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[1]);   //  ═
                    }
                    else if ((i == 0) && (j == yPantalla))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[4]);   //  ╚
                    }
                    else if ((i == xPantalla) && (j == 0))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[3]);   //  ╗
                    }
                    else if ((i == xPantalla) && (j == yPantalla))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[5]);   //  ╝
                    }
                    else if (j == 25)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.WriteLine(bordes[6]);   //  ╠
                        }
                        else if (i == xPantalla)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.WriteLine(bordes[7]);   //  ╣
                        }
                    }
                }
            }
            Console.SetCursorPosition(1, 26);
            Console.Write("Puntuacion:");
            Console.SetCursorPosition(70, 26);
            Console.Write("╔┴╗ x ");
        }

        public void DibujarPuntuaje(int puntuaje)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(14, 26);
            Console.Write(puntuaje);
        }
        public void DibujarVidas(int vidas)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(76, 26);
            Console.Write(vidas);
        }
        public void DibujarHUDScores(int xPantalla, int yPantalla)
        {
            int xInic = xPantalla / 3, xFin = xInic * 2;
            int yInic = 3, yFin = yPantalla - 7;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = xInic; i <= xFin; i++)
            {
                for (int j = yInic; j <= yFin; j++)
                {
                    if ((i == xInic) && (j == yInic))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[2]);   //  ╔
                    }
                    else if ((i == xInic || i == xFin) && !(j == yFin || j == yInic))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[0]);   //  ║
                    }
                    else if ((j == yInic || j == yFin || j == 25) && !(i == xFin || i == xInic))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[1]);   //  ═
                    }
                    else if ((i == xInic) && (j == yFin))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[4]);   //  ╚
                    }
                    else if ((i == xFin) && (j == yInic))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[3]);   //  ╗
                    }
                    else if ((i == xFin) && (j == yFin))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(bordes[5]);   //  ╝
                    }
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }
            Console.SetCursorPosition(xInic + 5, yInic + 2);
            Console.Write("Jugador");
            Console.SetCursorPosition(xInic + 17, yInic + 2);
            Console.Write("Score");
        }

        public void EscribirScores(int xPantalla, int yPantalla, int[] scores, string[] nombres)
        {
            int xInic = xPantalla / 3, xFin = xInic * 2;
            int yInic = 3, yFin = yPantalla - 7;
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(xInic + 7, yInic + 2 + (3 * (i + 1)));
                Console.Write(nombres[i]);
                Console.SetCursorPosition(xInic + 18, yInic + 2 + (3 * (i + 1)));
                Console.Write(scores[i]);
            }
        }
        public string EscribirNewScore(int score)
        {
            char tecla;
            ConsoleKeyInfo tecla2;
            string newNombre = "";
            Console.SetCursorPosition(1, 28);
            Console.Write(new string(' ', 19));
            Console.SetCursorPosition(12, 26);
            Console.Write(new string(' ', 10));
            Console.SetCursorPosition(31, 5);
            Console.Write("Tu nombre");
            Console.SetCursorPosition(44, 8);
            Console.Write(score);
            Console.SetCursorPosition(31, 7);
            Console.Write("┌───────┐");
            Console.SetCursorPosition(31, 9);
            Console.Write("└─═─═─═─┘");
            Console.SetCursorPosition(33, 8);
            tecla = Console.ReadKey().KeyChar;
            newNombre = newNombre + tecla.ToString() + " ";
            Console.SetCursorPosition(35, 8);
            tecla = Console.ReadKey().KeyChar;
            newNombre = newNombre + tecla.ToString() + " ";
            Console.SetCursorPosition(37, 8);
            tecla = Console.ReadKey().KeyChar;
            newNombre = newNombre + tecla.ToString() + " ";
            Console.SetCursorPosition(1, 28);
            Console.WriteLine("\"Enter\" para continuar");
            do { tecla2 = Console.ReadKey(); } 
            while (tecla2.Key != ConsoleKey.Enter) ;
            return newNombre;
        }
    }
}
