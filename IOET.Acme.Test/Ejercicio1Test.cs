using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IOET.Ejercicio1.Test
{
    [TestClass]
    public class Ejercicio1Test
    {
        [TestMethod]
        public void EjecutarTest()
        {
            Dominio dominio = new Dominio();
            string archivo = "data_empleado1.txt";
            dominio.Ejecutar(archivo);
        }
        [TestMethod]
        public void ValidarTest()
        {
            Validaciones validaciones = new Validaciones();
            int longitud = 13;
            List<string> registros = new List<string> { "MO01:00-03:00", "WE20:00-21:00" };
            List<string> resultado = validaciones.Validar(registros, longitud);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalculoTest()
        {
            Dominio dominio = new Dominio();
            DiaHoras data = new DiaHoras("MO", "04:00-08:00");
            int resultado = dominio.Calculo(data);
            Assert.IsNotNull(resultado);
        }
    }
}
