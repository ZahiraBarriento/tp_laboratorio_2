using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "Propiedades"

        /// <summary>
        /// Propiedad de solo lectura CantidadCalorias 
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor de la clase Snack
        /// Se reutiliza codigo llamando al constructor de la clase base Producto.
        /// </summary>
        /// <param name="marca">Tipo de marca de la cual iniciara la marca del snack</param>
        /// <param name="codigo">String del cual iniciara el codigo de barras del snack</param>
        /// <param name="color">Tipo de color del cual iniciara el color del snack</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Modificacion del metodo mostrar de la clase padre Producto.
        /// Se encarga de publicar todas los dulces.
        /// </summary>
        /// <returns>Retornara un string con los datos de la clase Snack</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
