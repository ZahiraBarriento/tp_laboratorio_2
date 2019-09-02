using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region "Atributos"

        /// <summary>
        /// Atributo de la clase Numero
        /// </summary>
        private double numero;

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Propiedad de solo escritura que valida el numero
        /// Será el único en todo el código que llame al método ValidarNumero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Inicializa los campos pasados como parametros con sus respectivos valores
        /// </summary>
        /// <param name="strNumero"> String a ser cargado</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Inicializa los campos pasado como parametros con sus respectivos valores.
        /// </summary>
        /// <param name="dbNumero"> Double a ser cargado</param>
        public Numero(double dbNumero) : this(dbNumero.ToString())
        {

        }

        /// <summary>
        /// Constructor por defecto asignará valor 0 al atributo numero.
        /// </summary>
        public Numero() : this(0)
        {

        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Metodo que comprobará que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero"> Valor recibido a ser cambiado</param>
        /// <returns> Retornará el numero en formato double. Caso contrario, retornará 0. </returns>
        private static double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double dbNumero);

            return dbNumero;
        }

        /// <summary>
        /// Metodo que convertirá un número binario a decimal.
        /// </summary>
        /// <param name="binario"> Numero a ser pasado a decimal </param>
        /// <returns> Retornara el numero pasado a decimal, si no posible retornará "Valor inválido". </returns>
        public static string BinarioDecimal(string binario)
        {

            int numero = binario.Length;
            double decimalBin = 0;
            string retorno = "0";
            int i;
            byte n;

            if (Convert.ToDouble(binario) >= 0)
            {
                for (i = 1; i <= numero; i++)
                {
                    n = byte.Parse(binario.Substring(numero - i, 1));

                    if (n == 1)
                    {
                        decimalBin += System.Math.Pow(2, i - 1);
                    }
                }

                retorno = Convert.ToString(decimalBin);
            }

            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que convertirá un número binadecimal a binario.
        /// </summary>
        /// <param name="numero"> Numero a ser pasado a binario </param>
        /// <returns> Retornara el numero pasado a binario, si no posible retornará "Valor inválido". </returns>
        public static string DecimalBinario(double numero)
        {
            string cadena = "";

            double aux;

            aux = Math.Floor(numero);

            if (aux > 0)
            {
                cadena = (aux % 2).ToString() + cadena;
                aux = (int)aux / 2;

            }

            return cadena;
        }

        /// <summary>
        /// Metodo que convertirá un número binadecimal a binario.
        /// </summary>
        /// <param name="numero"> Numero a ser pasado a binario </param>
        /// <returns> Retornara el numero pasado a binario, si no posible retornará "Valor inválido". </returns>
        public static string DecimalBinario(string numero)
        {
            return DecimalBinario(Convert.ToDouble(numero));
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Metodo que sumara dos numeros
        /// </summary>
        /// <param name="num1"> Primer numero a operar </param>
        /// <param name="num2"> Segundo numero a operar </param>
        /// <returns> Retornara el resultado de la suma </returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Metodo que restara dos numeros
        /// </summary>
        /// <param name="num1"> Primer numero a opearar </param>
        /// <param name="num2"> Segundo numero a operar </param>
        /// <returns> Retornara el resultado de la resta </returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Mertodos que multiplicara dos numeros
        /// </summary>
        /// <param name="num1"> Primer numero a operar </param>
        /// <param name="num2"> Segundo numero a operar </param>
        /// <returns> Retornara el resultado de la multiplicacion </returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Metodo que dividida dos numeros 
        /// Si se tratara de una división por 0, retornará double.MinValue
        /// </summary>
        /// <param name="num1"> Primer numero a operar </param>
        /// <param name="num2"> Segundo numero a operar </param>
        /// <returns> Retornara el resultado de la division</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double resultado;

            if (num2.numero == 0)
                resultado = double.MinValue;
            else
                resultado = num1.numero / num2.numero;

            return resultado;
        }

        #endregion
    
    }
}