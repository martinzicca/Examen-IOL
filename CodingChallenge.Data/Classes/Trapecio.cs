using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private decimal _baseMayor = 0;
        private decimal _altura = 0;

        private static int _cantidad = 0;
        private static decimal _areaSumada = 0;
        private static decimal _perSumado = 0;

        public Trapecio(int tipo, decimal ancho, decimal altura, decimal baseMayor) : base(tipo, ancho)
        {
            if (baseMayor <= ancho)
                throw new Exception("La base mayor no puede ser menor a la base menor.");

            _altura = altura;
            _baseMayor = baseMayor;
        }

        public override string TraducirForma(int cantidad, Dictionary<string, string> _etiquetasReporteDic)
        {
            if (cantidad == 1)
                return _etiquetasReporteDic["TrapecioSingular"];
            else
                return _etiquetasReporteDic["TrapecioPlural"];
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
            return (_baseMayor + base._lado) * _altura / 2;
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
            return (decimal)_baseMayor + base._lado + 2 * _altura;
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
