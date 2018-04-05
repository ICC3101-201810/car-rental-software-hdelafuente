using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Sucursal
    {
        string rut;
        string nombre_sucursal;
        string ubicacion;
        List<Vehiculo> vehiculos;
        List<String> registro; 
        public Sucursal(string Rut, string Nombre, string Ubicacion)
        {
            rut = Rut;
            nombre_sucursal = Nombre;
            ubicacion = Ubicacion;
            vehiculos = new List<Vehiculo>();
            registro = new List<String>();
        }

        public void agregaVehiculo(Vehiculo maquina)
        {
            vehiculos.Add(maquina);
        }
        public void arrienda(Cliente cliente, Vehiculo maquina)
        {
            String arriendo = "Cliente: " + cliente.getNombre() + "rut: " + cliente.getRut() + maquina.getInfo();
            registro.Add(arriendo);
        }
        public string getRut()
        {
            return this.rut;
        }
        public List<Vehiculo> getVehiculos()
        {
            return this.vehiculos;
        }
        public string getName()
        {
            return this.nombre_sucursal;
        }
    }
}
