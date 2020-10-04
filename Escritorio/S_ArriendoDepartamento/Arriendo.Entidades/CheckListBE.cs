using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class CheckListBE
    {
        /*
        P *ID_CHECK_IN NUMBER
           TIPO_CHECK NUMBER
           ENTREGA_LLAVE NUMBER
           ENTREGA_CONTROL_TV NUMBER
           ENTREGA_CONTROL_AIR NUMBER
           RECIBE_REGALO NUMBER
           F * RESERVA_ID NUMBER
            */
        public int IdCheckIn { get; set; }
        public int TipoCheck { get; set; }
        public int EntregaLlave { get; set; }
        public int EntregaControlTv { get; set; }
        public int EntregaControlAir { get; set; }
        public int RecibeRegalo { get; set; }
        public ReservaBE Reserva { get; set; }
        public CheckListBE()
        {
            Reserva = new ReservaBE();
        }
    }
}
