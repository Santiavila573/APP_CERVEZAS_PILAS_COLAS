using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCervezas.DataAccess
{
    // Clase que maneja la cola de pedidos
    public class ColaPedidos
    {
        private Queue<Pedido> cola;

        // Constructor para inicializar la cola de pedidos
        public ColaPedidos()
        {
            cola = new Queue<Pedido>();
        }

        // Método para encolar un pedido
        public void EncolarPedido(Pedido pedido)
        {
            cola.Enqueue(pedido);
        }

        // Método para desencolar un pedido
        public Pedido DesencolarPedido()
        {
            if (cola.Count == 0)
            {
                return null;
            }

            return cola.Dequeue();
        }
    }
}

