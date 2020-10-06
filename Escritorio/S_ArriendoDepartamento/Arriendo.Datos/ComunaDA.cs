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
    public class ComunaDA
    {
        //comentario
        private OracleConnection conn;
        ComunaBE oComuna;
        List<ComunaBE> listComuna;
        public ComunaDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComuna"></param>
        /// <returns></returns>
        public List<ComunaBE> ListarComunaPorId(int idComuna)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_COMUNA_POR_ID", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_COMUNA", idComuna));
                    OracleParameter oParam = new OracleParameter("CUR_COMUNAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listComuna = new List<ComunaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oComuna = new ComunaBE();
                        oComuna.IdComuna = int.Parse(item[0].ToString());
                        oComuna.NombreComuna = item[1].ToString();
                        oComuna.Provincia.IdProvincia = int.Parse(item[2].ToString());
                        listComuna.Add(oComuna);
                    }

                    return listComuna;
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
        public List<ComunaBE> ListarComunas()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_COMUNAS", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_COMUNAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listComuna = new List<ComunaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oComuna = new ComunaBE();
                        oComuna.IdComuna = int.Parse(item[0].ToString());
                        oComuna.NombreComuna = item[1].ToString();
                        oComuna.Provincia.IdProvincia = int.Parse(item[2].ToString());
                        listComuna.Add(oComuna);
                    }
                    return listComuna;
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

        public List<ComunaBE> ListarComunaPorProv(int provinciaId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_REGIONES.SP_LISTAR_COMUNAS_POR_PROV", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PROVINCIA_ID", provinciaId));
                    OracleParameter oParam = new OracleParameter("CUR_COMUNAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listComuna = new List<ComunaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oComuna = new ComunaBE();
                        oComuna.IdComuna = int.Parse(item[0].ToString());
                        oComuna.NombreComuna = item[1].ToString();
                        oComuna.Provincia.IdProvincia = int.Parse(item[2].ToString());
                        listComuna.Add(oComuna);
                    }
                    return listComuna;
                }
                catch (Exception ex)
                {

                    return null;
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }                
                }
            }
        }
    }
}
