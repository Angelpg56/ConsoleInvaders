using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class BloqueDefensivo : Sprite
    {
        Defensa[,] BloqueD;
        public BloqueDefensivo()
        {
            BloqueD = new Defensa[3,13];
        }
        public void GenerarBloque(int xInicio)
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    BloqueD[i, j] = new Defensa(12 + xInicio + j, 22 - i);
                    Console.ForegroundColor = ConsoleColor.Green;
                    BloqueD[i, j].Dibujar();
                }
            }
        }
        public bool RevisarBloque(int disparoX, int disparoY)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (BloqueD[i, j].GetEstado())
                    {
                        if (BloqueD[i, j].Colisiones(disparoX, disparoY))
                        {
                            BloqueD[i, j].Desaparecer();
                            if (j < 12)
                                BloqueD[i, j + 1].SetFase();
                            if (j > 0)
                                BloqueD[i, j - 1].SetFase();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}