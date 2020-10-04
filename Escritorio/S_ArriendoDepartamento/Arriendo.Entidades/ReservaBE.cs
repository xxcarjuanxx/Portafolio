using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ReservaBE
    {
        /*
            ID_RESERVA NUMBER
            CANTIDAD_PERSONAS NUMBER
            CANTIDAD_DIAS NUMBER
            FECHA_RESERVA DATE
            FECHA_ENTRADA DATE
            FECHA_SALIDA DATE
            MONTO_ACTICIPO NUMBER
            MONTO_A_PAGAR NUMBER
            MONTO_TOTAL NUMBER
            * ESTADO_RESERVA CHAR (3)
            F * PROPIEDAD_ID NUMBER
            F * TIPO_PAGO_ID NUMBER
            F * USUARIO_RUT NUMBER
            F * USUARIO_ROL 
             */
        public int IdReserva { get; set; }
        public bool IsSelected { get; set; }
        public int CantidadPersonas { get; set; }
        public int CantidadDias { get; set; }
        private string _fechaReserva;
        public string FechaReserva
        {
            get { return _fechaReserva; }
            set {
                _fechaReserva = value;
               
            }
        }

        private string _fechaEntrada;
        public string FechaEntrada
        {
            get { return _fechaEntrada; }
            set {
                _fechaEntrada = value;
              
            }
        }

        private string _fechaSalida;

        public string FechaSalida
        {
            get { return _fechaSalida; }
            set {
                _fechaSalida = value;
               
            }
        }


        public int MontoAnticipo { get; set; }
        public int MontoPagar { get; set; }
        public int MontoTotal { get; set; }

        private string _estadoReserva;
        public string EstadoReserva
        {
            get { return _estadoReserva; }
            set {
                _estadoReserva = value;
                switch (_estadoReserva.ToLower())
                {
                    case "res":
                        _estadoReserva = "Reservado";
                        break;
                    case "can":
                        _estadoReserva = "Cancelado";
                        break;
                    case "pag":
                        _estadoReserva = "Pagado";
                        break;
                    default:
                        _estadoReserva = "";
                        break;
                }

            }
        }

        public PropiedadBE Propiedad { get; set; }
        public TipoPagoBE TipoPago { get; set; }
        public UsuarioBE Usuario { get; set; }
        public RolBE Rol { get; set; }
        public ReservaBE()
        {
            this.IsSelected = false;
            Propiedad = new PropiedadBE();
            TipoPago = new TipoPagoBE();
            Usuario = new UsuarioBE();
            Rol = new RolBE();
        }
    }
}
