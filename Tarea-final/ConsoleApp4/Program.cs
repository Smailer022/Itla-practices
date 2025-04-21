using System;
using System.Collections.Generic;

namespace CoffeeExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            var cafeteria = new Cafeteria();
            cafeteria.Iniciar();
        }
    }

    public class Cafeteria
    {
        private List<Producto> productos = new List<Producto>();
        private List<Pedido> pedidos = new List<Pedido>();

        public Cafeteria()
        {
            productos.Add(new Producto(1, "Café Americano", 30));
            productos.Add(new Producto(2, "Café Latte", 45));
            productos.Add(new Producto(3, "Croissant", 25));
        }

        public void Iniciar()
        {
            Console.WriteLine("\nBienvenido a CoffeeExpress!");

            while (true)
            {
                Console.WriteLine("\n1. Ver Productos\n2. Crear Pedido\n3. Ver Pedidos\n4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarProductos();
                        break;
                    case "2":
                        CrearPedido();
                        break;
                    case "3":
                        MostrarPedidos();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        private void MostrarProductos()
        {
            Console.WriteLine("\nProductos Disponibles:");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Id}. {p.Nombre} - ${p.Precio}");
            }
        }

        private void CrearPedido()
        {
            var pedido = new Pedido();
            string seguir;

            do
            {
                MostrarProductos();
                Console.Write("Ingrese el ID del producto: ");
                int id = int.Parse(Console.ReadLine());
                var producto = productos.Find(p => p.Id == id);

                if (producto != null)
                {
                    pedido.AgregarProducto(producto);
                    Console.WriteLine($"{producto.Nombre} agregado.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }

                Console.Write("Agregar otro producto? (s/n): ");
                seguir = Console.ReadLine().ToLower();

            } while (seguir == "s");

            pedido.CalcularTotal();
            pedidos.Add(pedido);

            Console.WriteLine($"Pedido creado. Total: ${pedido.Total}\n");
        }

        private void MostrarPedidos()
        {
            Console.WriteLine("\nPedidos Realizados:");
            int count = 1;
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido #{count++} - Total: ${pedido.Total}");
            }
        }
    }

    public class Producto
    {
        public int Id { get; }
        public string Nombre { get; }
        public decimal Precio { get; }

        public Producto(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
    }

    public class Pedido
    {
        public List<Producto> Productos { get; } = new List<Producto>();
        public decimal Total { get; private set; }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public void CalcularTotal()
        {
            foreach (var producto in Productos)
            {
                Total += producto.Precio;
            }
        }
    }
}