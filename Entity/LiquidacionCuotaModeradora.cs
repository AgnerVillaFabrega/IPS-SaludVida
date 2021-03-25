using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora
    {
        public decimal CuotaModeradora { get; set; }
        public string NumeroLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public decimal SalarioDevengadoPaciente { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal Tarifa { get; set; }
        public decimal TopeMax { get; set; }
        public decimal InicioCuotaModeradora { get; set; }

        protected LiquidacionCuotaModeradora()
        {
        }

        protected LiquidacionCuotaModeradora(string numeroLiquidacion, string identificacionPaciente, string tipoAfiliacion, decimal salarioDevengadoPaciente, decimal valorServicio)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdentificacionPaciente = identificacionPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioDevengadoPaciente = salarioDevengadoPaciente;
            ValorServicio = valorServicio;
        }

        public void CalcularCuotaModeradora()
        {
            CalcularTarifa();
            InicioCuotaModeradora = ValorServicio * Tarifa;
            CalcularTope();
            CuotaModeradora = TotalCuotaModeraora();
        }
        public abstract void CalcularTarifa();
        public abstract void CalcularTope();

        public decimal TotalCuotaModeraora()
        {
            if (InicioCuotaModeradora>TopeMax )
            {
                return TopeMax;
            }
            return InicioCuotaModeradora;
        }
        public override string ToString()
        {
            return $"Numero Liquidacion: {NumeroLiquidacion}; Identificacion Paciente {IdentificacionPaciente}; " +
                $"Tipo afiliacion {TipoAfiliacion}; Total Liquidacion {CuotaModeradora}";
        }

    }
}
