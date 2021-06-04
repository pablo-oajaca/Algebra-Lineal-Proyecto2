using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra_Lineal_Proyecto2
{
    class Coordenada
    {
        string tipo; 
        int angulo;
        int x;
        int y;

        public int Angulo { get => angulo; set => angulo = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
