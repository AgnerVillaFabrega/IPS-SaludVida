using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimenSubsidiado : LiquidacionCuotaModeradora
    {
        public RegimenSubsidiado() { }
        public RegimenSubsidiado(string numeroLiquidacion, string indentificacion, string tipoAfiliacion, decimal salarioPaciente, decimal valorServicio) : base(numeroLiquidacion, indentificacion, tipoAfiliacion, salarioPaciente, valorServicio)
        {
        }

        public override void CalcularTarifa()
        {
            Tarifa = 0.5M;
        }

        public override void CalcularTope()
        {
            TopeMax = 200000;
        }
    }
}
