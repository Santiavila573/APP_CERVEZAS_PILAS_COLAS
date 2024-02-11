using AppCervezas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCervezas.ConsoleLogic
{
    // Clase que gestiona los pedidos de cerveza usando una cola
    public class GestorPedidos
    {
        private Queue<Pedido> pedidos;

        // Constructor para inicializar la cola de pedidos
        public GestorPedidos()
        {
            pedidos = new Queue<Pedido>();
        }

        // Método para realizar un pedido de cerveza
        public void RealizarPedido(string cliente, string cerveza, int cantidad)
        {
            Pedido pedido = new Pedido(cliente, cerveza, cantidad);
            pedidos.Enqueue(pedido);
        }

        // Método para atender un pedido de cerveza
        public Pedido AtenderPedido()
        {
            return pedidos.Count > 0 ? pedidos.Dequeue() : null;
        }
    }
}

