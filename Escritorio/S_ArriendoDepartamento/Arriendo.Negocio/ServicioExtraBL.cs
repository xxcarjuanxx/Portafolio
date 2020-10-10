using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class ServicioExtraBL
    {
        ServicioExtraDA oServicioExtraDA;
        public ServicioExtraBL()
        {
            oServicioExtraDA = new ServicioExtraDA();
        }

        public List<ServicioExtraBE> BuscarServioExtraPorIdPropiedad(int reservaId)
        {
            try
            {
                return oServicioExtraDA.BuscarServioExtraPorIdPropiedad(reservaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ServicioExtraBE> ListarServicioExtra()
        {
            try
            {
                return oServicioExtraDA.ListarServicioExtra();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
