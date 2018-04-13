using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Cliente
    {
        string rut;
        string nombre;
        String apellido;
        string razon_social;
        List<Vehiculo> en_arriendo;
        public Cliente(string Rut, string Nombre, string tipo, string Apellido)
        {
            rut = Rut;
            nombre = Nombre;
            apellido = Apellido;
            razon_social = tipo;
            en_arriendo = new List<Vehiculo>();
        }
        public String getRut()
        {
            return this.rut;
        }
        public String getNombre()
        {
            return this.nombre;
        }

        public void arrienda(Vehiculo maquina)
        {
            en_arriendo.Add(maquina);
        }
        public void devuelve(Vehiculo maquina)
        {
            en_arriendo.Remove(maquina);
        }
        public List<Vehiculo> getVehiculos()
        {
            return en_arriendo;
        }
        public string getInfo()
        {
            return "Nombre Sucursal: " + this.nombre + " " + this.apellido + " rut: " + this.rut ;
        }
    }
}
