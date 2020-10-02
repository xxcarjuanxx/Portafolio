using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class RegionBE
    {
        /*
          P * ID_REGION NUMBER
            * NOMBRE_REGION VARCHAR2 (80)
            * REGION_ORDINAL VARCHAR2 (5)
             */
        public int IdRegion { get; set; }
        public string NombreRegion { get; set; }
        public string RegionOrdinal { get; set; }// I, II, III, IV, etc
    }
}
