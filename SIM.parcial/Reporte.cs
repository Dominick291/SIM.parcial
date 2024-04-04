using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM.parcial
{
    class Reporte
    {
        string nombreDep;
        int codigo;
        DateTime fecha;
        decimal temperatura;

        public string NombreDep { get => nombreDep; set => nombreDep = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Temperatura { get => temperatura; set => temperatura = value; }
    }
}
