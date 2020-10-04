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
    public class FotoPropiedadDA
    {
        private OracleConnection conn;
        FotoPropiedadBE oFotoPropiedad;
        List<FotoPropiedadBE> listFotoPropiedad;
        public FotoPropiedadDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        public List<FotoPropiedadBE> ListarFotoPorId(int FotoId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_LISTAR_FOTO_POR_ID", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_FOTO_PROPIEDAD", FotoId));
                    OracleParameter oParam = new OracleParameter("CUR_FOTOS_PROPIEDAD", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listFotoPropiedad = new List<FotoPropiedadBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oFotoPropiedad = new FotoPropiedadBE();
                        oFotoPropiedad.IdFotoPropiedad = int.Parse(item[0].ToString());
                        oFotoPropiedad.ImagenPropiedad = item[1].ToString();
                        oFotoPropiedad.Propiedad.IdPropiedad = int.Parse(item[2].ToString());
                        listFotoPropiedad.Add(oFotoPropiedad);
                    }
                    return listFotoPropiedad;
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

        public List<FotoPropiedadBE> ListarFotoPorPropiedad(int propiedadId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_LISTAR_FOTO_POR_PROPIEDAD", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PROPIEDAD_ID", propiedadId));
                    OracleParameter oParam = new OracleParameter("CUR_FOTOS_PROPIEDAD", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listFotoPropiedad = new List<FotoPropiedadBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oFotoPropiedad = new FotoPropiedadBE();
                        oFotoPropiedad.IdFotoPropiedad = int.Parse(item[0].ToString());
                        oFotoPropiedad.ImagenPropiedad = item[1].ToString();
                        oFotoPropiedad.Propiedad.IdPropiedad = int.Parse(item[2].ToString());
                        listFotoPropiedad.Add(oFotoPropiedad);
                    }
                    return listFotoPropiedad;
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

        public string AgregarFotoPropiedad(FotoPropiedadBE fotoPropiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_CREAR_FOTO_PROPIEDAD", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PB_IMAGEN_PROPIEDAD", fotoPropiedad.ImagenPropiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PROPIEDAD_ID", fotoPropiedad.Propiedad.IdPropiedad));
                    
                   
                    OracleParameter oParam = new OracleParameter("S_RESULTADO", OracleDbType.Varchar2);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);
                    conn.Open();
                    oOracleCommand.ExecuteNonQuery();
                    conn.Close();
                    string resultado = oOracleCommand.Parameters["S_RESULTADO"].Value.ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return "";
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

        public string ActualizarFotoPropiedad(FotoPropiedadBE fotoPropiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_ACTUALIZAR_FOTO_PROPIEDAD", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_FOTO_PROPIEDAD", fotoPropiedad.IdFotoPropiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PB_IMAGEN_PROPIEDAD", fotoPropiedad.Propiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PROPIEDAD_ID", fotoPropiedad.Propiedad.IdPropiedad));

                    OracleParameter oParam = new OracleParameter("S_RESULTADO", OracleDbType.Varchar2);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);
                    conn.Open();
                    oOracleCommand.ExecuteNonQuery();
                    conn.Close();
                    string resultado = oOracleCommand.Parameters["S_RESULTADO"].Value.ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return "";
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
