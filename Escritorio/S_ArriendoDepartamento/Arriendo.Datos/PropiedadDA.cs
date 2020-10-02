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
    public class PropiedadDA
    {
        private OracleConnection conn;
        PropiedadBE oPropiedad;
        List<PropiedadBE> listPropiedad;
        public PropiedadDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        public List<PropiedadBE> ListarPropiedades()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_LISTAR_PROPIEDADES", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_PROPIEDADES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listPropiedad = new List<PropiedadBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oPropiedad = new PropiedadBE();
                        oPropiedad.IdPropiedad = int.Parse(item[0].ToString());
                        oPropiedad.Nombre = item[1].ToString();
                        oPropiedad.Direccion = item[2].ToString();
                        oPropiedad.DescripcionPropiedad = item[3].ToString();
                        oPropiedad.ValorDia = int.Parse(item[4].ToString());
                        oPropiedad.Orientacion = item[5].ToString();
                        oPropiedad.Tamanio = item[6].ToString();
                        oPropiedad.Piso = int.Parse(item[7].ToString());
                        oPropiedad.CantHuespedes = int.Parse(item[8].ToString());
                        oPropiedad.CantBanio = int.Parse(item[9].ToString());
                        oPropiedad.CantHabitaciones = int.Parse(item[10].ToString());
                        oPropiedad.AnioEdificacion = int.Parse(item[11].ToString());
                        oPropiedad.Comuna.IdComuna = int.Parse(item[12].ToString());
                        oPropiedad.EstadoPropiedad.IdEstadoPropiedad = int.Parse(item[13].ToString());
                        listPropiedad.Add(oPropiedad);
                    }
                    return listPropiedad;
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

        public List<PropiedadBE> ListarPropiedadPorId(int idPropiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_LISTAR_PROPIEDAD_POR_ID", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_PRPOIEDAD", idPropiedad));
                    OracleParameter oParam = new OracleParameter("CUR_PROPIEDADES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listPropiedad = new List<PropiedadBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oPropiedad = new PropiedadBE();
                        oPropiedad.IdPropiedad = int.Parse(item[0].ToString());
                        oPropiedad.Nombre = item[1].ToString();
                        oPropiedad.Direccion = item[2].ToString();
                        oPropiedad.DescripcionPropiedad = item[3].ToString();
                        oPropiedad.ValorDia = int.Parse(item[4].ToString());
                        oPropiedad.Orientacion = item[5].ToString();
                        oPropiedad.Tamanio = item[6].ToString();
                        oPropiedad.Piso = int.Parse(item[7].ToString());
                        oPropiedad.CantHuespedes = int.Parse(item[8].ToString());
                        oPropiedad.CantBanio = int.Parse(item[9].ToString());
                        oPropiedad.CantHabitaciones = int.Parse(item[10].ToString());
                        oPropiedad.AnioEdificacion = int.Parse(item[11].ToString());
                        oPropiedad.Comuna.IdComuna = int.Parse(item[12].ToString());
                        oPropiedad.EstadoPropiedad.IdEstadoPropiedad = int.Parse(item[13].ToString());
                        listPropiedad.Add(oPropiedad);
                    }
                    return listPropiedad;
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

        public List<PropiedadBE> ListarPropiedadPorComuna(int idPropiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_LISTAR_PROPIEDADES_POR_COMU", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_COMUNA", idPropiedad));
                    OracleParameter oParam = new OracleParameter("CUR_PROPIEDADES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listPropiedad = new List<PropiedadBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oPropiedad = new PropiedadBE();
                        oPropiedad.IdPropiedad = int.Parse(item[0].ToString());
                        oPropiedad.Nombre = item[1].ToString();
                        oPropiedad.Direccion = item[2].ToString();
                        oPropiedad.DescripcionPropiedad = item[3].ToString();
                        oPropiedad.ValorDia = int.Parse(item[4].ToString());
                        oPropiedad.Orientacion = item[5].ToString();
                        oPropiedad.Tamanio = item[6].ToString();
                        oPropiedad.Piso = int.Parse(item[7].ToString());
                        oPropiedad.CantHuespedes = int.Parse(item[8].ToString());
                        oPropiedad.CantBanio = int.Parse(item[9].ToString());
                        oPropiedad.CantHabitaciones = int.Parse(item[10].ToString());
                        oPropiedad.AnioEdificacion = int.Parse(item[11].ToString());
                        oPropiedad.Comuna.IdComuna = int.Parse(item[12].ToString());
                        oPropiedad.EstadoPropiedad.IdEstadoPropiedad = int.Parse(item[13].ToString());
                        listPropiedad.Add(oPropiedad);
                    }
                    return listPropiedad;
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

        public string AgregarPropiedad(PropiedadBE propiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_CREAR_PROPIEDAD", conn)) {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_NOMBRE", propiedad.Nombre));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DIRECCION", propiedad.Direccion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DESCRIPCION_PROPIEDAD", propiedad.DescripcionPropiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_VALOR_DIA", propiedad.ValorDia));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_ORIENTACION", propiedad.Orientacion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_TAMANIO", propiedad.Tamanio));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PISO", propiedad.Piso));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_HUESPEDES", propiedad.CantHuespedes));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_BANIO", propiedad.CantBanio));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_HABITACIONES", propiedad.CantHabitaciones));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ANIO_EDIFICACION", propiedad.AnioEdificacion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_COMUNA_ID", propiedad.Comuna));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ESTADO_PROPIEDAD_ID", propiedad.EstadoPropiedad.IdEstadoPropiedad));

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


        public string ActualizarPropiedad(PropiedadBE propiedad)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_PROPIEDAD.SP_ACTUALIZAR_PROPIEDAD", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_PROPIEDAD", propiedad.IdPropiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_NOMBRE", propiedad.Nombre));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DIRECCION", propiedad.Direccion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DESCRIPCION_PROPIEDAD", propiedad.DescripcionPropiedad));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_VALOR_DIA", propiedad.ValorDia));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_ORIENTACION", propiedad.Orientacion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_TAMANIO", propiedad.Tamanio));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_PISO", propiedad.Piso));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_HUESPEDES", propiedad.CantHuespedes));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_BANIO", propiedad.CantBanio));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CANT_HABITACIONES", propiedad.CantHabitaciones));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ANIO_EDIFICACION", propiedad.AnioEdificacion));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_COMUNA_ID", propiedad.Comuna));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ESTADO_PROPIEDAD_ID", propiedad.EstadoPropiedad.IdEstadoPropiedad));

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
