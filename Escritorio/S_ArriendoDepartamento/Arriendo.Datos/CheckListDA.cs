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
    public class CheckListDA
    {
        private OracleConnection conn;
        CheckListBE oChecklist;
        static List<CheckListBE> listCheck;

        public CheckListDA()
        {
            conn = new ConexionDA().obtenerConexion();
            listCheck = null;
        }
        public List<CheckListBE> Listarchecklist(int Idreserva)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_LISTAR_CHECK_LIST", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_RESERVA", Idreserva));
                    OracleParameter oParam = new OracleParameter("CUR_RESERVAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listCheck = new List<CheckListBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oChecklist = new CheckListBE();
                        oChecklist.IdCheckIn = int.Parse(item[0].ToString());
                        oChecklist.TipoCheck = item[1].ToString();
                        oChecklist.EntregaLlave = item[2].ToString();
                        oChecklist.EntregaControlTv = item[3].ToString();
                        oChecklist.EntregaControlAir = item[4].ToString();
                        oChecklist.RecibeRegalo = item[5].ToString();
                        
                        listCheck.Add(oChecklist);
                    }
                    return listCheck;
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
