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
    public partial class frmOrdenRecibida : System.Web.UI.Page
    {
        DataSet dsDatos = null;
        clsRecepcion objRecepcion = null;
        clsRecepcionManager objRecepcionManager = null;
        DataTable DatDatos = null;

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {

                Listar();

            }
        }

        protected void grdOrden_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fila;
            int filselect;
            fila = e.CommandArgument.ToString();
            filselect = Convert.ToInt32(fila);
            txtOrden.Text = grdOrden.Rows[filselect].Cells[1].Text;
            txtProducto.Text = grdOrden.Rows[filselect].Cells[3].Text;
            txtProducto.ToolTip = grdOrden.Rows[filselect].Cells[2].Text;
            txtSolicitado.Text = grdOrden.Rows[filselect].Cells[5].Text;
            txtDespachado.Text = grdOrden.Rows[filselect].Cells[6].Text;
            if (grdOrden.Rows[filselect].Cells[7].Text != "&nbsp;")
                txtRecibido.Text = grdOrden.Rows[filselect].Cells[7].Text;
        }


        protected void cmdGuardar_Click(object sender, EventArgs e)
        {


            if (int.Parse(txtSolicitado.Text) < int.Parse(txtRecibido.Text) )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('La cantidad excede lo solicitado');", true);
                return;
            }

            if (int.Parse(txtSolicitado.Text) != int.Parse(txtDespachado.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('La cantidad es diferente a lo despachado');", true);
                return;
            }


            Ingresar();
            Limpiar();
        }



        protected void cmdDespachar_Click(object sender, EventArgs e)
        {
            //Despachar();
            Listar();
            Limpiar();
            txtOrden.Text = "";
            txtProducto.Text = "";
            txtSolicitado.Text = "";
        }

        protected void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }


        protected void cmdRecibir_Click(object sender, EventArgs e)
        {
            Recibir();
            Listar();
            Limpiar();

        }


        #endregion Eventos

        #region Metodos


        private void Ingresar()
        {

            objRecepcion = new clsRecepcion();
            objRecepcion.strOperacion = "I";
            objRecepcion.strOrden = txtOrden.Text;
            objRecepcion.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objRecepcion.intCantidad = int.Parse(txtRecibido.Text);
            objRecepcionManager = new clsRecepcionManager(objRecepcion);
            objRecepcionManager.Guardar();
            Limpiar();
            Listar();
        }



        
        private void Recibir()
        {
           objRecepcion = new clsRecepcion();
           objRecepcion.strOperacion = "U";
           objRecepcion.intProducto = int.Parse(txtProducto.ToolTip.ToString());
           objRecepcion.strOrden = txtOrden.Text;
           objRecepcionManager = new clsRecepcionManager(objRecepcion);
           objRecepcionManager.Guardar();

        }

        
        private void Listar()
        {
            objRecepcion = new clsRecepcion();
            objRecepcion.strOperacion = "C";
            objRecepcionManager = new clsRecepcionManager(objRecepcion);
            DatDatos = new DataTable();
            DatDatos = objRecepcionManager.Listar();
            grdOrden.DataSource = DatDatos;
            grdOrden.DataBind();

        }






        private void Limpiar()
        {
            txtOrden.Text = "";
            txtProducto.Text = "";
            txtSolicitado.Text = "";
            txtDespachado.Text = "";
            txtRecibido.Text = "";

        }







        #endregion Metodos

        
    }
}