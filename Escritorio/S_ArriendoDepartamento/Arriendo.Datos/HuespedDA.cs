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
    public class HuespedDA
    {
        private OracleConnection conn;
        HuespedBE oHuesped;
        List<HuespedBE> listHuesped;
        public HuespedDA()
        {
            conn = new ConexionDA().obtenerConexion();
            listHuesped = null;
        }

        public List<HuespedBE> ListarHuespedPorIdReserva(int idReserva)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_HUESPED.SP_LISTAR_HUESPED_POR_ID_RES", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_RESERVA", idReserva));
                    OracleParameter oParam = new OracleParameter("CUR_HUESPED", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listHuesped = new List<HuespedBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oHuesped = new HuespedBE();
                        oHuesped.RutHuesped = int.Parse(item[0].ToString());
                        oHuesped.DvHuesped = Convert.ToChar(item[1].ToString());
                        oHuesped.NombreHuesped = item[2].ToString();
                        oHuesped.ApellidosHuesped = item[3].ToString();
                        oHuesped.TelefonoHuesped = int.Parse(item[4].ToString());
                        oHuesped.Reserva.IdReserva = int.Parse(item[5].ToString());
                        
                        listHuesped.Add(oHuesped);
                    }
                    return listHuesped;
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

        public List<HuespedBE> ListarHuespedes()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_HUESPED.SP_LISTAR_HUESPEDES", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_HUESPEDES", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listHuesped = new List<HuespedBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oHuesped = new HuespedBE();
                        oHuesped.RutHuesped = int.Parse(item[0].ToString());
                        oHuesped.DvHuesped = Convert.ToChar(item[1].ToString());
                        oHuesped.NombreHuesped = item[2].ToString();
                        oHuesped.ApellidosHuesped = item[3].ToString();
                        oHuesped.TelefonoHuesped = int.Parse(item[4].ToString());
                        oHuesped.Reserva.IdReserva = int.Parse(item[5].ToString());
                        listHuesped.Add(oHuesped);
                    }
                    return listHuesped;
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

        public List<HuespedBE> BuscarHuespedPorIdReserva(int idReserva)
        {
            try
            {
                if (listHuesped == null)
                {
                    listHuesped = ListarHuespedes();
                }
                
                return listHuesped.Where(h => h.Reserva.IdReserva.Equals(idReserva)).ToList();
               

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
