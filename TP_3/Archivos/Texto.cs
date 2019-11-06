using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en formato de texto en un archivo        
        /// </summary>
        /// <param name="archivo"> Nombre del archivo </param>
        /// <param name="datos"> Datos a guardar </param>
        /// <returns> Retornara true si el archivo fue guardado, de lo contrario false </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                retorno = true;
                writer.Close();
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo y los almacena en modo texto
        /// </summary>
        /// <param name="archivo"> Nombre del archivo a leer </param>
        /// <param name="datos"> Donde guardar los datos leido </param>
        /// <returns> Retornara true si los datos fueron leidos, de lo contrario false </returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                StreamReader streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
                streamReader.Close();
                retorno = true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
