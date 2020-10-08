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
        List<CheckListBE> listCheck;

        public CheckListDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }
        public List<CheckListBE> Listarchecklist()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_LISTAR_CHECK_LIST", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("P_CURSOR_SALIDA", OracleDbType.RefCursor);
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
                        oChecklist.TipoCheck = int.Parse(item[1].ToString());
                        oChecklist.EntregaLlave = int.Parse(item[2].ToString());
                        oChecklist.EntregaControlTv = int.Parse(item[3].ToString());
                        oChecklist.EntregaControlAir = int.Parse(item[4].ToString());
                        oChecklist.RecibeRegalo = int.Parse(item[4].ToString());
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
