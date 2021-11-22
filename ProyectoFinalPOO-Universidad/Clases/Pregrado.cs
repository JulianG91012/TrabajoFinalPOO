using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Pregrado : Estudiante
    {
        public enum L_tipos_tbj_grado { Practicas, Pasantía_Investigativa, Plan_Negocios};
        private string[] v_informacion = new string[3];

        //Constructo Superclase + Subclase:
        public Pregrado(string nombre, uint id, DateTime fecha_nac, string acudiente, L_tipos_tbj_grado var_tipos_tbj_grado, string[] v_informacion) 
            : base(nombre, acudiente, id, fecha_nac)
        {
            this.v_informacion = v_informacion;
        }

        //Implementacion de Interfaz desde Superclase:
        public override string HacerGrado(L_tipos_tbj_grado var_tbj_grado, string monitor)
        {
            try
            {
                Universidad universidad = new Universidad("UPB", "Carrera 70");
                float nota_cuantativa = universidad.Nota_Trabajo_Grado_Pregrado();
                string mensaje = "...Resultados de Trabajo de Grado...\n";
                mensaje = var_tbj_grado + "|" + monitor + "|" + nota_cuantativa;

                return mensaje;
            }
            catch (Exception error)
            {
                throw new Exception("Error al mostrar los resultados del trabajo de grado: " + error);
            }
        }

        //Accesores:
        public string[] V_informacion { get => v_informacion; set => v_informacion = value; }

    }
}
