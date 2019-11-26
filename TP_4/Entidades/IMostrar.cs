using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Firma de metodo que sera usada para mostrar los datos de un elemento
        /// </summary>
        /// <param name="elemento"> Elemento a mostrar </param>
        /// <returns> Retornada la informacion del elemento </returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
