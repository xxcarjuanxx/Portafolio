using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ProvinciaBE
    {
        /*
          P * ID_PROVINCIA NUMBER
            * NOMBRE_PROVINCIA VARCHAR2 (70)
            F * REGION_ID NUMBER
         */
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public RegionBE Region { get; set; }
        public ProvinciaBE()
        {
            Region = new RegionBE();
        }
    }
}
