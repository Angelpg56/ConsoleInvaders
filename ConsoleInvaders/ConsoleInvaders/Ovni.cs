using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Ovni : Enemigo
    {
        public Ovni()
        {
            this.x = 1;
            this.y = 2;
            this.imagen = "}─<O>─{";
            this.estado = true;
            this.direccion = false;
            this.puntosKill = 50;
            this.muerte = false;
            this.contadorMuerte = 0;
            this.imagenMuerte = "+" + this.puntosKill;
        }
        public void SetDireccion(bool newDireccion) { this.direccion = newDireccion; }


        public void MovimientoOvni()
        {
            if (this.estado)
            {
                this.Borrar();
                if (this.GetDireccion() && this.x > 2)
                    this.MoverIzquierda();
                else if (!this.GetDireccion() && this.x < 73)
                    this.MoverDerecha();
                else if (this.direccion)
                    this.direccion = false;
                else
                    this.direccion = true;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                this.MoverA();
            }
        }

        public bool revisarDD(int disparoX, int disparoY, ref int puntuaje)
        {
            if (this.estado)
            {
                if (this.Colisiones(disparoX, disparoY))
                {
                    this.Desaparecer();
                    puntuaje = puntuaje + this.GetPuntosKill();
                    return true;
                }
            }
            return false;
        }

        public void RevisarEstado()
        {
            if (this.GetMuerte() && this.estado)
                this.Desaparecer();
        }
    }
}