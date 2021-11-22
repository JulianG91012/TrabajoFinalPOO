using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Historia_Academica
    {
        private uint año;
        private uint semestre;
        internal List<Evaluacion> l_evaluaciones;

        //Constructor:
        public Historia_Academica(uint año, uint semestre, List<Evaluacion> l_evaluaciones)
        {
            Año = año;
            Semestre = semestre;
        }

        //Accesores:
        public uint Año { get => año; 
            set
            {
                if (value < Universidad.anho_fundacion || value > DateTime.Now.Year)
                    throw new Exception("El año del Historial Academico no cumple con los requisitos.");
                else
                    año = value;
            } 
        }
        internal List<Evaluacion> L_evaluaciones { get => l_evaluaciones; set => l_evaluaciones = value; }
        public uint Semestre { get => semestre;
            set
            {
                if (value > 10)
                    throw new Exception("El Semestre ingresado ha sobrepasado el máximo semestre que se tiene una carrera");
                else
                    semestre = value;

            } 
        }
    }
}
