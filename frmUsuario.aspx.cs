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
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using Controlador;

namespace Vista
{
    public partial class frmUsuario : System.Web.UI.Page
    {
        clsBasica objBasica = null;
        clsBasicaManager objBasicaManager = null;
        DataSet dsDatos = null;
        clsUsuario objUsuario = null;
        clUsuarioManager objUsuarioManager = null;
        DataTable DatDatos = null;

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                CargaCombo("R");
                Listar();

            }
        }

        private void CargaCombo(string parOperacion)
        {
            objBasica = new clsBasica();
            objBasica.strOperacion = parOperacion;
            objBasicaManager = new clsBasicaManager(objBasica);
            dsDatos = new DataSet();
            dsDatos = objBasicaManager.LlenarCombo();
            cboRol.DataSource = dsDatos;
            cboRol.DataTextField = "ro_nombre";
            cboRol.DataValueField = "ro_codigo";
            cboRol.DataBind();
            cboRol.Items.Insert(0, new ListItem("<Seleccione un Item>", "0"));
            cboRol.SelectedIndex = 0;

        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Enabled == true)
                Ingresar();
            else
                Actualizar();
            Listar();
        }

        protected void cmdEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
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
            txtDocumento.Text = grdDatos.Rows[filselect].Cells[1].Text;
            txtDocumento.Enabled = false;
            txtNombre.Text = grdDatos.Rows[filselect].Cells[2].Text;
            txtLogin.Text = grdDatos.Rows[filselect].Cells[3].Text;
            txtPassword.Text = grdDatos.Rows[filselect].Cells[4].Text;
            for (int cont = 0; cont <= cboRol.Items.Count; cont++)
            {
                cboRol.SelectedIndex = cont;
                if (cboRol.SelectedValue == grdDatos.Rows[filselect].Cells[5].Text)
                {
                    break;
                }
                cboRol.SelectedIndex = 0;
            }

        }


        #endregion Eventos

        #region Metodos

        private void Eliminar()
        {
            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "D";
            objUsuario.lonDocumento = long.Parse(txtDocumento.Text);
            objUsuarioManager = new clUsuarioManager(objUsuario);
            objUsuarioManager.Eliminar();
            Listar();
        }

        private void Actualizar()
        {
            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "U";
            objUsuario.lonDocumento = long.Parse(txtDocumento.Text);
            objUsuario.strNombre = txtNombre.Text;
            objUsuario.strLogin = txtLogin.Text;
            if (txtPassword.Text.Trim()!=null)
               objUsuario.strPassword = GeneraHash(txtPassword.Text);
            objUsuario.intRol = int.Parse(cboRol.SelectedItem.Value);
            objUsuarioManager = new clUsuarioManager(objUsuario);
            objUsuarioManager.Guardar();
        }

        private void Ingresar()
        {
            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "I";
            objUsuario.lonDocumento = long.Parse(txtDocumento.Text);
            objUsuario.strNombre = txtNombre.Text;
            objUsuario.strLogin = txtLogin.Text;
            objUsuario.strPassword = GeneraHash(txtPassword.Text);
            objUsuario.intRol = int.Parse(cboRol.SelectedItem.Value);
            objUsuarioManager = new clUsuarioManager(objUsuario);
            objUsuarioManager.Guardar();
        }

        private void Listar()
        {
            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "C";
            objUsuarioManager = new clUsuarioManager(objUsuario);
            DatDatos = new DataTable();
            DatDatos = objUsuarioManager.Listar();
            grdDatos.DataSource=DatDatos;
            grdDatos.DataBind();
           


        }

        private void Limpiar()
        {
            txtDocumento.Enabled = true;
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            cboRol.SelectedIndex = 0;
            Listar();

        }

        public string GeneraHash(string cadena)
        {
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            byte[] datos = ASCIIEncoding.ASCII.GetBytes(cadena.Trim());//new byte[Cadena.Length];
            hashMD5.ComputeHash(datos);
            cadena = Convert.ToBase64String(hashMD5.Hash);
            return cadena;
        }

        #endregion Metodos
    }
}