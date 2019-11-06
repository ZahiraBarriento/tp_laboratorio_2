using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciales
{
    public class Universidad
    {
        #region "Enumerado"
        /// <summary>
        /// Enumerado de los tipos de clases que hay
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos de la clase Universidad
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Get Obtiene la lista de jornadas
        /// SET establece la lista pasada
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Get Obtiene la lista de profesores
        /// SET establece la lista pasada
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Get Obtiene la lista de Alumnos
        /// SET establece la lista pasada
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
        /// Get Obtiene un elemento de la lista de jorganadas por medio de un index
        /// SET establece un elemento a la lista
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];

            }

            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Contrusctor por defecto que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornada = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Muetra los datos de la clase
        /// </summary>
        /// <param name="uni"> Universiada a mostrar </param>
        /// <returns> Retornara los datos de la univerdad dada </returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornada)
            {
                sb.Append(jornada.ToString());
            }

            return sb.ToString();
        }

        ///// <summary>
        ///// Guarda los datos de la clase en un archivo xml
        ///// </summary>
        ///// <param name="uni"> universidad que se desea guardad sus datos</param>
        ///// <returns> Retornara true si pudo hacer el archivo, de lo contrario false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> guardar = new Xml<Universidad>();

            if (guardar.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni))
            {
                retorno = true;
            }

            return retorno;
        }

        ///// <summary>
        ///// Lee los datos de un archivo xml
        ///// </summary>
        ///// <returns> Retornara una universidad con todos sus datos</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> leer = new Xml<Universidad>();
            Universidad u = new Universidad();

            leer.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out u);

            return u;
        }
        #endregion

        #region "Polimorfismo"
        /// <summary>
        /// Muetra los datos de forma publica
        /// </summary>
        /// <returns> Retorna los datos de la Universidad </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Compara si el alumno esta en la universidad
        /// </summary>
        /// <param name="g"> Universidad a comparar </param>
        /// <param name="a"> Alumno a verificar si esta en la universidad </param>
        /// <returns> Retornara true si el alumno esta en la universidad, de lo contrario false </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.alumnos)
            {
                if (a == alumno)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara si el alumno no esta en la universidad
        /// </summary>
        /// <param name="g"> Univerdad a comparar </param>
        /// <param name="a"> Alumno a verificar si esta en la universidad </param>
        /// <returns> Retornara true si el alumno no esta en la universidad, de lo contrario false </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara si el profesor esta dando clases en la universidad
        /// </summary>
        /// <param name="g"> Universidad a comparar </param>
        /// <param name="i"> Profesor a verificar si esta dando clases </param>
        /// <returns> Retornara true si el profesor esta dando clases, de lo contrio false </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profesor in g.profesores)
            {
                if (i == profesor)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara si el profesro no esta dando clases en la universidad
        /// </summary>
        /// <param name="g"> Universidad a comparar </param>
        /// <param name="i"> Profesor a verificar si no esta dando clases en la universidad </param>
        /// <returns> Retornara si el profesor esta dando clases, de lo contrario false </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca un profesor de la universidad que pueda dar esa clase
        /// </summary>
        /// <param name="u"> Universidad con la lista de profesores </param>
        /// <param name="clase"> Clase a comparar </param>
        /// <returns> Retorna el profesor si existe, de lo contrario exception </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor auxProfesor in u.profesores)
            {
                if (auxProfesor == clase)
                {
                    return auxProfesor;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Busca un profesor de la universidad que NO pueda dar esa clase
        /// </summary>
        /// <param name="u"> Universidad con la lista de profesores </param>
        /// <param name="clase"> Clase a comparar </param>
        /// <returns> Retorna el profesor que no pueda dar esa clase </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor auxProfesor in u.profesores)
            {
                if (auxProfesor != clase)
                {
                    retorno = auxProfesor;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agrega una clase a la universidad
        /// </summary>
        /// <param name="g"> universidad</param>
        /// <param name="clase"> clase que se quiere agregar</param>
        /// <returns> Retornara la universidad con sus clases</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProfesor = null;

            try
            {
                auxProfesor = (g == clase);
            }

            catch (Exception)
            {
                throw new SinProfesorException();
            }

            Jornada auxJornada = new Jornada(clase, auxProfesor);

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == clase)
                {
                    auxJornada += auxAlumno;
                }
            }

            g.Jornada.Add(auxJornada);

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad si esta no esta aun en ella.
        /// </summary>
        /// <param name="universidad"> Universidad a donde agregar el alumno </param>
        /// <param name="alumno"> Alumno a ser agregado </param>
        /// <returns> Retornara la universidad con el nuevo alumno su no estaba aun en ella </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(u == a))
            {
                u.alumnos.Add(a);
            }

            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }
        /// <summary>
        /// Agregara un instructor a la universidad si esta no esta aun en ella.
        /// </summary>
        /// <param name="universidad"> Univerdad a donde agregar el instructor </param>
        /// <param name="instructor"> Instructor a ser agregado </param>
        /// <returns> Retornara la universidad con el instructor sin aun no estaba en ella </returns>
        public static Universidad operator +(Universidad universidad, Profesor instructor)
        {
            if (universidad == instructor)
            {
                return universidad;
            }

            universidad.profesores.Add(instructor);

            return universidad;
        }
        #endregion
    }
}
