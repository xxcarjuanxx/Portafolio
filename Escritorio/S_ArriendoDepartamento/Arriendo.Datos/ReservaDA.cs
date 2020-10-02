using Arriendo.Datos.Conexion;
using Arriendo.Entidades;
using Microsoft.VisualBasic;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Datos
{
    public class ReservaDA
    {
        private OracleConnection conn;
        ReservaBE oReserva;
        List<ReservaBE> listReserva;
        public ReservaDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        public List<ReservaBE> ListarReservas()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_LISTAR_RESERVAS", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_RESERVAS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listReserva = new List<ReservaBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                      
                        oReserva = new ReservaBE();
                        oReserva.IdReserva = int.Parse(item[0].ToString());
                        oReserva.CantidadPersonas = int.Parse(item[1].ToString());
                        oReserva.CantidadDias = int.Parse(item[2].ToString());
                        oReserva.FechaReserva = Convert.ToDateTime(item[3].ToString()).ToString("dd-MM-yy");
                        oReserva.FechaEntrada = Convert.ToDateTime(item[4].ToString()).ToString("dd-MM-yy");
                        oReserva.FechaSalida = Convert.ToDateTime(item[5].ToString()).ToString("dd-MM-yy");
                        oReserva.MontoAnticipo = int.Parse(item[6].ToString());
                        oReserva.MontoPagar = int.Parse(item[7].ToString());
                        oReserva.MontoTotal = int.Parse(item[8].ToString());
                        oReserva.EstadoReserva = item[9].ToString();
                        oReserva.Propiedad.IdPropiedad = int.Parse(item[10].ToString());
                        oReserva.TipoPago.IdTipoPago = int.Parse(item[11].ToString());
                        oReserva.Usuario.RutUsuario = item[12].ToString();
                        listReserva.Add(oReserva);
                    }
                    return listReserva;
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
