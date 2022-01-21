using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private static int _cantidad = 0;
        private static decimal _areaSumada = 0;
        private static decimal _perSumado = 0;

        public Circulo(int tipo, decimal ancho) : base(tipo, ancho)
        {
        }

        public override string TraducirForma(int cantidad, Dictionary<string, string> _etiquetasReporteDic)
        {
            if (cantidad == 1)
                return _etiquetasReporteDic["CirculoSingular"];
            else
                return _etiquetasReporteDic["CirculoPlural"];
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
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
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
            return (decimal)Math.PI * _lado;
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
