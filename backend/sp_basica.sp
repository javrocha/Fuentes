if exists (select * from sysobjects where id = object_id('sp_basica'))
  drop procedure sp_basica
GO
	

create proc sp_basica(
@i_operacion          char(1)          = null

)
as 

if @i_operacion='R'
begin
   select ro_codigo,ro_nombre from ej_rol
end 

if @i_operacion='P'
begin
   select pr_codigo,pr_descripcion from ej_producto
end 


if @i_operacion='Z'
begin
   select zo_codigo,zo_descripcion from ej_zona
end 
