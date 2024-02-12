using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Type1 : Enemigo
    {
        public Type1(int xIni)
        {
            this.x = xIni;
            this.y = 3;
            this.imagen = "╠O╣";
            this.estado = true;
            this.puntosKill = 30;
            this.muerte = false;
            this.contadorMuerte = 0;
            this.imagenMuerte = "+" + this.puntosKill;
        }
    }
}
