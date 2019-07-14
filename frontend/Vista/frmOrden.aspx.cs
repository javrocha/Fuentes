using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using Controlador;

namespace Vista
{
    public partial class frmOrden : System.Web.UI.Page
    {
        clsBasica objBasica = null;
        clsBasicaManager objBasicaManager = null;
        DataSet dsDatos = null;
        clsOrden objOrden = null;
        clsOrdenManager objOrdenManager = null;
        DataTable DatDatos = null;

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargaCombo("P");
                Listar();

            }
        }


        protected void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStock.Text = ConsultarStock().ToString();
        }
        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtStock.Text)<int.Parse(txtCantidad.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('La cantida excede el inventario actual');", true);
                return;
            }

            if (txtOrden.Enabled == true)
                Ingresar();
            else
                Actualizar();
            Listar();
        }

       

        protected void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void grdDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fila;
            int filselect;
            fila = e.CommandArgument.ToString();
            filselect = Convert.ToInt32(fila);
            txtOrden.Text = grdDatos.Rows[filselect].Cells[1].Text;
            txtOrden.Enabled = false;
            txtCantidad.Text= grdDatos.Rows[filselect].Cells[4].Text;
            txtStock.Text = grdDatos.Rows[filselect].Cells[5].Text;
            for (int cont = 0; cont <= cboProducto.Items.Count; cont++)
           {
                   cboProducto.SelectedIndex = cont;
                if (cboProducto.SelectedValue == grdDatos.Rows[filselect].Cells[2].Text)
          {
           break;
               }
               cboProducto.SelectedIndex = 0;
           }

        }


        #endregion Eventos

        #region Metodos

        private int ConsultarStock()
        {
            int intTotal=0;
            objOrden = new clsOrden();
            objOrden.strOperacion = "Q";
            objOrden.intProducto= int.Parse(cboProducto.SelectedItem.Value);
            objOrdenManager = new clsOrdenManager(objOrden);
            intTotal = objOrdenManager.ConsultarStock();
            return intTotal;
        }

        private void CargaCombo(string parOperacion)
        {
            objBasica = new clsBasica();
            objBasica.strOperacion = parOperacion;
            objBasicaManager = new clsBasicaManager(objBasica);
            dsDatos = new DataSet();
            dsDatos = objBasicaManager.LlenarCombo();
            cboProducto.DataSource = dsDatos;
            cboProducto.DataTextField = "pr_descripcion";
            cboProducto.DataValueField = "pr_codigo";
            cboProducto.DataBind();
            cboProducto.Items.Insert(0, new ListItem("<Seleccione un Item>", "0"));
            cboProducto.SelectedIndex = 0;

        }

        private void Actualizar()
        {
            objOrden = new clsOrden();
            objOrden.strOperacion = "U";
            objOrden.strOrden = txtOrden.Text;
            objOrden.intProducto = int.Parse(cboProducto.SelectedItem.Value);
            objOrden.intCantidad = int.Parse(txtCantidad.Text);
            objOrdenManager = new clsOrdenManager(objOrden);
            objOrdenManager.Guardar();
        }

        private void Ingresar()
        {
            objOrden = new clsOrden();
            objOrden.strOperacion = "I";
            objOrden.strOrden=txtOrden.Text;
            objOrden.intProducto = int.Parse(cboProducto.SelectedItem.Value);
            objOrden.intCantidad = int.Parse(txtCantidad.Text);
            objOrdenManager = new clsOrdenManager(objOrden);
            objOrdenManager.Guardar();
        }

        private void Listar()
        {
            objOrden = new clsOrden();
            objOrden.strOperacion = "C";
            objOrdenManager = new clsOrdenManager(objOrden);
            DatDatos = new DataTable();
            DatDatos = objOrdenManager.Listar();
            grdDatos.DataSource=DatDatos;
            grdDatos.DataBind();
           


        }

        private void Limpiar()
        {
            txtOrden.Enabled = true;
            txtOrden.Text = "";
            txtStock.Text = "";
            txtCantidad.Text = "";
            cboProducto.SelectedIndex = 0;
           
            Listar();

        }



        #endregion Metodos

        protected void cboProducto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}