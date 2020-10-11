using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class CheckListBL
    {
        CheckListDA ochecklistDA;
        public CheckListBL()
        {
            ochecklistDA = new CheckListDA();
        }
        public List<CheckListBE> ListarChecklist(int Idreserva)
        {
            try
            {
                return ochecklistDA.Listarchecklist(Idreserva);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AgregarCheckList(CheckListBE ocheck)
        {
            try
            {
                return ochecklistDA.agregar(ocheck);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
