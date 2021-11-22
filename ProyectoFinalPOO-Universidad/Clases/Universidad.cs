using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoFinalPOO_Universidad.Clases
{
    class Universidad
    {
        private string nombre;
        private string direccion;
        private List<Estudiante> l_estudiantes;
        private List<Docente> l_profesores;
        private List<Historia_Academica> l_historias_academicas;
        private List<Asignatura> l_asignaturas;
        //Ya con esto tenemos creados los atributos de la Universidad, vamos a agregar atributos que nos servirán para más adelante:
        public const byte edad_min_admision = 16;
        public const uint anho_fundacion = 1970;
        public const float nota_min_pasar = 3;
        public const float nota_max = 5;
        private uint contador_est_perdieron_evals = 0;
        private uint contador_est_ganaron_evals = 0;
        private string materia_mas_ganada = "";
        private string materia_mas_perdida = "";

        public Universidad(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Cargar_L_Asignaturas();
            Cargar_L_Docentes();
            Cargar_L_Estudiantes_Pre();
            Cargar_L_Estudiantes_Pos();
            Cargar_M_Estudiantes_Posgrado();
            Cargar_L_Historias_Academicas();
            
        }
        //public Universidad()
        //{

        //}

        public Universidad(string nombre, string direccion, List<Estudiante> l_estudiantes)
        {
            Nombre = nombre;
            Direccion = direccion;
            this.l_estudiantes = l_estudiantes;
        }

        public float Nota_Trabajo_Grado_Pregrado()
        {
            Random aleatorio = new Random();
            float nota_cuantitativa = aleatorio.Next(0, 5);
            return nota_cuantitativa;
        }
        public bool Nota_Trabajo_Grado_Posgrado()
        {
            Random aleatorio = new Random();
            bool nota_cualitativa;
            if ((byte)aleatorio.Next(1, 2) == 1)
                nota_cualitativa = true;
            else
                nota_cualitativa = false;
            return nota_cualitativa;
        }
        public string Reporte_Evaluaciones()
        {
            try
            {
                string mesaje = "...Estado de Notas...";
                uint cont_eva_ganadas_matematicas = 0;
                uint cont_eva_ganadas_cristologia = 0;
                uint cont_eva_ganadas_humanidades = 0;
                //Acceder a las evaluaciones que estan en las listas de historias academicas de la universidad
                //contar las evaluaciones ganadas o perdidas
                //revisar de que aignatura es la evaluacion
                foreach (Historia_Academica elemento in l_historias_academicas)
                {
                    foreach (Evaluacion elemento1 in elemento.L_evaluaciones)
                    {
                        if (elemento1.Nota_final >= nota_min_pasar || elemento1.Nota_final <= nota_max)
                            contador_est_ganaron_evals++;
                        else
                            contador_est_perdieron_evals++;

                        switch (elemento1.Materia.Nombre.ToUpper())
                        {
                            case "MATEMATICAS":
                                if (elemento1.Nota_final >= nota_min_pasar || elemento1.Nota_final <= nota_max)
                                    cont_eva_ganadas_matematicas++;
                                break;
                            case "CRISTOLOGIA":
                                if (elemento1.Nota_final >= nota_min_pasar || elemento1.Nota_final <= nota_max)
                                    cont_eva_ganadas_cristologia++;
                                break;
                            case "HUMANIDADES":
                                if (elemento1.Nota_final >= nota_min_pasar || elemento1.Nota_final <= nota_max)
                                    cont_eva_ganadas_humanidades++;
                                break;
                            default:
                                throw new Exception("La materia no fue encontrada.");
                        }
                    }
                }
                if (cont_eva_ganadas_matematicas > cont_eva_ganadas_cristologia && cont_eva_ganadas_matematicas > cont_eva_ganadas_humanidades)
                    materia_mas_ganada = "MATEMATICAS";
                else if (cont_eva_ganadas_cristologia > cont_eva_ganadas_matematicas && cont_eva_ganadas_cristologia > cont_eva_ganadas_humanidades)
                    materia_mas_ganada = "CRISTOLOGIA";
                else if (cont_eva_ganadas_humanidades > cont_eva_ganadas_matematicas && cont_eva_ganadas_humanidades > cont_eva_ganadas_cristologia)
                    materia_mas_ganada = "HUMANIDADES";
                else if (cont_eva_ganadas_matematicas < cont_eva_ganadas_cristologia && cont_eva_ganadas_matematicas < cont_eva_ganadas_humanidades)
                    materia_mas_perdida = "MATEMATICAS";
                else if (cont_eva_ganadas_cristologia < cont_eva_ganadas_matematicas && cont_eva_ganadas_cristologia < cont_eva_ganadas_humanidades)
                    materia_mas_perdida = "CRISTOLOGIA";
                else if (cont_eva_ganadas_humanidades < cont_eva_ganadas_matematicas && cont_eva_ganadas_humanidades < cont_eva_ganadas_cristologia)
                    materia_mas_perdida = "HUMANIDADES";

                mesaje = "Estudiantes que ganaron Evaluaciones: " + contador_est_ganaron_evals + "\nEstudiantes que perdieron Evaluaciones: " + contador_est_perdieron_evals;
                mesaje = "Asignatura estudiantes mas ganan los estudiantes: " + materia_mas_ganada + "\nAsignatura estudiantes mas pierden los estudiantes: " + materia_mas_perdida;
                return mesaje;
            }
            catch (Exception error)
            {
                throw new Exception("Error en el contardor de Evaluaciones  : " + error);
            }
        }
        public void Cargar_L_Docentes()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\ListaProfesores.txt");

                string[] v_docentes;
                List<string> l_titulos = new List<string>();
                Docente profesor;
                Random aleatorio = new Random();

                string linea;
                linea = archivo.ReadLine();

                while (linea != null)
                {
                    v_docentes = linea.Split('|');
                    if (v_docentes[0].ToUpper() == "T")
                    {
                        for (int i = 1; i < v_docentes.Length; i++)
                        {
                            l_titulos.Add(v_docentes[i]);
                        }
                    }
                    else if (v_docentes[0].ToUpper() == "D")
                    {
                        profesor = new Docente(v_docentes[1], (uint)aleatorio.Next(300000, 1000000), DateTime.Parse(v_docentes[2]), v_docentes[3], l_titulos);
                        l_profesores.Add(profesor);
                    }
                    else
                        throw new Exception("Hay un error en el archivo");
                    linea = archivo.ReadLine();
                }

            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error: " + error);
            }
        }
        public void Cargar_L_Estudiantes_Pre()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\ListaEstudiantesPre.txt");

                string[] v_estudiante_pre;
                string[] v_info_estudiante_pre = new string[3];
                Estudiante estudiante_pre;
                Random aleatorio = new Random();
                string linea;
                linea = archivo.ReadLine();

                while (linea != null)
                {
                    v_estudiante_pre = linea.Split('|');
                    if (v_estudiante_pre[0].ToUpper() == "I")
                    {
                        for (int i = 1; i < v_info_estudiante_pre.Length; i++)
                        {
                            v_info_estudiante_pre[i] = v_estudiante_pre[i];
                        }
                        /*
                        v_info_estudiante_pre[1] = v_estudiante_pre[1];
                        v_info_estudiante_pre[1] = v_estudiante_pre[2];
                        v_info_estudiante_pre[1] = v_estudiante_pre[3];
                        */
                    }
                    else if (v_estudiante_pre[0].ToUpper() == "PRE")
                    {
                        estudiante_pre = new Pregrado(v_estudiante_pre[1], (uint)aleatorio.Next(300000, 1000000), DateTime.Parse(v_estudiante_pre[2]), v_estudiante_pre[3], Pregrado.L_tipos_tbj_grado.Practicas, v_info_estudiante_pre);
                        l_estudiantes.Add(estudiante_pre);
                    }
                    else
                        throw new Exception("Hay un error en el archivo de EStudiantes Pregrado");
                    linea = archivo.ReadLine();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error al cargar Estudiantes de Pregrado:" + error);
            }
        }
        public void Cargar_L_Estudiantes_Pos()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\ListaEstudiantesPost.txt");
                string[] v_estudiantes_pos;
                string[,] m_info_estudiante_pos = Cargar_M_Estudiantes_Posgrado();
                Random aleatorio = new Random();
                Estudiante estudiante_pos;
                string linea;
                linea = archivo.ReadLine();

                while (linea != null)
                {
                    v_estudiantes_pos = linea.Split('|');
                    estudiante_pos = new Posgrado(v_estudiantes_pos[0], (uint)aleatorio.Next(300000, 999999), DateTime.Parse(v_estudiantes_pos[1]), v_estudiantes_pos[2], m_info_estudiante_pos, "Hacer Tesis");
                    l_estudiantes.Add(estudiante_pos);
                    linea = archivo.ReadLine();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error al cargar Estudiantes de Posgrado:" + error);
            }
        }
        public string[,] Cargar_M_Estudiantes_Posgrado()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\InfoMatrizEstudiantePos.txt");
                string[] v_matriz_pos;
                string[,] m_info_estudios_previos = new string[5, 3];
                string linea;
                linea = archivo.ReadLine();

                while (linea != null)
                {
                    v_matriz_pos = linea.Split('|');
                    m_info_estudios_previos = new string[5, 3]
                    {
                        { v_matriz_pos[0], v_matriz_pos[1], v_matriz_pos[2] },
                        { v_matriz_pos[3], v_matriz_pos[4], v_matriz_pos[5] },
                        { v_matriz_pos[6], v_matriz_pos[7], v_matriz_pos[8] },
                        { v_matriz_pos[9], v_matriz_pos[10], v_matriz_pos[11] },
                        { v_matriz_pos[12], v_matriz_pos[13], v_matriz_pos[14] },
                    };
                    linea = archivo.ReadLine();
                }
                return m_info_estudios_previos;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrió un error al cargar la matriz de estudios previos de los Estudiantes de Posgrado:" + error);
            }
        }

        public void Cargar_L_Historias_Academicas()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\ListaHistorialAcademico.txt");
                string[] v_historia_aca;
                Historia_Academica historia_academica;
                List<Evaluacion> l_evaluaciones = new List<Evaluacion>();
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    v_historia_aca = linea.Split('|');
                    if (v_historia_aca[0].ToUpper() == "INF")
                    {
                        historia_academica = new Historia_Academica(uint.Parse(v_historia_aca[1]), uint.Parse(v_historia_aca[2]), l_evaluaciones);
                        l_historias_academicas.Add(historia_academica);
                    }
                    else
                        throw new Exception("Hay un error en el archivo Lista Historial Academico.");
                    linea = archivo.ReadLine();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error al cargar la lista de historias academicas: " + error);
            }
        }
        public void Cargar_L_Asignaturas()
        {
            try
            {
                StreamReader archivo = new StreamReader("C:\\Users\\USUARIO\\Desktop\\UPB\\para subir a Git\\TrabajofinalPOO\\ListaAsignaturas.txt");
                string[] v_asignaturas;
                Asignatura asignatura;
                List<string> l_docentes = new List<string>();
                string linea = archivo.ReadLine();
                while (linea != null)
                {
                    v_asignaturas = linea.Split('|');
                    if (v_asignaturas[0].ToUpper() == "A")
                    {
                        asignatura = new Asignatura(v_asignaturas[1], uint.Parse(v_asignaturas[2]), l_profesores);
                        l_asignaturas.Add(asignatura);
                    }
                    else
                        throw new Exception("Hay un error en el archivo Asignatura");
                    linea = archivo.ReadLine();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error al cargar la lista de asignaturas: " + error);
            }
        }


        //Accesores:
        public string Nombre { get => nombre;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new Exception("Error en el nombre de la Universidad");
                else
                    nombre = value.ToUpper();
            } 
        }
        public string Direccion { get => direccion;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new Exception("Error en la direccion de la Universidad");
                else
                    direccion = value.ToUpper();
            }
        }
        internal List<Estudiante> L_estudiantes { get => l_estudiantes; set => l_estudiantes = value; }
        internal List<Docente> L_docentes { get => l_profesores; set => l_profesores = value; }
        internal List<Historia_Academica> L_historias_academicas { get => l_historias_academicas; set => l_historias_academicas = value; }
        internal List<Asignatura> L_asignaturas { get => l_asignaturas; set => l_asignaturas = value; }
        public uint Contador_est_perdieron_evals { get => contador_est_perdieron_evals; set => contador_est_perdieron_evals = value; }
        public uint Contador_est_ganaron_evals { get => contador_est_ganaron_evals; set => contador_est_ganaron_evals = value; }
        public string Materia_mas_ganada { get => materia_mas_ganada; set => materia_mas_ganada = value; }
        public string Materia_mas_perdida { get => materia_mas_perdida; set => materia_mas_perdida = value; }
    }
}
