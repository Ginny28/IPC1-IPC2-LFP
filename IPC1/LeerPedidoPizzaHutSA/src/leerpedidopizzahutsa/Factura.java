package leerpedidopizzahutsa;
import com.itextpdf.text.BadElementException;
import com.itextpdf.text.Chunk;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Image;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;
/**
 * @author nelson & andrea
 */
public class Factura {

    private File ruta_destino=null;

    public Factura(){
    }

    
    public void crear_PDF(String f, String no, String d, String t, String n,String tm,String p,String i,String to) throws BadElementException, MalformedURLException, IOException{
       
        Colocar_Destino();
        
        if(this.ruta_destino!=null){
            try {
                
                Document mipdf = new Document() {};
                
                PdfWriter.getInstance(mipdf, new FileOutputStream(this.ruta_destino + ".pdf"));
                mipdf.open();
               

                Image foto = Image.getInstance("/home/nelson/NetBeansProjects/PizzaHutS.A/pizzaHut.jpg");
              
                foto.scaleToFit(100, 100);
                foto.setAlignment(Chunk.ALIGN_RIGHT);
                mipdf.add(foto);
    

                mipdf.addAuthor("Nelson & Andrea");

                 mipdf.add(new Paragraph("Factura#: "+f));
                  mipdf.add(new Paragraph(no));
                   mipdf.add(new Paragraph(d));
                    mipdf.add(new Paragraph(t));
                     mipdf.add(new Paragraph(n));
                      mipdf.add(new Paragraph(tm));
                       mipdf.add(new Paragraph(p));
                        mipdf.add(new Paragraph(i));
                         mipdf.add(new Paragraph(to));
                mipdf.close();
                JOptionPane.showMessageDialog(null,"Documento PDF creado");
            } catch (DocumentException ex) {
                Logger.getLogger(LeerPedidoPizzaHutSAApp.class.getName()).log(Level.SEVERE, null, ex);
            } catch (FileNotFoundException ex) {
                Logger.getLogger(LeerPedidoPizzaHutSAApp.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    
    public void Colocar_Destino(){
       FileNameExtensionFilter filter = new FileNameExtensionFilter("Archivo PDF","pdf","PDF");
       JFileChooser fileChooser = new JFileChooser();
       fileChooser.setFileFilter(filter);
       int result = fileChooser.showSaveDialog(null);
       if ( result == JFileChooser.APPROVE_OPTION ){
           this.ruta_destino = fileChooser.getSelectedFile().getAbsoluteFile();
        }
    }

}

