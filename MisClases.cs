using System;
using System.Collections.Generic;

namespace GestionProductos
{
 class Producto
        {
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public int Inventario { get; set; }
            public List<String> Clientes {get; set;}

            public Producto(string nombre, double precio, List<String> clientes,int iventario=0)
            {
                Nombre = nombre;
                Precio = precio;
                Inventario = iventario;
                Clientes = clientes;
            }

            public void ActPrecio(double nuevoPrecio)
            {
                this.Precio = nuevoPrecio;
            }
            public void ActInventario(int nuevaCantidad)
            {
                this.Inventario = nuevaCantidad;
            }

            public void ActCliente(string nuevoCLiente)
            {
                this.Clientes.Add(nuevoCLiente);
            }
        }

}