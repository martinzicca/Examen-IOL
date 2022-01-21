using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        private decimal _altura = 0;

        private static int _cantidad = 0;
        private static decimal _areaSumada = 0;
        private static decimal _perSumado = 0;

        public Rectangulo(int tipo, decimal ancho, decimal altura) : base(tipo, ancho)
        {
            if (altura == ancho)
                throw new Exception("No es un rectangulo, es un cuadrado.");

            _altura = altura;
        }

        public override string TraducirForma(int cantidad, Dictionary<string, string> _etiquetasReporteDic)
        {           
            if (cantidad == 1)
                return _etiquetasReporteDic["RectanguloSingular"];
            else
                return _etiquetasReporteDic["RectanguloPlural"];
        }

        public override int Get_Cantidad()
        {
            return _cantidad;
        }

        public override void Set_Cantidad(int cant)
        {
            _cantidad += cant;
        }

        #region Metodos Area

        public override decimal CalcularArea()
        {
            return (decimal)base._lado * _altura;
        }

        public override void Set_AreaTotal(decimal area_a_sumar)
        {
            _areaSumada += area_a_sumar;
        }

        public override decimal Get_AreaTotal()
        {
            return _areaSumada;
        }

        #endregion Metodos Area

        #region Metodos Perimetro

        public override decimal CalcularPerimetro()
        {
            return (decimal)2 * _altura + 2 * base._lado;
        }

        public override void Set_PerimetroTotal(decimal per_a_sumar)
        {
            _perSumado += per_a_sumar;
        }

        public override decimal Get_PerimetroTotal()
        {
            return _perSumado;
        }
        
        #endregion Metodos Perimetro
    }
}
