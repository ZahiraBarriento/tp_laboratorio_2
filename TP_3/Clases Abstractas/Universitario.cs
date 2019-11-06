using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Universitario
        /// </summary>
        private int legajo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        ///  Inicializa los campos pasados como parametros
        /// </summary>
        /// <param name="legajo"> Leajo a ser cargado </param>
        /// <param name="nombre"> Nombre a ser cargado </param>
        /// <param name="apellido"> Apellido a ser cargado </param>
        /// <param name="dni"> DNI a ser cargado </param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Muestra los datos cargados
        /// </summary>
        /// <returns> Retornara todos los datos del universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Firma de método abstracto
        /// </summary>
        protected abstract string ParticiparEnClase();
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// Verifica si el objeto pasado es del mismo tipo de ser asi compara sus campos DNI y Legajo
        /// </summary>
        /// <param name="obj"> Objeto a valdidar </param>
        /// <returns> Retorna true si son el mismo tipo y si comparten el mismo DNI y LEGAJO, de lo contrario false </returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj.GetType() == this.GetType())//Evalua si son del mismo tipo
            {
                if (((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Compara si dos universitarios son iguales por el tipo, DNI  o legajo
        /// </summary>
        /// <param name="pg1"> dato a comparar</param>
        /// <param name="pg2"> dato a comparar</param>
        /// <returns> Retornara true si ambos datos son iguales o false de lo contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.Equals(pg2))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
