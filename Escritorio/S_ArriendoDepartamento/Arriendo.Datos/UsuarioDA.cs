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
    public class UsuarioDA
    {
        private OracleConnection conn;
        UsuarioBE oUsuario;
        List<UsuarioBE> listUsuario;
        public UsuarioDA()
        {
            conn = new ConexionDA().obtenerConexion();
        }

        public List<UsuarioBE> ListarUsuarios()
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_USUARIO.SP_LISTAR_USUARIOS", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    OracleParameter oParam = new OracleParameter("CUR_USUARIOS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listUsuario = new List<UsuarioBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oUsuario = new UsuarioBE();
                        oUsuario.RutUsuario = item[0].ToString();
                        oUsuario.DvUsuario = char.Parse(item[1].ToString());
                        oUsuario.NombreUsuario = item[2].ToString();
                        oUsuario.ApellidosUsuario = item[3].ToString();
                        oUsuario.DireccionUsuario = item[4].ToString();
                        oUsuario.TelefonoUsuario = int.Parse(item[5].ToString());
                        oUsuario.EmailUsuario = item[6].ToString();
                        oUsuario.PasswordUsuario = item[7].ToString();
                        oUsuario.Estado = char.Parse(item[8].ToString());
                        oUsuario.RolUsuario.IdRol = int.Parse(item[9].ToString());
                        listUsuario.Add(oUsuario);
                    }
                    return listUsuario;
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

        public List<UsuarioBE> ListarUsuarioRutRol(UsuarioBE usuario)
        {
            using (OracleCommand oOracleCommand = new OracleCommand("PKG_USUARIO.SP_LISTAR_USUARIO_RUT_ROL", conn))
            {
                try
                {
                    oOracleCommand.CommandType = CommandType.StoredProcedure;
                    oOracleCommand.CommandTimeout = 10;
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_RUT_USUARIO", usuario.RutUsuario));
                    oOracleCommand.Parameters.Add(new OracleParameter("PN_ROL_USUARIO", usuario.RolUsuario.IdRol));
                    OracleParameter oParam = new OracleParameter("CUR_USUARIOS", OracleDbType.RefCursor);
                    oParam.Direction = ParameterDirection.Output;
                    oParam.Size = 128;

                    oOracleCommand.Parameters.Add(oParam);

                    DataTable oDataTable = new DataTable();
                    conn.Open();
                    oDataTable.Load(oOracleCommand.ExecuteReader());
                    conn.Close();
                    listUsuario = new List<UsuarioBE>();
                    foreach (DataRow item in oDataTable.Rows)
                    {
                        oUsuario = new UsuarioBE();
                        oUsuario.RutUsuario = item[0].ToString();
                        oUsuario.DvUsuario = char.Parse(item[1].ToString());
                        oUsuario.NombreUsuario = item[2].ToString();
                        oUsuario.ApellidosUsuario = item[3].ToString();
                        oUsuario.DireccionUsuario = item[4].ToString();
                        oUsuario.TelefonoUsuario = int.Parse(item[5].ToString());
                        oUsuario.EmailUsuario = item[6].ToString();
                        oUsuario.PasswordUsuario = item[7].ToString();
                        oUsuario.Estado = char.Parse(item[8].ToString());
                        oUsuario.RolUsuario.IdRol = int.Parse(item[9].ToString());
                        listUsuario.Add(oUsuario);
                    }
                    return listUsuario;
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

        public UsuarioBE Login(UsuarioBE usuarioBE) {
            try
            {
                List<UsuarioBE> listUsuario = ListarUsuarios();
                oUsuario = new UsuarioBE();
                oUsuario = listUsuario.Find(u=>u.RutUsuario.Equals(usuarioBE.RutUsuario) && u.PasswordUsuario.Equals(usuarioBE.PasswordUsuario) && u.RolUsuario.IdRol.Equals(usuarioBE.RolUsuario.IdRol));
                return oUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetCorreoAdministrador(int rolUsuario)
        {
            try
            {
                string correo = "";
                List<UsuarioBE> listUsuario = ListarUsuarios().Where(u => u.RolUsuario.IdRol.Equals(rolUsuario)).ToList();
                int count = listUsuario.Count();
                int countForeach = 0;
                foreach (UsuarioBE item in listUsuario.ToList())
                {
                    countForeach++;
                    if (count.Equals(countForeach))
                    {
                        correo += item.EmailUsuario;
                    }
                    else
                    {
                        correo = item.EmailUsuario + ",";
                    }


                }
                return correo;
            }
            catch (Exception)
            {

                return "correoNovalido@novalido.cl";
            }

        }

        public UsuarioBE UsuarioPorRut(string rut)
        {
            try
            {
                oUsuario = new UsuarioBE();
                return oUsuario = ListarUsuarios().Where(r => r.RutUsuario.Contains(rut)).First();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
