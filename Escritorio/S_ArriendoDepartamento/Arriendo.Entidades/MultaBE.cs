using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class MultaBE
    {
        /*
         P *ID_MULTA NUMBER
            DESCRIPCION_MULTA VARCHAR2 (255 BYTE)
            VALOR_MULTA NUMBER
         */
        public int IdMulta { get; set; }
        public string DescripcionMulta { get; set; }
        private int _valorMulta;

        public int ValorMulta
        {
            get { return _valorMulta; }
            set {
                _valorMulta = value;
                if (_valorMulta.Equals(0))
                {
                    throw new Exception("Ingrese el valor de la multa ");
                } 
            }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set {
                _comentario = value;
                if (_comentario.Trim().Length.Equals(0))
                {
                    throw new Exception("Ingrese un comentario ");
                }
            }
        }

        public string idCheck { get; set; }
        public bool IsSelected { get; set; }

        public MultaBE()
        {
            
           
        }

    }
}
