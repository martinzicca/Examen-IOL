using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private static int _cantidad = 0;
        private static decimal _areaSumada = 0;
        private static decimal _perSumado = 0;

        public Cuadrado(int tipo, decimal ancho) : base(tipo, ancho)
        {
        }

        public override string TraducirForma(int cantidad, Dictionary<string, string> _etiquetasReporteDic)
        {            
            if(cantidad == 1)
                return _etiquetasReporteDic["CuadradoSingular"];
            else
                return _etiquetasReporteDic["CuadradoPlural"];
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
            return base._lado * base._lado;
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
            return _lado * 4;
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
