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
    public class clsBasicaManager
    {
        clsDatos cnConexion = null;
        clsBasica objBasica = null;
        DataTable datResultado = null;
        DataSet dsResultado = null;
        public clsBasicaManager(clsBasica parobjBasica)
        {
            objBasica = parobjBasica;
        }

        public DataTable Listar()
        {
            datResultado= new DataTable();
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objBasica.strOperacion;
                datResultado = cnConexion.Consultar(parParameter, "sp_basica");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

        public DataSet LlenarCombo()
        {
            dsResultado = new DataSet();
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objBasica.strOperacion;
                dsResultado = cnConexion.CargarCombo(parParameter, "sp_basica");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return dsResultado;


        }


        public static implicit operator clsBasicaManager(clsUsuario v)
        {
            throw new NotImplementedException();
        }
    }
}
