using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class HuespedBL
    {
        HuespedDA oHuespedDA;
        public HuespedBL()
        {
            oHuespedDA = new HuespedDA();
        }

        public List<HuespedBE> ListarHuespedPorIdReserva(int idReserva) {
            try
            {
                return oHuespedDA.ListarHuespedPorIdReserva(idReserva);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<HuespedBE> ListarHuespedes() {
            try
            {
                return oHuespedDA.ListarHuespedes() ;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<HuespedBE> BuscarHuespedPorIdReserva(int idReserva) {
            try
            {
                return oHuespedDA.BuscarHuespedPorIdReserva(idReserva);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
