using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ReservaCanceladaBE
    {
        /*
          P * ID_RESERVA_CANCELADA NUMBER
            * FECHA_CANCELACION DATE
            * CANTIDAD_DIAS NUMBER
            * FECHA_RESERVA DATE
            * FECHA_ENTRADA DATE
            * FECHA_SALIDA DATE
            * MONTO_ACTICIPO NUMBER
            * PORCENTAJE_MULTA NUMBER
            * MONTO_MULTA NUMBER
            * ESTADO_RESERVA CHAR (3)
              OBSERVACION_CANCELACION VARCHAR2 (255 BYTE)
            * RESERVA_ID NUMBER
            * PROPIEDAD_ID NUMBER
            * USUARIO_RUT NUMBER
            * TIPO_PAGO_ID NUMBER
            F * MOTIVO_CANCELACION_ID NUMBER
         */
        public int IdReservaCancelada { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public int CantidadDias { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int MontoAnticipo { get; set; }
        public int PorcentajeMulta { get; set; }
        public int MontoMulta { get; set; }
        public char EstadoReserva { get; set; }
        public string ObservacionCancelacion { get; set; }
        public int Reserva { get; set; }
        public int Propiedad { get; set; }
        public int Usuario { get; set; }
        public int TipoPago { get; set; }
        public MotivoCancelacionBE MotivoCancelacion { get; set; }

        public ReservaCanceladaBE()
        {
            MotivoCancelacion = new MotivoCancelacionBE();
        }
    }
}
