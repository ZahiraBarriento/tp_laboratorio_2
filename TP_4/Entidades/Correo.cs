using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Correo
        /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region "Propiedad"
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {   get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor que inicializara las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// FinEntregas cerrará todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort(); 
                }
            }
        }

        /// <summary>
        ///  Mostrara los datos de todos los paquetes de la lista de paquetes
        /// </summary> 
        /// <param name="elemento"> Elementos de la lista </param>
        /// <returns> Retornara la informacion de la lista </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string aux = "";

            foreach (Paquete p in (List<Paquete>)((Correo)elemento).paquetes)
            {
                aux += (string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }

            return aux;
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Se agregara un paquete a la lista de paquetes de correo. 
        /// </summary>
        /// <param name="c"> Correo donde se agregara el paquete </param>
        /// <param name="p"> Paquete a ser agregado </param>
        /// <returns> Retornara el correo con todos los paquetes</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("El tracking ID " + p.TrackingID + " ya figura en la lista de envios.");
                }
            }

            c.paquetes.Add(p);

            //Creamos un hilo para el metodo MockCicloDeVida
            Thread hilo = new Thread(p.MockCicloDeVida);
            //Lo agregamos
            c.mockPaquetes.Add(hilo);

            hilo.Start();

            return c;

        }
        #endregion
    }
}
