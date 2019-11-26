using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guardara un archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto"> Texto a guardar </param>
        /// <param name="archivo"> Nombre del archivo </param>
        /// <returns> Retornada true si se pudo guardar, en caso contrario false </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    writer.Write(texto);
                    retorno = true;
                }
            }

            catch (Exception)
            {
               
            }

            return retorno;
        }
    }
}
