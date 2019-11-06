using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciales;
using Excepciones;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalido()
        {
            Alumno alumno = new Alumno(5, "Roberto", "Gimenez", "42537186", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesor()
        {
            Universidad universidad = new Universidad();
            universidad += Universidad.EClases.Laboratorio;
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Alumno alumno = new Alumno(1, "martin", "Martinez", "654f621", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetido()
        {
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Roberto", "Gimenez", "92537186", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            Alumno alumno2 = new Alumno(2, "Roberto", "Gimenez", "92537186", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            universidad += alumno1;
            universidad += alumno2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivo()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("UniversidadNoExite.xml", out universidad);
        }

        [TestMethod]
        public void TestIsNotNull()
        {
            //Creo un nuevo alumno que sera el que va ser evaluado
            Alumno alumno = new Alumno(5, "Roberto", "Gimenez", "41526863", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);

            //Valido que todos los campos no sean null
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.Nombre);
            Assert.IsNotNull(alumno.DNI);
            Assert.IsNotNull(alumno.Nacionalidad);
        }

        [TestMethod]
        public void TestIsNumber()
        {
            Alumno alumno = new Alumno(9, "Carlos", "Pelegrini", "90587159", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }
    }
}
