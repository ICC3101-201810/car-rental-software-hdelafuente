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
        List<String> registro_arriendos;
        List<String> registro_devoluciones;
        public Sucursal(string Rut, string Nombre, string Ubicacion)
        {
            rut = Rut;
            nombre_sucursal = Nombre;
            ubicacion = Ubicacion;
            vehiculos = new List<Vehiculo>();
            registro_arriendos = new List<String>();
        }

        public void agregaVehiculo(Vehiculo maquina)
        {
            vehiculos.Add(maquina);
        }
        public void arrienda(Cliente cliente, Vehiculo maquina, int dias)
        {
            int price = maquina.SetPrecio(dias);
            String arriendo = "Cliente: " + cliente.getNombre() + " rut: " + cliente.getRut() + maquina.getInfo() + "Precio: " + price.ToString() + "Fecha Retorno: " + (DateTime.Today.Day + dias).ToString() +"/"+ DateTime.Today.Month.ToString();
            registro_arriendos.Add(arriendo);
            cliente.arrienda(maquina);
            maquina.Resta();
            
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
        public void devuelve(Cliente cliente, Vehiculo maquina)
        {
            String arriendo = "Cliente: " + cliente.getNombre() + " rut: " + cliente.getRut() + " retorna vehiculo " + maquina.getInfo();
            vehiculos.Add(maquina);
            registro_devoluciones.Add(arriendo);
            cliente.devuelve(maquina);
            maquina.Suma();
        }
        public string getInfo()
        {
            return "Nombre Sucursal: " + this.nombre_sucursal + " rut: " + this.rut + " Ubicacion: " + this.ubicacion;
        }
    }
}
