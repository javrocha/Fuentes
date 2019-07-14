if exists (select * from sysobjects where id = object_id('sp_orden_entrega'))
  drop procedure sp_orden_entrega
GO
	

create proc sp_orden_entrega(
@i_operacion          char(1)          = null,
@i_referencia         varchar(50)      = null,
@i_producto           int              = null,
@i_cantidad           int              = null


)
as 
declare
@w_resultado int,
@w_zona int,
@w_producto int,
@w_orden varchar(50)



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
			       group by c.pr_codigo,c.or_referencia ),
           CANT_RECIBIDA   =  (select sum(en_cantidad)  from ej_orden_entrega d
	                       where a.pr_codigo=d.pr_codigo 
                               and a.or_referencia=d.or_referencia)
   from    ej_orden a
   left join ej_producto b on a.pr_codigo=b.pr_codigo  where es_codigo=2
end 



if @i_operacion='I'
begin
   if not exists(select 1 from   ej_orden_entrega 
                 where pr_codigo=@i_producto 
                 and or_referencia=@i_referencia) 
				
      insert into ej_orden_entrega  (pr_codigo,      or_referencia,   en_fecha,   en_cantidad)
      values                        (@i_producto,    @i_referencia,   getdate(),   @i_cantidad)              
   else
      update ej_orden_entrega   set en_cantidad= @i_cantidad
	  where pr_codigo=@i_producto 
      and or_referencia=@i_referencia
end


if @i_operacion='U'
begin
   begin tran
   
   declare ORDENES cursor for
   select pr_codigo,zo_codigo, or_referencia,sum(mo_cantidad)  
   from ej_orden_despacho 
   where pr_codigo=@i_producto  and  or_referencia=@i_referencia
   group by pr_codigo,zo_codigo, or_referencia
   open ORDENES
       
       fetch next from ORDENES 
       into @w_producto, @w_zona, @w_orden ,@w_resultado
       while @@fetch_status = 0
       begin
          print 'pasa'
		  update ej_inventario
           set in_cantidad=in_cantidad-@w_resultado
           where  pr_codigo=@i_producto 
           and    zo_codigo = @w_zona
	   
       fetch next from ORDENES 
       into @w_producto, @w_zona, @w_orden ,@w_resultado	   
	end
    close ORDENES 
    deallocate ORDENES 
   
	
   update ej_orden
   set es_codigo=3
   where  pr_codigo=@i_producto 
   and    or_referencia=@i_referencia 
   commit tran
            
end



