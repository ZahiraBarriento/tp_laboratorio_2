using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region "Atributos"
        /// <summary>
        /// Atributos de la clase PaqueteDAO
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de PaqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.correo_sp_2017);
            PaqueteDAO.comando = new SqlCommand();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Guardara los datos de un paquete en la base de datos
        /// </summary>
        /// <param name="p"> Paquete a guardar </param>
        /// <returns> Retornara true si los datos fueron guardados, de lo contrario false </returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {

                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
                PaqueteDAO.comando.CommandText = "INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno)  VALUES ('" + p.DireccionEntrega + "' , '" + p.TrackingID + "','Zahira Barriento' )";

                PaqueteDAO.conexion.Open();

                if (PaqueteDAO.comando.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }

            return retorno;
        }
        #endregion
    }
}
