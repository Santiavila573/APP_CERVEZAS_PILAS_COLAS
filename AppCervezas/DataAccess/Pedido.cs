using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCervezas.DataAccess
{
    // Clase que representa un pedido de cerveza
    public class Pedido
    {
        // Propiedades del pedido
        public string Cliente { get; set; }
        public string Cerveza { get; set; }
        public int Cantidad { get; set; }

        // Constructor para inicializar un pedido con los valores especificados
        public Pedido(string cliente, string cerveza, int cantidad)
        {
            Cliente = cliente;
            Cerveza = cerveza;
            Cantidad = cantidad;
        }
    }
}
