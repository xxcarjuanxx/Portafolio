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
        public List<CheckListBE> ListarChecklist()
        {
            try
            {
                return ochecklistDA.Listarchecklist();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
