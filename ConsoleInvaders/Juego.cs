using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Juego
    {
        int[] nPuntuaciones = new int[6];
        string[] nNombres = new string[6];
        string rutaPuntuaciones = "Puntuaciones.txt";
        string rutaNombres = "Nombres.txt";

        public Juego()
        {

        }
        public void Lanzar() {
            Fichero fichero = new Fichero();
            fichero.CargarFichero(nPuntuaciones, nNombres, rutaPuntuaciones, rutaNombres);
            Console.CursorVisible = false;
            Bienvenida pTitulo = new Bienvenida();
            Partida partida = new Partida();
            HUD hud = new HUD();
            Console.Title = "Console Invaders ═O═";
            int xPantalla = 80, yPantalla = 29;
            hud.DibujarHUD(xPantalla, yPantalla);

            do
            {
                pTitulo.Lanzar(xPantalla, yPantalla, nPuntuaciones, nNombres);
                hud.DibujarHUD(xPantalla, yPantalla);
                if (pTitulo.GetSalir() == false)
                {
                    nPuntuaciones[5] = partida.Lanzar();
                    hud.DibujarHUDScores(xPantalla, (yPantalla / 2) + 3);
                    nNombres[5] = hud.EscribirNewScore(nPuntuaciones[5]);
                    OrdenarScores(nPuntuaciones, nNombres);
                    hud.DibujarHUD(xPantalla, yPantalla);
                    fichero.GuardarFichero(nPuntuaciones, nNombres, rutaPuntuaciones, rutaNombres);
                }
            } while (pTitulo.GetSalir() == false);
        }

        public void OrdenarScores(int[] puntuaciones, string[] nombres)
        {
            int puntucionAux;
            string nPuntuacionAux;
            for (int i = 0; i < 6 - 1; i++)
            {
                for (int j = i + 1; j < 6; j++)
                {
                    if (puntuaciones[i] < puntuaciones[j])
                    {
                        puntucionAux = puntuaciones[i];
                        nPuntuacionAux = nombres[i];
                        puntuaciones[i] = puntuaciones[j];
                        nombres[i] = nombres[j];
                        puntuaciones[j] = puntucionAux;
                        nombres[j] = nPuntuacionAux;
                    }
                }
            }
        }
    }
}
