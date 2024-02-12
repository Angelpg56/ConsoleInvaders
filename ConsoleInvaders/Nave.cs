using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Nave : Sprite
    {
        Disparo disparo = new Disparo();
        Reloj reloj = new Reloj(0);
        int vidas, contadorMuerte;
        public Nave(int xIni, int yIni)
        {
            this.x = xIni;
            this.y = yIni;
            this.imagen = "╔┴╗";
            this.vidas = 3;
    }
        public int GetX() { return this.x; }
        public int GetY() { return this.y; }
        public int GetVidas() { return vidas; }
        public bool GetCicloD() { return this.disparo.GetCiclo(); }
        public int GetDisparoX() { return this.disparo.x; }
        public int GetDisparoY() { return this.disparo.y; }
        public bool GetDisparoActivo() { return this.disparo.GetDisparoActivo(); }
        public void SetDisparoActivo() { this.disparo.SetDisparoInactivo(); }
        public void SetVidas() { this.vidas = 0; }
        public override void MoverA()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Dibujar();
        }
        public void MoverDerecha()
        {
            Borrar();
            if (this.x < 79 - this.imagen.Length)
                this.x = this.x + 2;
        }
        public void Moverizquierda()
        {
            Borrar();
            if (this.x > 2)
                this.x -= 2;
        }
        public void disparar()
        {
            if (!this.disparo.GetDisparoActivo())
            {
                this.disparo.Disparar(this.x, this.y, true);
                this.disparo.MoverA();
            }
        }

        public void estadoDisparo()
        {
            if (this.disparo.GetDisparoActivo())
                this.disparo.Continuar(true);
        }

        public void PerderVida()
        {
            this.imagen  = "-1♥";
            this.vidas -= 1;
            this.contadorMuerte = 3;
        }

        public void RevisarEstado()
        {
            if (this.contadorMuerte > 0)
                this.contadorMuerte -= 1;
            else
                this.imagen = "╔┴╗";
            this.MoverA();
        }
    }
}
