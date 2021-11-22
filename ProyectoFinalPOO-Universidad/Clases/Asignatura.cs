using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Asignatura
    {
        private string nombre;
        private uint semestre; 
        internal static List<Docente> l_profesores;

        public Asignatura(string nombre, uint semestre, List<Docente> l_profesores)
        {
            Nombre = nombre;
            Semestre = semestre;
            L_profesores = l_profesores;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public uint Semestre
        {
            get => semestre;
            set
            {
                if (value > 10)
                    throw new Exception("El Semestre ingresado ha sobrepasado el máximo semestre en el que se puede registrar un curso");
                else
                    semestre = value;
            }
        }
        public List<Docente> L_profesores { get => l_profesores; set => l_profesores = value; }
    }
}
