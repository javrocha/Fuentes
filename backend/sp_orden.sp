if exists (select * from sysobjects where id = object_id('sp_orden'))
  drop procedure sp_orden
GO
	

create proc sp_orden(
@i_operacion          char(1)          = null,
@i_referencia         varchar(50)      = null,
@i_producto           int              = null,
@i_cantidad           int              = null


)
as 
declare
@w_resultado int


if @i_operacion='I'
begin
 if not exists(select 1 from   ej_orden where pr_codigo=@i_producto and or_referencia=@i_referencia )
   insert into ej_orden  (pr_codigo,      or_referencia,   or_cantidad,      or_fecha,  es_codigo)
   values                (@i_producto,    @i_referencia,   @i_cantidad,       getdate(),  1)

end 


if @i_operacion='Q'
begin
   select @w_resultado=sum(in_cantidad) from ej_inventario  where pr_codigo=@i_producto
    select isnull(@w_resultado,0)
end 


if @i_operacion='U'
begin
 
   update  ej_orden  
   set   or_cantidad=@i_cantidad
   where pr_codigo=@i_producto and or_referencia=@i_referencia 


end 


if @i_operacion='C'
begin
   
   select  REFERENCIA   =  a.or_referencia, 
           CODPROD      =  a.pr_codigo,
	   PRODUCTO     =  pr_descripcion,
	   CANTIDAD     =  or_cantidad,
	   STOCK        =  (select sum(in_cantidad) from ej_inventario d
			    where d.pr_codigo=a.pr_codigo) ,
	   FECHA        =  or_fecha,
	   CODEST       =  a.es_codigo,
	   ESTADO       =  es_descripcion
   from    ej_orden a
   left join ej_producto b on a.pr_codigo=b.pr_codigo
   left join ej_estado c on a.es_codigo=c.es_codigo 
end 
