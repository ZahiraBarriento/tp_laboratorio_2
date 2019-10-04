using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado de las marcas de producto.
        /// </summary>
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Producto
        /// </summary>
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias
        /// </summary>
        protected virtual short CantidadCalorias { get; }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor (publico) de producto.
        /// </summary>
        /// <param name="codigoDeBarra">String con el cual iniciara el codigo de barras</param>
        /// <param name="marca">Tipo de marca con el cual iniciara la marca</param>
        /// <param name="color">Tipo de color con el cual iniciara el color</param>
        public Producto(string codigo, EMarca marca ,ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Sting explicit para castear un producto a string
        /// </summary>
        /// <param name="p"> Producto a ser mostrado </param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region "Sobrecarga de operadores"

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Primer producto a ser comparado</param>
        /// <param name="v2">Segundo producto a ser comparado</param>
        /// <returns>Retornara verdadero si los dos productos son iguales, falso si no lo son</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;

            if (v1.codigoDeBarras == v2.codigoDeBarras)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Primer producto a ser comparado</param>
        /// <param name="v2">Segundo producto a ser comparado</param>
        /// <returns>Retornara verdadero si son distintos los dos productos, o falso si no lo son</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }

        #endregion

        #region "Sobreescribir"

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion
    }
}
