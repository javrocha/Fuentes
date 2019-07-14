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
    public partial class frmOrdenRecogida : System.Web.UI.Page
    {
        clsBasica objBasica = null;
        clsBasicaManager objBasicaManager = null;
        DataSet dsDatos = null;
        clsDespacho objDespacho = null;
        clsDespachoManager objDespachoManager = null;
        DataTable DatDatos = null;

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargaCombo("Z");
                Listar();

            }
        }


        protected void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim()!="")
            txtStock.Text = ConsultarStock().ToString();
        }



        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            
            
            if (int.Parse(txtStock.Text) < (int.Parse(txtCantidad.Text) + int.Parse(txtTotalZon.Text)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('La cantida excede el inventario de la zona');", true);
                return;
            }

            if (int.Parse(txtSolicitado.Text) < (int.Parse(txtCantidad.Text) + int.Parse(txtTotalProd.Text)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('La cantida excede la cantidad solicitada');", true);
                return;
            }

            if (txtLote.Enabled == true)
                Ingresar();
            else
                Actualizar();
            ListarDespachos();
            Limpiar();
        }

        protected void cmdEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            ListarDespachos();
            Limpiar();
        }

        protected void cmdDespachar_Click(object sender, EventArgs e)
        {
            Despachar();
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

        protected void grdDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fila;
            int filselect;
            fila = e.CommandArgument.ToString();
            filselect = Convert.ToInt32(fila);
            txtOrden.Text = grdOrden.Rows[filselect].Cells[1].Text;
            txtProducto.Text = grdOrden.Rows[filselect].Cells[3].Text;
            txtProducto.ToolTip = grdOrden.Rows[filselect].Cells[2].Text;
            cboZona.SelectedIndex = 0;
            txtSolicitado.Text= grdOrden.Rows[filselect].Cells[5].Text;
            ListarDespachos();

            
            
            

        }
        protected void grdDespacho_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fila;
            int filselect;
            fila = e.CommandArgument.ToString();
            filselect = Convert.ToInt32(fila);
            txtTotalProd.Text = grdDespacho.Rows[filselect].Cells[10].Text;
            txtTotalZon.Text = grdDespacho.Rows[filselect].Cells[11].Text;
            txtCantidad.Text= grdDespacho.Rows[filselect].Cells[9].Text;
            txtLote.Text= grdDespacho.Rows[filselect].Cells[7].Text;
            txtLote.Enabled = false;
            txtPallet.Text = grdDespacho.Rows[filselect].Cells[8].Text;
            txtPallet.Enabled = false;
            cboZona.Enabled = false;
            txtStock.Text =grdDespacho.Rows[filselect].Cells[12].Text;
            for (int cont = 0; cont <= cboZona.Items.Count; cont++)
           {
                   cboZona.SelectedIndex = cont;
                if (cboZona.SelectedValue == grdDespacho.Rows[filselect].Cells[4].Text)
          {
           break;
               }
               cboZona.SelectedIndex = 0;
           }

        }


        #endregion Eventos

        #region Metodos

        private int ConsultarStock()
        {
            int intTotal=0;
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "Q";
            objDespacho.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objDespacho.intzona = int.Parse(cboZona.SelectedItem.Value);
            objDespachoManager = new clsDespachoManager(objDespacho);
            intTotal = objDespachoManager.ConsultarStock();
            return intTotal;
        }
        
        private void CargaCombo(string parOperacion)
        {
            objBasica = new clsBasica();
            objBasica.strOperacion = parOperacion;
            objBasicaManager = new clsBasicaManager(objBasica);
            dsDatos = new DataSet();
            dsDatos = objBasicaManager.LlenarCombo();
            cboZona.DataSource = dsDatos;
            cboZona.DataTextField = "zo_descripcion";
            cboZona.DataValueField = "zo_codigo";
            cboZona.DataBind();
            cboZona.Items.Insert(0, new ListItem("<Seleccione un Item>", "0"));
            cboZona.SelectedIndex = 0;

        }

        private void Eliminar()
        {
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "D";
            objDespacho.strOrden = txtOrden.Text;
            objDespacho.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objDespacho.intzona = int.Parse(cboZona.SelectedItem.Value);
            objDespacho.intLote = int.Parse(txtLote.Text);
            objDespacho.intPallet = int.Parse(txtPallet.Text);
            objDespachoManager = new clsDespachoManager(objDespacho);
            objDespachoManager.Eliminar();
           
        }


        private void Actualizar()
        {
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "U";
            objDespacho.strOrden = txtOrden.Text;
            objDespacho.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objDespacho.intzona = int.Parse(cboZona.SelectedItem.Value);
            objDespacho.intLote = int.Parse(txtLote.Text);
            objDespacho.intPallet = int.Parse(txtPallet.Text);
            objDespacho.intCantidad = int.Parse(txtCantidad.Text);
            objDespachoManager = new clsDespachoManager(objDespacho);
            objDespachoManager.Guardar();
          
        }


        private void Despachar()
        {
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "A";
            objDespacho.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objDespacho.strOrden = txtOrden.Text;
            objDespachoManager = new clsDespachoManager(objDespacho);
            objDespachoManager.Guardar();

        }

        private void Ingresar()
        {

            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "I";
            objDespacho.strOrden=txtOrden.Text;
            objDespacho.intProducto = int.Parse(txtProducto.ToolTip.ToString());
            objDespacho.intLote = int.Parse(txtLote.Text);
            objDespacho.intPallet= int.Parse(txtPallet.Text);
            objDespacho.intCantidad= int.Parse(txtCantidad.Text);
            objDespacho.intzona= int.Parse(cboZona.SelectedItem.Value);
            objDespacho.intCantidad = int.Parse(txtCantidad.Text);
            objDespachoManager = new clsDespachoManager(objDespacho);
            objDespachoManager.Guardar();
        }

        private void Listar()
        {
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "C";
            objDespachoManager = new clsDespachoManager(objDespacho);
            DatDatos = new DataTable();
            DatDatos = objDespachoManager.Listar();
            grdOrden.DataSource=DatDatos;
            grdOrden.DataBind();
    
        }


        private void ListarDespachos()
        {
            objDespacho = new clsDespacho();
            objDespacho.strOperacion = "S";
            objDespacho.strOrden = txtOrden.Text;
            objDespachoManager = new clsDespachoManager(objDespacho);
            DatDatos = new DataTable();
            DatDatos = objDespachoManager.Listar();
            grdDespacho.DataSource = DatDatos;
            grdDespacho.DataBind();

        }



        private void Limpiar()
        {
            cboZona.SelectedIndex = 0;
            cboZona.Enabled = true;
            txtCantidad.Text = "";
            txtLote.Enabled = true;
            txtPallet.Enabled = true;
            txtPallet.Text = "";
            txtLote.Text = "";
            ListarDespachos();
            txtCantidad.Text = "";
            txtTotalProd.Text = "";
            txtTotalZon.Text = "";
            txtStock.Text = "";
        }



        #endregion Metodos

        protected void cboProducto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}