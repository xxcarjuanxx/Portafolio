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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
