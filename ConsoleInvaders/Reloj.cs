using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    internal class Reloj
    {
        public int reloj, relojI;

        public Reloj(int newType)    //     1 = enemigos    2 = disparo y ovni
        {
            if (newType == 1)
            {
                this.relojI = 20000;
            }
            else
            {
                this.relojI = 5000;
            }
        }

        public bool Ciclo()
        {
            this.reloj++;
            if (this.reloj == this.relojI)
            {
                this.reloj = 0;
                return true;
            }
                return false;
        }
    }
}
