using Arriendo.Negocio;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Test
{
    class Test
    {
        //static RegionDA regionDa;
        static ComunaBL comunaDL;
        static UsuarioBL usuarioBL;
        //static ProvinciaDA provinciaDa;
        static List<ComunaBE> listComuna;
        static List<UsuarioBE> listUsuario;
        static void Main(string[] args)
        {
            try
            {
                //ListaComunaId();
                LoginUsuario();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
                Console.ReadKey();
            }
           
        }

        private static void ListaComunaId()
        {
            comunaDL = new ComunaBL();
            listComuna = new List<ComunaBE>();
            int idComuna = 338;
            listComuna = comunaDL.ListarComunaPorId(idComuna);

            foreach (ComunaBE item in listComuna.ToList())
            {
                Console.WriteLine("Id COmuna : " + item.IdComuna);
                Console.WriteLine("Nombre COmuna : " + item.NombreComuna);
                Console.WriteLine("Id Provincia : " + item.Provincia.IdProvincia);
                Console.WriteLine("-------------------------------------------");
            }
            
        }

        private static void LoginUsuario() {
            usuarioBL = new UsuarioBL();
            listUsuario = new List<UsuarioBE>();
            listUsuario = usuarioBL.ListarUsuarios();

            foreach (UsuarioBE item in listUsuario.ToList())
            {
                Console.WriteLine("-----------------Usuarios--------------------------");
                Console.WriteLine("Rut : " + item.RutUsuario);
                Console.WriteLine("Dv : " + item.DvUsuario);
                Console.WriteLine("Nombre : " + item.NombreUsuario);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
