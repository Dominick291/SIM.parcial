using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM.parcial
{
    class Temperatura
    {
        int codigo;
        decimal temperaturas;
        DateTime fecha;

        public int Codigo { get => codigo; set => codigo = value; }
        public decimal Temperaturas { get => temperaturas; set => temperaturas = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
