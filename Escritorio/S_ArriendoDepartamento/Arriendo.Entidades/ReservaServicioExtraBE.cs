using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ReservaServicioExtraBE
    {
        /*
        PF* RESERVA_ID NUMBER
        PF* SERVICIO_EXTRA_ID NUMBER
        *   FECHA_INSC_SERVICIO DATE
         */
        public ReservaBE Reserva { get; set; }
        public ServicioExtraBE ServicioExtra { get; set; }
        public DateTime FechaInscServicio { get; set; }
        public ReservaServicioExtraBE()
        {
            Reserva = new ReservaBE();
            ServicioExtra = new ServicioExtraBE();

        }
    }
}
