using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Datos.Conexion
{
    public class ConexionDA
    {
        private static ConexionDA _instance;
        private OracleConnection conn;
        string cadena = ConfigurationManager.ConnectionStrings["Activa"].ConnectionString;

        public ConexionDA()
        {
            try
            {
                cadena = ZthSeguridad.Metodos.Desencriptar(cadena);
                if (conn == null)
                {
                    conn = new OracleConnection(cadena);
                    //Console.WriteLine("entre");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("error" + ex.Message);
            }
        }

        public static ConexionDA GetConexion() {
            if (_instance == null)
            {
                _instance = new ConexionDA();
            }
            return _instance;
        }

        //retornamos el estado de la conexion
        public OracleConnection obtenerConexion()
        {
            return conn;
        }
    }
}
