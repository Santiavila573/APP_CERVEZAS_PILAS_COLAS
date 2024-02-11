using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCervezas.DataAccess
{
    // Clase que maneja la pila de cervezas disponibles
    // Clase que gestiona las cervezas disponibles usando una pila
    public class PilaCervezas
    {
        private Stack<string> cervezas;

        // Constructor para inicializar la pila con algunas cervezas predeterminadas
        public PilaCervezas()
        {
            cervezas = new Stack<string>();
            // Inicializamos la pila con algunas cervezas predeterminadas
            cervezas.Push("Corona");
            cervezas.Push("Heineken");
            cervezas.Push("Budweiser");
        }

        // Método para agregar una nueva cerveza a la pila
        public void AgregarCerveza(string cerveza)
        {
            cervezas.Push(cerveza);
        }

        // Método para obtener la cerveza disponible en la cima de la pila
        public string ObtenerCervezaDisponible()
        {
            return cervezas.Count > 0 ? cervezas.Peek() : null;
        }

        // Método para sacar una cerveza específica de la pila
        public void SacarCerveza(string cerveza)
        {
            if (cervezas.Contains(cerveza))
            {
                Stack<string> tempStack = new Stack<string>();

                while (cervezas.Count > 0)
                {
                    string cervezaActual = cervezas.Pop();
                    if (cervezaActual != cerveza)
                    {
                        tempStack.Push(cervezaActual);
                    }
                }

                // Restaurar la pila original
                while (tempStack.Count > 0)
                {
                    cervezas.Push(tempStack.Pop());
                }
            }
        }

        // Propiedad para acceder a todas las cervezas de la pila
        public IEnumerable<string> Cervezas
        {
            get { return cervezas; }
        }
    }
}