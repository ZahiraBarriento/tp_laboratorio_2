using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Persona
        /// </summary>
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Get obtiene el apellido 
        /// Set valida que el apellido solo contenga letras
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Get obtiene el DNI
        /// Set valida que el DNI sea correcto segun su nacionalidad
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Get obtiene la nacionalidad
        /// Set Valida que el nombre solo contenga letras
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Get obtiene el nombre
        /// Set valida que el nombre contenga solo letras
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Set valida que el DNI sea correcto
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Inicializa los campos pasados como parametros con sus respectivos valores
        /// </summary>
        /// <param name="nombre"> Nombre a ser cargado</param>
        /// <param name="apellido"> Apellido a ser cargado</param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa los campos pasados como parametros con sus respectivos valores
        /// </summary>
        /// <param name="nombre"> Nombre a ser cargado</param>
        /// <param name="apellido"> Apellido a ser cargado</param>
        /// <param name="dni"> DNI a ser cargado</param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa los campos pasados como parametros con sus respectivos valores
        /// </summary>
        /// <param name="nombre"> Nombre a ser cargado</param>
        /// <param name="apellido"> Apellido a ser cargado</param>
        /// <param name="dni"> DNI a ser cargado</param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida si el dato pasado como parametro es valido para un nombre o apellido
        /// </summary>
        /// <param name="dato"> Nombre a validar </param>
        /// <returns> Retornara el nombre o apellido validado </returns>
        private string ValidarNombreApellido(string dato)
        {
            string resultado = dato;

            Regex validar = new Regex("^[a-z|A-Z]+?$");

            if (!(validar.IsMatch(dato)))
            {
                resultado = null;
            }

            return resultado;
        }

        /// <summary>
        /// Valida si el DNI es valido para la nacionalidad pasada como argumento
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad del dni </param>
        /// <param name="dato"> DNI a validar </param>
        /// <returns> Retornara el DNI validado </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }

            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }

            else
            {
                throw new NacionalidadInvalidaException(); 
            }
        }

        /// <summary>
        /// Convierte un string a int y valida si el DNI es valido para la nacionalidad pasada como argumento
        /// </summary>
        /// <param name="nacionalidad">nacionalidad del dni</param>
        /// <param name="dato"> dni a validar</param>
        /// <returns> Retornara el DNI validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            Regex validar = new Regex("^[0-9]+?$");

            if (validar.IsMatch(dato) && Int32.TryParse(dato, out int auxDni))
            {
                return ValidarDni(nacionalidad, auxDni);
            }

            else
            {
                throw new DniInvalidoException("Formato incorrecto.");
            }
        }

        /// <summary>
        /// Mostrara los datos de la clase
        /// </summary>
        /// <returns> Retornara los datos cargados de la persona </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n\n", this.Nacionalidad);

            return sb.ToString();
        }
        #endregion
    }
}
