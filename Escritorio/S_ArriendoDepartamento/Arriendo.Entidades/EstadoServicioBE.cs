using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class EstadoServicioBE
    {
        /*
         P *ID_ESTADO_SERVICIO NUMBER
            NOMBRE_ESTADO_SERVICIO VARCHAR2 (100)
         */
        public int IdEstadoServicio { get; set; }
        public string NombreEstadoServicio { get; set; }
        public string DescripcionEstadoServicio { get; set; }
    }
}
