using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
        public class MultaBL
       {
        MultaDA oMultaDA;
        public MultaBL()
        {
            oMultaDA = new MultaDA();
        }

        public bool AgregarMulta(MultaBE omulta,CheckListMultaBE ocheck)
        {
            try
            {
                return oMultaDA.agregar(omulta,ocheck);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MultaBE> ListarMulta(int IdCheck)
        {
            try
            {
                return oMultaDA.ListarMulta(IdCheck);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
