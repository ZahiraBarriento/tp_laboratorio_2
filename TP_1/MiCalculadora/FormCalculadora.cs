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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }
        
        /// <summary>
        /// Boton operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Boton limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

        /// <summary>
        /// Boton convertir a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;

            resultado = Numero.DecimalBinario(lblResultado.Text);

            if (resultado == "")
            {
                resultado = "Valor invalido";
                btnConvertirADecimal.Enabled = false;//Cancelo las opciones convertir
                btnConvertirABinario.Enabled = false;
            }

            if (resultado == "Valor inválido")
            {
                resultado = "Valor invalido";
                btnConvertirADecimal.Enabled = false;//Cancelo las opciones convertir
                btnConvertirABinario.Enabled = false;
            }

            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;

            lblResultado.Text = resultado;

        }

        /// <summary>
        /// Boton convertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado;

            if (lblResultado.Text == "Valor invalido")
            {
                btnConvertirABinario.Enabled = false;
                lblResultado.Text = "Valor invalido";
                btnConvertirADecimal.Enabled = false;
            }

            else
            {
                resultado = Numero.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultado;
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
        }

        #region "Metodos"

        /// <summary>
        /// Metodo limpiar que borrará los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Método estatico Operar será estático, este llama al método Operar de Calculadora
        /// </summary>
        /// <param name="numero1"> Primer numero a operar </param>
        /// <param name="numero2"> Segundo numero a operar </param>
        /// <param name="operador"> Operador a ser cargado </param>
        /// <returns> Retornar el resultado al método de evento del botón btnOperar que reflejará el resultado en el Label txtResultado. </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero operando1 = new Numero(numero1);
            Numero operando2 = new Numero(numero2);

            return Calculadora.Operar(operando1, operando2, operador);
        }

        #endregion
    }
}
