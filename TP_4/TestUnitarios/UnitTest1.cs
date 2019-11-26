using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorreoInstanciado()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void PaquetesIguales()
        {
            try
            {
                Correo correo = new Correo();
                Paquete p1 = new Paquete("abc 123", "1234-123-123");
                Paquete p2 = new Paquete("abc 123", "1234-123-123");
                correo += p1;
                correo += p2;
            }

            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
