using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Type3 : Enemigo
    {
        public Type3(int xIni)
        {
            this.x = xIni;
            this.y = 7;
            this.imagen = "═O═";
            this.estado = true;
            this.puntosKill = 10;
            this.muerte = false;
            this.contadorMuerte = 0;
            this.imagenMuerte = "+" + this.puntosKill;
        }
    }
}
