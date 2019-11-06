using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciales
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Profesor
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor static que inicializara el random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa la lista de EClases
        /// </summary>
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Inizializa al profesor con los campos pasados como parametro
        /// </summary>
        /// <param name="id"> ID a ser cargado </param>
        /// <param name="nombre"> Nombre a ser cargado </param>
        /// <param name="apellido"> Apellido a ser cargado </param>
        /// <param name="dni"> DNI a ser cargado </param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Genera una clase aleatoria y la agrega a la clase del dia
        /// </summary>
        private void _randomClases()
        {
            Array ArrayEclases = Enum.GetValues(typeof(Universidad.EClases));

            Universidad.EClases randomClass = (Universidad.EClases)ArrayEclases.GetValue(random.Next(ArrayEclases.Length));
            this.clasesDelDia.Enqueue(randomClass);
        }
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// Muestra los datos cargados del profesor
        /// </summary>
        /// <returns> Retorna los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Muestra las clases que da el profesor
        /// </summary>
        /// <returns> Retorna todas las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.Append(clase + "\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de forma publica cargados del profesor
        /// </summary>
        /// <returns> Retornara los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Compara si un profesor da una clase
        /// </summary>
        /// <param name="i"> Profesor a verificar </param>
        /// <param name="clase"> Clase a comparar</param>
        /// <returns> Retornara true si el profesor da la clase, de lo contrario false </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases auxclase in i.clasesDelDia)
            {
                if (auxclase == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara si un profesor no da una clase
        /// </summary>
        /// <param name="i"> Profesor a verificar </param>
        /// <param name="clase"> Clase a comparar </param>
        /// <returns> Retorna si el profesor no esta en la clase </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
