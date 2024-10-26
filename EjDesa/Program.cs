using System;
using System.Collections.Generic;

namespace primerProyecto
{
    class Program
    {
        static void Main()
        {
        menu:
            Console.WriteLine("Hola Sir LionVRagnarsson");
            Console.WriteLine("Ingrese el número de clase del ejercicio a ejecutar: ");
            Console.WriteLine("Ejercicio 1: ingresar y mostrar números");
            Console.WriteLine("Ejercicio 2: calcular el área de un círculo");
            Console.WriteLine("Ejercicio 3: operaciones matemáticas básicas");
            Console.WriteLine("0. Salir");

            if (int.TryParse(Console.ReadLine(), out int caso))
            {
                switch (caso)
                {
                    case 1:
                        List<int> numeros = new List<int>();
                        string entrada;
                        Console.WriteLine("Ingresa los números: ");
                        Console.WriteLine("Introduce 'salir' para terminar y mostrar los números ingresados");
                        while (true)
                        {
                            entrada = Console.ReadLine();
                            if (entrada.ToLower() == "salir")
                            {
                                Console.Clear();
                                break;
                            }
                            if (int.TryParse(entrada, out int numero))
                            {
                                numeros.Add(numero);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ingresa un número válido");
                            }
                        }
                        Console.WriteLine("Números ingresados: ");
                        foreach (int num in numeros)
                        {
                            Console.WriteLine(num);
                        }
                        Console.ReadLine();
                        goto menu;

                    case 2:
                        Console.WriteLine("Ingrese el radio del círculo: ");
                        if (float.TryParse(Console.ReadLine(), out float radio))
                        {
                            float area = (float)Math.PI * (float)Math.Pow(radio, 2);
                            Console.Clear();
                            Console.WriteLine($"El área del círculo es: {area}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ingresa un número válido para el radio");
                        }
                        goto menu;

                    case 3:
                        Presentar();
                        Console.Write("Selecciona una opción: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Operacion(Suma);
                                goto menu;
                            case "2":
                                Operacion(Resta);
                                goto menu;
                            case "3":
                                Operacion(Multiplicacion);
                                goto menu;
                            case "4":
                                Operacion(Division);
                                goto menu;
                            case "5":
                                return;
                            default:
                                Console.WriteLine("Opción no válida");
                                goto menu;
                        }

                    case 0:
                        Console.WriteLine("Saliendo...");
                        return;

                    default:
                        Console.WriteLine("Número de clase no válido");
                        goto menu;
                }
            }
            else
            {
                Console.WriteLine("Ingresa un número válido para el caso.");
                goto menu;
            }
        }

        static void Presentar()
        {
          
            Console.ReadKey();
            Console.Clear ();
            Console.WriteLine("Selecciona la operación que desees realizar");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Salir");
        }

        static void Operacion(Func<int, int, float> operacion)
        {
            Console.Write("Ingresa el valor de a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el valor de b: ");
            int b = int.Parse(Console.ReadLine());
            float resultado = operacion(a, b);
            Console.WriteLine("El resultado es: " + resultado);
            Console.ReadKey();
            Console.Clear();
        }

        static float Suma(int a, int b)
        {
            return a + b;
        }

        static float Resta(int a, int b)
        {
            return a - b;
        }

        static float Multiplicacion(int a, int b)
        {
            return a * b;
        }

        static float Division(int a, int b)
        {
            if (b != 0)
            {
                return (float)a / b;
            }
            else
            {
                Console.WriteLine("No se puede dividir entre 0");
                return 0;
            }
        }
    }
}
