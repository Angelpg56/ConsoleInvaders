using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Defensa : Sprite
    {
        bool estado;
        string imagen1, imagen2;
        int fase;

        public Defensa(int newX, int newY) 
        { 
            this.estado = true;
            this.imagen = "█";
            this.imagen1 = "█";
            this.imagen2 = "▒";
            this.y = newY;
            this.x = newX;
            this.fase = 0;
        }
        public bool GetEstado() { return estado; }
        public void SetFase() 
        { 
            this.fase += 1;
            this.RevisarFase();
        }

        public void Desaparecer()
        {
            this.Borrar();
            this.estado = false;
        }

        public void RevisarFase()
        {
            if (this.fase == 1)
            {
                this.imagen = this.imagen2;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                this.Dibujar();
            }
            else if (this.fase == 2)
            {
                this.Desaparecer();
            }
        }
    }
}