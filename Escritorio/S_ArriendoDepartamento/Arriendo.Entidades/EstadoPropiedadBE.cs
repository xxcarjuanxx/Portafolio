using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class EstadoPropiedadBE
    {
        /*
          P * ID_ESTADO_PROPIEDAD NUMBER
            * DESCRIPCION_ESTADO VARCHAR2 (100)
         */
        public int IdEstadoPropiedad { get; set; }
        public string DescripcionEstado { get; set; }
        public EstadoPropiedadBE()
        {

        }
    }
}
