using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class ComunaBL
    {
        ComunaDA oCumunaDA;
        public ComunaBL()
        {
            oCumunaDA = new ComunaDA();
        }
        public List<ComunaBE> ListarComunaPorId(int idComuna) {
            try
            {
                return oCumunaDA.ListarComunaPorId(idComuna);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
