using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado que dira el estado del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region "Delegado"
        /// <summary>
        /// Delegado que sera usado en MockCicloDeVida
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object s, EventArgs e);
        #endregion

        #region "Atributos/Eventos"
        /// <summary>
        /// Atributos de la clase Paquete
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Propiedad lecutura y escritura de direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad lecutura y escritura de estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Propiedad lecutura y escritura de trackingID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor que inicializara con los parametros pasados.
        /// </summary>
        /// <param name="direccionEntrega"> Direccion de entrega con la que se inicializara </param>
        /// <param name="trackingID"> Tracking ID con el que se inicializar </param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Hará que el paquete cambie de estado 
        /// </summary>
        public void MockCicloDeVida()
        {
            //Recorremos los estados del paquete con un while
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);//Genera una demora de 4 segundos

                if (this.Estado != EEstado.Entregado && this.Estado != EEstado.EnViaje)
                {
                    this.Estado = EEstado.EnViaje;

                }

                else if (this.Estado != EEstado.Entregado && this.Estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }

                this.InformaEstado.Invoke(null, null);

                if (this.estado == EEstado.Entregado)
                {
                    try
                    {
                        PaqueteDAO.Insertar(this);
                    }

                    catch(Exception)
                    {

                    }
                }

            }
        }

        /// <summary>
        /// Mostrar los datos del paqete pasado por parametro
        /// </summary>
        /// <param name="elemento"> Paquete a mostrar</param>
        /// <returns> Retornada un string con los datos del paquete </returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return string.Format("{0} para {1} \n", p.TrackingID, p.DireccionEntrega);
        }
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// Mostrar la informacion del paquete
        /// </summary>
        /// <returns> Retornara los datos del paquete </returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region "Sobrecarga de operadores"

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo
        /// </summary>
        /// <param name="p1">Paquete uno a ser comparado</param>
        /// <param name="p2">Paquete dos a ser comparado</param>
        /// <returns> Retornara true si son iguales, en los ocntrario false </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retono = false;

            if (p1.TrackingID == p2.TrackingID)
            {
                retono = true;
            }

            return retono;
        }

        /// <summary>
        /// Dos paquetes seran distintos siempre y cuando su Tracking ID sea distinto.
        /// </summary>
        /// <param name="p1">Paquete uno a ser comparado</param>
        /// <param name="p2">Paquete dos a ser comparado</param>
        /// <returns> Retornara true si son distintos, en los ocntrario false </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
