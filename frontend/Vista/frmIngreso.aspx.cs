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
    public partial class frmIngreso : System.Web.UI.Page
    {


        DataSet dsDatos = null;
        clsUsuario objUsuario = null;
        clUsuarioManager objUsuarioManager = null;
        DataTable DatDatos = null;
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdIngreso_Click(object sender, EventArgs e)
        {
            string strValor = "";
            string strLogin = "";
            objUsuario = new clsUsuario();
            objUsuario.strOperacion = "V";
            objUsuario.strLogin = txtUsuario.Text;
            objUsuario.strPassword = GeneraHash(txtClave.Text);
            objUsuarioManager = new clUsuarioManager(objUsuario);
            DatDatos = new DataTable();
            DatDatos = objUsuarioManager.Listar();
            foreach (DataRow rowvalor in DatDatos.Rows)
            {
                strValor = rowvalor[0].ToString();
                strLogin = txtUsuario.Text;
            }

            if (strValor == "0")
            {
                lblMenIng.Visible = true;
                lblMenIng.Text = "*Clave incorrecta";
                return ; 
            }


            if (strValor == "-1")
            {
                lblMenIng.Visible = true;
                lblMenIng.Text = "*Usuario incorrecto";
                return;
            }

            Response.Redirect("frmAplicaciones.aspx?login=" + strLogin);
       


    }

    public string GeneraHash(string cadena)
        {
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            byte[] datos = ASCIIEncoding.ASCII.GetBytes(cadena.Trim());
            hashMD5.ComputeHash(datos);
            cadena = Convert.ToBase64String(hashMD5.Hash);
            return cadena;
        }


    }
}