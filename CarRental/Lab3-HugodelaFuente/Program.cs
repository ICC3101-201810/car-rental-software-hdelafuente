using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static public void MuestraVehiculos(List<Vehiculo> lista)
        {
            Console.WriteLine("------------------------\n");
            foreach (var maquina in lista)
            {
                maquina.getInfo();
            }
            Console.WriteLine("------------------------\n");
            Console.Write("Seleccione Patente: ");
        }
        static public void MuestraVehiculosTipo(List<Vehiculo> lista, int tipo)
        {
            Console.WriteLine("------------------------\n");
            foreach (var maquina in lista)
            {
                if (maquina.GetTipo()==tipo)
                {
                    maquina.getInfo();
                }
            }
            Console.WriteLine("------------------------\n");
            Console.Write("Seleccione Patente: ");
        }

        static public Vehiculo BuscaVehiculo(string patente, List<Vehiculo> maquinas)
        {
            foreach (Vehiculo maquina in maquinas)
            {
                foreach (string patentes in maquina.GetPatente())
                {
                    if (patente==patentes)
                    {
                        return maquina;
                    }
                }
            }
            Console.Beep();
            Console.Beep();
            return null;
        }
        static public Cliente BuscaPersona(string rut, List<Cliente> Personas)
        {
            foreach (Cliente persons in Personas)
            {
                if (rut==persons.getRut())
                {
                    return persons;
                }

            }
            Console.Beep();
            Console.Beep();
            return null;
        }
        static public Sucursal BuscaSucursal(string rut, List<Sucursal> lista)
        {
            foreach (Sucursal lugar in lista)
            {
                if (rut == lugar.getRut())
                {
                    return lugar;
                }
            }
            Console.Beep();
            Console.Beep();
            return null;
        }
        static public void EligeVehiculo()
        {
            Console.Write("Tipo de vehiculo" +
                        "\n 1.Auto" +
                        "\n 2.Camioneta" +
                        "\n 3.Moto" +
                        "\n 4.Camion" +
                        "\n 5.Bus " +
                        "\n 6.Maquinaria Pesada" +
                        "\n 7.Acuatico" +
                        "\n Numero: ");
        }        
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
                Console.Write("Opcion (numero): ");
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
                            Console.Clear();
                            Console.WriteLine("Sucursal agregada exitosamente!");
                            Console.Beep();
                            goto Menu;
                        }
                    }
                    Console.Clear();
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
                    Console.Beep();
                    clientes.Add(cliente);
                    Console.Clear();
                    Console.WriteLine("Cliente registrado con exito!");
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
                    EligeVehiculo();
                    int tipo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Cuantas?");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    Vehiculo maquina = new Vehiculo(marca, Modelo, cantidad);
                    maquina.SetTipo(tipo);
                    maquina.GenerarPatente(cantidad);
                    MuestraSucursales(sucursales);
                    Console.Write("Rut de la sucursal: ");
                    String rut_s = Console.ReadLine();
                    Sucursal lugar = BuscaSucursal(rut_s, sucursales);
                    if (maquina == null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Vehiculo no se encuentra en inventario...");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    Console.Beep();
                    lugar.agregaVehiculo(maquina);
                    Console.WriteLine("\n-------------------------------------------------------------------");
                    Console.WriteLine("Vehiculo agregado a sucursal: " + lugar.getName() + " rut: " + rut_s);
                    Console.WriteLine("-------------------------------------------------------------------\n");
                    goto Menu;
                }
                else if (des=="2")
                {
                    EligeVehiculo();
                    int tipoVehiculo = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    Console.Write("\nCantidad de dias: ");
                    int dias = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    MuestraClientes(clientes);
                    Console.WriteLine("Rut del cliente: ");
                    String rut = Console.ReadLine();
                    Cliente persona = BuscaPersona(rut, clientes);
                    if (persona == null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Cliente no registrado...");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    MuestraSucursales(sucursales);
                    Console.WriteLine("Rut de la sucursal: ");
                    String rut2 = Console.ReadLine();
                    Sucursal lugar = BuscaSucursal(rut2, sucursales);
                    if (lugar == null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Sucursal no encontrada...\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    MuestraVehiculosTipo(lugar.getVehiculos(), tipoVehiculo);
                    string patente = Console.ReadLine();
                    Vehiculo maquina = BuscaVehiculo(patente, lugar.getVehiculos());
                    if (maquina == null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Vehiculo no se encuentra en inventario...\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.WriteLine("¿Incluir Accesorios?");
                    String des2 = Console.ReadLine();
                    des2.ToLower();
                    if (des2 == "si" && maquina.GetTipo()!=1)
                    {
                        List<Accesorios> acc = new List<Accesorios>();
                        while (true)
                        {
                            Console.WriteLine("Cual?");
                            string nombre = Console.ReadLine();
                            Accesorios accesorio = new Accesorios(nombre, 300);
                            acc.Add(accesorio);
                            Console.WriteLine("Otro? (si/no)");
                            string des123 = Console.ReadLine();
                            if (des123 == "si")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        lugar.arrienda(persona, maquina, dias);
                        Console.WriteLine("Arriendo Realizado\n");
                        goto Menu;
                    }
                    else if (des2=="si" && maquina.GetTipo()==1)
                    {

                    }
                    else if (des2=="no")
                    {
                        lugar.arrienda(persona, maquina, dias);
                        Console.WriteLine("Arriendo Realizado\n");
                        goto Menu;
                    }

                }
                else if (des=="5")
                {
                    Console.Clear();
                    MuestraClientes(clientes);
                    Console.WriteLine("Rut del cliente: ");
                    String rut = Console.ReadLine();
                    Cliente persona = BuscaPersona(rut, clientes);
                    if (persona==null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Cliente no registrado...");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    MuestraVehiculos(persona.getVehiculos());
                    string patente = Console.ReadLine();
                    Vehiculo maquina = BuscaVehiculo(patente, persona.getVehiculos());
                    if (maquina==null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Cliente no posee vehiculo especificado...");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    MuestraSucursales(sucursales);
                    Console.WriteLine("Rut de la sucursal: ");
                    String rut2 = Console.ReadLine();
                    Sucursal lugar = BuscaSucursal(rut2, sucursales);
                    if (lugar == null)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Sucursal no encontrada...");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        goto Menu;
                    }
                    Console.Clear();
                    lugar.devuelve(persona, maquina);
                    Console.Beep();
                    Console.WriteLine("Devolucion Realizada");

                }
            }
        }
    }
}
