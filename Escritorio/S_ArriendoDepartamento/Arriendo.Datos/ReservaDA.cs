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
        static List<ReservaBE> listReserva;
        PropiedadDA propiedadDA;
        UsuarioDA usuarioDA;
        public ReservaDA()
        {
            conn = new ConexionDA().obtenerConexion();
            propiedadDA = new PropiedadDA();
            usuarioDA = new UsuarioDA();
           
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
                        oReserva.IdReserva = int.Parse(item["ID_RESERVA"].ToString());
                        oReserva.CantidadPersonas = int.Parse(item["CANTIDAD_PERSONAS"].ToString());
                        oReserva.CantidadDias = int.Parse(item["CANTIDAD_DIAS"].ToString());
                        oReserva.FechaReserva = Convert.ToDateTime(item["FECHA_RESERVA"].ToString()).ToString("dd-MM-yy");
                        oReserva.FechaEntrada = Convert.ToDateTime(item["FECHA_ENTRADA"].ToString()).ToString("dd-MM-yy");
                        oReserva.FechaSalida = Convert.ToDateTime(item["FECHA_SALIDA"].ToString()).ToString("dd-MM-yy");
                        oReserva.MontoAnticipo = int.Parse(item["MONTO_ACTICIPO"].ToString());
                        oReserva.MontoPagar = int.Parse(item["MONTO_A_PAGAR"].ToString());
                        oReserva.MontoTotal = int.Parse(item["MONTO_TOTAL"].ToString());
                        oReserva.EstadoReserva = item["ESTADO_RESERVA"].ToString();
                        //oReserva.Propiedad.IdPropiedad = int.Parse(item[10].ToString());
                        oReserva.TipoPago.IdTipoPago = int.Parse(item["TIPO_PAGO_ID"].ToString());
                        //oReserva.Usuario.RutUsuario = item[12].ToString();
                        oReserva.Usuario = usuarioDA.UsuarioPorRut(item["USUARIO_RUT"].ToString());
                        oReserva.Propiedad = propiedadDA.BuscarPropiedadId(int.Parse(item["PROPIEDAD_ID"].ToString()));
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

        public async void RunReservas() {
            Task<List<ReservaBE>> taskListaReserva = new Task<List<ReservaBE>>(ListarReservas);
            taskListaReserva.Start();
            await taskListaReserva;
        }

        public List<ReservaBE> ReservaPorRut(List<ReservaBE> oListReserva, string rut) {
            try
            {
                listReserva = new List<ReservaBE>();
                return listReserva = oListReserva.Where(r => r.Usuario.RutUsuario.Contains(rut)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        

        public string Registra_Pago_Reserva(ReservaBE reservaBE)
        {
          
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_RESERVA.SP_PAGO_RESERVA", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_RESERVA", reservaBE.IdReserva));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_MONTO_A_PAGAR", reservaBE.MontoPagar));
                    oOracleCommand.Parameters.Add(new OracleParameter("PS_ESTADO_RESERVA", reservaBE.EstadoReserva));


                    OracleParameter oParam = new OracleParameter("S_RESULTADO", OracleDbType.Varchar2);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;
                    oOracleCommand.Parameters.Add(oParam);
                    conn.Open();
                    oOracleCommand.ExecuteReader();

                    oReserva = new ReservaBE();
                    oReserva = listReserva.Where(r=>r.IdReserva.Equals(reservaBE.IdReserva)).First();
                    listReserva.Remove(oReserva);
                    oReserva.EstadoReserva = reservaBE.EstadoReserva;
                    oReserva.MontoPagar = reservaBE.MontoPagar;
                    listReserva.Add(oReserva);


                    string respuesta = oOracleCommand.Parameters["S_RESULTADO"].Value.ToString();
                    //0 es igual a se realizo la acción.........
                    //1 es igual ocurrio algo que no se puedo realizar la acción
                   // string[] respuestaDB = respuesta.Split(',');
                    
                    return respuesta;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw new Exception("error: "+ ex.Message);
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

        public List<ReservaBE> GetAllReservas() {
            
            if (listReserva == null)
            {
                return ListarReservas();
            }
            else {
                listReserva.Select(r =>
                {
                    r.IsSelected = false;
                    return r;
                }).ToList();

                //var list = from reserva in listReserva
                //           orderby reserva.FechaReserva descending
                //           select reserva;
                listReserva = (from reserva in listReserva
                               orderby Convert.ToDateTime(reserva.FechaReserva) descending
                               select reserva).ToList();

                //listReserva = listReserva.OrderByDescending(r => DateTime.Parse(r.FechaReserva).ToString("dd-MM-yy")).ToList();


                return listReserva;
            }
        }

      

    }
}
