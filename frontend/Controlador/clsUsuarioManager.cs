using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Controlador
{
    public class clUsuarioManager
    {
        clsDatos cnConexion = null;
        clsUsuario objUsuario = null;
        DataTable datResultado = null;

        public clUsuarioManager(clsUsuario parobjUsuario)
        {
            objUsuario = parobjUsuario;
        }

        public DataTable Listar()
        {
            datResultado= new DataTable();
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[3];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objUsuario.strOperacion;
                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_login";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Value = objUsuario.strLogin;
                parParameter[1].Size = 15;
                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_psw";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Value = objUsuario.strPassword;
                parParameter[1].Size = 100;



                datResultado = cnConexion.Consultar(parParameter, "sp_usuario");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

        public DataTable Habilitar()
        {
            datResultado = new DataTable();
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objUsuario.strOperacion;
                datResultado = cnConexion.Consultar(parParameter, "sp_seg_modulo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }


        public DataTable Guardar()
        {
            
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[6];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objUsuario.strOperacion;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_documento";
                parParameter[1].SqlDbType = SqlDbType.BigInt;
                parParameter[1].Value = objUsuario.lonDocumento;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_nombre";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 50;
                parParameter[2].Value = objUsuario.strNombre;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@i_login";
                parParameter[3].SqlDbType = SqlDbType.VarChar;
                parParameter[3].Size = 15;
                parParameter[3].Value = objUsuario.strLogin;

                parParameter[4] = new SqlParameter();
                parParameter[4].ParameterName = "@i_psw";
                parParameter[4].SqlDbType = SqlDbType.VarChar;
                parParameter[4].Size = 100;
                parParameter[4].Value = objUsuario.strPassword;

                parParameter[5] = new SqlParameter();
                parParameter[5].ParameterName = "@i_rol";
                parParameter[5].SqlDbType = SqlDbType.VarChar;
                parParameter[5].Value = objUsuario.intRol;

                cnConexion.EjecutarSP(parParameter, "sp_usuario");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

        public DataTable Eliminar()
        {
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[2];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objUsuario.strOperacion;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_documento";
                parParameter[1].SqlDbType = SqlDbType.BigInt;
                parParameter[1].Value = objUsuario.lonDocumento;
                cnConexion.EjecutarSP(parParameter, "sp_usuario");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

        public static implicit operator clUsuarioManager(clsUsuario v)
        {
            throw new NotImplementedException();
        }
    }
}
