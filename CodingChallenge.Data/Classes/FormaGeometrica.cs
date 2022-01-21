/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Collections;
using CodingChallenge.Data.Internacionalizacion;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        private static Dictionary<string, string> _etiquetasReporteDic = new Dictionary<string, string>();

        #endregion

        protected readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        /// <summary>
        /// Se hizo este metodo como para que sea accesible desde el constructor.
        /// </summary>
        /// <param name="ci"></param>
        public static void DefinirLenguajeYRecursos(CultureInfo ci)
        {
            ResXResourceReader _recursoIdiomas = null;

            switch (ci.Name)
            {
                case "en-US":
                    _recursoIdiomas = new ResXResourceReader(@".\CodingChallenge.Data.Internacionalizacion\FormaGeometrica.en-US.resx");
                    break;
                case "es-ES":
                case "es-MX":
                    _recursoIdiomas = new ResXResourceReader(@".\CodingChallenge.Data.Internacionalizacion\FormaGeometrica.es-ES.resx");
                    break;
                default:
                    _recursoIdiomas = new ResXResourceReader(@".\CodingChallenge.Data.Internacionalizacion\FormaGeometrica.resx");
                    break;
            }

            CargarEtiquetasReporte(_recursoIdiomas);
        }

        private static void CargarEtiquetasReporte(ResXResourceReader _recursoIdiomas)
        {
            foreach (DictionaryEntry d in _recursoIdiomas)
                _etiquetasReporteDic.Add(d.Key.ToString(), d.Value.ToString());
        }

        public static string Imprimir(List<FormaGeometrica> formas)
        {

            var sb = new StringBuilder();

            if (!formas.Any())
                sb.Append(_etiquetasReporteDic["ReporteListaVacia"]);
            else
            {
                // Hay por lo menos una forma

                //  ************************** HEADER ************************** 
                sb.Append(_etiquetasReporteDic["ReporteTitulo"]);

                for (var i = 0; i < formas.Count; i++)
                {
                    decimal area = formas[i].CalcularArea();
                    decimal perimetro = formas[i].CalcularPerimetro();

                    formas[i].Set_AreaTotal(area);
                    formas[i].Set_PerimetroTotal(perimetro);
                    formas[i].Set_Cantidad(1);
                }

                // Variables de totales sumando todas las figuras:
                decimal totalArea = 0, totalPerimetro = 0, totalCantidad = 0;

                // Recorro las diferentes formas y directamente voy acumulando area, perimetro y cantidad en las clases heredadas.
                foreach (var unGrupo in formas.GroupBy(x => x.Tipo))
                {
                    int totalGenerico = formas.FindAll(x => x.Tipo == unGrupo.Key).ToList().Count;
                    FormaGeometrica unaForma = formas.Find(x => x.Tipo == unGrupo.Key);
                    sb.Append(ObtenerLinea(totalGenerico, unaForma.Get_AreaTotal(), unaForma.Get_PerimetroTotal(), unaForma, CultureInfo.CurrentCulture));

                    totalArea += unaForma.Get_AreaTotal();
                    totalPerimetro += unaForma.Get_PerimetroTotal();
                    totalCantidad += unaForma.Get_Cantidad();
                }

                // ************************** FOOTER **************************
                sb.Append("TOTAL:<br/>");
                sb.Append(totalCantidad + " " + _etiquetasReporteDic["ReporteFormas"] + " ");

                sb.Append(_etiquetasReporteDic["ReportePerimetro"] + " " + (totalPerimetro).ToString("#.##") + " ");
                sb.Append("Area " + (totalArea).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometrica tipo, CultureInfo ci)
        {
            if (cantidad > 0)
                return $"{cantidad} {tipo.TraducirForma(cantidad, _etiquetasReporteDic)} | Area {area:#.##} | " + _etiquetasReporteDic["ReportePerimetro"] + $"{ perimetro: #.##} <br/>";

            return string.Empty;
        }

        public abstract string TraducirForma(int cantidad, Dictionary<string, string> _etiquetasReporteDic);

        public abstract int Get_Cantidad();

        public abstract void Set_Cantidad(int cant);

        #region Metodos Area 

        public abstract decimal CalcularArea();

        public abstract void Set_AreaTotal(decimal area_a_sumar);

        public abstract decimal Get_AreaTotal();

        #endregion Metodos Area 

        #region Metodos Perimetro

        public abstract decimal CalcularPerimetro();

        public abstract void Set_PerimetroTotal(decimal area_a_sumar);

        public abstract decimal Get_PerimetroTotal();

        #endregion Metodos Perimetro        
    }
}
