using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class MotivoCancelacionBE
    {
        /*
         P *ID_MOTIVO NUMBER
            DESCRIPCION_MOTIVO VARCHAR2 (200)
            ESTADO_MOTIVO CHAR (1)
         */
        public int IdMotivo { get; set; }
        public string DescripcionMotivo { get; set; }
        public char EstadoMotivo { get; set; }
    }
}
