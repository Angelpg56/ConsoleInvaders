using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Type2 : Enemigo
    {
        public Type2(int xIni)
        {
            this.x = xIni;
            this.y = 5;
            this.imagen = "╚╦╝"; 
            this.estado = true;
            this.puntosKill = 20;
            this.muerte = false;
            this.contadorMuerte = 0;
            this.imagenMuerte = "+" + this.puntosKill;
        }
    }
}
