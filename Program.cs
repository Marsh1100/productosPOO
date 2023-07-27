using System;
using System.Collections.Generic;

namespace GestionProductos
{
    class Tienda
    {
        static Dictionary<int, Producto> Productos = new Dictionary<int, Producto>();

        static void Main(string[] args)
        {
            bool continuar = true;

            do {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE PRODUCTOS \n\n");
                Console.WriteLine("1. Agregar nuevo producto");
                Console.WriteLine("2. Mostrar un producto");
                Console.WriteLine("3. Listar todos los productos");
                Console.WriteLine("4. Actualizar precio de producto");
                Console.WriteLine("5. Actualizar la cantidad en inventario de un producto");
                Console.WriteLine("6. Actualizar el listado de clientes");                
                Console.WriteLine("7. Eliminar producto");
                Console.WriteLine("8. Terminar\n\n");
                Console.WriteLine("******************************");
                Console.Write("Elija una Opción: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            agregar();
                            break;
                        case 2:
                            mostrar();
                            break;
                        case 3:
                            listar();
                            break;
                        case 4:
                            actualizarPrecio();
                            break;
                        case 5:
                            actualizarInventario();
                            break;
                        case 6:
                            actualizarClientes();
                            break;
                        case 7:
                            borrar();
                            break;
                        case 8:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Elija Opción entre 1 y 8");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                    Console.ReadKey();
                }
            } while (continuar);
        }

        static void agregar()
        {
            Console.Clear();
            Console.WriteLine("Agregar Producto");
            Console.Write("Ingrese CÓDIGO de Producto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (Productos.ContainsKey(id))
                {
                    Console.WriteLine("El Código ya existe...");
                }
                else
                {
                    Console.Write("Ingrese nombre del producto: ");
                    string nombre =  Console.ReadLine() ?? "";

                    Console.Write("Ingrese el precio del producto: ");
                    if (double.TryParse(Console.ReadLine(), out double precio))
                    {
                        //Console.Write("Ingrese los clientes del usuario (separados por comas): ");
                        List<string> clientes = new List<string>();

                        Producto newProducto = new Producto(nombre, precio,clientes);
                        Productos.Add(id, newProducto);
                        Console.WriteLine("Producto agregado correctamente.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor numérico para el precio");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("Código No válido");
                Console.ReadKey();
            }
        }

        static void actualizarPrecio()
        {
            Console.Clear();
            Console.WriteLine("Actualizar precio de producto");
            Console.Write("Ingrese código del producto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {

                if (Productos.TryGetValue(id, out Producto? ProductoTienda))
                {
                    Console.Write("Ingrese el precio del producto: ");
                    if (double.TryParse(Console.ReadLine(), out double precio))
                    {
                        ProductoTienda.ActPrecio(precio);
                        Console.WriteLine("Precio actualizado correctamente.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor numérico para el precio");
                        Console.ReadKey();
                    }
                  
                }
                else
                {
                    Console.WriteLine("No se encontró un producto con ese código.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Código NO válido.");
                Console.ReadKey();
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void actualizarInventario()
        {
            Console.Clear();
            Console.WriteLine("Actualizar cantidad de productos del inventario");
            Console.Write("Ingrese código del producto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {

                if (Productos.TryGetValue(id, out Producto? ProductoTienda))
                {
                    Console.Write("Ingrese nueva cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        ProductoTienda.ActInventario(cantidad);
                        Console.WriteLine("Cantidad actualizada correctamente.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor numérico para la cantidad");
                        Console.ReadKey();
                    }
                  
                }
                else
                {
                    Console.WriteLine("No se encontró un producto con ese código.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Código NO válido.");
                Console.ReadKey();
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        static void actualizarClientes()
        {
            Console.Clear();
            Console.WriteLine("Actualizar listado de clientes del inventario");
            Console.Write("Ingrese código del producto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {

                if (Productos.TryGetValue(id, out Producto? ProductoTienda))
                {
                    Console.Write("Ingrese nuevo cliente: ");
                    string? nuevoCliente = Console.ReadLine();
                    if(nuevoCliente == null){
                        nuevoCliente="cliente";
                    }
                    ProductoTienda.ActCliente(nuevoCliente);

                    Console.WriteLine("Clientes actualizados correctamente.");
                     Console.ReadKey();
                    
                    
                  
                }
                else
                {
                    Console.WriteLine("No se encontró un producto con ese código.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Código NO válido.");
                Console.ReadKey();
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        static void mostrar()
        {
            Console.Clear();
            Console.WriteLine("Mostrar producto");
            Console.Write("Ingrese código del producto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {

                if (Productos.TryGetValue(id, out Producto? Producto))
                {
                    Console.WriteLine("Información del producto:");
                    Console.WriteLine($"Nombre: {Producto.Nombre}");
                    Console.WriteLine($"Precio: {Producto.Precio}");
                    Console.WriteLine($"Inventario cantidad: {Producto.Inventario}");

                    Console.WriteLine("Clientes:");
                    foreach (var cliente in Producto.Clientes)
                    {
                        Console.WriteLine($"- {cliente}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró un producto con ese código.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Código NO válido.");
                Console.ReadKey();
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void listar()
        {
            Console.Clear();
            Console.WriteLine("Listado de Productos ");
            if (Productos.Count > 0)
            {
                foreach (var producto in Productos)
                {
                    Console.WriteLine($"Código: {producto.Key}");
                    Console.WriteLine($"Nombre: {producto.Value.Nombre}");
                    Console.WriteLine($"Precio: {producto.Value.Precio}");
                    Console.WriteLine($"Cantidad Inventario: {producto.Value.Inventario}");
                    Console.WriteLine("Clientes:");
                    foreach (var cliente in producto.Value.Clientes)
                    {
                        Console.WriteLine($"- {cliente}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        static void borrar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar un Producto");
            Console.Write("Ingrese el código del producto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (Productos.ContainsKey(id))
                {
                    Productos.Remove(id);
                    Console.WriteLine("Producto eliminado");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No se encontró ningún producto con el número de identificación");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Código NO válido.");
                Console.ReadKey();
            }
        }
    }

}
