using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Enemigo : Sprite
    {
        protected Random rnd = new Random();
        protected Disparo disparo = new Disparo();
        public bool estado;   //true = vivo   false = muerto
        protected bool direccion, muerte;     //false = derecha   true = izquierda
        protected int puntosKill, contadorMuerte;

        public int GetPuntosKill() { return this.puntosKill; }
        public bool GetDireccion() {  return direccion; }
        public int GetDisparoX() { return this.disparo.x; }
        public int GetDisparoY() { return this.disparo.y; }
        public int GetY() { return this.y; }
        public bool GetMuerte() { return this.muerte; }
        public int GetContadorMuerte() { return this.contadorMuerte; }
        public void SetContadorMuerte() { this.contadorMuerte = this.contadorMuerte + 1; }
        public bool GetDisparoActivo() { return this.disparo.GetDisparoActivo(); }
        public void SetDisparoActivo() { this.disparo.SetDisparoInactivo(); }
        public void MoverDerecha()
        {
                this.x += 2;
        }
        public void MoverIzquierda()
        {
                this.x -= 2;
        }
        public void MoverLinea()
        {
                this.y += 1;
        }
        public void Desaparecer()
        {
            if (this.muerte)
            {
                if (this.GetMuerte() && this.GetContadorMuerte() > 2)
                {
                    this.estado = false;
                    this.Borrar();
                }
                else
                {
                    this.SetContadorMuerte();
                }
            }
            else
            {
                this.Borrar();
                this.imagen = imagenMuerte;
                this.MoverA();
                this.muerte = true;
            }
        }
        public void disparar()
        {
            if (!this.disparo.GetDisparoActivo())
            {
                this.disparo.Disparar(this.x, this.y, false);
                this.disparo.MoverA();
            }
        }

        public void estadoDisparo()
        {
            if (this.disparo.GetDisparoActivo())
                this.disparo.Continuar(false);
        }

    }
}
