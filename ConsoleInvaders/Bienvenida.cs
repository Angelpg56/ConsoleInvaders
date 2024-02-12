using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Bienvenida
    {
        bool salir;
        public bool GetSalir() { return salir; }
        public void Lanzar(int xPantalla, int yPantalla, int[] scores, string[] nombres)
        {
            ConsoleKeyInfo tecla;
            HUD hud = new HUD();
            do
            {
                Console.SetCursorPosition(1, 28);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Pulse \"Intro\" para jugar o \"Escape\" para salir");
                hud.DibujarHUDScores(xPantalla, yPantalla);
                hud.EscribirScores(xPantalla, yPantalla, scores, nombres);

                tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.Escape)
                    salir = true;
                else if (tecla.Key == ConsoleKey.Enter)
                    salir = false;
            } while (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Escape);
        }
    }
}
