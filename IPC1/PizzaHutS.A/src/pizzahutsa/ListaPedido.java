package pizzahutsa;

/**
 *
 * @author nelson
 */
public class ListaPedido {
    NodoPedido inicio;
    private String nombrexml;
    private String direccionxml;
    private String nitxml;
    private String telefonoxml;
    private String masaxml;
    private String pizzaxml;
    private String ingredientesxml;
    private String facxml;
    private String totalxml;
    

public ListaPedido(){
    inicio = null;
}

public void ingresarPedido(String get_factura,String get_nombre, String get_direccion, String get_telefono, String get_nit,String get_pizza,String get_tipomasa,String get_peperoni,String get_jamon,String get_pollo,String get_res,String get_salami,String get_salchicha,String get_tocino,String get_cebolla,String get_pimiento,String get_tomate,String get_aceitunas,String get_champiñones,String get_piña,String get_queso,String get_total){
NodoPedido tmp = new NodoPedido();

tmp.nombre = get_nombre;
tmp.direccion = get_direccion;
tmp.telefono = get_telefono;
tmp.nit = get_nit;
tmp.pizza= get_pizza;
tmp.tipomasa= get_tipomasa;
tmp.Factura= get_factura;
tmp.Total= get_total;
tmp.aceitunas= get_aceitunas;
tmp.cebolla=get_cebolla;
tmp.champiñones= get_champiñones;
tmp.jamon= get_jamon;
tmp.peperoni= get_peperoni;
tmp.pimiento= get_pimiento;
tmp.piña= get_piña;
tmp.pollo= get_pollo;
tmp.queso= get_queso;
tmp.res= get_res;
tmp.salami= get_salami;
tmp.salchicha= get_salchicha;
tmp.tocino= get_tocino;
tmp.tomate=get_tomate;


 if (inicio == null){
            inicio = tmp;
        }else{
            NodoPedido aux = inicio;
            while(true){
                if(aux.siguiente == null){
                    break;
                }else{
                    aux = aux.siguiente;
                }
            }
            aux.siguiente = tmp;
        }

}

public void MostrarPedido(){
NodoPedido aux = inicio;
while(true){
            if(aux.siguiente != null){
                System.out.println("Factura:"+aux.Factura+ "\n"+"Nombre: "+aux.nombre+"\n"+"Direccion: "+aux.direccion+"\n"
                        +"Numero de telefono: "+aux.telefono+"\n"+"Numero de nit: "+aux.nit +"\n"
                        +"Tipo de masa:"+aux.tipomasa +"\n"+"pizza:"+ aux.pizza+"\n"
                        +"Ingredientes extras: "+aux.queso+", "+aux.piña +" "+aux.champiñones+", "+aux.aceitunas+", "+aux.tomate+", "+aux.pimiento+" "+aux.cebolla+"\n"
                        +aux.tocino+", "+aux.salchicha+", "+aux.salami+", "+aux.res+", "+aux.pollo+", "+aux.jamon+", "+aux.peperoni+"\n"
                        +"Total:"+aux.Total);
                System.out.println("*********************************************************************************************************");

                aux = aux.siguiente;
            }else{
               System.out.println("Factura:"+aux.Factura+ "\n"+"Nombre: "+aux.nombre+"\n"+"Direccion: "+aux.direccion+"\n"
                        +"Numero de telefono: "+aux.telefono+"\n"+"Numero de nit: "+aux.nit +"\n"
                        +"Tipo de masa:"+aux.tipomasa +"\n"+"pizza:"+ aux.pizza+"\n"
                        +"Ingredientes extras: "+aux.queso+", "+aux.piña +" "+aux.champiñones+", "+aux.aceitunas+", "+aux.tomate+", "+aux.pimiento+" "+aux.cebolla+"\n"
                        +aux.tocino+", "+aux.salchicha+", "+aux.salami+", "+aux.res+", "+aux.pollo+", "+aux.jamon+", "+aux.peperoni+"\n"
                        +"Total:"+aux.Total);
               System.out.println("*********************************************************************************************************");
               break;
            }
        }

}
public void xmlFactura(String facxml){
this.facxml= facxml;
}
public String getFactura(){
return facxml;
}
public void xmlNombre(String nombrexml){
this.nombrexml = nombrexml;
}
public String getNombre(){
return nombrexml;
}
public void xmlDireccion(String direccionxml){
this.direccionxml = direccionxml;
}
public String getDireccion(){
return direccionxml;
}
public void xmlTelefono(String telefonoxml){
this.telefonoxml = telefonoxml;
}
public String getTelefono(){
return telefonoxml;
}
public void xmlNit(String Nitxml){
this.nitxml = Nitxml;
}
public String getNit(){
return nitxml;
}
public void xmlTipoMasa(String Masaxml){
this.masaxml = Masaxml;
}
public String getMasa(){
return masaxml;
}
public void xmlPizza(String Pizzaxml){
this.pizzaxml = Pizzaxml;
}
public String getPizza(){
return pizzaxml;
}
public void xmlIngredientes(String ingredientes){
    this.ingredientesxml = ingredientes;

}
public String getIngredientes(){
return ingredientesxml;
}
public void xmlTotal(String totalxml){
this.totalxml= totalxml;
}
public String getTotal(){
return totalxml;
}

}
