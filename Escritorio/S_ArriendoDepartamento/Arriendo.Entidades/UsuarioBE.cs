using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class UsuarioBE
    {
        /*
            RUT_USUARIO NUMBER
            DV_USUARIO CHAR (1)
            NOMBRE_USUARIO VARCHAR2 (100)
            APELLIDOS_USUARIO VARCHAR2 (100)
            DIRECCION_USUARIO VARCHAR2 (150)
            TELEFONO_USUARIO NUMBER
            EMAIL_USUARIO VARCHAR2 (100)
            PASSWORD_USUARIO VARCHAR2 (100)
            ESTADO CHAR (1)
            PF* ROL_USUARIO
*/
    
        private string _rutUsuario;

        public string RutUsuario
        {
            get { return _rutUsuario; }
            set {
                _rutUsuario = value;
                
            }
        }


        public char DvUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public int TelefonoUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public char Estado { get; set; }
        public RolBE RolUsuario { get; set; }
        public UsuarioBE()
        {
            RolUsuario = new RolBE();
        }
    }
}
