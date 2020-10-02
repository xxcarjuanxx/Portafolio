using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class PropiedadInventarioBE
    {
        /*
            PF* PROPIEDAD_ID NUMBER
            PF* INVENTARIO_ID NUMBER
            * CANTIDAD NUMBER
            * FECHA_ASIGNACION DATE
         */
        public PropiedadBE Propiedad { get; set; }
        public InventarioBE Inventario { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public PropiedadInventarioBE()
        {
            Propiedad = new PropiedadBE();
            Inventario = new InventarioBE();
        }
    }
}
