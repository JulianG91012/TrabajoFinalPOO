using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Evaluacion
    {
        private Estudiante alumno;
        private Asignatura materia;
        internal static float nota_final;

        //Constructor:
        public Evaluacion(Estudiante alumno, Asignatura materia, float nota)
        {
            Alumno = alumno;
            Materia = materia;
            Nota_final = nota;
        }

        //Accesores:
        public Estudiante Alumno { get => Alumno; 
            set
            {
                if (value == null)
                    throw new Exception("Por favor ingrese el nombre de un estudianta");
                else
                    alumno = value;
            } 
        }
        public Asignatura Materia { get => Materia;
            set
            {
                if (value == null)
                    throw new Exception("Por favor ingrese el nombre de alguna Asignatura");
                else
                    materia = value;
            } 
        }
        public float Nota_final { get => nota_final;
            set
            {
                if (value < 0 || value > 5)
                    throw new Exception("La nota no cumple con los requisitos");
                else
                    nota_final = value;
            } 
        }

    }
}
