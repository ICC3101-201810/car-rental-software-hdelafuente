using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Accesorios
    {
        string nombre;
        int precio;
        public Accesorios(string miNombre, int miPrecio)
        {
            nombre = miNombre;
            precio = miPrecio;
        }
        public int GetPrecioAcc()
        {
            return this.precio;
        }
    }
}
