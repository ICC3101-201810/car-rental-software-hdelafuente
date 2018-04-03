using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Vehiculo
    {
        string marca;
        string modelo;
        string tipo;

        public Vehiculo(string Marca,string Modelo,string Tipo)
        {
            marca = Marca;
            modelo = Marca;
            tipo = Tipo;
        }
        public string getInfo()
        {
            return "Marca: " + this.marca + "Modelo: " + this.modelo + "Tipo: " + this.tipo; 
        }
        public string getTipo()
        {
            return this.tipo;
        }
    }
}
