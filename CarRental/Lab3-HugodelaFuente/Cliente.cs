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
        bool licencia;
        public Cliente(string Rut, string Nombre, string tipo, string Apellido)
        {
            rut = Rut;
            nombre = Nombre;
            apellido = Apellido;
            giro = tipo;
            licencia = true;
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
