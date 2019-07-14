<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIngreso.aspx.cs" Inherits="Vista.frmIngreso" %>

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head Runat=Server> 
   <title>Fundación la luz</title>
   <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
   <link href="css/menu.css" rel="stylesheet" type="text/css" />    
   <link href="css/media.css" rel="stylesheet" type="text/css" />    
    
    
   
    
</head>

<form class="form1" runat="server">

<div id="headerme">
    <div class="site_titleme">
        <h1><img src="bg/laluz.gif" alt="" class="magnify" /> <a href="#" style="color: #FFFF66">Fundación</a> <a href="#  ">La Luz</a></h1>
    </div>
    <div class="sloganme"> Hacemos la diferencia en un mundo indiferente. </div>
    <div id="navme">
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



<section class="contenido-menu">
    <div class="fondo-menu">

        <article class="container-menu">
            <a class="vinculo-menu" href="index.html"">Inicio</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="nosotros.html">Nosotros</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="programa.html">Nuestros servicios</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="Ingreso.aspx">Aplicaciones</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="https://comunicacionesfund28.wixsite.com/laluzdecolombia">Capacitaciones</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="#">Galería</a>
        </article>
        <article class="container-menu">
            <a class="vinculo-menu" href="Contactenos.aspx">Contáctenos</a>
        </article>
    </div>
</section>
<br>
<body>


    <section class="contenidoing">

        <article class="posting">
        <div class="imagen">
            &nbsp;<img alt="" class="center"  src="img/Candado.jpg" /></div>
      
        <div class="clave">
         
           <a style="color:#0174DF; font-size: 1.3em;font-family: helvetica, arial, sans-serif;">Usuario:</a>
            &nbsp
            <asp:TextBox ID="txtUsuario" runat="server" Width="214px"></asp:TextBox>
            <br />     <br />
             <a style="color:#0174DF; font-size: 1.3em;font-family: helvetica, arial, sans-serif;">Clave:</a>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
            <asp:TextBox ID="txtClave" runat="server" Width="214px" TextMode="Password"></asp:TextBox>
             <br />
            
            
            <asp:HyperLink ID="lblMenIng" style="color:#FF0000; font-size: 1.1em;font-family: helvetica, arial, sans-serif;" runat="server" Visible="False">*Usuario o clave incorrecta</asp:HyperLink>
            <br />   <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
            <asp:Button ID="cmdIngreso" runat="server" BackColor="#003599" BorderColor="#FFFF99" BorderStyle="Solid" ForeColor="White" Height="33px" Text="Ingresar" Width="250px" OnClick="cmdIngreso_Click"   />
            <br/> <br/> 
            
            <a  style="color:#0174DF; font-size: 1.3em;font-family: helvetica, arial, sans-serif;" href="#">Cambio de clave</a>

        </div>
           
        
           
      
        
        </article>
       

       
    </section>

</body>
<br><br>


<div id="footer" class="auto-style2">
    <div class="lfooter"> &nbsp 2019 &copy; Fundación La Luz </div>
</div>
</form>


</html>



