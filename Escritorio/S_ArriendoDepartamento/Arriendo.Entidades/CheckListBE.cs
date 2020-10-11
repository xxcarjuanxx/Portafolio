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

        private string _tipoCheck;
        public string TipoCheck
        {
            get { return _tipoCheck; }
            set
            {
                _tipoCheck = value;
                switch (_tipoCheck)
                {
                    case "0":
                        _tipoCheck = "No";
                        break;
                    case "1":
                        _tipoCheck = "Si";
                        break;

                }

            }

        }

        private string _entregaLlave;
        public string EntregaLlave
        {
            get { return _entregaLlave; }
            set
            {
                _entregaLlave = value;
                switch (_entregaLlave)
                {
                    case "0":
                        _entregaLlave = "No";
                        break;
                    case "1":
                        _entregaLlave = "Si";
                        break;

                }

            }
        }

        private string _entregaControlTv;
        public string EntregaControlTv
        {
            get { return _entregaControlTv; }
            set
            {
                _entregaControlTv = value;
                switch (_entregaControlTv)
                {
                    case "0":
                        _entregaControlTv = "No";
                        break;
                    case "1":
                        _entregaControlTv = "Si";
                        break;

                }

            }
        }

        private string _entregaControlAir;
        public string EntregaControlAir
        {
            get { return _entregaControlAir; }
            set
            {
                _entregaControlAir = value;
                switch (_entregaControlAir)
                {
                    case "0":
                        _entregaControlAir = "No";
                        break;
                    case "1":
                        _entregaControlAir = "Si";
                        break;

                }

            }

        }

        private string _recibeRegalo;
        public string RecibeRegalo
        {
            get { return _recibeRegalo; }
            set
            {
                _recibeRegalo = value;
                switch (_recibeRegalo)
                {
                    case "0":
                        _recibeRegalo = "No";
                        break;
                    case "1":
                        _recibeRegalo = "Si";
                        break;

                }

            }
        }
        public ReservaBE Reserva { get; set; }
        
        public CheckListBE()
        {
            Reserva = new ReservaBE();
        }

        public CheckListBE(string tipoCheck, 
            string entregaLlave, 
            string entregaControlTv, 
            string entregaControlAir, 
            string recibeRegalo,
            int reserva)
        {
            Reserva = new ReservaBE();
            this._tipoCheck = tipoCheck;
            this._entregaLlave = entregaLlave;
            this._entregaControlTv = entregaControlTv;
            this._entregaControlAir = entregaControlAir;
            this._recibeRegalo = recibeRegalo;
            this.Reserva.IdReserva = reserva;
        }
    }
}
