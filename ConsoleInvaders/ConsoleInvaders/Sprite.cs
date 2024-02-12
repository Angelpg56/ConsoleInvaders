using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Sprite
    {
        public int x;     //  Limites    X = 1 - 80;
        public int y;     //  Limites    Y = 1 - 24;
        protected string imagen;
        protected string imagenMuerte;


        public virtual void MoverA()
        {
            Borrar();
            Dibujar();
        }
        public void Dibujar()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.imagen);
        }
        public virtual void Borrar()
        {
            Console.SetCursorPosition(this.x, this.y);
            string borrado = new string(' ', this.imagen.Length);
            Console.Write(borrado);
        }

        public virtual bool Colisiones(int disparoX, int disparoY)
        {
            bool revisarX = (this.x < disparoX + 1) && (this.x > disparoX - this.imagen.Length);
            bool revisarY = (this.y == disparoY) || (this.y == disparoY - 1) || (this.y == disparoY + 1);

            return revisarX && revisarY;
        }
    }
}
