using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class UsuarioBE
    {
        private string _rutUsuario;

        public string RutUsuario
        {
            get { return _rutUsuario; }
            set {
                _rutUsuario = value;
                if (_rutUsuario.Trim().Length.Equals(0)) {
                    throw new Exception("Por favor ingrese su usuario");
                }
            }
        }


        public char DvUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public int TelefonoUsuario { get; set; }
        public string EmailUsuario { get; set; }
        private string _passwordUsuario;

        public string PasswordUsuario
        {
            get { return _passwordUsuario; }
            set
            {
                _passwordUsuario = value;
                if (_passwordUsuario.Trim().Length.Equals(0))
                {
                    throw new Exception("Por favor ingrese su contraseña");
                }
            }
        }

        public char Estado { get; set; }
        public RolBE RolUsuario { get; set; }
        public UsuarioBE()
        {
            RolUsuario = new RolBE();
        }
    }
}
