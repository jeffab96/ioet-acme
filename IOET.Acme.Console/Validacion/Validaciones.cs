using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Ejercicio1
{
    public class Validaciones
    {
        public List<string> Validar(List<string> registros, int longitudData)
        {
            List<string> validaciones = new List<string>();
            if (registros.Any(a => a.Length != longitudData))
                validaciones.Add("ERROR CON LA LONGITUD DE AL MENOS UN DATO");
            try
            {
                foreach (string item in registros)
                {
                    List<string> temp = item.Substring(2).Split('-').ToList();
                    var horaInicio = Convert.ToDateTime(temp[0]).TimeOfDay;
                    var horaFin = Convert.ToDateTime(temp[1]).TimeOfDay;
                    if (horaInicio > horaFin)
                    {
                        validaciones.Add("INCOHERENCIA ENTRE LAS HORAS DE INICIO Y FIN");
                        break;
                    }
                    var we = (Dias)Enum.Parse(typeof(Dias), item.Substring(0, 2));
                }
            }
            catch (ArgumentException w)
            {
                validaciones.Add("ERROR CON AL MENOS UN DÍA");
            }
            catch (Exception e)
            {
                validaciones.Add("ERROR CON LA HORA DE AL MENOS UN DATO");
            }
            return validaciones;
        }
    }
}
