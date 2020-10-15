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
    }
}
