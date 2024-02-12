using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Partida
    {
        public int Lanzar()
        {
            int puntuaje = 0;
            ConsoleKeyInfo tecla;
            Random rnd = new Random();
            HUD hud = new HUD();
            BloqueDefensivo bDefensivo1 = new BloqueDefensivo();
            BloqueDefensivo bDefensivo2 = new BloqueDefensivo();
            BloqueDefensivo bDefensivo3 = new BloqueDefensivo();
            Ovni ovni = new Ovni();
            Nave nave = new Nave(39, 24);
            BloqueEnemigos bEnemigos = new BloqueEnemigos();
            bEnemigos.SetDireccion(false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 28);
            Console.WriteLine("\"Escape\" para salir");

            bDefensivo1.GenerarBloque(0);
            bDefensivo2.GenerarBloque(22);
            bDefensivo3.GenerarBloque(44);
            bEnemigos.GenerarEnemigos();
            bEnemigos.MoverA();
            nave.MoverA();
            tecla = Console.ReadKey();
            hud.DibujarVidas(nave.GetVidas());
            do
            {
                if (bEnemigos.GetNumeroEnemigos() <= 0)
                {
                    bEnemigos.GenerarEnemigos();
                    bEnemigos.MoverA();
                }
                if (Console.KeyAvailable)
                {
                    tecla = Console.ReadKey();
                    if (tecla.Key == ConsoleKey.RightArrow)
                        nave.MoverDerecha();
                    else if (tecla.Key == ConsoleKey.LeftArrow)
                        nave.Moverizquierda();
                    else if (tecla.Key == ConsoleKey.Spacebar)
                        nave.disparar();
                    nave.MoverA();
                }
                if (nave.GetCicloD())
                {
                    nave.estadoDisparo();
                    if (nave.GetDisparoActivo() && bEnemigos.revisarDRecibidos(nave.GetDisparoX(), nave.GetDisparoY(), ref puntuaje))
                    {
                        nave.SetDisparoActivo();
                        hud.DibujarPuntuaje(puntuaje);
                    }

                    if (nave.GetDisparoActivo() && (bDefensivo1.RevisarBloque(nave.GetDisparoX(), nave.GetDisparoY()) ||
                        (bDefensivo2.RevisarBloque(nave.GetDisparoX(), nave.GetDisparoY()) || (bDefensivo3.RevisarBloque(nave.GetDisparoX(), nave.GetDisparoY())))))
                    {
                        nave.SetDisparoActivo();
                        hud.DibujarPuntuaje(puntuaje);
                    }

                    bEnemigos.TiroRandom();
                    bEnemigos.RevisarDisparos(nave);
                    bEnemigos.RevisarDisparos(bDefensivo1);
                    bEnemigos.RevisarDisparos(bDefensivo2);
                    bEnemigos.RevisarDisparos(bDefensivo3);
                    hud.DibujarVidas(nave.GetVidas());
                    bEnemigos.MovimientoTiro();

                    if (ovni.estado)
                    {
                        ovni.MovimientoOvni();
                        if (nave.GetDisparoActivo() && ovni.revisarDD(nave.GetDisparoX(), nave.GetDisparoY(), ref puntuaje))
                        {
                            nave.SetDisparoActivo();
                            hud.DibujarPuntuaje(puntuaje);
                        }
                        ovni.RevisarEstado();
                    }
                }
                if (bEnemigos.GetCiclo())
                {
                    if (!ovni.estado)
                    {
                        int spawnOvni = rnd.Next(0, 200);
                        if (spawnOvni == 94)
                        {
                            ovni = new Ovni();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            ovni.MoverA();
                        }
                    }
                    bEnemigos.RevisarEstado();
                    nave.RevisarEstado();
                    if (bEnemigos.MovimientoEnemigo())
                        nave.SetVidas();
                }
            } while (tecla.Key != ConsoleKey.Escape && nave.GetVidas() > 0);
            return puntuaje;
        }
    }
}
