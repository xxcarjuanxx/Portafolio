using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class ReservaBL
    {
        ReservaDA oReservaDA;
        public ReservaBL()
        {
            oReservaDA = new ReservaDA();
        }

        public List<ReservaBE> ListarReservas() {
            try
            {
                return oReservaDA.ListarReservas();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ReservaBE> ReservaPorRut(List<ReservaBE> oListReserva, string rut) {
            try
            {
                return oReservaDA.ReservaPorRut(oListReserva, rut);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Registra_Pago_Reserva(ReservaBE reservaBE) {
            try
            {
                await Task.Delay(1000);
                return oReservaDA.Registra_Pago_Reserva(reservaBE);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
