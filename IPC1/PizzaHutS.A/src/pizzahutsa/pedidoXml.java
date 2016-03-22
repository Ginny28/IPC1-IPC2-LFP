/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package pizzahutsa;

import com.sun.org.apache.xerces.internal.jaxp.DocumentBuilderFactoryImpl;
import com.sun.org.apache.xml.internal.serialize.OutputFormat;
import com.sun.org.apache.xml.internal.serialize.XMLSerializer;
import java.io.*;
import java.util.*;
import java.text.*;
import org.w3c.dom.*;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;

public class pedidoXml {
   private static final String TAG_PEDIDO   		= "Pedido";
   private static final String TAG_ORDEN 		= "Orden";
   private static final String TAG_FACTURA              = "Factura";
   private static final String TAG_NOMBRE 		= "Nombre";
   private static final String TAG_DIRECCION     	= "Direccion";
   private static final String TAG_TELEFONO 		= "telefono";
   private static final String TAG_NIT           	= "Nit";
   private static final String TAG_MASA           	= "Masa";
   private static final String TAG_PIZZA           	= "Pizza";
   private static final String TAG_INGREDIENTES         = "Ingredientes";
   private static final String TAG_TOTAL                = "Total";
  

   //Codificación Estandar
   private static final String XML_VERSION 		= "1.0";
   private static final String XML_ENCODING 		= "ISO-8859-1";
   private static final String JAVA_ENCODING 		= "8859_1";

   // Definición de Nombre de Archivo a Grabar
   private static final String NOMBRE_ARCHIVO_XML 	= "Pedido.xml";

   private Document 	xmlDoc 	= null;
   private Element 	personal	= null;
   
   
   
    /** Método para retornar el documento XML en cadena de texto */
  public String obtenerTextoXML() {
      return generaTextoXML();
  }

   /** Método para generar el elemento Personal del documento XML usando DOM */
  public void generaDocumentoXMLPersonal() {
    try {
      // Crea un documento XML
      DocumentBuilderFactory dbFactory = DocumentBuilderFactoryImpl.newInstance();
      DocumentBuilder docBuilder = dbFactory.newDocumentBuilder();
      xmlDoc = docBuilder.newDocument();
    } catch(Exception e) {
        System.out.println("Error : " + e);
    }

    // crea un elemento personal
    personal = xmlDoc.createElement(TAG_PEDIDO);

    // agrega el elemento principal
    xmlDoc.appendChild(personal);
  }

   /** Método para generar documento XML usando DOM */
  public void generaDocumentoXMLEmpleado(ListaPedido listapedido) {
    Element orden;
    Element item;

    // crea un elemento NOMBRE y agrega al elemento PEDIDO
    orden = xmlDoc.createElement(TAG_ORDEN);
    personal.appendChild(orden);
    // agrega el elemento factura dentro del elemento orden
    item = xmlDoc.createElement(TAG_FACTURA);
    item.appendChild(xmlDoc.createTextNode(listapedido.getFactura()));
    orden.appendChild(item);

    item = xmlDoc.createElement(TAG_NOMBRE);
    item.appendChild(xmlDoc.createTextNode(listapedido.getNombre()));
    orden.appendChild(item);
   //agrega el elemento Nombre dentro del elemento orden
    item = xmlDoc.createElement(TAG_DIRECCION);
    item.appendChild(xmlDoc.createTextNode(listapedido.getDireccion()));
    orden.appendChild(item);

    //agrega el elemento Fecha de Nacimiento dentro del elemento Empleado
    item = xmlDoc.createElement(TAG_TELEFONO);
    item.appendChild(xmlDoc.createTextNode(listapedido.getTelefono()));
    orden.appendChild(item);

    //agrega el elemento Salario dentro del elemento Empleado
    item = xmlDoc.createElement(TAG_NIT);
    item.appendChild(xmlDoc.createTextNode(listapedido.getNit()));
    orden.appendChild(item);

    //agrega el elemento Salario dentro del elemento Empleado
    item = xmlDoc.createElement(TAG_MASA);
    item.appendChild(xmlDoc.createTextNode(listapedido.getMasa()));
    orden.appendChild(item);

    //agrega el elemento Salario dentro del elemento Empleado
    item = xmlDoc.createElement(TAG_PIZZA);
    item.appendChild(xmlDoc.createTextNode(listapedido.getPizza()));
    orden.appendChild(item);

    //agrega el elemento Salario dentro del elemento Empleado
    item = xmlDoc.createElement(TAG_INGREDIENTES);
    item.appendChild(xmlDoc.createTextNode(listapedido.getIngredientes()));
    orden.appendChild(item);

    item = xmlDoc.createElement(TAG_TOTAL);
    item.appendChild(xmlDoc.createTextNode(listapedido.getTotal()));
    orden.appendChild(item);
   
  }

  // genera el objeto de documento XML en una cadena de texto
  private String generaTextoXML() {

    StringWriter  strWriter    = null;
    XMLSerializer xmlSerializer   = null;
    OutputFormat  outFormat    = null;

    try {
      xmlSerializer = new XMLSerializer();
      strWriter = new StringWriter();
      outFormat = new OutputFormat();

      // estableciendo el formato
      outFormat.setEncoding(XML_ENCODING);
      outFormat.setVersion(XML_VERSION);
      outFormat.setIndenting(true);
      outFormat.setIndent(4);

      // Define una escritura
      xmlSerializer.setOutputCharStream(strWriter);

      // Aplicando el formato establecido
      xmlSerializer.setOutputFormat(outFormat);

      // Serializando el documento XML
      xmlSerializer.serialize(xmlDoc);
      strWriter.close();
    } catch (IOException ioEx) {
        System.out.println("Error : " + ioEx);
    }
    return strWriter.toString();
  }

  public void grabaDocumentoXML(String textoXML) {
      try {
         OutputStream fout= new FileOutputStream(NOMBRE_ARCHIVO_XML);
         OutputStream bout= new BufferedOutputStream(fout);
         OutputStreamWriter out = new OutputStreamWriter(bout, JAVA_ENCODING);
         out.write(textoXML);
         out.flush();
         out.close();
      }
      catch (UnsupportedEncodingException e) {
        System.out.println("La Máquina Virtual no soporta la codificación Latin-1.");
      }
      catch (IOException e) {
        System.out.println(e.getMessage());
      }
      catch (Exception e) {
         System.out.println("Error : " + e);
      }
  }
}
