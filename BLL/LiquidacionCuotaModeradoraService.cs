using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        private LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;
        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }
        public string Guardar(LiquidacionCuotaModeradora liquidacionCuota)
        {
            try
            {
                if (liquidacionCuotaModeradoraRepository.Buscar(liquidacionCuota.IdentificacionPaciente)==null)
                {
                    liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuota);
                    return "Datos guardados exitosamente";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Se presento el siguiente error: " + e.Message;
            }
        }
        public string Eliminar(string  numeroLiquidacion)
        {
            try
            {
                if (liquidacionCuotaModeradoraRepository.Buscar(numeroLiquidacion) != null)
                {
                    liquidacionCuotaModeradoraRepository.Eliminar(numeroLiquidacion);
                    return $"Se elimino a la liquidacion {numeroLiquidacion}";
                }
                return $"No se encontro a la liquidacion {numeroLiquidacion}";
            }
            catch (Exception exception)
            {
                return "Se presento el siguiente error: " + exception.Message;
            }
        }
        public string Modificar(LiquidacionCuotaModeradora liquidacionBase, LiquidacionCuotaModeradora liquidacionNew)
        {
            try
            {
                if (liquidacionCuotaModeradoraRepository.Buscar(liquidacionBase.NumeroLiquidacion)!=null)
                {
                    liquidacionCuotaModeradoraRepository.Modificar(liquidacionBase, liquidacionNew);
                    return $"Se modifico a la liquidacion con numero {liquidacionBase.NumeroLiquidacion}";
                }
                return $"No se encontro la liquidacion con numero {liquidacionBase.NumeroLiquidacion}";
            }
            catch (Exception exception)
            {
                return "Se presento el siguiente error: " + exception.Message;
            }
        }
        public ConsultaResponse Consultar()
        {
            try
            {
                return new ConsultaResponse(liquidacionCuotaModeradoraRepository.Consultar());
            }
            catch (Exception exception)
            {
                return new ConsultaResponse("Se presento el siguiente error: "+ exception.Message);
            }
        }
        public BusquedaResponse Buscar(string numeroLiquidacion)
        {
            try
            {
                return new BusquedaResponse(liquidacionCuotaModeradoraRepository.Buscar(numeroLiquidacion));
            }
            catch (Exception exception)
            {
                return new BusquedaResponse("Se presento el siguiente error: " + exception.Message);
            }
        }
    }
    #region CLASES RESPONSE
    public class ConsultaResponse
    {
        public List<LiquidacionCuotaModeradora> LiquidacionCuotaModeradoras { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaResponse(List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras)
        {
            LiquidacionCuotaModeradoras = liquidacionCuotaModeradoras;
            Error = false;
        }
        public ConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BusquedaResponse
    {
        public LiquidacionCuotaModeradora LiquidacionCuotaModeradora { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaResponse(LiquidacionCuotaModeradora liquidacion)
        {
            LiquidacionCuotaModeradora = liquidacion;
            Error = false;
        }
        public BusquedaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    #endregion 
}
