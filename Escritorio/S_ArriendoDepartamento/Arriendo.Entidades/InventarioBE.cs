using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class InventarioBE
    {
        /*P * ID_INVENTARIO NUMBER
            * DESCRIPCION VARCHAR2 (255 BYTE)
            * VALOR NUMBER
*/
        public int IdInventario { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
    }
}
