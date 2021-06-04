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

                     if (horaInicio.Minutes != 0 || horaFin.Minutes != 0)
                        validaciones.Add("ERROR Horano ");

                    if (!(horaInicio >= Dominio.horarios["MananaHoraInicio"] && horaFin <= Dominio.horarios["MananaHoraFin"]
                        || horaInicio >= Dominio.horarios["TardeHoraInicio"] && horaFin <= Dominio.horarios["TardeHoraFin"]
                        || horaInicio >= Dominio.horarios["NocheHoraInicio"] && horaFin <= Dominio.horarios["NocheHoraFin"]))
                        validaciones.Add("ERROR CON AL MENOS UN DATO QUE NO SE ENCUENTRA ENTRE SOLO UN RANGO DE HORAS ESPECÍFICO.");
                    if (horaInicio > horaFin)
                    {
                        validaciones.Add("ERROR LA HORA FIN ES MENOR A LA HORA DE INICIO.");
                        break;
                    }
                    var we = (Dias)Enum.Parse(typeof(Dias), item.Substring(0, 2));
                }
            }
            catch (ArgumentException w)
            {
                validaciones.Add("ERROR CON AL MENOS UN DÍA.");
            }
            catch (Exception e)
            {
                validaciones.Add("ERROR CON LA HORA DE AL MENOS UN DATO.");
            }
            return validaciones;
        }
    }
}
