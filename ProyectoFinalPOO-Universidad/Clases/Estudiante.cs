using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOO_Universidad.Interfaces;

namespace ProyectoFinalPOO_Universidad.Clases
{
    //La Clase es una SuperClase de Pregrado y Posgrado, por lo que es abstracta:
    abstract class Estudiante : IHacerGrado, IHacerTesis, IConsultar
    {
        //Al ser Superclase, debemos declarar los atributos como Protegidos para que las subclases los puedan usar correctamente:
        private string nombre;
        protected string acudiente;
        protected uint id;
        private DateTime fecha_nac;

        //Protected - Public
        public Estudiante(string nombre, string acudiente, uint id, DateTime fecha_nac)
        {
            try
            {
                Nombre = nombre;
                Acudiente = acudiente;
                this.id = id;
                Fecha_nac = fecha_nac;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error en el constructor de Estudiante" + error);
            }
            
        }





        //Se crean los accesores para validar cada uno de los atributos.
        public string Nombre { get => nombre; 
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new Exception("Revisar el nombre del Estudiante");
                else
                    nombre = value.ToUpper();
            }
        }
        public string Acudiente { get => acudiente;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new Exception("Revisar el nombre del Acudiente");
                else
                    acudiente = value.ToUpper();
            }
        }
        public uint Id { get => id;}
        public DateTime Fecha_nac { get => fecha_nac;
            set
            {
                if (value.Year == DateTime.Now.Year || value.Year > DateTime.Now.Year - Universidad.edad_min_admision)
                    throw new Exception("La Fecha de nacimiento es incorrecta para los parámetros de la Universidad");
                else
                    fecha_nac = value;
            }

        }

        //Se Implementan las Interfaces:
        public virtual string HacerGrado(Pregrado.L_tipos_tbj_grado var_tbj_grado, string monitor)
        {
            return "";
        }

        public virtual string HacerTesis(string titulo_tesis, string director, string evaluador1, string evaluador2, DateTime fecha_sustentacion)
        {
            return "";
        }

        public virtual List<Evaluacion> Consultar_Evaluaciones(uint año, uint semestre)
        {
            try
            {
                List<Evaluacion> l_evaluaciones_est = new List<Evaluacion>();
                Universidad universidad = new Universidad();
                foreach (Historia_Academica elemento in universidad.L_historias_academicas)
                {
                    if (elemento.Año == año && elemento.Semestre == semestre)
                    {
                        foreach (Evaluacion elemento1 in elemento.L_evaluaciones)
                        {
                            if (elemento1.Alumno.Nombre == nombre)
                            {
                                l_evaluaciones_est.Add(elemento1);
                            }
                            else
                                throw new Exception("No se encontraron evaluaciones de este estudiante");
                        }
                    }
                    else
                        throw new Exception("No se encontró la historia académica");
                }
                return l_evaluaciones_est;
            }
            catch (Exception error)
            {
                throw new Exception("Hubo un error al intentar consultar las Evaluaciones" + error);
            }
        }
    }
}
