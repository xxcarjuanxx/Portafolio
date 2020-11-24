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
       
        private string _comentarioUsuario;

        public string ComentarioUsuario
        {
            get { return _comentarioUsuario; }
            set
            {
                _comentarioUsuario = value;
                if (_comentarioUsuario.Trim().Length.Equals(0))
                {
                    throw new Exception("Ingrese un comentario ");
                }
            }
        }
        public CheckListMultaBE()
        {
            CheckList = new CheckListBE();
            Multa = new MultaBE();
        }
    }
}
