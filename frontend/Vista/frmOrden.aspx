<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOrden.aspx.cs" Inherits="Vista.frmOrden" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head Runat=Server> 
    <title>Fundación la luz</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
   <link href="css/style.css" rel="stylesheet" type="text/css" />
   <link href="css/menu.css" rel="stylesheet" type="text/css" />    
   <link href="css/grid.css" rel="stylesheet" type="text/css" />  
    <script type="text/javascript"  src="jquery/jquery-3.3.1.min.js"></script>

    <style type="text/css">
        .auto-style1 {
            width: 741px;
        }
        .auto-style2 {
            width: 24px;
        }
        .auto-style5 {
            width: 101px;
        }
        .auto-style6 {
            width: 137px;
        }
        .auto-style7 {
            width: 101px;
            height: 21px;
        }
        .auto-style9 {
            height: 21px;
        }
        .auto-style10 {
            width: 137px;
            height: 21px;
        }
        .auto-style15 {
            height: 21px;
            width: 123px;
        }
        .auto-style16 {
            width: 123px;
        }
        .auto-style18 {
            width: 70px;
            height: 21px;
        }
        .auto-style19 {
            width: 70px;
        }
        .auto-style21 {
            width: 101px;
            height: 30px;
        }
        .auto-style23 {
            height: 30px;
        }
        .auto-style24 {
            width: 137px;
            height: 30px;
        }
        .auto-style25 {
            height: 30px;
            width: 123px;
        }
        .auto-style26 {
            width: 70px;
            height: 30px;
        }
        .auto-style27 {
            width: 65px;
            height: 21px;
        }
        .auto-style28 {
            width: 65px;
            height: 30px;
        }
        .auto-style29 {
            width: 65px;
        }
    </style>

</head>
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
            <li><a href="https://comunicacionesfund28.wixsite.com/laluzdecolombia">Capacitaciones</a></li>
            <li><a href="#">Galería</a></li>
            <li><a href="Contactenos.aspx">Contáctenos</a></li>
      </ul>
    </div>
  
  </div>


<body>

 <br /><br /> <br />
  <div id="wrapper">
 
    <ul class="menu">
       
        <li class="item2"><a href="#">ORDENES</a>
            <ul>
                <li class="subitem1"><a href="frmOrden.aspx">INGRESO</a></li>
                <li class="subitem1"><a href="frmOrdenRecogida.aspx">RECOGIDA</a></li>
                <li class="subitem1"><a href="frmOrdenRecibida.aspx">ENTREGA</a></li>
             </ul>
        </li>
       <li class="item1" ><a href="#" >REPORTES</a>
            <ul>
                <li class="subitem1"><a href="#">REPORTE 1</a></li>
            </ul>
        </li>
      
      
    </ul>
 
</div>

    <form id="form1" runat="server">
      
        <table class="auto-style1">
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style27"></td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style15"></td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style18"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style28">
                 <asp:RequiredFieldValidator ID="reqNumDoc0" runat="server" ControlToValidate="txtOrden" ErrorMessage="*Ingrese campo" Font-Size="7px" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                 </td>
                <td class="auto-style23">
                    <asp:Label ID="lblOrden" runat="server" Text="Orden:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style25"></td>
                <td class="auto-style26"></td>
                <td class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style28">
                 <asp:RequiredFieldValidator ID="reqNumDoc1" runat="server" ControlToValidate="cboProducto" ErrorMessage="*Ingrese campo" Font-Size="7px" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                 </td>
                <td class="auto-style23">
                    <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="cboProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProducto_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style25">
                    <asp:Button ID="cmdGuardar" runat="server" OnClick="cmdGuardar_Click" Text="Guardar" Width="150px" />
                </td>
                <td class="auto-style26"></td>
                <td class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style28">
                    &nbsp;</td>
                <td class="auto-style23">
                    <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:TextBox ID="txtStock" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style25">
                    <asp:Button ID="cmdLimpiar" runat="server" OnClick="cmdLimpiar_Click" Text="Limpiar" Width="150px" />
                </td>
                <td class="auto-style26"></td>
                <td class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style27">
                 <asp:RequiredFieldValidator ID="reqNumDoc2" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*Ingrese campo" Font-Size="7px" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                 </td>
                <td class="auto-style9">
                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style15">
                 <asp:RegularExpressionValidator ID="regNumDoc" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*Dato inválido" Font-Size="7px" ForeColor="#CC3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style18"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
                <td colspan="4">
                    <asp:GridView ID="grdDatos" runat="server" OnRowCommand="grdDatos_RowCommand" Width="475px" OnSelectedIndexChanged="grdDatos_SelectedIndexChanged">
                   <Columns >
                      <asp:CommandField ButtonType="Image" SelectImageUrl="img/lapiz3.png"  ShowSelectButton  ="True" SelectText="" />
                     </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style19">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </form>
</body>

    
<div id="footer" class="auto-style2">
    <div class="lfooter"> &nbsp 2019 &copy; Fundación La Luz </div>
</div>
  </div>
    
<script type="text/javascript">
    $(function () {

        var menu_ul = $('.menu > li > ul'),
            menu_a = $('.menu > li > a');

        menu_ul.hide();

        menu_a.click(function (e) {
            e.preventDefault();
            if (!$(this).hasClass('active')) {
                menu_a.removeClass('active');
                menu_ul.filter(':visible').slideUp('normal');
                $(this).addClass('active').next().stop(true, true).slideDown('normal');
            } else {
                $(this).removeClass('active');
                $(this).next().stop(true, true).slideUp('normal');
            }
        });

    });

    function setHourglass() {
        document.body.style.cursor = 'wait';
    }
</script>
    

</html>
