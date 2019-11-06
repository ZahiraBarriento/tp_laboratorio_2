using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciales
{
    public sealed class Alumno : Universitario
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado de estados de la cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Alumno
        /// </summary>
        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Inizializa todos los atributos menos estado de cuenta.
        /// </summary>
        /// <param name="id"> Id a ser cargado </param>
        /// <param name="nombre"> Nombre a ser cargado </param>
        /// <param name="apellido"> Apellido a ser cargado </param>
        /// <param name="dni"> DNI a ser cargado </param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargado </param>
        /// <param name="claseQueToma"> Clase a ser cargada </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa todos los campos pasados por parametros
        /// </summary>
        /// <param name="id"> Id a ser cargado </param>
        /// <param name="nombre"> Nombre a ser cargado </param>
        /// <param name="apellido"> Apellido a ser cargado </param>
        /// <param name="dni"> DNI a ser cargado </param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada </param>
        /// <param name="claseQueToma"> Clase a ser cargada </param>
        /// <param name="estadoCuenta"> Estado de la cuenta a cargardo </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns> Retornara todos los datos cargados del alumno </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            string aux = null;

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    aux = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    aux = "Está becado";
                    break;
                case EEstadoCuenta.Deudor:
                    aux = "Deudor";
                    break;
                default:
                    break;
            }

            sb.AppendFormat("\nESTADO DE CUENTA: {0}", aux);

            return sb.ToString();
        }

        /// <summary>
        /// Muestra la clase que toma
        /// </summary>
        /// <returns> Retornara la clase que toma el alumno </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("TOMA CLASE DE " + this.claseQueToma);
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        } 

        /// <summary>
        /// Hará publico los datos
        /// </summary>
        /// <returns> Retornara los datos del alumno </returns>
        public override string ToString()
        {
            return ("ALUMNOS: \n" + this.MostrarDatos() + this.ParticiparEnClase());
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Compara un alumno y una clase
        /// </summary>
        /// <param name="alumno"> Alumno a comparar </param>
        /// <param name="clase"> Clase que se verifica </param>
        /// <returns> Retornara true si un alumno toma una clase y su estado de cuenta no es Deudor, de lo contrario false </returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            bool retorno = false;

            if(alumno.estadoCuenta != EEstadoCuenta.Deudor && alumno.claseQueToma == clase)
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Compara un alumno y una clase
        /// </summary>
        /// <param name="alumno"> Alumno a comparar </param>
        /// <param name="clase"> ClASE a verificar</param>
        /// <returns> Retornara true si un alumno no toma esa clase, de lo contrario false </returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            bool retorno = false;

            if (alumno.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }
        #endregion
    }
}
