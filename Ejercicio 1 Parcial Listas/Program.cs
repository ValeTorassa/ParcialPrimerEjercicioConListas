using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_Parcial_Listas
{
    internal class Program
    {
        static void Main()
        {
            //declaracion de la listas
            List<int> edades = new List<int>();
            List<int> comisiones = new List<int>();
            List<double> promedios = new List<double>();

            int comisionMax = 0;

            //conjunto de metodos
            IngresoAlumno(ref edades, ref comisiones, ref comisionMax);

            CalculoMejorPromedio(ref edades, ref comisiones,ref promedios, ref comisionMax);

            MostrarMejorPromedio(promedios);

            //pausa del programa
            Console.ReadKey();

        }


        //INICIO metodo ingresoAlumno
        static void IngresoAlumno(ref List<int> edades, ref List<int> comisiones, ref int comisionMax) {

            string finIngreso = "";
            int comisionum = 1;

            //DO-WHILE CAMBIO DE COMISIONES
            do
            {
                int num = 1;
                int edad;

                Console.WriteLine("Bienvenido a la comision " + comisionum);

                //DO-WHILE INGRESO DE ALUMNOS
                do
                {
                    
                    Console.WriteLine("Ingrese la edad del alumno de " + num);
                    edad = int.Parse(Console.ReadLine());

                    //si es cero no hago nada y paso a la siguiente comision
                    if (edad == 0)
                    {
                        //comprobacion para continuar
                        Console.WriteLine("¿Finalizar ingreso de comisiones?");
                        Console.WriteLine("Presione 0 para finalizar el ingreso");
                        Console.WriteLine("Presione cualquier tecla para continuar con la siguiente comision");
                        finIngreso = Console.ReadLine();


                    }
                    //si no lo es valido el ingreso
                    else
                    {
                        //VALIDACION INGRESO NUM
                        while (edad < 10 || edad > 20)
                        {
                            Console.WriteLine("Ingrese la edad del alumno de " + num);
                            edad = int.Parse(Console.ReadLine());
                        }

                        //agrego los datos a la lista
                        edades.Add(edad);
                        comisiones.Add(comisionum);

                    }

                    //sumo el numero de alumno
                    num++;

                } while (edad != 0);

                comisionum++;

                //almaceno la comisionmax para luego usarla en un for
                comisionMax = comisionum;

            } while (finIngreso != "0");

        }//FIN metodo ingresoAlumno


        //INICIO metodo calculo de promedio
        static void CalculoMejorPromedio(ref List<int> edades, ref List<int> comisiones, ref List<double> promedios, ref int comisionMax)
        {
                       
            //for para calculo de promedio
            for (int i = 1; i<comisionMax; i++)
            {
                double edadtotal = 0;
                double alumnos = 0;

                //recorro toda los datos ingresados
                for (int k = 0; k < edades.Count; k++)
                {                   

                    //si es igual a la comision que se esta reccoriendo lo uso para el promedio
                    if (comisiones[k] == i)
                    {
                        edadtotal = edadtotal + edades[k];
                        alumnos++;
                    }

                }

                double promedio = edadtotal / alumnos;

                //imprimo cada uno de los promedios
                Console.WriteLine("el promedio de la comision " + i + " es de " + promedio);

                //añado el promedio de cada una de las comisiones a una lista
                promedios.Add(promedio);

            }

        } //FIN metodo calculo de promedio


        //INICIO metodo mostrar mejor promedio
        static void MostrarMejorPromedio(List<double> promedios)
        {
            double mejorpromedio = 0;
            int mejorcomision = 0;
            int numComision = 1;
            
            //foreach que recorre todos los promedios guardados
            foreach (double promedio in promedios)
            {
                numComision++;

                //utilizo la busqueda secuencial para encontrar el mejor promedio
                if (mejorpromedio < promedio)
                {                   
                    mejorpromedio = promedio;
                    mejorcomision = numComision;
                }               
            }

            Console.WriteLine("El mejor promedio de edad fue de " + mejorpromedio + " por la comision " + mejorcomision);

        } //FIN metodo mostrar mejor promedio 

    } //FIN clase
}

/* PARCIAL
Ejercicio 1:
Determinar la comisión de primer año que tiene el mayor promedio de edad 
de sus integrantes y cuál es dicho promedio. 
Para ello se dispone de un listado con el número de comisión y la edad 
de cada estudiante.
El listado está ordenado por número de comisión.
Se desconoce la cantidad de estudiantes de cada comisión. 
Se deben ingresar por teclado los datos de cada estudiante.
El ingreso tanto de comisión como de edades por comisión, será con 0.
El programa a desarrollar usará un arreglo bidimensional.
Se crearán 3 funciones o métodos: 
IngresoAlumno(); // Se ingresarán los datos del listado.
CalculoMejorPromedio(); // se calcularán los promedios por curso
MostrarMejorPromedio(); // muestra el mejor promedio.
Utilice parámetro por valor y por referencia de manera que los métodos sean de 
tipo: static void
*/
