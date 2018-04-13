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
            Console.WriteLine("------------------------\n");
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
            Console.WriteLine("------------------------\n");
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
                    Console.Write("Patente: ");
                    String patente = Console.ReadLine();
                    Console.Write("Tipo de vehiculo" +
                        "\n 1.Auto" +
                        "\n 2.Camioneta" +
                        "\n 3.Moto" +
                        "\n4.Camion" +
                        "\n5.Bus " +
                        "\n6.Maquinaria Pesada" +
                        "\n7.Acuatico" +
                        "\n Numero: ");
                    int tipo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Cuantas?");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    Vehiculo maquina = new Vehiculo(marca, Modelo, patente, cantidad);
                    maquina.SetTipo(tipo);
                    MuestraSucursales(sucursales);
                    Console.Write("Rut de la sucursal: ");
                    String rut_s = Console.ReadLine();
                    foreach (Sucursal sucursal in sucursales)
                    {
                        if (sucursal.getRut() == rut_s)
                        {
                            sucursal.agregaVehiculo(maquina);
                            Console.WriteLine("\n-------------------------------------------------------------------");
                            Console.WriteLine("Vehiculo agregado a sucursal: " + sucursal.getName() + " rut: " + rut_s);
                            Console.WriteLine("-------------------------------------------------------------------\n");
                            goto Menu;
                        }
                    }
                    Console.WriteLine("Sucursal no encontrada...\n");


                }
                else if (des=="2")
                {
                    Console.WriteLine("¿Incluir Accesorios?");
                    String des2 = Console.ReadLine();
                    des2.ToLower();
                    if (des2 == "si")
                    {
                        Console.WriteLine("Tipo de vehiculo\n1.Auto\n2.Camioneta\n3.Moto\n4.Camion\n5.Bus\n6.Maquinaria Pesada\n7.Acuatico\nNumero: ");
                        int algo =Convert.ToInt32(Console.ReadLine());
                        List<Accesorios> acc = new List<Accesorios>();
                        while (true)
                        {
                            Console.WriteLine("Cual?");
                            string nombre = Console.ReadLine();
                            Accesorios accesorio = new Accesorios(nombre, 300);
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
                        Console.Write("\nCantidad de dias: ");
                        int dias = Convert.ToInt32(Console.ReadLine());
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
                                            if (maquina.getCantidad() > 0)
                                            {
                                                lugar.arrienda(persona, maquina);
                                                maquina.SetAcc(acc);
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
                        Console.WriteLine("Tipo de vehiculo\n1.Auto\n2.Camioneta\n3.Moto\n4.Camion\n5.Bus\n6.Maquinaria Pesada\n7.Acuatico\nNumero: ");
                        String algo = Console.ReadLine();
                        Console.Write("\nCantidad de dias: ");
                        int dias = Convert.ToInt32(Console.ReadLine());
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
                                            if (maquina.getCantidad() > 0)
                                            {
                                                lugar.arrienda(persona, maquina, dias);
                                                Console.WriteLine("Arriendo realizado");
                                                goto Menu;
                                            }
                                        }
                                        Console.WriteLine("Vehiculo no disponible en sucursal...\n");
                                        goto Menu;

                                    }
                                }
                                Console.WriteLine("Sucursal no encontrada...\n");
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Cliente no registrado...");

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
                    
                }

            }
        }
    }
}
