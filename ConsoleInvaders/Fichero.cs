using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInvaders
{
    class Fichero
    {
        public void CargarFichero(int[] nPuntuaciones, string[] nNombres, string rutaPuntuaciones, string rutaNombres)
        {
            if (File.Exists(rutaPuntuaciones))        //Guardar las puntuaciones, no va
            {
                string[] lineas = File.ReadAllLines(rutaPuntuaciones);
                nPuntuaciones = Array.ConvertAll(lineas, int.Parse);
                if (File.Exists(rutaNombres))
                {
                    nNombres = File.ReadAllLines(rutaNombres);
                }
                else
                {
                    for (int i = 0; i< 5; i++)
                    {
                        nNombres[i] = "- - -";
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    nPuntuaciones[i] = 000;
                    nNombres[i] = "- - -";
                }
            }
        }
        public void GuardarFichero(int[] nPuntuaciones, string[] nNombres, string rutaPuntuaciones, string rutaNombres)
        {
            File.WriteAllLines(rutaPuntuaciones, Array.ConvertAll(nPuntuaciones, x => x.ToString()));
            File.WriteAllLines(rutaNombres, nNombres);
        }
    }
}
