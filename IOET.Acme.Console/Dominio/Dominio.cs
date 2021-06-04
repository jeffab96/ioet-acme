using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Ejercicio1
{
    public class Dominio
    {
        public static readonly Dictionary<string, TimeSpan> horarios = new Dictionary<string, TimeSpan>()
        {
            { "MananaHoraInicio", new TimeSpan(0, 0, 0) },
            { "MananaHoraFin", new TimeSpan(9, 0, 0) },
            { "TardeHoraInicio", new TimeSpan(9, 0, 0)},
            { "TardeHoraFin", new TimeSpan(18, 0, 0)} ,
            { "NocheHoraInicio", new TimeSpan(18, 0, 0)},
            { "NocheHoraFin", new TimeSpan(24, 0, 0)}
        };
        static int longitudData = 13;


        /// <summary>
        /// Método que ejecuta el programa
        /// </summary>
        /// <param name="archivo">El nombre del archivo</param>
        public void Ejecutar(string[] archivo)
        {
            string nombre = archivo.Length != 0 ? archivo[0] : "";
            if (nombre.Length == 0)
                Console.WriteLine("Por favor ingrese un parámetro(archivo) de entrada");
            else
            {
                string text = System.IO.File.ReadAllText(nombre);
                List<string> empleados = text.Split(';').ToList();
                empleados.ForEach(f => Procesamiento(f));
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Método que realiza el procesamiento de un empleado
        /// </summary>
        /// <param name="text">Texto con datos de una persona.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public string Procesamiento(string text)
        {
            string resultado = "";
            List<DiaHoras> datos = new List<DiaHoras>();

            List<string> divisionTexto = text.Split('=').ToList();
            string nombre = divisionTexto[0];
            string data = divisionTexto[1];
            List<string> registros = data.Split(',').ToList();
            registros.ForEach(f => datos.Add(new DiaHoras(f.Substring(0, 2), f.Substring(2))));

            //Se ejecutan las validaciones de cada registro.
            List<string> validaciones = new Validaciones().Validar(registros, longitudData);
            if (validaciones.Count == 0)
            {
                int total = 0;
                for (int i = 0; i < datos.Count; i++)
                {
                    //Realiza el cálculo de cada registro diario.
                    total += Calculo(datos[i]);
                }
                resultado = $"The amount to pay {nombre} is: { total} USD";
                Console.WriteLine(resultado);
            }
            else
            {
                validaciones.ForEach(f => Console.WriteLine(nombre + ":" + f.ToString()));
                resultado = "ERROR";
            }
            return resultado;
        }

        /// <summary>
        /// Se envía un día hora con los daros para el cálculo del valor por el día en base a su hora de inicio y hora fin.
        /// </summary>
        /// <param name="temp">Se envía un día hora con la fecha.</param>
        /// <returns>Retorna el valor del día.</returns>
        public int Calculo(DiaHoras temp)
        {
            int valorHoras = 0;
            int horas = (temp.HoraFin - temp.HoraInicio).Hours;
            if (temp.Dia >= Dias.MO && temp.Dia <= Dias.FR)
            {
                if (temp.HoraInicio >= horarios["MananaHoraInicio"] && temp.HoraFin <= horarios["MananaHoraFin"])
                    valorHoras = horas * (int)ValorHorarioSemana.Manana;
                else if (temp.HoraInicio >= horarios["TardeHoraInicio"] && temp.HoraFin <= horarios["TardeHoraFin"])
                    valorHoras = horas * (int)ValorHorarioSemana.Tarde;
                else if (temp.HoraInicio >= horarios["NocheHoraInicio"] && temp.HoraFin <= horarios["NocheHoraFin"])
                    valorHoras = horas * (int)ValorHorarioSemana.Noche;

            }
            else if (temp.Dia >= Dias.SA && temp.Dia <= Dias.SU)
            {
                if (temp.HoraInicio >= horarios["MananaHoraInicio"] && temp.HoraFin <= horarios["MananaHoraFin"])
                    valorHoras = horas * (int)ValorHorarioFinSemana.Manana;
                else if (temp.HoraInicio >= horarios["TardeHoraInicio"] && temp.HoraFin <= horarios["TardeHoraFin"])
                    valorHoras = horas * (int)ValorHorarioFinSemana.Tarde;
                else if (temp.HoraInicio >= horarios["NocheHoraInicio"] && temp.HoraFin <= horarios["NocheHoraFin"])
                    valorHoras = horas * (int)ValorHorarioFinSemana.Noche;
            }
            return valorHoras;
        }
    }
}
