using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using System.Data;


namespace Vista
{
    public partial class frmAplicaciones : System.Web.UI.Page
    {
        DataSet dsDatos = null;
        clsUsuario objUsuario = null;
        clUsuarioManager objUsuarioManager = null;
        DataTable DatDatos = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            HabilitarModulos();
        }

        protected void cmdGestionHumana_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmUsuario.aspx");
        }


        protected void cmdInventario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmOrden.aspx");
        }

        private void HabilitarModulos()
        {
            string strValor = "";
            string strCad = "";
            strCad = Convert.ToString(Request.QueryString["login"]);

            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "Q";
            objUsuario.strLogin = strCad;
            objUsuarioManager = new clUsuarioManager(objUsuario);
            DatDatos = new DataTable();
            DatDatos = objUsuarioManager.Listar();
            foreach (DataRow rowvalor in DatDatos.Rows)
            {
                strValor = rowvalor[0].ToString();
                switch (strValor)
                {
                   
                 
                    case "Inventarios":
                        cmdInventario.Enabled = true;
                        hypInventario.Enabled = true;
                        break;

                    case "Usuario":
                        cmdGestionHumana.Enabled = true;
                        hypGestionHumana.Enabled = true;
                        break;
                    default:
                        break;
                }
            }



        }

    }
}