using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Metodo privado y estico que valida que el operador
        /// </summary>
        /// <param name="operador"> Operador a ingresar </param>
        /// <returns> Retornara el operador ingresado, si no se ingresa retornara "+" </returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*") 
            {
                retorno = operador;
            }

            else 
            {
                retorno = "+";
            }

            return retorno;
        }

        /// <summary>
        /// Metodo estatico que validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1"> Primer numero a operar </param>
        /// <param name="num2"> Segundo numero a operar </param>
        /// <param name="operador"> Tipo de operardor </param>
        /// <returns> Retornara el resultado </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                default:
                    break;
            }

            return resultado;
        }

    }
}
