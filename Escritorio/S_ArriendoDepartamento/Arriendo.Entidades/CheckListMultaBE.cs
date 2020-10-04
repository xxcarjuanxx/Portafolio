using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class CheckListMultaBE
    {
        /*
        PF* CHECK_LIST_ID NUMBER
        PF* MULTA_ID NUMBER
        COMENTARIO_USUARIO VARCHAR2 (255 BYTE)
         */
        public CheckListBE CheckList { get; set; }
        public MultaBE Multa { get; set; }
        public string ComentarioUsuario { get; set; }
        public CheckListMultaBE()
        {
            CheckList = new CheckListBE();
            Multa = new MultaBE();
        }
    }
}
