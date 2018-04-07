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
        int cantidad;
        List<string> accesorios;

        public Vehiculo(string Marca,string Modelo,string Tipo, string Motor, int Cantidad)
        {
            marca = Marca;
            modelo = Marca;
            tipo = Tipo;
            motor = Motor;
            cantidad = Cantidad;
            accesorios = new List<string>();
        }
        public string getInfo()
        {
            return "Marca: " + this.marca + "Modelo: " + this.modelo + "Motor: " + this.motor + "Tipo: " + this.tipo; 
        }
        public string getTipo()
        {
            return this.tipo;
        }
        public int getCantidad()
        {
            return this.cantidad;
        }
        public void suma()
        {
            cantidad++;
        }
        public void resta()
        {
            cantidad--;
        }
        public void resetAcc()
        {
            accesorios = new List<string>();
        }
        public void setAcc(List<string> acc)
        {
            accesorios = acc;
        }
    }
}
