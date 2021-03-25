using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimenContibutivo : LiquidacionCuotaModeradora
    {
        public RegimenContibutivo() { }
        public RegimenContibutivo(string numeroLiquidacion, string indentificacion, string tipoAfiliacion, decimal salarioPaciente, decimal valorServicio) : base(numeroLiquidacion, indentificacion, tipoAfiliacion, salarioPaciente, valorServicio)
        {
        }
        public override void CalcularTarifa()
        {
            if (SalarioDevengadoPaciente < 2)
                Tarifa = 0.15M;
            else if (SalarioDevengadoPaciente >= 1 && SalarioDevengadoPaciente <= 5)
                Tarifa = 0.20M;
            else if (SalarioDevengadoPaciente > 5)
                Tarifa = 0.25M;
        }

        public override void CalcularTope()
        {
            if (SalarioDevengadoPaciente < 2)
                TopeMax =250000;
            else if (SalarioDevengadoPaciente >= 1 && SalarioDevengadoPaciente <= 5)
                TopeMax =900000;
            else if (SalarioDevengadoPaciente > 5)
                TopeMax = 1500000;
        }
    }
}
