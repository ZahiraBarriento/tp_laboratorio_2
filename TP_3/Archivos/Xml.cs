using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un formato xml
        /// Serializa una clase
        /// </summary>
        /// <param name="archivo"> Nombre del archivo </param>
        /// <param name="datos"> Datos a guardar </param>
        /// <returns> Retornara true si el archivo fue guardado, de lo contrario false </returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter guardar = new StreamWriter(archivo);
                serializer.Serialize(guardar, datos);
                guardar.Close();
                retorno = true;
            }

            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos en un formato xml
        /// Deserializa una clase
        /// </summary>
        /// <param name="archivo"> Nombre del archivo </param>
        /// <param name="datos"> Datos a guardar (al tener out tiene que tener una asignacion) </param>
        /// <returns> Retornara true si el archivo fue guardado, de lo contrario false </returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader leer = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(leer); //Cuando hay out hay que definir el parametro o tira error
                leer.Close();
                retorno = true;
            }

            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
