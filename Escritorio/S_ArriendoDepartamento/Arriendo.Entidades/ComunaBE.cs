using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class ComunaBE
    {
        /*
           P * ID_COMUNA NUMBER
           * NOMBRE_COMUNA VARCHAR2 (80)
           F * PROVINCIA_ID NUMBER
        */
        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }
        public ProvinciaBE Provincia { get; set; }
        public ComunaBE()
        {
            Provincia = new ProvinciaBE();
        }
    }
}
