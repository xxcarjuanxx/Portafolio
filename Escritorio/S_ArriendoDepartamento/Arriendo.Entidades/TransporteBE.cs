using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class TransporteBE
    {
        /*
          P * PATENTE CHAR (6)
            * MARCA VARCHAR2 (100)
            * MODELO VARCHAR2 (100)
            * CANTIDAD_ASIENTOS NUMBER
            F * USUARIO_RUT NUMBER
            F * USUARIO_ROL NUMBER
            F * SERVICIO_EXTRA_ID NUMBER
             */
        public char Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantidadAsientos { get; set; }
        public UsuarioBE Usuario { get; set; }
        public RolBE Rol { get; set; }
        public ServicioExtraBE ServicioExtra { get; set; }
        public TransporteBE()
        {
            Usuario = new UsuarioBE();
            Rol = new RolBE();
            ServicioExtra = new ServicioExtraBE();
        }
    }
}
