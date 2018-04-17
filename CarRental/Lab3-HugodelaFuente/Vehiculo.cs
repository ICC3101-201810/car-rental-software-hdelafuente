using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Vehiculo
    {
        bool electrico;
        bool dvd;
        bool asientos_extra;
        bool maletero_grande;


        string marca;
        string modelo;
        int tipo;
        List<string> patente;
        int cantidad;
        List<Accesorios> accesorios;

        Dictionary<int, string> Tipo = new Dictionary<int, string>
        {
            {1, "Auto"},
            {2, "Camioneta" },
            {3, "Moto" },
            {4, "Camion" },
            {5, "Bus" },
            {6, "Maquinaria Pesada" },
            {7, "Acuatico" }
            
        };

        Dictionary<int, int> Precio = new Dictionary<int, int>
        {
            {1, 30000},
            {2, 45000},
            {3, 15000},
            {4, 200000},
            {5, 100000},
            {6, 300000 },
            {7, 50000 }

        };

        public Vehiculo(string Marca,string Modelo, int Cantidad)
        {
            marca = Marca;
            modelo = Marca;
            patente = new List<string>();
            cantidad = Cantidad;
            accesorios = new List<Accesorios>();
        }

        public void GenerarPatente(int cuantas)
        {
            Random rn = new Random();
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            while (cuantas >= 0)
            {
                int letra1 = rn.Next(0,25);
                int letra2 = rn.Next(0,25);
                int letra3 = rn.Next(0,25);
                int letra4 = rn.Next(0,25);
                int numero1 = rn.Next(0, 100);
                patente.Add(letras[letra1] + letras[letra2] + letras[letra3] + letras[4] + "-" +numero1.ToString());
                cuantas--;
            }
        }

        public void SetTipo(int numero)
        {
            tipo = numero;
        }

        public int GetTipo()
        {
            return this.tipo;
        }
        
        public List<string> GetPatente()
        {
            return this.patente;
        }

        public int SetPrecio(int dias)
        {
            int contador=0;
            foreach (Accesorios item in accesorios)
            {
                contador+=item.GetPrecioAcc();
            }
            return dias * Precio[this.tipo] + contador;
        }

        public string GetSpecs()
        {
            return this.marca + " " + this.modelo;
        }

        public void getInfo()
        {
            foreach (string patentes in patente)
            {
                Console.WriteLine(this.GetSpecs() + "Patente: " + patentes);
            }
        }

        public int getCantidad()
        {
            return this.cantidad;
        }
        public List<Accesorios> GetAccesorios()
        {
            return this.accesorios;
        }
        public void Suma()
        {
            cantidad++;
        }

        public void Resta()
        {
            cantidad--;
        }

        public void ResetAcc()
        {
            accesorios = new List<Accesorios>();
        }

        public void SetAcc(List<Accesorios> acc)
        {
            accesorios = acc;
        }

        public void AccesoriosAuto(List<Accesorios> accesorios)
        {
            Console.WriteLine("¿Asientos Extra? (si/no)");
            string des1 = Console.ReadLine().ToLower();
            if (des1 == "si")
            {
                asientos_extra = true;
            }
            
            Console.WriteLine("¿DVD? (si/no)");
            string des2 = Console.ReadLine().ToLower();
            if (des2 == "si")
            {
                dvd = true;
            }
            else
            {
                dvd = false;
            }
            Console.WriteLine("¿Maletero mas grande? (si/no)");
            string des3 = Console.ReadLine().ToLower();
            if (des1 == "si")
            {
                maletero_grande = true;
            }
            else
            {
                maletero_grande = false;
            }
            if (des1 == "no")
            {
                asientos_extra = false;
                Console.WriteLine("¿Electrico? (si/no)");
                string des4 = Console.ReadLine().ToLower();
                if (des4=="si")
                {
                    electrico = true;
                }
                else
                {
                    electrico = false;
                }
            }
        }
        
    }
}
