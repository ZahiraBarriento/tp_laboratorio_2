using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciales
{
    public class Jornada
    {
        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Jornada
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Get obtiene el alumno
        /// Set establece la lista
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Get obtiene la clase
        /// Set establece una clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Get obtiene el profesor
        /// Set establece el profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region "Constructores"
        //// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos 
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa los campos pasado por parametro
        /// </summary>
        /// <param name="clase"> Clase a ser cargada </param>
        /// <param name="instructor"> Profesor a ser cargado </param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Guarda la jornada pasada como argumento en el archivo
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> Retornara true si lo puede guardar, de lo contrario false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto guardado = new Texto();
            bool retorno = false;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";

            if (guardado.Guardar(path, jornada.ToString()))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo
        /// </summary>
        /// <returns> Retornara un string con los datos leidos</returns>
        public static string Leer()
        {
            string retorno = null;
            Texto texto = new Texto();
            bool validarLectura = texto.Leer("Jornada.txt", out retorno);

            if (validarLectura)
            {
                return retorno;
            }

            return retorno;
        }
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// expone los datos de la jornada
        /// </summary>
        /// <returns> string con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("JORNADA:\n");
            sb.Append("CLASE DE " + this.Clase);
            sb.AppendLine(" POR " + this.Instructor);

            foreach (Alumno auxAlumno in this.Alumnos)
            {
                sb.AppendLine(auxAlumno.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Compara un alumno con una jornada
        /// </summary>
        /// <param name="j"> Jornada a comparar </param>
        /// <param name="a"> Alumno a comparar </param>
        /// <returns> Retornara true si el alumno esta en la jornada, de lo contrario false </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno auxAlumno in j.alumnos)
            {
                if (auxAlumno == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara si el alumno no esta en la jornada
        /// </summary>
        /// <param name="j"> Jornada a comparar </param>
        /// <param name="a"> Alumno a comparar </param>
        /// <returns> Retornara si el alumno no esta en la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si ese alumno  no esta previamente cargado
        /// </summary>
        /// <param name="jornada">jornada</param>
        /// <param name="alumno">alumno a agregar</param>
        /// <returns> Retornara la jornada </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }
        #endregion
    }
}
