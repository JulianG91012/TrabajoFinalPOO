using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Posgrado: Estudiante
    {
        private string[,] v_estudios_previos = new string[3, 5];
        public const byte m_info_filas = 5;
        public const byte m_info_columnas = 3;
        private string trabajoGrado;

        //Constructor:
        public Posgrado(string nombre, uint id, DateTime fecha_nac, string acudiente,  string[,] v_estudios_previos, string trabajo_grado) 
            : base(nombre, acudiente, id, fecha_nac)
        {
            V_estudios_previos = v_estudios_previos;
            TrabajoGrado = trabajo_grado;
        }

        public override string HacerTesis(string titulo_tesis, string director, string evaluador1, string evaluador2, DateTime fecha_sustentacion)
        {
            try
            {
                Universidad universidad = new Universidad();
                bool nota_cualitativa = universidad.Nota_Trabajo_Grado_Posgrado();
                string mensaje = "...Resultado de Tesis...\n";
                mensaje = titulo_tesis + "|" + director + "|" + evaluador1 + "|" + evaluador2 + "|" + nota_cualitativa + "|" + fecha_sustentacion;
                return mensaje;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error al hacer la tesis" + error);
            }
            
        }


        //Accesor:
        protected string[,] V_estudios_previos { get => v_estudios_previos; set => v_estudios_previos = value; }
        public string TrabajoGrado { get => trabajoGrado; 
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new Exception("Error en el tipo de trabajo de grado especificado");
                else
                    trabajoGrado = value.ToUpper();
            } 
        }
    }
}
