using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Administrador admin = new Administrador();


            int bucleGeneral = -1;

            while (bucleGeneral != 0)
            {
                Console.Clear();
                MostrarMenu();
                try
                {
                    int respuesta = int.Parse(Console.ReadLine());
                    switch (respuesta)
                    {
                        case 1: // INGRESAR CANAL, TOMAMOS LOS DATOS PARA IMPLEMENTAR LA FUNCION INGRESARCANALADMIN
                            Console.Clear();
                            Console.WriteLine("Ingrese nombre del Canal");
                            string nombreCanal = Console.ReadLine();
                            Console.WriteLine("Ingrese la resolución");
                            Console.WriteLine("1- HD");
                            Console.WriteLine("2- SD");


                            int resolucionCanal = int.Parse(Console.ReadLine());


                            Console.WriteLine("Es multilenguaje?");
                            Console.WriteLine("1- SI");
                            Console.WriteLine("2- NO");

                            int multilenguaje = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el precio del canal");
                            double precioCanal = double.Parse(Console.ReadLine());

                            Console.WriteLine("El ingreso del canal fue: " + admin.IngresarCanalAdmin(nombreCanal, resolucionCanal, multilenguaje, precioCanal));

                            Console.ReadKey();
                            break;
                        case 2: // VER LISTA DE PAQUETES
                            Console.Clear();
                            foreach (Paquete p in admin.GetListaPaquetes())
                            {
                                Console.WriteLine("PAQUETE CON ID " + p.Id + ": ");
                                Console.WriteLine(p + " Dispone de " + p.GetListaCanalesPaquete().Count + " Canales");
                                Console.WriteLine("  CANALES: ");
                                foreach (Canal c in p.GetListaCanalesPaquete())
                                {
                                    Console.WriteLine(c);
                                }
                            }
                            Console.ReadKey();
                            break;
                        case 3: // MODIFICAR COSTO FIJO
                            Console.Clear();
                            Console.WriteLine("El costo fijo actual es de $" + HD.costoFijo);
                            Console.WriteLine("Ingrese nuevo costo fijo");
                            double nuevoCF = double.Parse(Console.ReadLine());

                            admin.CambiarCostoFijo(nuevoCF);
                            Console.WriteLine("El nuevo costo fijo es: " + HD.costoFijo);
                            Console.ReadKey();
                            break;
                        case 4: // PAQUETES CON MAS CANALES
                            Console.Clear();
                            foreach (Paquete p in admin.GetPaquetesConMasCanales())
                            {
                                Console.WriteLine(p + " || La cantidad de canales es: " + p.GetListaCanalesPaquete().Count);
                            }
                            Console.ReadKey();
                            break;

                        case 5: // FILTRAR POR PRECIO FIJO INGRESADO POR USUARIO


                            int bucle = -1;
                            while (bucle != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese el valor para mostrar los paquetes que superen ese monto");
                                double precioFijo = double.Parse(Console.ReadLine());

                                if (precioFijo > 0)
                                {
                                    foreach (Paquete p in admin.FiltrarPaquetePorPrecio(precioFijo))
                                    {
                                        Console.WriteLine(p);
                                    }
                                    bucle = 0; 
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese un valor mayor a 0");
                                    Console.ReadKey();
                                }
                            }
                            Console.ReadKey();
                            break;

                        //SALIR
                        case 0:
                            bucleGeneral = 0;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese un número válido");
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("***SERVICIO TVisión URUGUAY***");
            Console.WriteLine("1- Ingresar un CANAL de TV");
            Console.WriteLine("2- Visualizar TODOS los paquetes");
            Console.WriteLine("3- Modificar costo fijo de GRABACION EN NUBE");
            Console.WriteLine("4- Mostrar paquetes con MAS canales");
            Console.WriteLine("5- Listar paquetes cuyo precio supere un valor dado");
            Console.WriteLine("0- SALIR");
        }
    }
}
