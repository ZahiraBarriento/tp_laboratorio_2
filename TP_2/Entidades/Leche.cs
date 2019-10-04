using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado que dara los tipos de leche
        /// 
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Leche
        /// </summary>
        private ETipo tipo;
        #endregion

        #region "Propiedades"

        /// <summary>
        /// Propiedad de solo lectura CantidadCalorias
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor de la clase leche.
        /// </summary>
        /// <param name="marca">Tipo de marca de la cual iniciara la marca de la leche</param>
        /// <param name="codigo">String del cual iniciara el codigo de barras de la leche</param>
        /// <param name="color">Tipo de color del cual iniciara el color de la leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca, codigo, color, ETipo.Entera)
        {

        }

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Tipo de marca de la cual iniciara la marca de la leche</param>
        /// <param name="codigoDeBarra">String del cual iniciara el codigo de barras de la leche</param>
        /// <param name="color">Tipo de color del cual iniciara el color de la leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Modificacion del metodo mostrar de la clase padre Producto.
        /// Se encarga de publicar todas las leches.
        /// </summary>
        /// <returns>Retornara un string con los datos de la clase Leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
