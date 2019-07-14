if exists (select * from sysobjects where id = object_id('sp_orden_despacho'))
  drop procedure sp_orden_despacho
GO
	

create proc sp_sp_usuario(
@i_operacion          char(1)          = null,
@i_referencia         varchar(50)      = null,
@i_producto           int              = null,
@i_zona               int              = null,
@i_lote               int              = null,
@i_pallet             int              = null,
@i_cantidad           int              = null


)
as 
declare
@w_resultado int



if @i_operacion='C'
begin
   
   select  REFERENCIA      =  a.or_referencia, 
           CODPROD         =  a.pr_codigo,
		   PRODUCTO        =  pr_descripcion,
		   FECHA           =  convert(varchar,or_fecha,101),
		   CANT_PEDIDA     =  or_cantidad,
		   CANT_RECOGIDA   =  (select sum(mo_cantidad) from ej_orden_despacho c
						       where a.pr_codigo=c.pr_codigo 
							   and a.or_referencia=c.or_referencia
							   group by c.pr_codigo,c.or_referencia ) 
		   
   from    ej_orden a
   left join ej_producto b on a.pr_codigo=b.pr_codigo  where es_codigo=1
end 



if @i_operacion='Q'
begin
   select @w_resultado = sum(in_cantidad) from ej_inventario  
   where pr_codigo=@i_producto
   and   zo_codigo=@i_zona
   group by pr_codigo, zo_codigo
   
   select isnull(@w_resultado,0)
   
end 


if @i_operacion='S'
begin

 select    REFERENCIA      =  a.or_referencia, 
           CODPROD         =  a.pr_codigo,
	   PRODUCTO        =  pr_descripcion,
	   CODZON          =  a.zo_codigo,
	   ZONA            =  zo_descripcion,
	   FECHA           =  convert(varchar,mo_fecha,101),
           LOTE            =  mo_lote,
	   PALLET          =  mo_pallet,
	   CANTIDAD        =  mo_cantidad,
	   REC_PRODUCTO    = (select sum(mo_cantidad) from ej_orden_despacho d
	                       where a.pr_codigo=d.pr_codigo 
			       and a.or_referencia=d.or_referencia
			       group by d.pr_codigo,d.or_referencia ),
           REC_ZONA        =  (select sum(mo_cantidad) from ej_orden_despacho e
			       where a.pr_codigo=e.pr_codigo 
	   		       and a.or_referencia=e.or_referencia
			       and a.zo_codigo=e.zo_codigo
      			       group by e.pr_codigo,e.or_referencia,e.zo_codigo ),
           STOCK_ZONA      =   (select sum(in_cantidad) from ej_inventario f
                                where a.pr_codigo=f.pr_codigo
                                and   a.zo_codigo=f.zo_codigo
                                group by f.pr_codigo, f.zo_codigo)							   
		   				   
           from    ej_orden_despacho a
           left join ej_producto b on a.pr_codigo=b.pr_codigo
	   left join ej_zona c on a.zo_codigo=c.zo_codigo
	   where a.or_referencia=@i_referencia
end 


if @i_operacion='I'
begin
 if not exists(select 1 from   ej_orden_despacho where pr_codigo=@i_producto 
                and zo_codigo=@i_zona and or_referencia=@i_referencia 
				and mo_lote =@i_lote and mo_pallet=@i_pallet)
   insert into ej_orden_despacho  (pr_codigo,      zo_codigo,    or_referencia,   mo_fecha,   
                                   mo_lote,        mo_pallet,    mo_cantidad)
   values                         (@i_producto,    @i_zona,      @i_referencia,    getdate(),  
                                   @i_lote,        @i_pallet,    @i_cantidad)              
end

if @i_operacion='U'
begin
   update ej_orden_despacho
   set mo_cantidad=@i_cantidad
   where  pr_codigo=@i_producto 
   and    zo_codigo=@i_zona and or_referencia=@i_referencia 
   and   mo_lote =@i_lote and mo_pallet=@i_pallet           
end

if @i_operacion='D'
begin
   print @i_producto 
   print @i_zona
   print @i_referencia 
   print @i_lote 
   print @i_pallet           

   delete  ej_orden_despacho
   where  pr_codigo=@i_producto 
   and    zo_codigo=@i_zona and or_referencia=@i_referencia 
   and   mo_lote =@i_lote and mo_pallet=@i_pallet           
end

if @i_operacion='A'
begin
   update ej_orden
   set es_codigo=2
   where  pr_codigo=@i_producto 
   and    or_referencia=@i_referencia 
	         
end
