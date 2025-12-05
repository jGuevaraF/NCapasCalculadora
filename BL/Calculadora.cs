using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Calculadora
    {
        //metodos
        public static float Suma(ML.Calcualdora calcualdora)
        {
            calcualdora.Resultado = calcualdora.Numero1 + calcualdora.Numero2;
            return calcualdora.Resultado;
        }
    }
}
