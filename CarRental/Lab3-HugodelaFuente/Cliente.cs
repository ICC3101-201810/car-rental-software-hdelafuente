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
        string giro;
        List<Vehiculo> enArriendo;
        public Cliente(string Rut, string Nombre, string tipo, string Apellido)
        {
            rut = Rut;
            nombre = Nombre;
            apellido = Apellido;
            giro = tipo;
            enArriendo = new List<Vehiculo>();
        }
        public String getRut()
        {
            return this.rut;
        }
        public String getNombre()
        {
            return this.nombre;
        }
        
    }
}
