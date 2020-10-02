using Arriendo.Datos;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class UsuarioBL
    {
        UsuarioDA oUsuarioDA;
        public UsuarioBL()
        {
            oUsuarioDA = new UsuarioDA();
        }

        public List<UsuarioBE> ListarUsuarios() {
            try
            {
                return oUsuarioDA.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UsuarioBE Login(UsuarioBE usuarioBE) {
            try
            {
                return oUsuarioDA.Login(usuarioBE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
