using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Business.Logic
{
    public class Validaciones
    {
        public static Boolean EsMailValido(string email)
        {
            string expresion = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@(([a-zA-Z]+[\w-]+\.){1,2}[a-zA-Z]{2,4})$";
            return Regex.IsMatch(email, expresion);
        }

        public static Boolean EsFechaValida(string fecha)
        {
            string expresion = @"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})";
            return Regex.IsMatch(fecha, expresion);
        }
        public static Boolean EsClaveValida(string clave)
        {
            string expresion = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(clave, expresion);
        }






    }
}
