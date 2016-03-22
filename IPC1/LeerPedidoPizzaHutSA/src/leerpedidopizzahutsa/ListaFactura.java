package leerpedidopizzahutsa;

import java.awt.Component;
import java.io.File;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileFilter;

/**
 * @author Andrea & nelson
 */
public class ListaFactura {
NodoListaFactura inicio;
    private FileFilter filter;
    private Component mainPanel;

    public ListaFactura(){
    inicio = null;
    }


        public void Ingresa_Pedido(int get_factura,String get_nombre, String get_direccion, String get_telefono, String get_nit,String get_pizza, String get_masa,String get_ingredientes,String get_total){

        NodoListaFactura tmp = new NodoListaFactura();

        tmp.nombre = get_nombre;
        tmp.direccion =  get_direccion;
        tmp.ingredientes = get_ingredientes;
        tmp.masa = get_masa;
        tmp.pizza = get_pizza;
        tmp.telefono = get_telefono;
        tmp.factura = get_factura;
        tmp.total = get_total;
        tmp.nit = get_nit;

        if (inicio == null){
            inicio = tmp;
        }else{
            NodoListaFactura aux = inicio;
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

/*   public void Listar_Factura(){

        NodoListaFactura aux = inicio;
        while(true){
            if(aux.siguiente != null){
                System.out.println("Nombre: " + aux.nombre
                        +"\n"+ "direccion: " + aux.direccion
                        +"\n"+ "Masa: " + aux.masa
                        +"\n"+ "Piza: " + aux.pizza
                        +"\n"+ "Ingredientes: " + aux.ingredientes
                        +"\n"+ "total: " + aux.total
                        +"\n"+ "factura: " + aux.factura
                        +"\n"+ "telefono: " + aux.telefono
                        +"\n"+ "nit: " + aux.nit);
                aux = aux.siguiente;
            }else{
                System.out.println("Nombre: " + aux.nombre
                        +"\n"+ "direccion: " + aux.direccion
                        +"\n"+ "Masa: " + aux.masa
                        +"\n"+ "Piza: " + aux.pizza
                        +"\n"+ "Ingredientes: " + aux.ingredientes
                        +"\n"+ "total: " + aux.total
                        +"\n"+ "factira: " + aux.factura
                        +"\n"+ "telefono: " + aux.telefono
                        +"\n"+ "nit: " + aux.nit);
                break;
            }
        }
    }*/
public void Buscar_Factura(int get_factura){
        NodoListaFactura aux = inicio;
        while(true){
            if(aux != null){
                if (aux.factura == get_factura){
                    System.out.println("ORDEN ENCONTRADA:");
                    
                    javax.swing.JOptionPane.showMessageDialog(mainPanel,("Factura#: "+aux.factura +"\n"+aux.nombre+"\n"+aux.direccion+"\n"+aux.telefono
                            +"\n"+aux.nit+"\n"+aux.masa+"\n"+aux.pizza+"\n"+aux.ingredientes+"\n"+aux.total));

                    break;

                }

                aux = aux.siguiente;
            }else{
                javax.swing.JOptionPane.showMessageDialog(mainPanel,"ORDEN NO ENCONTRADA");
                break;
            }
        }
    }

    




}

