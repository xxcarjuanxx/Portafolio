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
    public class MultaDA
    {
        private OracleConnection conn;
        MultaBE oMulta;
        CheckListMultaBE oCheckMulta;
      
        static List<MultaBE> listCheck;

        public MultaDA()
        {
            conn = new ConexionDA().obtenerConexion();
         
        }
        public bool agregar(MultaBE omulta,CheckListMultaBE ocheckMulta)
        {

            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_CREAR_MULTA", conn))
            {
                try
                {
                   
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DESCRIPCION_MULTA", omulta.DescripcionMulta));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_VALOR_MULTA", omulta.ValorMulta));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_CHECK_LIST_ID", ocheckMulta.CheckList.IdCheckIn));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_COMENTARIO_USUARIO", ocheckMulta.ComentarioUsuario));
                    

                    OracleParameter oParam = new OracleParameter("S_RESULTADO", OracleDbType.Varchar2);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);
                    conn.Open();
                    oOracleCommand.ExecuteReader();

                    string respuesta = oOracleCommand.Parameters["S_RESULTADO"].Value.ToString();
                    //0 es igual a se realizo la acción.........
                    //1 es igual ocurrio algo que no se puedo realizar la acción

                    if (respuesta.Equals("0"))
                    {
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
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

        public List<MultaBE> ListarMulta(int IdCheck)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_LISTAR_MULTA", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_CHECK_LIST", IdCheck));
                    OracleParameter oParam = new OracleParameter("CUR_RESERVAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listCheck = new List<MultaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oMulta = new MultaBE();
                        oCheckMulta = new CheckListMultaBE();
                        oCheckMulta.CheckList.IdCheckIn = int.Parse(item[0].ToString());
                        oMulta.IdMulta = int.Parse(item[1].ToString());
                        oMulta.Comentario = item[2].ToString();
                        oMulta.DescripcionMulta = item[3].ToString();
                        oMulta.ValorMulta = int.Parse(item[4].ToString());
                      
                        

                        listCheck.Add(oMulta);
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



        public bool actualizar(MultaBE ochech)
        {

            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_ACTUALIZAR_MULTA", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_CHECK_LIST", ochech.idCheck));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_MULTA",ochech.IdMulta));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_DESCRIPCION_MULTA", ochech.DescripcionMulta));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_VALOR_MULTA", ochech.ValorMulta));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_COMENTARIO_USUARIO", ochech.Comentario));
                  



                    OracleParameter oParam = new OracleParameter("S_RESULTADO", OracleDbType.Varchar2);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);
                    conn.Open();
                    oOracleCommand.ExecuteReader();

                    string respuesta = oOracleCommand.Parameters["S_RESULTADO"].Value.ToString();
                    //0 es igual a se realizo la acción.........
                    //1 es igual ocurrio algo que no se puedo realizar la acción

                    if (respuesta.Equals("0"))
                    {
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
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
