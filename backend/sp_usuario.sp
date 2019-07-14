if exists (select * from sysobjects where id = object_id('sp_usuario'))
  drop procedure sp_usuario
GO
	

create proc sp_sp_usuario(
@i_operacion          char(1)          = null,
@i_documento          bigint           = null,             
@i_nombre             varchar(50)      = null,
@i_login              varchar(15)      = null,
@i_psw                varchar(100)      = null,
@i_rol                int              = null 

)
as 
declare
@w_resultado smallint,
@w_psw            varchar(80),
@w_nombre         varchar(100)



if @i_operacion='V'   
begin  
  
   select @w_resultado=0
   select @w_nombre=''         
   select @w_psw            =  us_psw, 
          @w_nombre         = us_nombre
   from ej_usuario A
   where us_login=@i_login    



if ltrim(rtrim(@w_nombre))=''
  select @w_resultado=-1
else
begin
   if @w_psw=@i_psw 
       select @w_resultado=1
   else
      select @w_resultado=0
end

select @w_resultado,        @w_nombre  

end       


if @i_operacion='I'
begin
 if not exists(select 1 from   ej_usuario where us_documento=@i_documento)
 begin  
   insert into ej_usuario(us_documento,      us_nombre,   us_login,      us_psw)
   values                (@i_documento,       @i_nombre,    @i_login, @i_psw)

   insert into ej_usuario_rol (us_documento, ro_codigo)
   values  (@i_documento, @i_rol)
 end 
 select @w_resultado=@@ROWCOUNT
end 



if @i_operacion='U'
begin
   
   update ej_usuario set        us_nombre    =  @i_nombre ,
                                us_login     =  @i_login ,  
                                us_psw       =  @i_psw  
   where                        us_documento =  @i_documento

   update ej_usuario_rol   set  ro_codigo        =  @i_rol 
   where                        us_documento =  @i_documento


   select @w_resultado=@@ROWCOUNT
end 



if @i_operacion='D'
begin
   
   delete ej_usuario_rol   
   where us_documento =  @i_documento

   delete ej_usuario
   where  us_documento   =  @i_documento


   select @w_resultado=@@ROWCOUNT
end 


if @i_operacion='C'
begin
   
   select  DOCUMENTO  =  a.us_documento, 
           NOMBRE     =  us_nombre,
           USUARIO    =  us_login, 
	   CLAVE      =  us_psw ,
	   CODIGO     =  c.ro_codigo,
	   ROL        =  ro_nombre
   from    ej_usuario a
   left join ej_usuario_rol b on a.us_documento=b.us_documento
   left join ej_rol c on b.ro_codigo=c.ro_codigo 
end 

if @i_operacion='Q'   
begin  
   select mo_nombre from ej_modulo A,
          ej_usuario_modulo B  
   where us_login  = @i_login    
   and A.mo_codigo = B.mo_codigo
   
end   