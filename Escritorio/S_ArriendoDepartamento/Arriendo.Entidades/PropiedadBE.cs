using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Entidades
{
    public class PropiedadBE
    {
        /*
          P * ID_PROPIEDAD NUMBER
            * NOMBRE VARCHAR2 (100)
            * DIRECCION VARCHAR2 (150)
            * DESCRIPCION_PROPIEDAD VARCHAR2 (255 BYTE)
            * VALOR_DIA NUMBER
            * ORIENTACION VARCHAR2 (255 BYTE)
            * TAMANIO VARCHAR2 (255 BYTE)
            * PISO NUMBER
            * CANT_HUESPEDES NUMBER
            * CANT_BANIO NUMBER
            * CANT_HABITACIONES NUMBER
            * ANIO_EDIFICACION NUMBER
            * RUTA_IMAGEN VARCHAR2 (255 BYTE)
            F * COMUNA_ID NUMBER
            F * ESTADO_PROPIEDAD_ID NUMBER
         */
        public int IdPropiedad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string DescripcionPropiedad { get; set; }
        public int ValorDia { get; set; }
        public string Orientacion { get; set; }
        public string Tamanio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Piso { get; set; }
        public int CantHuespedes { get; set; }
        public int CantBanio { get; set; }
        public int CantHabitaciones { get; set; }
        public int AnioEdificacion { get; set; }
        public ComunaBE Comuna { get; set; }
        public EstadoPropiedadBE EstadoPropiedad { get; set; }
        public PropiedadBE()
        {
            Comuna = new ComunaBE();
            EstadoPropiedad = new EstadoPropiedadBE();
        }
    }
}
