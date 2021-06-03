using System;

namespace IOET.Ejercicio1
{
    public class DiaHoras
    {
        public DiaHoras(string nombre, string rango)
        {
            Nombre = nombre;
            Rango = rango;
        }
        public string Nombre { get; set; }
        public string Rango { get; set; }
        public TimeSpan HoraInicio
        {
            get
            {
                return Convert.ToDateTime(Rango.Split('-')[0]).TimeOfDay;
            }
        }
        public TimeSpan HoraFin
        {
            get
            {
                return Convert.ToDateTime(Rango.Split('-')[1]).TimeOfDay;
            }
        }

        public Dias Dia
        {
            get
            {
                try
                {
                    return (Dias)Enum.Parse(typeof(Dias), Nombre);
                }
                catch (Exception e)
                {
                    return Dias.DF;
                }
            }
        }
    }
}

