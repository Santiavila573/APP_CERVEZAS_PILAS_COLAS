using System;
using AppCervezas.DataAccess;
using AppCervezas.ConsoleLogic;


namespace AppCervezas.AppCervezasUX
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una pila de cervezas disponibles
            PilaCervezas pilaCervezas = new PilaCervezas();
            // Crear el gestor de pedidos
            GestorPedidos gestorPedidos = new GestorPedidos();
            // Lista para registrar las cervezas añadidas en el pedido actual
            List<string> cervezasPedidoActual = new List<string>();

            Console.WriteLine("BIENVENIDO A APP-CERVEZAS");
            Console.WriteLine("----------------------");

            bool continuar = true;
            while (continuar)
            {
                // Realizar un pedido
                RealizarPedido(gestorPedidos, cervezasPedidoActual, pilaCervezas);

                Console.Write("\n¿Desea realizar otro pedido? (S/N): ");
                string respuesta = Console.ReadLine().Trim().ToUpper();
                continuar = (respuesta == "S");

                // Mostrar los pedidos realizados
                ListarPedidosRealizados(gestorPedidos);

                // Mostrar las cervezas disponibles
                MostrarCervezasDisponibles(pilaCervezas);

                // Eliminar las cervezas añadidas a los pedidos de la lista de cervezas disponibles
                foreach (var cerveza in cervezasPedidoActual)
                {
                    pilaCervezas.SacarCerveza(cerveza);
                }
                cervezasPedidoActual.Clear(); // Limpiar la lista de cervezas añadidas en el pedido actual
            }
        }

        // Métodos para interactuar con el usuario
        // (Los métodos RealizarPedido, ListarPedidosRealizados y MostrarCervezasDisponibles)
        // están implementados como funciones estáticas según la estructura de capas de la aplicación.

        // Método para realizar un pedido
        static void RealizarPedido(GestorPedidos gestorPedidos, List<string> cervezasPedidoActual, PilaCervezas pilaCervezas)
        {
            Console.WriteLine("\nRealizar Pedido:");
            Console.Write("Nombre del cliente: ");
            string cliente = Console.ReadLine();
            Console.Write("Nombre de la cerveza: ");
            string cerveza = Console.ReadLine();
            cervezasPedidoActual.Add(cerveza); // Agregar la cerveza al registro del pedido actual
            Console.Write("Cantidad: ");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("La cantidad debe ser un número entero positivo.");
                Console.Write("Ingrese nuevamente la cantidad: ");
            }

            gestorPedidos.RealizarPedido(cliente, cerveza, cantidad);
            Console.WriteLine("Pedido realizado correctamente.");
        }

        // Método para listar todos los pedidos realizados
        static void ListarPedidosRealizados(GestorPedidos gestorPedidos)
        {
            Console.WriteLine("\nPedidos Realizados:");
            Console.WriteLine("-------------------");

            // Listar pedidos realizados
            Pedido pedido;
            while ((pedido = gestorPedidos.AtenderPedido()) != null)
            {
                Console.WriteLine($"Cliente: {pedido.Cliente}, Cerveza: {pedido.Cerveza}, Cantidad: {pedido.Cantidad}");
            }

            if (pedido == null)
            {
                Console.WriteLine("No hay pedidos realizados.");
            }
        }

        // Método para mostrar las cervezas disponibles
        static void MostrarCervezasDisponibles(PilaCervezas pilaCervezas)
        {
            Console.WriteLine("\nCervezas Disponibles:");
            Console.WriteLine("---------------------");

            // Mostrar cervezas disponibles
            foreach (var cerveza in pilaCervezas.Cervezas)
            {
                Console.WriteLine(cerveza);
            }
        }
    }
}