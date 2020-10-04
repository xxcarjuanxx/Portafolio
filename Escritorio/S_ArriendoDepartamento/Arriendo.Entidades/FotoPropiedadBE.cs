using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class FotoPropiedadBE
    {
        /*
            P * ID_FOTO_PROPIEDAD NUMBER
            * IMAGEN_PROPIEDAD BLOB
            F * PROPIEDAD_ID NUMBER
         */
        public int IdFotoPropiedad { get; set; }
        public string ImagenPropiedad { get; set; }
        public PropiedadBE Propiedad { get; set; }
        public FotoPropiedadBE()
        {
            Propiedad = new PropiedadBE();
        }
    }
}
