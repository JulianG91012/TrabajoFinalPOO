using System;
using ProyectoFinalPOO_Universidad.Clases;
using System.IO;

namespace ProyectoFinalPOO_Universidad
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Universidad UPB = new Universidad("Julian", "Cra70");
                Console.WriteLine("Bienvenidos a la Universidad Potificia Bolivariana");
                Console.WriteLine("Presione la tecla ENTER para continuar");
                Console.WriteLine("Si desea salir del programa, presione: CTRL + C");

                //Variable de control del ciclo
                bool continuar = true;

                while (continuar)
                {
                    //Respuestas del usuario
                    string respuesta = Console.ReadLine();

                    Console.WriteLine("Ingrese su tipo de usuario: Pregrado o Posgrado");
                    respuesta = Console.ReadLine();

                    if (respuesta.ToUpper().Equals("PREGRADO"))
                    {
                        //variables de ingreso por el usuario
                        Console.WriteLine("Ingrese el tipo de trabajo que hizo: \n1. Practica \n2. Pasantia Investigativa \n3. Plan de negocios");
                        string seleccion;
                        //seleccion = Console.ReadLine();

                        switch (seleccion = Console.ReadLine())
                        {
                            case "1":
                                try
                                {
                                    string linea;
                                    string[] arreglo_split;
                                    string[] v_informacion = new string[3];
                                    String resp_nombre;
                                    String resp_datetime;
                                    String resp_acudiente;
                                    Console.WriteLine("Ingrese su nombre: ");
                                    resp_nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese su fecha de Nacimiento en formato DD/MM/AAAA: ");
                                    resp_datetime = Console.ReadLine();
                                    Console.WriteLine("Ingrese el nombre de su acudiente: ");
                                    resp_acudiente = Console.ReadLine();
                                    Pregrado pre1 = new Pregrado(resp_nombre, 123455, DateTime.Parse(resp_datetime), resp_acudiente, Pregrado.L_tipos_tbj_grado.Practicas, v_informacion);
                                    linea = pre1.HacerGrado(Pregrado.L_tipos_tbj_grado.Practicas, "Cesar");
                                    arreglo_split = linea.Split('|');

                                    Console.WriteLine("Tipo de trabajo: " + arreglo_split[0] + "\nMonitor: " + arreglo_split[1] + "\nNota: " + arreglo_split[2]);
                                }
                                catch (Exception error)
                                {
                                    throw new Exception("Ocurrió un error al seleccionar la opción de Practica" + error);
                                }
                                break;
                            case "2":
                                try
                                {
                                    String linea2;
                                    String[] arregloSplit;
                                    String[] v_informacion = new string[3];
                                    String resp_nombre;
                                    String resp_datetime;
                                    String resp_acudiente;
                                    Console.WriteLine("Ingrese su nombre: ");
                                    resp_nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese su fecha de Nacimiento en formato DD/MM/AAAA: ");
                                    resp_datetime = Console.ReadLine();
                                    Console.WriteLine("Ingrese el nombre de su acudiente: ");
                                    resp_acudiente = Console.ReadLine();
                                    Pregrado pre2 = new Pregrado(resp_nombre, 123456, DateTime.Parse(resp_datetime), resp_acudiente, Pregrado.L_tipos_tbj_grado.Pasantía_Investigativa, v_informacion);
                                    linea2 = pre2.HacerGrado(Pregrado.L_tipos_tbj_grado.Pasantía_Investigativa, "Juan");
                                    arregloSplit = linea2.Split('|');

                                    Console.WriteLine("Tipo de trabajo: " + arregloSplit[0] + "\nMonitor: " + arregloSplit[1] + "\nNota: " + arregloSplit[2]);
                                }
                                catch (Exception error)
                                {
                                    throw new Exception("Ocurrió un error al seleccionar la opción de Pasantía Investigativa" + error);
                                }
                                break;
                            case "3":
                                try
                                {
                                    String linea;
                                    String[] arregloSplit;
                                    String[] v_informacion = new string[3];
                                    String resp_nombre;
                                    String resp_datetime;
                                    String resp_acudiente;
                                    Console.WriteLine("Ingrese su nombre: ");
                                    resp_nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese su fecha de Nacimiento en formato DD/MM/AAAA: ");
                                    resp_datetime = Console.ReadLine();
                                    Console.WriteLine("Ingrese el nombre de su acudiente: ");
                                    resp_acudiente = Console.ReadLine();
                                    Pregrado pre3 = new Pregrado(resp_nombre, 123457, DateTime.Parse(resp_datetime), resp_acudiente, Pregrado.L_tipos_tbj_grado.Plan_Negocios, v_informacion);
                                    linea = pre3.HacerGrado(Pregrado.L_tipos_tbj_grado.Plan_Negocios, "Juan");
                                    arregloSplit = linea.Split('|');

                                    Console.WriteLine("Tipo de trabajo: " + arregloSplit[0] + "\nMonitor: " + arregloSplit[1] + "\nNota: " + arregloSplit[2]);
                                }
                                catch (Exception error)
                                {
                                    throw new Exception("Ocurrió un error al seleccionar la opción de Plan de Negocios" + error);
                                }
                                break;

                            default:
                                Console.WriteLine("Ingrese una opción válida");
                                break;
                        }
                        }
                        /*
                           if (seleccion == "1")
                           {
                               string linea;
                               string[] arreglo_split;
                               string[] v_informacion = new string[3];

                               Pregrado pre1 = new Pregrado("Julian", 123455, DateTime.Parse("05/05/2003"), "Eliana", Pregrado.L_tipos_tbj_grado.Plan_Negocios, v_informacion);
                               linea = pre1.HacerGrado(Pregrado.L_tipos_tbj_grado.Pasantía_Investigativa, "Cesar");
                               arreglo_split = linea.Split('|');

                               Console.WriteLine("Tipo de trabajo: " + arreglo_split[0] + "\nMonitor: " + arreglo_split[1] + "\nNota: " + arreglo_split[2]);
                           }


                       else if (seleccion == "2")
                       {
                           String linea2;
                           String[] arregloSplit;
                           String[] v_informacion = new string[3];
                           Pregrado pre2 = new Pregrado("Styven", 123456, DateTime.Parse("10/10/2000"), "Maria", Pregrado.L_tipos_tbj_grado.Plan_Negocios, v_informacion);
                           linea2 = pre2.HacerGrado(Pregrado.L_tipos_tbj_grado.Pasantía_Investigativa, "Juan");
                           arregloSplit = linea2.Split('|');

                           Console.WriteLine("Tipo de trabajo: " + arregloSplit[0] + "\nMonitor: " + arregloSplit[1] + "\nNota: " + arregloSplit[2]);
                       }

                       else if (seleccion == "3")
                       {
                           String linea;
                           String[] arregloSplit;
                           String[] v_informacion = new string[3];
                           Pregrado pre3 = new Pregrado("Sebastian", 123457, DateTime.Parse("7/01/1999"), "Juan", Pregrado.L_tipos_tbj_grado.Practicas, v_informacion);
                           linea = pre3.HacerGrado(Pregrado.L_tipos_tbj_grado.Plan_Negocios, "Juan");
                           arregloSplit = linea.Split('|');

                           Console.WriteLine("Tipo de trabajo: " + arregloSplit[0] + "\nMonitor: " + arregloSplit[1] + "\nNota: " + arregloSplit[2]);

                       }
                       else
                       {
                           throw new Exception("Ingresó un tipo de trabajo no válido");
                       }
                   }
                        */

                       else if (respuesta.ToUpper().Equals("POSGRADO"))
                        {
                            String linea;
                            String[] arregloSplit;
                            String resp_nombre;
                            String resp_fecha_sust;
                            Console.WriteLine("Ingrese el Titulo de la tesis: ");
                            String resp1 = Console.ReadLine();
                            Console.WriteLine("Ingrese su nombre: ");
                            resp_nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese la fecha en la que va a sustentar en formato DD/MM/AA");
                            resp_fecha_sust = Console.ReadLine();
                            string[,] v_estudios_previos = new string[5, 3];
                            Posgrado pos1;
                            pos1 = new Posgrado(resp_nombre, 555556, DateTime.Parse("19/05/1986"), "Olman", v_estudios_previos, "Tesis");
                            linea = pos1.HacerTesis(resp1, "Cesar", "Leonardo", "Ferney", DateTime.Parse(resp_fecha_sust));
                            arregloSplit = linea.Split('|');

                            Console.WriteLine("Titulo de Tesis: " + arregloSplit[0] + "\nDirector: " + arregloSplit[1] + "\nEvaluador 1: " + arregloSplit[2] + "\nEvaluador 2: " + arregloSplit[3] + "\nFecha Sustentacion" + arregloSplit[4]);
                        }
                        else
                        {
                            Console.WriteLine("Debes escoger una de las opciones");
                        }
                    }
                }
            
                        /*for (uint i)
                          string mensaje = "";
                          foreach (Pregrado elemento in UPB.L_estudiantes)
                          {
                              elemento.ToString();
                          }
                          Console.WriteLine(mensaje);

                          foreach (Posgrado elemento in UPB.L_estudiantes)
                          {
                              mensaje = "\n" + elemento.Nombre + "|" + elemento.Id + "|" + elemento.Fecha_nac + "|" + elemento.Acudiente;
                              for (uint i = 0; i < Posgrado.m_info_filas; i++)
                              {
                                  for (uint j = 0; j < Posgrado.m_info_columnas; j++)
                                  {
                                      mensaje = elemento.Estudios_prev[i, j];
                                  }
                                  mensaje = "\n";
                              }
                          }
                          Console.WriteLine(mensaje);
                    }
                }
            }*/
            catch (Exception error)
            {
                Console.WriteLine("Ha ocurrido un error al ejecutar el programa" + error);
            }
            finally
            {
                Console.WriteLine("\nFin de la ejecucion");
                Console.ReadKey();
            }
        }
    }
}
