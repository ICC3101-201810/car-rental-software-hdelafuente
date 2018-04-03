using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            List<Cliente> clientes = new List<Cliente>();
            while (true)
            {
                Console.WriteLine("1.Crear Sucursal");
                Console.WriteLine("2.Relizar un Arriendo");
                Console.WriteLine("3.Agregar un cliente");
                Console.WriteLine("4.Agregar Vehiculo");
                Console.WriteLine("5.Salir");
                Console.WriteLine("-------------------------");
                Console.Write("Opcion: ");
                String des = Console.ReadLine();
                if (des=="1")
                {
                    Console.Write("Nombre: ");
                    String nombre = Console.ReadLine();
                    nombre.ToLower();
                    Console.Write("rut (sin puntos): ");
                    String rut = Console.ReadLine();
                    Console.Write("Ubicacion: ");
                    String ubi = Console.ReadLine();
                    Sucursal sucursal = new Sucursal(rut, nombre, ubi);
                    sucursales.Add(sucursal);
                }
                else if (des=="3")
                {
                    Console.Write("Nombre: ");
                    String nombre = Console.ReadLine();
                    nombre.ToLower();
                    Console.Write("Apellido: ");
                    String apellido = Console.ReadLine();
                    apellido.ToLower();
                    Console.Write("rut(sin puntos): ");
                    String rut = Console.ReadLine();
                    Console.Write("Empresa o Persona: ");
                    String input1 = Console.ReadLine();
                    input1.ToLower();
                    Cliente cliente = new Cliente(rut, nombre, input1,apellido);
                    clientes.Add(cliente);
                    
                }
                else if (des=="5")
                {
                    break;
                }
                else if (des=="2")
                {
                    Console.WriteLine("¿Incluir Accesorios?");
                    String des2 = Console.ReadLine();
                    des2.ToLower();
                    if (des2 == "si")
                    {

                    }
                    else if (des2=="no")
                    {
                        Console.WriteLine("Tipo de vehiculo (Auto, Moto, Acuatico, Maquinaria Pesada): ");
                        String algo = Console.ReadLine();
                        algo.ToLower();
                        Console.WriteLine("rut del cliente (sin puntos y con guion): ");
                        String rut = Console.ReadLine();
                        Console.WriteLine("rut de la sucursal (sin puntos y con guion): ");
                        String rut2 = Console.ReadLine();
                        foreach (Cliente cosa in clientes)
                        {
                            if (cosa.getRut()==rut)
                            {
                                foreach (Sucursal item in sucursales)
                                {
                                    if (rut2==item.getRut())
                                    {
                                        foreach (Vehiculo maquina in item.getVehiculos())
                                        {
                                            if (maquina.getTipo()==algo)
                                            {
                                                item.arrienda(cosa, maquina);
                                                Console.WriteLine("Arriendo realizado");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                    }

                }

            }
        }
    }
}
