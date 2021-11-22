using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOO_Universidad.Clases;

namespace ProyectoFinalPOO_Universidad.Interfaces
{
    interface IConsultar
    {
        List<Evaluacion> Consultar_Evaluaciones(uint año, uint semestre);
        
    }
}
