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
    public class ProvinciaDA
    {
        private OracleConnection conn;
        ProvinciaBE oProvincia;
        List<ProvinciaBE> listProvincia;
        public ProvinciaDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        

        public List<ProvinciaBE> ListarProvinciaPorId(int provinciaId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_PROVINCIA_POR_ID", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_PROVINCIA", provinciaId));
                    OracleParameter oParam = new OracleParameter("CUR_PROVINCIAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listProvincia = new List<ProvinciaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oProvincia = new ProvinciaBE();
                        oProvincia.IdProvincia = int.Parse(item[0].ToString());
                        oProvincia.NombreProvincia = item[1].ToString();
                        oProvincia.Region.IdRegion = int.Parse(item[2].ToString());
                        listProvincia.Add(oProvincia);
                    }
                    return listProvincia;
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

        public List<ProvinciaBE> ListarProvincias()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_PROVINCIAS", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_PROVINCIAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listProvincia = new List<ProvinciaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oProvincia = new ProvinciaBE();
                        oProvincia.IdProvincia = int.Parse(item[0].ToString());
                        oProvincia.NombreProvincia = item[1].ToString();
                        oProvincia.Region.IdRegion = int.Parse(item[2].ToString());
                        listProvincia.Add(oProvincia);
                    }
                    return listProvincia;
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

        public List<ProvinciaBE> ListarProvinciaPorRegion(int regionId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_PROVINCIA_POR_ID", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_REGION_ID", regionId));
                    OracleParameter oParam = new OracleParameter("CUR_PROVINCIAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listProvincia = new List<ProvinciaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oProvincia = new ProvinciaBE();
                        oProvincia.IdProvincia = int.Parse(item[0].ToString());
                        oProvincia.NombreProvincia = item[1].ToString();
                        oProvincia.Region.IdRegion = int.Parse(item[2].ToString());
                        listProvincia.Add(oProvincia);
                    }
                    return listProvincia;
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


    }
}
