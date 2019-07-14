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
    public class clsOrdenManager
    {
        clsDatos cnConexion = null;
        clsOrden objOrden = null;
        DataTable datResultado = null;

        public clsOrdenManager(clsOrden parobjOrden)
        {
            objOrden = parobjOrden;
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
                parParameter[0].Value = objOrden.strOperacion;
                datResultado = cnConexion.Consultar(parParameter, "sp_orden");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

        public int ConsultarStock()
        {
            int intResultado = 0;
            try
            {
                cnConexion = new clsDatos();

                SqlParameter[] parParameter = new SqlParameter[2];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objOrden.strOperacion;
                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_producto";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].Value = objOrden.intProducto;
                intResultado = cnConexion.ConsultarProducto (parParameter, "sp_orden");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return intResultado;


        }


        public DataTable Guardar()
        {
            
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[4];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objOrden.strOperacion;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_referencia";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].Value = objOrden.strOrden;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_producto";
                parParameter[2].SqlDbType = SqlDbType.Int;
                parParameter[2].Value = objOrden.intProducto;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@i_cantidad";
                parParameter[3].SqlDbType = SqlDbType.Int;
                parParameter[3].Value = objOrden.intCantidad;
                
                cnConexion.EjecutarSP(parParameter, "sp_orden");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }

      
       
    }
}
