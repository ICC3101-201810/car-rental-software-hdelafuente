﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Vehiculo
    {
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
    }
}
