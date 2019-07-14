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
    public class clsRecepcionManager
    {
        clsDatos cnConexion = null;
        clsRecepcion objRecepcion = null;
        DataTable datResultado = null;

        public clsRecepcionManager(clsRecepcion parobjRecepcion)
        {
            objRecepcion = parobjRecepcion;
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
                parParameter[0].Value = objRecepcion.strOperacion;
                datResultado = cnConexion.Consultar(parParameter, "sp_orden_entrega");
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
                SqlParameter[] parParameter = new SqlParameter[4];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objRecepcion.strOperacion;

                parParameter[1] = new SqlParameter();   
                parParameter[1].ParameterName = "@i_referencia";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].Value = objRecepcion.strOrden;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_producto";
                parParameter[2].SqlDbType = SqlDbType.Int;
                parParameter[2].Value = objRecepcion.intProducto ;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@i_cantidad";
                parParameter[3].SqlDbType = SqlDbType.Int;
                parParameter[3].Value = objRecepcion.intCantidad;

                cnConexion.EjecutarSP(parParameter, "sp_orden_entrega");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }
     

   

    }
}
