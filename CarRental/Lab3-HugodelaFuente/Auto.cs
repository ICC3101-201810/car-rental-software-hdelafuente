using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Auto : Vehiculo
    {
        string marca;
        string modelo;
        int cantidad;
        List<string> patente;
        List<Accesorios> accesorios;
        bool electrico;
        bool dvd;
        bool asientos_extra;
        bool maletero_grande;
        public Auto(string Marca, string Modelo, int Cantidad) : base(Marca,Modelo,Cantidad)
        {
            marca = Marca;
            modelo = Marca;
            patente = new List<string>();
            cantidad = Cantidad;
            accesorios = new List<Accesorios>();
        }

        public void AccesoriosAuto()
        {
            Console.WriteLine("¿Asientos Extra? (si/no)");
            string des1 = Console.ReadLine().ToLower();
            Console.WriteLine("¿DVD? (si/no)");
            string des2 = Console.ReadLine().ToLower();
            Console.WriteLine("¿Maletero mas grande? (si/no)");
            string des3 = Console.ReadLine().ToLower();
            if (des1=="no")
            {
                Console.WriteLine("¿Electrico? (si/no)");
                string des4 = Console.ReadLine().ToLower();
            }

            
        }

    }
}
