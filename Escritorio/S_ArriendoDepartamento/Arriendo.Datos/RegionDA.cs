using Arriendo.Datos.Conexion;
using Arriendo.Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Datos
{
    public class RegionDA
    {
        private OracleConnection conn;
        RegionBE oRegion;
        List<RegionBE> listRegion;
        public RegionDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        public List<RegionBE> ListarRegionPorId(int regionId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_REGION_POR_ID", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_REGION", regionId));
                    OracleParameter oParam = new OracleParameter("CUR_REGIONES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listRegion = new List<RegionBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oRegion = new RegionBE();
                        oRegion.IdRegion = int.Parse(item[0].ToString());
                        oRegion.NombreRegion = item[1].ToString();
                        oRegion.RegionOrdinal = item[2].ToString();
                        listRegion.Add(oRegion);
                    }
                    return listRegion;
                }
                catch (Exception ex)
                {

                    return null;
                    // throw new Exception(ex.Message);
                }
                finally
                {

                    if (conn.State == ConnectionState.Open) {
                        conn.Close();
                    }   
                }
            }
        }

        public List<RegionBE> ListarRegion()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_REGIONES", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_REGIONES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listRegion = new List<RegionBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oRegion = new RegionBE();
                        oRegion.IdRegion = int.Parse(item[0].ToString());
                        oRegion.NombreRegion = item[1].ToString();
                        oRegion.RegionOrdinal = item[2].ToString();
                        listRegion.Add(oRegion);
                    }
                    return listRegion;
                }
                catch (Exception ex)
                {
                    return null;
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }
        }

        public static String encriptarClave(String clave)
        {
            char[] array = clave.Trim().ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (char)(array[i] + (char)5);
            }

            String encriptado = array.ToArray().ToString();

            return encriptado;
        }

        //Metodo para desencriptar una clave
        public static String desencriptarClave(String clave)
        {
            char[] arrayD = clave.Trim().ToCharArray();

            for (int i = 0; i < arrayD.Length; i++)
            {
                arrayD[i] = (char)(arrayD[i] - (char)5);
            }

            String desencriptado = arrayD.ToString();

            return desencriptado;
        }
    }
}
