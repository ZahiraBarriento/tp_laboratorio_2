using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Propiedades"

        /// <summary>
        /// Propiedad de solo lectura CantidadCalorias
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor de la clase Dulce.
        /// Se reutiliza codigo, llamando al constructor de la clase padre.
        /// </summary>
        /// <param name="marca">Tipo de marca de la cual iniciara la marca del dulce</param>
        /// <param name="codigoDeBarra">String del cual iniciara el codigo de barras del dulce</param>
        /// <param name="color">Tipo de color del cual iniciara el color del dulce</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base (codigo, marca, color)
        {

        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Modificacion del metodo mostrar de la clase padre Producto.
        /// Se encarga de publicar todas los dulces.
        /// </summary>
        /// <returns>Retornara un string con los datos de la clase Dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
