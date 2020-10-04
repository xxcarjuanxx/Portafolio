using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ServicioExtraBE
    {
        /*
          * ID_SERVICIO NUMBER
            DESCRIPCION_SERVICIO VARCHAR2 (255)
            VALOR_SERVICIO NUMBER
            CANTIDAD_PERSONAS NUMBER
            VALOR_TOTAL_SERVICIO NUMBER
            F * PROPIEDAD_ID NUMBER
            F * ESTADO_SERVICIO_ID NUMBER
         */
        public int IdServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public int ValorServicio { get; set; }
        public int CantidadPersonas { get; set; }
        public int ValorTotalServicio { get; set; }
        public PropiedadBE Propiedad { get; set; }
        public EstadoServicioBE EstadoServicio { get; set; }
        public ServicioExtraBE()
        {
            Propiedad = new PropiedadBE();
            EstadoServicio = new EstadoServicioBE();
        }
    }
}
