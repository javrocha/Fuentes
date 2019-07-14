<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAplicaciones.aspx.cs" Inherits="Vista.frmAplicaciones" %>

<html background-color: #F0F2D9 xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
   <title>Fundación la luz</title>
   <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
   <link href="../css/style.css" rel="stylesheet" type="text/css" />
   <link href="../css/styleap.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 105px;
        }
        .auto-style5 {
            width: 299px;
        }
        .auto-style8 {
            width: 219px;
        }
        .auto-style9 {
            width: 66px;
        }
        .auto-style10 {
            width: 187px;
        }
        .auto-style11 {
            width: 6px;
        }
        .auto-style12 {
            height: 7px;
        }
        .auto-style13 {
            width: 105px;
            height: 7px;
        }
        .auto-style14 {
            width: 187px;
            height: 7px;
        }
        .auto-style15 {
            width: 299px;
            height: 7px;
        }
        .auto-style16 {
            width: 6px;
            height: 7px;
        }
        .auto-style17 {
            width: 219px;
            height: 7px;
        }
        .auto-style18 {
            width: 66px;
            height: 7px;
        }
        .auto-style19 {
            height: 31px;
        }
        .auto-style20 {
            width: 105px;
            height: 31px;
        }
        .auto-style21 {
            width: 187px;
            height: 31px;
        }
        .auto-style22 {
            width: 299px;
            height: 31px;
        }
        .auto-style23 {
            width: 6px;
            height: 31px;
        }
        .auto-style24 {
            width: 219px;
            height: 31px;
        }
        .auto-style25 {
            width: 66px;
            height: 31px;
        }
        </style>
    
</head>

<body>






    <form id="form1" runat="server">






<div id="header">
    <div class="site_title">
      <h1><img src="img/laluz.png" alt="" class="magnify" /> <a href="#" style="color: #FFFF66">Fundación</a> <a href="#  ">La Luz</a></h1>
    </div>
    <div class="slogan"> Hacemos la diferencia en un mundo indiferente. </div>
    <div id="nav">
    <ul>
            <li><a href="#"></a></li>
            <li><a href="index.html">Inicio</a></li>
            <li><a href="nosotros.html">Nosotros</a></li>
            <li><a href="programa.html">Nuestros servicios</a></li>
            <li><a href="frmIngreso.aspx">Aplicaciones</a></li>
            <li><a href="Gestion humana/Ingreso.aspx">Aplicaciones</a></li>
            <li><a href="https://comunicacionesfund28.wixsite.com/laluzdecolombia">Capacitaciones</a></li>
            <li><a href="#">Galería</a></li>
            <li><a href="#">Contáctenos</a></li>
      </ul>
    </div>
  
  </div>
      <div id="ingresoespacio" >
      </div>
     <div id="imagen" >
     <img alt=""  src="img/Bienvenida.png"  />
         
     </div>

   
    <div id="bienvenida">
        <asp:Label ID="lblBienvenida" runat="server" Text="Bienvenido(a) " Font-Names="MS Reference Sans Serif" Font-Size="X-Large" ForeColor="Blue" Font-Bold="True"></asp:Label>
        <br> </br>
           
          <div class="boxingreso">
      <p>En la parte inferior de la página, encontrarás las diferentes aplicaciones web disponibles.  </p>  
       <br> </br>
          
         </div>
    </div>
  <table class="auto-style2">
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style13"></td>
            <td class="auto-style14"></td>
            <td class="auto-style15"></td>
            <td class="auto-style16"></td>
            <td class="auto-style17"></td>
            <td class="auto-style18"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">
                <asp:ImageButton ID="cmdGestionHumana" runat="server" ImageUrl="img/GestionHumana.png" ToolTip="Usuarios" OnClick="cmdGestionHumana_Click" Enabled="False" />
            </td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">
                <asp:ImageButton ID="cmdInventario" runat="server" ImageUrl="img/Inventarios.png" ToolTip="Inventario" OnClick="cmdInventario_Click" Enabled="False" />
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>
                <asp:ImageButton ID="cmdPresupuesto" runat="server" Height="111px" ImageUrl="img/Presupuesto.png" ToolTip="Presupuesto" Width="122px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">
                <asp:HyperLink ID="hypGestionHumana" runat="server" ForeColor="Blue" NavigateUrl="~/frmUsuario.aspx" Enabled="False">Usuarios</asp:HyperLink>
            </td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">
                <asp:HyperLink ID="hypInventario" runat="server" ForeColor="Blue" NavigateUrl="~/frmOrden.aspx" Enabled="False">Inventario</asp:HyperLink>
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td>
                <asp:HyperLink ID="hypPresupuesto" runat="server" ForeColor="Blue">Presupuesto</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19"></td>
            <td class="auto-style20"></td>
            <td class="auto-style21"></td>
            <td class="auto-style22"></td>
            <td class="auto-style23"></td>
            <td class="auto-style24"></td>
            <td class="auto-style25"></td>
            <td class="auto-style19"></td>
            <td class="auto-style19"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        
  </body>
  
<div id="footer" class="auto-style2">
    <div class="lfooter"> &nbsp 2019 &copy; Fundación La Luz </div>
</div>
    
    </form>

</html>