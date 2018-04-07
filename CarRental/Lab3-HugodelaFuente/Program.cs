using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static public string MuestraSucursales(List<Sucursal> sucursales)
        {
            Console.WriteLine("Sucursales Disponibles");
            Console.WriteLine("------------------------");
            foreach (Sucursal sucursal in sucursales)
            {
                Console.WriteLine(sucursal.getInfo());
            }
            Console.WriteLine("------------------------");
            return " ";
        }
        static public string MuestraClientes(List<Cliente> clientes)
        {
            Console.WriteLine("Clientes Registrados");
            Console.WriteLine("------------------------");
            foreach (Cliente persona in clientes)
            {
                Console.WriteLine(persona.getInfo());
            }
            Console.WriteLine("------------------------");
            return " ";
        }
        static void Main(string[] args)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            List<Cliente> clientes = new List<Cliente>();
            Console.WriteLine("Bienvenido a RentCar!");
            while (true)
            {
                if (sucursales.Count==0)
                {
                    Console.WriteLine("Debe agregar una surcursal primero");
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
                Menu:
                // <menu>
                Console.WriteLine("1.Crear Sucursal");
                Console.WriteLine("2.Relizar un Arriendo");
                Console.WriteLine("3.Agregar un cliente");
                Console.WriteLine("4.Agregar Vehiculo al inventario");
                Console.WriteLine("5.Devolver Vehiculo");
                Console.WriteLine("6.Salir");
                Console.WriteLine("-------------------------");
                Console.Write("Opcion: ");
                String des = Console.ReadLine();
                // </menu>

                if (des=="1")
                {
                    Console.Write("Nombre: ");
                    String nombre = Console.ReadLine();
                    nombre.ToLower();
                    Console.Write("Rut : ");
                    String rut = Console.ReadLine();
                    Console.Write("Ubicacion: ");
                    String ubi = Console.ReadLine();
                    Sucursal sucursal = new Sucursal(rut, nombre, ubi);
                    foreach (Sucursal sucursal1 in sucursales)
                    {
                        if (sucursal1.getRut() == rut)
                        {
                            sucursales.Add(sucursal1);
                            goto Menu;
                        }
                    }
                    Console.WriteLine("Sucursal ya existente...");
                }
                else if (des=="3")
                {
                    Console.Write("Nombre: ");
                    String nombre = Console.ReadLine();
                    nombre.ToLower();
                    Console.Write("Apellido: ");
                    String apellido = Console.ReadLine();
                    apellido.ToLower();
                    Console.Write("Rut: ");
                    String rut = Console.ReadLine();
                    Console.Write("Empresa o Persona: ");
                    String input1 = Console.ReadLine();
                    input1.ToLower();
                    Cliente cliente = new Cliente(rut, nombre, input1,apellido);
                    foreach (Cliente persona in clientes)
                    {
                        if (persona.getRut() == cliente.getRut())
                        {
                            Console.WriteLine("Cliente ya existe...");
                            goto Menu;
                        }
                    }
                    clientes.Add(cliente);
                    
                }
                else if (des=="6")
                {
                    break;
                }
                else if (des=="4")
                {
                    Console.Write("Marca: ");
                    String marca = Console.ReadLine();
                    marca.ToLower();
                    Console.Write("Modelo: ");
                    String Modelo = Console.ReadLine();
                    Modelo.ToLower();
                    Console.Write("Motor: ");
                    String motor = Console.ReadLine();
                    motor.ToLower();
                    Console.Write("Tipo de vehiculo: ");
                    String tipo = Console.ReadLine();
                    tipo.ToLower();
                    Console.WriteLine("Cuantas?");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    Vehiculo maquina = new Vehiculo(marca, Modelo, tipo, motor, cantidad);
                    MuestraSucursales(sucursales);
                    Console.Write("Rut de la sucursal: ");
                    String rut_s = Console.ReadLine();
                    foreach (Sucursal sucursal in sucursales)
                    {
                        if (sucursal.getRut() == rut_s)
                        {
                            sucursal.agregaVehiculo(maquina);
                            Console.WriteLine("Vehiculo agregado a sucursal: " + sucursal.getName() + " rut: " + rut_s);
                            goto Menu;
                        }
                    }
                    Console.WriteLine("Sucursal no encontrada...");


                }
                else if (des=="2")
                {
                    Console.WriteLine("¿Incluir Accesorios?");
                    String des2 = Console.ReadLine();
                    des2.ToLower();
                    if (des2 == "si")
                    {
                        Console.WriteLine("Tipo de vehiculo (Auto, Moto, Acuatico, Maquinaria Pesada): ");
                        String algo = Console.ReadLine();
                        algo.ToLower();
                        List<string> acc = new List<string>();
                        while (true)
                        {
                            Console.WriteLine("Cual?");
                            string accesorio = Console.ReadLine();
                            accesorio.ToLower();
                            acc.Add(accesorio);
                            Console.WriteLine("Otro? (si/no)");
                            string des123 = Console.ReadLine();
                            if (des123=="si")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        MuestraClientes(clientes);
                        Console.WriteLine("Rut del cliente: ");
                        String rut = Console.ReadLine();
                        MuestraSucursales(sucursales);
                        Console.WriteLine("Rut de la sucursal: ");
                        String rut2 = Console.ReadLine();
                        foreach (Cliente persona in clientes)
                        {
                            if (persona.getRut() == rut)
                            {
                                foreach (Sucursal lugar in sucursales)
                                {
                                    if (rut2 == lugar.getRut())
                                    {
                                        foreach (Vehiculo maquina in lugar.getVehiculos())
                                        {
                                            if (maquina.getTipo() == algo && maquina.getCantidad() > 0)
                                            {
                                                lugar.arrienda(persona, maquina);
                                                maquina.setAcc(acc);
                                                Console.WriteLine("Arriendo realizado");
                                                goto Menu;
                                            }
                                        }
                                        Console.WriteLine("Vehiculo no disponible en sucursal...");
                                        goto Menu;

                                    }
                                }
                                Console.WriteLine("Sucursal no encontrada...");
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Cliente no encontrado...");

                    }
                    else if (des2=="no")
                    {
                        Console.WriteLine("Tipo de vehiculo (Auto, Moto, Acuatico, Maquinaria Pesada): ");
                        String algo = Console.ReadLine();
                        algo.ToLower();
                        MuestraClientes(clientes);
                        Console.WriteLine("Rut del cliente: ");
                        String rut = Console.ReadLine();
                        MuestraSucursales(sucursales);
                        Console.WriteLine("Rut de la sucursal: ");
                        String rut2 = Console.ReadLine();
                        foreach (Cliente persona in clientes)
                        {
                            if (persona.getRut()==rut)
                            {
                                foreach (Sucursal lugar in sucursales)
                                {
                                    if (rut2==lugar.getRut())
                                    {
                                        foreach (Vehiculo maquina in lugar.getVehiculos())
                                        {
                                            if (maquina.getTipo()==algo && maquina.getCantidad() > 0)
                                            {
                                                lugar.arrienda(persona, maquina);
                                                Console.WriteLine("Arriendo realizado");
                                                goto Menu;
                                            }
                                        }
                                        Console.WriteLine("Vehiculo no disponible en sucursal...");
                                        goto Menu;

                                    }
                                }
                                Console.WriteLine("Sucursal no encontrada...");
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Cliente no encontrado...");

                    }

                }
                else if (des=="5")
                {
                    Console.WriteLine("Tipo de vehiculo (Auto, Moto, Acuatico, Maquinaria Pesada): ");
                    String algo = Console.ReadLine();
                    algo.ToLower();
                    MuestraClientes(clientes);
                    Console.WriteLine("Rut del cliente: ");
                    String rut = Console.ReadLine();
                    MuestraSucursales(sucursales);
                    Console.WriteLine("Rut de la sucursal: ");
                    String rut2 = Console.ReadLine();
                    foreach (Cliente persona in clientes)
                    {
                        if (persona.getRut() == rut)
                        {
                            foreach (Sucursal lugar in sucursales)
                            {
                                if (rut2 == lugar.getRut())
                                {
                                    foreach (Vehiculo maquina in persona.getVehiculos())
                                    {
                                        if (maquina.getTipo() == algo)
                                        {
                                            lugar.devuelve(persona, maquina);
                                            maquina.resetAcc();
                                            Console.WriteLine("Devolucion realizada");
                                            goto Menu;
                                        }
                                    }
                                    Console.WriteLine("Cliente no posee vehiculo especificado...");
                                    goto Menu;

                                }
                            }
                            Console.WriteLine("Sucursal no encontrada...");
                            goto Menu;
                        }
                    }
                    Console.WriteLine("Cliente no encontrado...");
                    goto Menu;
                }

            }
        }
    }
}
