using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
    
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
        }

        #region "Botones"
        /// <summary>
        /// Boton agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrakingID.Text);
            p.InformaEstado += paq_InformaEstado;

            try
            {
                correo += p;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                this.ActualizarDatos();
            }

        }

        /// <summary>
        /// Boton Mostrar Todos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Actualizara el listado
        /// </summary>
        private void ActualizarDatos()
        {
            //Primero se limpiaran los 3 listBox
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            //recorrerá la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
            foreach (Paquete auxPaquete in correo.Paquetes)
            {
                switch (auxPaquete.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(auxPaquete);
                        break;

                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(auxPaquete);
                        break;

                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(auxPaquete);
                        break;

                }
            }

        }

        /// <summary>
        /// Mostrara la informacion del paquete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Llamara al metodo ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarDatos();
            }

        }
        #endregion
    }
}
