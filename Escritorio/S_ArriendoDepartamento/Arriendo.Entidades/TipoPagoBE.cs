using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class TipoPagoBE
    {
        /*
         P * ID_TIPO_PAGO NUMBER
            NOMBRE_TIPO_PAGO VARCHAR2 (100)
         */
        public int IdTipoPago { get; set; }
        public string NombreTipoPago { get; set; }
    }
}
