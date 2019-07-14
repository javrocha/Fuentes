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
    public class clsDespachoManager
    {
        clsDatos cnConexion = null;
        clsDespacho objDespacho = null;
        DataTable datResultado = null;

        public clsDespachoManager(clsDespacho parobjDespacho)
        {
            objDespacho = parobjDespacho;
        }

        public DataTable Listar()
        {
            datResultado= new DataTable();
            try
            {
                cnConexion = new clsDatos();
                SqlParameter[] parParameter = new SqlParameter[2];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objDespacho.strOperacion;
                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_referencia";
                parParameter[1].SqlDbType = SqlDbType.Char;
                parParameter[1].Value = objDespacho.strOrden;
                datResultado = cnConexion.Consultar(parParameter, "sp_orden_despacho");
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

                SqlParameter[] parParameter = new SqlParameter[3];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objDespacho.strOperacion;
                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_producto";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].Value = objDespacho.intProducto;
                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_zona";
                parParameter[2].SqlDbType = SqlDbType.Int;
                parParameter[2].Value = objDespacho.intzona;

                intResultado = cnConexion.ConsultarProducto (parParameter, "sp_orden_despacho");
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
                SqlParameter[] parParameter = new SqlParameter[7];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objDespacho.strOperacion;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_referencia";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].Value = objDespacho.strOrden;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_producto";
                parParameter[2].SqlDbType = SqlDbType.Int;
                parParameter[2].Value = objDespacho.intProducto;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@i_zona";
                parParameter[3].SqlDbType = SqlDbType.Int;
                parParameter[3].Value = objDespacho.intzona;

                parParameter[4] = new SqlParameter();
                parParameter[4].ParameterName = "@i_lote";
                parParameter[4].SqlDbType = SqlDbType.Int;
                parParameter[4].Value = objDespacho.intLote;

                parParameter[5] = new SqlParameter();
                parParameter[5].ParameterName = "@i_pallet";
                parParameter[5].SqlDbType = SqlDbType.Int;
                parParameter[5].Value = objDespacho.intPallet;

                parParameter[6] = new SqlParameter();
                parParameter[6].ParameterName = "@i_cantidad";
                parParameter[6].SqlDbType = SqlDbType.Int;
                parParameter[6].Value = objDespacho.intCantidad;
                
                cnConexion.EjecutarSP(parParameter, "sp_orden_despacho");



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
                SqlParameter[] parParameter = new SqlParameter[6];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@i_operacion";
                parParameter[0].SqlDbType = SqlDbType.Char;
                parParameter[0].Value = objDespacho.strOperacion;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@i_referencia";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].Value = objDespacho.strOrden;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@i_producto";
                parParameter[2].SqlDbType = SqlDbType.Int;
                parParameter[2].Value = objDespacho.intProducto;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@i_zona";
                parParameter[3].SqlDbType = SqlDbType.Int;
                parParameter[3].Value = objDespacho.intzona;

                parParameter[4] = new SqlParameter();
                parParameter[4].ParameterName = "@i_lote";
                parParameter[4].SqlDbType = SqlDbType.Int;
                parParameter[4].Value = objDespacho.intLote;

                parParameter[5] = new SqlParameter();
                parParameter[5].ParameterName = "@i_pallet";
                parParameter[5].SqlDbType = SqlDbType.Int;
                parParameter[5].Value = objDespacho.intPallet;

                cnConexion.EjecutarSP(parParameter, "sp_orden_despacho");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return datResultado;


        }


    }
}
