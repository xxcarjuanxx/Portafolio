using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class MultaBE
    {
        /*
         P *ID_MULTA NUMBER
            DESCRIPCION_MULTA VARCHAR2 (255 BYTE)
            VALOR_MULTA NUMBER
         */
        public int IdMulta { get; set; }
        public string DescripcionMulta { get; set; }
        public int ValorMulta { get; set; }
    }
}
