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
        string motor;

        public Vehiculo(string Marca,string Modelo,string Tipo, string Motor)
        {
            marca = Marca;
            modelo = Marca;
            tipo = Tipo;
            motor = Motor;
        }
        public string getInfo()
        {
            return "Marca: " + this.marca + "Modelo: " + this.modelo + "Motor: " + this.motor + "Tipo: " + this.tipo; 
        }
        public string getTipo()
        {
            return this.tipo;
        }
    }
}
