using System;
using System.Collections.Generic;
using System.Globalization;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES"); // usa recurso en castellano
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture); 

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US"); // usa recurso en ingles
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES"); // usa recurso en castellano
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            var cuadrados = new List<FormaGeometrica> { new Cuadrado(FormaGeometrica.Cuadrado, 5) };
            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(FormaGeometrica.Cuadrado, 5),
                new Cuadrado(FormaGeometrica.Cuadrado, 1),
                new Cuadrado(FormaGeometrica.Cuadrado, 3)
            };

            CultureInfo.CurrentCulture = new CultureInfo("en-US"); // usa recurso en ingles
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {           
            CultureInfo.CurrentCulture = new CultureInfo("en-US"); // usa recurso en ingles
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(FormaGeometrica.Cuadrado, 5),
                new Circulo(FormaGeometrica.Circulo, 3),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 4),

                new Cuadrado(FormaGeometrica.Cuadrado, 2),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 9),
                new Circulo(FormaGeometrica.Circulo, 2.75m),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas).Replace('.', ',');

            Assert.AreEqual("<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
            resumen);

            //Assert.AreEqual(1, 1);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES"); // usa recurso en castellano
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);


            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(FormaGeometrica.Cuadrado, 5),
                new Circulo(FormaGeometrica.Circulo, 3),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 4),
                new Cuadrado(FormaGeometrica.Cuadrado, 2),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 9),
                new Circulo(FormaGeometrica.Circulo, 2.75m),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumen_MartinZicca1()
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES"); // usa recurso en castellano
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            var formas = new List<FormaGeometrica>
            {
                new Rectangulo(FormaGeometrica.Rectangulo, 4,2),
                new Trapecio(FormaGeometrica.Trapecio, 2,5,9)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Reporte de Formas</h1>" +
                            "1 Rectangulo | Area 8 | Perimetro 12 <br/>" +
                            "1 Trapecio | Area 27,5 | Perimetro 21 <br/>" +
                            "TOTAL:<br/>2 formas Perimetro 33 Area 35,5",
            resumen);
        }

        [TestCase]
        public void TestResumen_MartinZicca2()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US"); // usa recurso en ingles
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);


            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(FormaGeometrica.Cuadrado, 5),
                new Circulo(FormaGeometrica.Circulo, 3),
                new TrianguloEquilatero(FormaGeometrica.TrianguloEquilatero, 4),

                new Rectangulo(FormaGeometrica.Rectangulo, 2,7),
                new Rectangulo(FormaGeometrica.Rectangulo, 4,2),

                new Trapecio(FormaGeometrica.Trapecio, 3,1,4)
            };

            var resumen = FormaGeometrica.Imprimir(formas).Replace('.', ',');

            Assert.AreEqual(@"<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>" +
                                                   "1 Circle | Area 7,07 | Perimeter 9,42 <br/>" +
                                                   "1 Triangle | Area 6,93 | Perimeter 12 <br/>" +
                                                   "2 Rectangles | Area 22 | Perimeter 30 <br/>" +
                                                   "1 Trapeze | Area 3,5 | Perimeter 9 <br/>" +

                              "TOTAL:<br/>6 shapes Perimeter 80,42 Area 64,5",
            resumen);
        }

        [TestCase("en-US")]
        public void TestResumen_MartinZicca3(string name)
        {            
            CultureInfo.CurrentCulture = new CultureInfo(name); // usa recurso en ingles
            FormaGeometrica.DefinirLenguajeYRecursos(CultureInfo.CurrentCulture);

            var formas = new List<FormaGeometrica>
            {
                new Rectangulo(FormaGeometrica.Rectangulo, 4,9),
                new Rectangulo(FormaGeometrica.Rectangulo, 8,7),

                new Trapecio(FormaGeometrica.Trapecio, 2,6,7),
                new Trapecio(FormaGeometrica.Trapecio, 4,2,6)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>2 Rectangles | Area 92 | Perimeter 56 <br/>" +
                                                  "2 Trapezes | Area 37 | Perimeter 35 <br/>" +
                                                  "TOTAL:<br/>4 shapes Perimeter 91 Area 129",
            resumen);
        }
    }
}
