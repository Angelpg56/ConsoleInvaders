using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class BloqueEnemigos : Enemigo
    {
        Enemigo[,] Bloque = new Enemigo[10, 3];
        Reloj reloj = new Reloj(1);
        int tiroAleatorio, tiroQuien, revisarVivos, nEnemigos;
        bool estadoBloque;

        public BloqueEnemigos()
        {
            estadoBloque = true;
            revisarVivos = -1;
            nEnemigos = 0;
        }
        public bool GetCiclo() { return this.reloj.Ciclo(); }
        public int GetNumeroEnemigos() { return nEnemigos; }
        public void SetDireccion(bool newDireccion) { this.direccion = newDireccion; }

        public void GenerarEnemigos()
        {
            for (int i = 0; i < 10; i++)
            {
                Bloque[i, 2] = new Type1(21 + (i * 4));
                nEnemigos++;
                Bloque[i, 0] = new Type3(21 + (i * 4));
                nEnemigos++;
                Bloque[i, 1] = new Type2(21 + (i * 4));
                nEnemigos++;
            }
        }

        public override void MoverA()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Bloque[i, j].estado)
                    {
                        if (Bloque[i, j] is Type1)
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        else if (Bloque[i, j] is Type2)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Bloque[i, j].Dibujar();
                    }
                }
            }
        }

        public void TiroRandom()
        {
            bool okT = false;
            tiroAleatorio = rnd.Next(0, 5);
            if (tiroAleatorio == 3) 
            {
                tiroQuien = rnd.Next(0, 9);
                do
                {
                    if (Bloque[tiroQuien, 0].estado)
                    {
                        Bloque[tiroQuien, 0].disparar();
                        okT = true;
                    }
                    else if (Bloque[tiroQuien, 1].estado)
                    {
                        Bloque[tiroQuien, 1].disparar();
                        okT = true;
                    }
                    else if (Bloque[tiroQuien, 2].estado)
                    {
                        Bloque[tiroQuien, 2].disparar();
                        okT = true;
                    }
                    else
                    {
                        if (tiroQuien < 9)
                        {
                            revisarVivos = tiroQuien;
                            tiroQuien++;
                        }
                        else
                            tiroQuien = 0;
                    }
                    if (tiroQuien == revisarVivos)
                    {
                        okT = true;
                        estadoBloque = false;
                    }
                } while (!okT);
            }
        }

        public void MovimientoTiro()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Bloque[i, j].estadoDisparo();
                }
            }
        }
        public bool MovimientoEnemigo()
        {
            if (Bloque[9, 0].x < 77 && !this.direccion)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Bloque[i, j].estado)
                        {
                            Bloque[i, j].Borrar();
                        }
                        Bloque[i, j].MoverDerecha();
                    }
                }
            }
            else if (Bloque[0, 0].x > 2 && this.direccion)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Bloque[i, j].estado)
                        {
                            Bloque[i, j].Borrar();
                        }
                        Bloque[i, j].MoverIzquierda();
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Bloque[i, j].estado)
                        {
                            Bloque[i, j].Borrar();
                        }
                        Bloque[i, j].MoverLinea();
                        if (Bloque[i, j].GetY() > 22)
                            return true;
                    }
                }
                if (this.direccion)
                    this.direccion = false;
                else
                    this.direccion = true;
            }
            this.MoverA();
            return false;
        }

        public bool revisarDRecibidos(int disparoX, int disparoY, ref int puntuaje)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Bloque[i, j].GetMuerte())
                    {
                        if (Bloque[i, j].Colisiones(disparoX, disparoY))
                        {
                            Bloque[i, j].Desaparecer();
                            puntuaje = puntuaje + Bloque[i, j].GetPuntosKill();
                            nEnemigos--;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void RevisarDisparos(Nave nave)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Bloque[i, j].GetDisparoActivo() && (nave.Colisiones(Bloque[i, j].GetDisparoX(), Bloque[i, j].GetDisparoY() + 1)))
                    {
                        Bloque[i, j].SetDisparoActivo();
                        nave.Borrar();
                        nave.PerderVida();
                    }
                }
            }
        }
        public void RevisarDisparos(BloqueDefensivo defensas)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (defensas.RevisarBloque(Bloque[i, j].GetDisparoX(), Bloque[i, j].GetDisparoY() + 1))
                        Bloque[i, j].SetDisparoActivo();
                }
            }
        }
        public void RevisarEstado()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Bloque[i, j].GetMuerte() && Bloque[i, j].estado)
                    {
                        Bloque[i, j].Desaparecer();
                    }
                }
            }
        }
    }
}
