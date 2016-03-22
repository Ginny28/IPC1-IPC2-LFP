package leerpedidopizzahutsa;

/**
 *
 * @author nelson & Andrea
 */
public class NodoListaFactura {
    
    String nombre,direccion,telefono,nit,pizza,masa,ingredientes,total;
    int factura;
    NodoListaFactura siguiente;

    public NodoListaFactura(){
        nombre = "";
        direccion = "";
        telefono= "";
        nit= "";
        pizza= "";
        masa= "";
        ingredientes= "";
        factura = 0;
        total = "";
    siguiente = null;
}

}
