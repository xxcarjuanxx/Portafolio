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
    public class ServicioExtraDA
    {
        private OracleConnection conn;
        ServicioExtraBE oServicioExtra;
        EstadoServicioBE oEstadoServicio;
        List<ServicioExtraBE> listServicioExtra;
        //List<EstadoServicioBE> listEstadoServicio;
        ReservaServicioExtraBE oReservaServicioExtraBE;
        static List<ReservaServicioExtraBE> listReservaServicioExtra;
       
        public ServicioExtraDA()
        {
            conn = new ConexionDA().obtenerConexion();
            listReservaServicioExtra = null;
        }

        public List<ServicioExtraBE> BuscarServioExtraPorIdReserva(int idReserva)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_SERVICIOS_EXTRA.SP_LISTAR_SERVI_EXTRA_POR_RES", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_RESERVA_ID", idReserva));
                    OracleParameter oParam = new OracleParameter("CUR_SERVI_EXTRA", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listServicioExtra = new List<ServicioExtraBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oServicioExtra = new ServicioExtraBE();
                        oServicioExtra.IdServicio = int.Parse(item[0].ToString());
                        oServicioExtra.DescripcionServicio = item[1].ToString();
                        oServicioExtra.ValorServicio = int.Parse(item[2].ToString());
                        oServicioExtra.CantidadPersonas = int.Parse(item[3].ToString());
                        oServicioExtra.ValorTotalServicio = int.Parse(item[4].ToString());
                        oServicioExtra.Propiedad.IdPropiedad = int.Parse(item[5].ToString());
                        oServicioExtra.EstadoServicio = BuscarEstadoServioId(int.Parse(item[6].ToString()));
                        listServicioExtra.Add(oServicioExtra);
                    }
                    return listServicioExtra;
                }
                catch (Exception ex)
                {

                    return null;
                   
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

        public EstadoServicioBE BuscarEstadoServioId(int estadoId)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_SERVICIOS_EXTRA.SP_LISTAR_ESTAD_SERVI_POR_ID", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ID_ESTADO_SERVICIO", estadoId));
                    OracleParameter oParam = new OracleParameter("CUR_ESTADO_SERVICIOS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    oEstadoServicio = new EstadoServicioBE();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oEstadoServicio.IdEstadoServicio = int.Parse(item[0].ToString());
                        oEstadoServicio.NombreEstadoServicio = item[1].ToString();
                        oEstadoServicio.DescripcionEstadoServicio = item[2].ToString();
                       
                    }
                    return oEstadoServicio;
                }
                catch (Exception )
                {
                    return null;

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

        public List<ServicioExtraBE> ListarServicioExtra()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_SERVICIOS_EXTRA.SP_LISTAR_SERVI_EXTRAS", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_SERVI_EXTRA", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listServicioExtra = new List<ServicioExtraBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oServicioExtra = new ServicioExtraBE();
                        oServicioExtra.IdServicio = int.Parse(item[0].ToString());
                        oServicioExtra.DescripcionServicio = item[1].ToString();
                        oServicioExtra.ValorServicio = int.Parse(item[2].ToString());
                        oServicioExtra.CantidadPersonas = int.Parse(item[3].ToString());
                        oServicioExtra.ValorTotalServicio = int.Parse(item[4].ToString());
                        oServicioExtra.Propiedad.IdPropiedad = int.Parse(item[5].ToString());
                        oServicioExtra.EstadoServicio = BuscarEstadoServioId(int.Parse(item[6].ToString()));
                        listServicioExtra.Add(oServicioExtra);
                    }
                    return listServicioExtra;
                }
                catch (Exception)
                {

                    return null;

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

        public List<ReservaServicioExtraBE> ListarReservaServicioExtra()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_SERVICIOS_EXTRA.SP_LISTAR_RESER_SERVI_EXTRA", conn))
            {
                try
                {

                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_SERVI_EXTRA", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);


                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listReservaServicioExtra = new List<ReservaServicioExtraBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oReservaServicioExtraBE = new ReservaServicioExtraBE();
                        //oReservaServicioExtraBE.ServicioExtra.IdServicio = int.Parse(item[0].ToString());
                        //oReservaServicioExtraBE.ServicioExtra.DescripcionServicio = item[1].ToString();
                        //oReservaServicioExtraBE.ServicioExtra.ValorServicio = int.Parse(item[2].ToString());
                        //oReservaServicioExtraBE.ServicioExtra.CantidadPersonas = int.Parse(item[3].ToString());
                        //oReservaServicioExtraBE.ServicioExtra.ValorTotalServicio = int.Parse(item[4].ToString());
                        //oReservaServicioExtraBE.ServicioExtra.Propiedad.IdPropiedad = int.Parse(item[5].ToString());
                        //oReservaServicioExtraBE.ServicioExtra.EstadoServicio.IdEstadoServicio = int.Parse(item[6].ToString());
                        oReservaServicioExtraBE.Reserva.IdReserva = int.Parse(item[7].ToString());
                        listReservaServicioExtra.Add(oReservaServicioExtraBE);
                    }
                    return listReservaServicioExtra;
                }
                catch (Exception)
                {

                    return null;

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


        public bool BuscarReserServExtPorReserID(int idReserva)
        {
            try
            {
                if (listReservaServicioExtra == null)
                {
                    listReservaServicioExtra = ListarReservaServicioExtra();
                }
                var lista = listReservaServicioExtra.Where(r => r.Reserva.IdReserva.Equals(idReserva)).ToList();
                if (lista.Count>0) {
                    return true;
                }
                return false;


            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
