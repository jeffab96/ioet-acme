using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IOET.Ejercicio1.Test
{
    [TestClass]
    public class Ejercicio1Test
    {
        /// <summary>
        /// Test que recibe registros de días trabajados con sus horas respectivas para calcular el valor a pagar.
        /// </summary>
        [TestMethod]
        public void CalculoTest()
        {
            Dominio dominio = new Dominio();
            int esperado = 120;
            DiaHoras data = new DiaHoras("SA", "01:00-05:00");
            int resultado = dominio.Calculo(data);
            Assert.AreEqual(esperado, resultado);
        }
        /// <summary>
        /// Test que realiza validaciones sobre registro de días y horas enviados.
        /// </summary>
        [TestMethod]
        public void ValidarTest()
        {
            Validaciones validaciones = new Validaciones();
            int longitud = 13;
            List<string> registros = new List<string> { "MO01:00-03:01", "WE20:00-21:00" };
            List<string> resultado = validaciones.Validar(registros, longitud);
            Assert.AreEqual(0, resultado.Count);
        }
        /// <summary>
        /// Test que envía una cadena completa de empleado con registros de días y horas trabajadas.
        /// </summary>
        [TestMethod]
        public void ProcesamientoTest()
        {
            Dominio dominio = new Dominio();
            string esperado = "The amount to pay RENE is: 215 USD";
            string resultado = dominio.Procesamiento("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00");
            Assert.AreEqual(resultado, esperado);
        }
    }
}
