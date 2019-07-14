using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class clsDatos
    {

        SqlConnection cnnConexion=null;
        SqlCommand cmdComando = null;
        SqlDataAdapter dapAdaptador = null;
        DataTable datResultado = null;
        DataSet dsResultado = null;
        string strConexion = String.Empty;

        public clsDatos()
        {

            strConexion = "server=asael.colombiahosting.com.co\\MSSQLSERVER2014 ; database=laluzde_funluz ; User ID = laluzde_admin;  

         }

        public void EjecutarSP(SqlParameter[]parParametros,string parProcedimiento)
        {
            try
            {
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parProcedimiento;
                cmdComando.Parameters.AddRange(parParametros);
                cmdComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }


        }

        public DataTable Consultar(SqlParameter[] parParametros, string parProcedimiento)
        {
            datResultado = null;
            try
            {
                datResultado = new DataTable();
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parProcedimiento;
                cmdComando.Parameters.AddRange(parParametros);
                dapAdaptador = new SqlDataAdapter(cmdComando);
                dapAdaptador.Fill(datResultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                dapAdaptador.Dispose();
            }

            return (datResultado);

        }

        public int ConsultarProducto(SqlParameter[] parParametros, string parProcedimiento)
        {
            int intOperacion = 0;
            datResultado = null;
            try
            {
                datResultado = new DataTable();
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parProcedimiento;
                cmdComando.Parameters.AddRange(parParametros);
                cnnConexion.Open();
                intOperacion = int.Parse(cmdComando.ExecuteScalar().ToString());
            }
             catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
            finally
            {
               cnnConexion.Dispose();
               cmdComando.Dispose();
            }

            return (intOperacion);

        }

        public DataSet CargarCombo(SqlParameter[] parParametros, string parProcedimiento)
        {
            dsResultado = null;
            try
            {
                dsResultado = new DataSet();
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parProcedimiento;
                cmdComando.Parameters.AddRange(parParametros);
                dapAdaptador = new SqlDataAdapter(cmdComando);
                dapAdaptador.Fill(dsResultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                dapAdaptador.Dispose();
            }

            return (dsResultado);

        }

    }

   
}
