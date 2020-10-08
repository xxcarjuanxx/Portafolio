using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class HuespedBE
    {
        /*
          P * RUT_HUESPED NUMBER
            * DV_HUESPED CHAR (1)
            * NOMBRES_HUESPED VARCHAR2 (150)
            * APELLIDOS_HUESPED VARCHAR2 (150)
            TELEFONO_HUESPED NUMBER
            PF* RESERVA_ID NUMBER
         */
        public int RutHuesped { get; set; }
        public bool IsSelected { get; set; }
        public char DvHuesped { get; set; }
        public string NombreHuesped { get; set; }
        public string ApellidosHuesped { get; set; }
        public int TelefonoHuesped { get; set; }
        public ReservaBE Reserva { get; set; }
        public HuespedBE()
        {
            Reserva = new ReservaBE();
        }
    }
}
