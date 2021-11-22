using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Interfaces
{
    interface IHacerTesis
    {
        public abstract string HacerTesis(string titulo_tesis, string director, string evaluador1, string evaluador2, DateTime fecha_sustentacion);
    }
}
