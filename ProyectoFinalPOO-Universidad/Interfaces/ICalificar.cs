using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOO_Universidad.Clases;

namespace ProyectoFinalPOO_Universidad.Interfaces
{
    interface ICalificar
    {
        Evaluacion Hacer_Y_Calificar_Evaluacion(Estudiante estudiante, Asignatura materia, float nota_final, uint año, uint semestre);
    }
}
