using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOO_Universidad.Clases;
using ProyectoFinalPOO_Universidad.Interfaces;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Docente: ICalificar
    {
        private string nombre;
        private uint id;
        private DateTime fecha_nac;
        private string salon_clase;
        private List<string> l_titulos;

        //Primero se declaran los atributos
        //Luego se crean los accesores con sus respectivos valores
        //Se crea el constructor con los accesores creados
        public Docente(string nombre, uint id, DateTime fecha_nac, string salon_clase, List<string> l_titulos)
        {
            Nombre = nombre;
            this.id = id;
            Fecha_nac = fecha_nac;
            Salon_clase = salon_clase;
            L_titulos = l_titulos;
        }



        //Accesores:
        public string Nombre { get => nombre; 
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new Exception("Error en el nombre del Docente");
                else
                    nombre = value.ToUpper();
            } 
        }
        public uint Id { get => id;}
        public DateTime Fecha_nac { get => fecha_nac;
            set
            {
                if (value.Year == DateTime.Now.Year)
                    throw new Exception("Error en la fecha de nacimiento del docente");
                else
                    fecha_nac = value;
            } 
                 
        }
        public string Salon_clase { get => salon_clase;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 4)
                    throw new Exception("Error en el número del salón de clase");
                else
                    salon_clase = value.ToUpper();
            }     
        }

        public List<string> L_titulos { get => l_titulos; set => l_titulos = value; }

        //Interfaces:
        public virtual Evaluacion Hacer_Y_Calificar_Evaluacion(Estudiante estudiante, Asignatura materia, float nota_final, uint año, uint semestre)
        {
            try
            {
                //Se crea la evaluacion y se califica
                Evaluacion evaluacion = new Evaluacion(estudiante, materia, nota_final);
                Universidad universidad = new Universidad("UPB", "Carrera 70");
                //Se Confirma que la asignatura sea dictada por el profesor
                foreach (Docente elemento in Asignatura.l_profesores)
                {
                    if (elemento.Nombre == nombre)
                    {
                        //Reporta la evaluacion a la historia
                        //Busca en la listas de historias academicas de la universidad
                        //Y añade la evalucion creada a la lista de evaluaciones de la historia academica en cuestion
                        foreach (Historia_Academica elemento1 in universidad.L_historias_academicas)
                        {
                            if (elemento1.Año == año && elemento1.Semestre == semestre)
                            {
                                elemento1.L_evaluaciones.Add(evaluacion);
                            }
                            else
                                throw new Exception("No se encontró la historia academica");
                        }
                    }
                    else
                        throw new Exception("El docente no dicta esta materia");
                }
                return evaluacion;
            }
            catch (Exception error)
            {
                throw new Exception("Hubo un error al Hacer y Calificar las Evaluaciones" + error);
            }
        }
    }
}
