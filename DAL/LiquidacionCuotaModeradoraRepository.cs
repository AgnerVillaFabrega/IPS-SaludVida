using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string ruta = "LiquidacionCuotaModeradora.txt";
        public void Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(ruta,FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{liquidacionCuotaModeradora.NumeroLiquidacion};{liquidacionCuotaModeradora.IdentificacionPaciente};" +
                $"{liquidacionCuotaModeradora.TipoAfiliacion};{liquidacionCuotaModeradora.SalarioDevengadoPaciente};" +
                $"{liquidacionCuotaModeradora.ValorServicio};{liquidacionCuotaModeradora.Tarifa};" +
                $"{liquidacionCuotaModeradora.InicioCuotaModeradora}");
            writer.Close();
            file.Close();
        }
        public List<LiquidacionCuotaModeradora> Consultar()
        {
            List<LiquidacionCuotaModeradora> ListaliquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine())!=null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = MapearLiquidacion(linea);
                ListaliquidacionCuotaModeradoras.Add(liquidacionCuotaModeradora);
            }
            reader.Close();
            file.Close();
            return ListaliquidacionCuotaModeradoras;
        }
        public static LiquidacionCuotaModeradora MapearLiquidacion(string linea)
        {

            string[] datosLiquiacion = linea.Split(';');
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;
            if (datosLiquiacion[2].ToUpper() == "C")
                liquidacionCuotaModeradora = new RegimenContibutivo();
            else
                liquidacionCuotaModeradora = new RegimenSubsidiado();
            #region Particiones
            liquidacionCuotaModeradora.NumeroLiquidacion = datosLiquiacion[0];
            liquidacionCuotaModeradora.IdentificacionPaciente = datosLiquiacion[1];
            liquidacionCuotaModeradora.TipoAfiliacion = datosLiquiacion[2];
            liquidacionCuotaModeradora.SalarioDevengadoPaciente = decimal.Parse(datosLiquiacion[3]);
            liquidacionCuotaModeradora.ValorServicio = decimal.Parse(datosLiquiacion[4]);
            liquidacionCuotaModeradora.Tarifa = decimal.Parse(datosLiquiacion[5]);
            liquidacionCuotaModeradora.InicioCuotaModeradora = decimal.Parse(datosLiquiacion[6]);
            #endregion

            return liquidacionCuotaModeradora;
        }
        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
            foreach (var item in Consultar())
            {
                if (Encontrado(item.NumeroLiquidacion,numeroLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }
        public bool Encontrado(string IdRegistrada, string IdBuscada)
        {
            return IdRegistrada == IdBuscada;
        } 
        public void Eliminar(string numeroLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = Consultar();
            FileStream File = new FileStream(ruta, FileMode.Create);
            File.Close();
            foreach (var item in liquidacionCuotaModeradoras)
            {
                if (!Encontrado(item.NumeroLiquidacion, numeroLiquidacion))
                {
                    Guardar(item);
                }
                   
            }
        }
        public void Modificar(LiquidacionCuotaModeradora liquidacionBase, LiquidacionCuotaModeradora liquidacionNew)
        {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
            liquidacionCuotaModeradoras = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in liquidacionCuotaModeradoras)
            {
                if (!Encontrado(item.IdentificacionPaciente, liquidacionBase.IdentificacionPaciente))
                    Guardar(item);
                else
                    Guardar(liquidacionNew);
            }
        }

    }
}
