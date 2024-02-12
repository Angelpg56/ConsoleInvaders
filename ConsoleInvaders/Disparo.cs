using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Disparo : Sprite
    {
        bool disparoActivo = false;
        string imagen1, imagen2;
        Reloj reloj = new Reloj(2);

        public Disparo()
        {
            this.imagen = "{";
            this.imagen1 = "{";
            this.imagen2 = "}";
        }
        public bool GetCiclo() { return this.reloj.Ciclo(); }
        public bool GetDisparoActivo() { return disparoActivo; }
        public void SetDisparoInactivo()
        {
            this.Borrar();
            disparoActivo = false;
        }


        public void Disparar(int xInic, int yInic, bool bando)
        {
            Console.ForegroundColor = ConsoleColor.White;
            this.x = xInic + 1;
            if (bando)
                this.y = yInic - 1;
            else
                this.y = yInic + 1;
            this.disparoActivo = true;
        }
        public void Continuar(bool bando)
        {
            this.Borrar();
            if (this.y > 1 && bando)
            {
                this.y -= 1;
                if(this.y % 2 == 0)
                    this.imagen = imagen1;
                else
                    this.imagen = imagen2;
                Console.ForegroundColor = ConsoleColor.White;
                this.MoverA();
            }
            else if (this.y < 24 && !bando)
            {
                this.y += 1;
                if (this.y % 2 == 0)
                    this.imagen = imagen1;
                else
                    this.imagen = imagen2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                this.MoverA();
            }
            else
            {
                this.Borrar();
                disparoActivo = false;
            }
        }
    }
}
