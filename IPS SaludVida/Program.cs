using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace IPS_SaludVida
{
    public class Program
    {
        static void Main(string[] args)
        {
            LiquidacionCuotaModeradoraService liquidacionService = 
                new LiquidacionCuotaModeradoraService();

            LiquidacionCuotaModeradora liquidacionContributivo;
            LiquidacionCuotaModeradora liquidacionSubsidiado;

            string numeroLiquidacion = "45";
            string idPaciente = " 1311234";
            string tipoAfiliacion = "Contributivo";
            decimal salarioPaciente = 4;
            decimal valorSercio = 200000;


            liquidacionContributivo = new RegimenContibutivo(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorSercio) ;
            liquidacionContributivo.CalcularCuotaModeradora();
            Console.WriteLine($"Su liquidacion es: {liquidacionContributivo.CuotaModeradora}");
            Console.WriteLine($"/// Guardando desde Servicio///");
            liquidacionService.Guardar(liquidacionContributivo);
            Console.WriteLine("/// Consultando desde servicio ///");
            ConsultaResponse response = liquidacionService.Consultar();
            if (!response.Error)
            {
                foreach (var item in response.LiquidacionCuotaModeradoras)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.Error);
            }

            Console.WriteLine("/// Eliminando desde servicio ///");
            Console.WriteLine(liquidacionService.Eliminar("123"));
            Console.ReadKey();
   //         liquidacionSubsidiado = new RegimenSubsidiado(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorSercio);
            

        }
    }
}
