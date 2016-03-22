package xcl;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.Color;
import java.io.*;
import javax.swing.table.TableColumn;
import java.awt.Desktop;
/**
 * @author nelson
 */
public final class xcl extends JFrame{
//Variables de la clase xcl
public JMenu men1,men2,men3,men4,men5,men6,men7,men8,men9,men10;
public JMenuBar barmen;
public Color color = Color.LIGHT_GRAY;
public Color color1 = Color.LIGHT_GRAY;
private JToolBar tol1;
private JLabel lab1;
private JTextField fil1,fil2;
public JTable table;
int a,b,c,d,e,f,g,h,i,j,k,l;
TableColumn tcol;
String dato1,dato2,dato3,dato4,dato5,dato6,dato7,dato8,dato9,dato10,dato11,dato12,dato13,dato14,dato15,dato16;
//Constructor de la Clase xcl
public xcl(){
super ("XCL");
CrearTabla();
componentes();
//Maneja el Evento del Texfiel donde se coloca las formulas
ManejadorCampoTexto manejador = new ManejadorCampoTexto();
fil2.addActionListener(manejador);
//Dar color a celdas
/*for (k=1;k<31;++k){
tcol = table.getColumnModel().getColumn(k);
tcol.setCellRenderer(new colorCel());
}*/
//Tamaño cierre y hacer Visible la tabla
setSize(800,600);
setVisible(true);
setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
}
//Metodo donde se crea la tabla
public void CrearTabla(){
final tabl dftm = new tabl();
table = new JTable(dftm);
//dftm.setValueAt ("Nelson", 0, 1);
for (h = 0; h<31;h++){
for (f = 1; f<31; f++){
System.out.println(""+dftm.getValueAt(h,f));
}
}
//Visible el scrol de abajo y poder selecionar columna
table.setColumnSelectionAllowed(true);
table.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
table.doLayout();
//Agregarle un ScrollPane a Tabla
JScrollPane barras = new JScrollPane(table);
barras.setBounds(25,60,975,545);
add(barras);
//encabezados de la tabla
dftm.setColumnIdentifiers(new String[] { "", "A", "B", "C", "D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","AA","AB","AC","AD"});
dftm.setColumnIdentifiers(new String[] { "", "a", "b", "c", "d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","aa","ab","ac","ad"});
//se crea la numeracion de todas las filas en la columna no editable
for(int fil = 0; fil < 60; fil++)
table.setValueAt(fil , fil, 0);
table.getColumnModel().getColumn(0).setCellRenderer(table.getTableHeader().getDefaultRenderer());
//Visualizar valor de celda con un click
table.addMouseListener(new MouseAdapter()
   {
@Override
public void mouseClicked(MouseEvent e)
{
int fila = table.rowAtPoint(e.getPoint());
int columna = table.columnAtPoint(e.getPoint());
if ((fila > -1) && (columna > 0))
fil2.setText((String) dftm.getValueAt(fila,columna));      }
   });


//psicion
//Evento para dar posicion con Mause
table.addMouseListener(new MouseAdapter()
{
@Override
public void mouseClicked(MouseEvent e)
{
int fila = 1+table.getSelectedRow();
int columna = table.getSelectedColumn();
if ((fila > -1) && (columna > -1))
System.out.println(table.getColumnName(columna)+fila);
fil1.setText(table.getColumnName(columna)+(fila-1));
}
});
//Listar el evento del Teclado
table.addKeyListener(new KeyAdapter(){
//Evento de presionar teclas en teclado
@Override
public void keyPressed(KeyEvent ke){
//posicion movimiento para abajo
switch(ke.getKeyCode()){
    case KeyEvent.VK_DOWN:
    int fila = 1+table.getSelectedRow();
    int columna = table.getSelectedColumn();
    if ((fila > -1) && (columna > -1))
    fil1.setText(table.getColumnName(columna)+(fila));
break;
//posicion movimiento para arriba
case KeyEvent.VK_UP:
    int fila1 = 1+table.getSelectedRow();
    int columna1 = table.getSelectedColumn();
    if ((fila1 > -1) && (columna1 > -1))
    fil1.setText(table.getColumnName(columna1)+(fila1-2));
break;
//posicion movimiento para la derecha
case KeyEvent.VK_RIGHT:
    int fila2 = 1+table.getSelectedRow();
    int columna2 = table.getSelectedColumn();
    if ((fila2 > -1) && (columna2 > -1)){
    fil1.setText(table.getColumnName(columna2+1)+(fila2-1));
    }
break;
//posicion movimiento para la izquierda
case KeyEvent.VK_LEFT:
    int fila3 = 1+table.getSelectedRow();
    int columna3 = table.getSelectedColumn();
    if ((fila3 > -1) && (columna3 > -1))
    fil1.setText(table.getColumnName(columna3-1)+(fila3-1));
    break;
//clik enter
    case KeyEvent.VK_ENTER:
    int fila4 = 1+table.getSelectedRow();
    int columna4 = table.getSelectedColumn();
    if ((fila4 > -1) && (columna4 > -1))
    fil1.setText(table.getColumnName(columna4)+(fila4));
    break;
//clik enter
    case KeyEvent.VK_TAB:
    int fila5 = 1+table.getSelectedRow();
    int columna5 = table.getSelectedColumn();
    if ((fila5 > -1) && (columna5 > -1)){
    fil1.setText(table.getColumnName(columna5+1)+(fila5-1));
    }
   
    break;
}
}
});
}//fin del metodo crear tabla

//Metodo para los Componentes
public void componentes(){
barmen=new JMenuBar();
setJMenuBar(barmen);
tol1 = new JToolBar();
tol1.addSeparator();
fil1 = new JTextField(5);
tol1.add(fil1);
tol1.addSeparator();
tol1.addSeparator();
tol1.addSeparator();
lab1 = new JLabel("fx    ");
tol1.add(lab1);
fil2 = new JTextField(60);
tol1.add(fil2);
getContentPane().add(tol1,BorderLayout.NORTH);
//*menu Archivo
men1 = new  JMenu("Archivo");
men1.setMnemonic('a');
barmen.add(men1);
JMenuItem men1_it1 = new JMenuItem ("Guardar o Borrar");
men1.add(men1_it1);
men1_it1.setMnemonic('c');
men1_it1.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
int result = JOptionPane.showConfirmDialog(table,"Guardar Trabajo, Antes de Borrar");
if (result == JOptionPane.YES_OPTION) {
JFileChooser ven = new JFileChooser();
int i = ven.showSaveDialog(null);
if (i == JFileChooser.APPROVE_OPTION) {
File arch = ven.getSelectedFile();
ven = null;
try {
FileOutputStream fiO = new FileOutputStream(arch);
ObjectOutputStream tag = new ObjectOutputStream(fiO);
tag.flush();
} catch (Exception xx) {
}
}
} else if (result == JOptionPane.NO_OPTION) {
for( int fil = 0 ; fil < table.getRowCount(); fil++ ){
for( int col = 1 ; col < table.getColumnCount(); col++ ){
table.setValueAt(null , fil , col );
}
}
}
    }

});
//Menu Editar
men2 = new  JMenu("Editar");
men2.setMnemonic('e');
JMenuItem men2_it1 = new JMenuItem ("Color de Fondo de Celda");
JMenuItem men2_it2= new JMenuItem ("Color de Letra");
men2.add(men2_it1);
men2.addSeparator();
men2.add(men2_it2);
barmen.add(men2);
men2_it1.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
color = JColorChooser.showDialog(null,"seleccionar color",color);
if ( color == null )
color = Color.RED;
table.setBackground(color);
    }
});
men2_it2.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
color1 = JColorChooser.showDialog(null,"seleccionar color",color1);
table.setForeground(color1);
}
});

//menu Ayuda
men4 = new JMenu("Ayuda");
men4.setMnemonic('h');
barmen.add(men4);
JMenuItem men4_it1 = new JMenuItem ("Manual Tecnico");
JMenuItem men4_it2 = new JMenuItem ("Manual Usuario");
JMenuItem men4_it3 = new JMenuItem ("Acerca De");
men4.add(men4_it1);
men4.addSeparator();
men4.add(men4_it2);
men4.addSeparator();
men4.add(men4_it3);
men4_it1.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
File path = new File ("PrimeraFaseProyectoManualTecnico.pdf");
                try {
                    Desktop.getDesktop().open(path);
                } catch (IOException ex) {
                    Logger.getLogger(xcl.class.getName()).log(Level.SEVERE, null, ex);
                }
}
});
men4_it2.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
File path = new File ("PrimeraFaseProyectoManualUsuario.pdf");
                try {
                    Desktop.getDesktop().open(path);
                } catch (IOException ex) {
                    Logger.getLogger(xcl.class.getName()).log(Level.SEVERE, null, ex);
                }
}
});
men4_it3.addActionListener(new ActionListener(){
public void actionPerformed(ActionEvent e){
JFrame framxx = new JFrame();
framxx.setTitle("Acerca De");
framxx.getContentPane().setLayout(new FlowLayout());
JLabel labelxx  = new JLabel  ("Autor Nelson Daniel Cruz ardiano");
JLabel labelxxx = new JLabel  ("              Carnet: 2009-15606");
JLabel labelxxxx = new JLabel ("         Nombre de Software: XCL");
JLabel labelxxxxx = new JLabel("                 Version: Prueba");
framxx.add(labelxx);
framxx.add(labelxxx);
framxx.add(labelxxxx);
framxx.add(labelxxxxx);
framxx.setSize(210,200);
framxx.setVisible(true);
}
});
//como ingresar formulas
men5 = new JMenu("Como ingresar formulas");
men5.setMnemonic('c');
barmen.add(men5);
JMenuItem men5_it1 = new JMenuItem ("Suma       : =suma(axx,bxx)");
JMenuItem men5_it2 = new JMenuItem ("Resta      : =resta(axx,bxx)");
JMenuItem men5_it3 = new JMenuItem ("Multiplicar: =multiplicar(axx,bxx)");
men5.add(men5_it1);
men5.addSeparator();
men5.add(men5_it2);
men5.addSeparator();
men5.add(men5_it3);
men5.addSeparator();
JMenuItem men5_it4 = new JMenuItem ("Exponenciar: =exponenciar(axx,AA)");
JMenuItem men5_it5 = new JMenuItem ("Concatenar : =concatenar(axx,bxx)");
JMenuItem men5_it6 = new JMenuItem ("Substraer  : =substraer(axx,AA)");
men5.add(men5_it4);
men5.addSeparator();
men5.add(men5_it5);
men5.addSeparator();
men5.add(men5_it6);
men5.addSeparator();
JMenuItem men5_it7 = new JMenuItem ("Substring  : =substring(axx,AA,BB)");
men5.add(men5_it7);



}//Fin corchete de Metodo Componentes

//Esta clase maneja los datos del Jtefiel de formulas donde se pone A1
private class ManejadorCampoTexto implements ActionListener{
public void actionPerformed(ActionEvent e ){
//Extraer datos del texfield
String texto = (fil2.getText());
//String texto1 = (fil3.getText());
//System.out.println(texto1);
String substraer = "substraer";
String substring = "substring";
String concatenar = "concatenar";
String suma = "suma";
String resta = "resta";
String multiplicar = "multiplicar";
String exponenciar = "exponenciar";
//Comparacion de evento en fil2
if ( e.getSource() == fil2 ){//corchete inicial if de evento
//extraer los valores ingresados en el jtexfiel
String subS = texto.substring(1,10);
String subC = texto.substring(1,11);
String subSuma = texto.substring(1,5);
String subPot = texto.substring(1,12);
String subRes = texto.substring(1,6);
String subMul = texto.substring(1,12);
String subStr = texto.substring(1,10);
//comparacion exponenciar
if (subPot.equals(exponenciar)){
String subP1 = texto.substring(13,14);
String subP2 = texto.substring(14,16);
String subP3 = texto.substring(17,19);
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subP1.equals(table.getColumnName(n)) && (Integer.parseInt(subP2) == m )){
dato1 =(String)table.getValueAt(Integer.parseInt(subP2), n);
dato5 = (String)subP3;
double d =Double.valueOf(dato1.trim()).doubleValue();
double d1 =Double.valueOf(dato5.trim()).doubleValue();
fil2.setText(String.valueOf(Math.pow(d, d1)));
}
}
}//fin del for exponenciar
}//fin de exponenciar
//Operacion Sustraer
if (subS.equals(substraer)){
String subS1 = texto.substring(11,12);
String subS2 = texto.substring(12,14);
String subS3 = texto.substring(15,17);
double d50 =Double.valueOf(subS3.trim()).doubleValue();
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subS1.equals(table.getColumnName(n)) && (Integer.parseInt(subS2) == m )){
dato2 =(String)table.getValueAt(Integer.parseInt(subS2), n);
String subS4 = dato2.substring( (int)(d50)-1,(int)(d50));
fil2.setText(subS4);
    }
}
}//fin del for substraer
}//fin de corchete substraer
//substring
if (subStr.equals(substring)){
String subStr1 = texto.substring(11,12);
String subStr2 = texto.substring(12,14);
String subStr3 = texto.substring(15,17);
String subStr4 = texto.substring(18,20);
double d51 =Double.valueOf(subStr3.trim()).doubleValue();
double d52 =Double.valueOf(subStr4.trim()).doubleValue();
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subStr1.equals(table.getColumnName(n)) && (Integer.parseInt(subStr2) == m )){
dato12 =(String)table.getValueAt(Integer.parseInt(subStr2), n);
String subStr5 = dato12.substring( (int)(d51)-1,(int)(d52));
fil2.setText(subStr5);
}
}
}//fin del for substraer
}//fin substraer
//Concatenar
if (subC.equals(concatenar))  {
String subC1 = texto.substring(12,13);
String subC2 = texto.substring(13,15);
String subC3 = texto.substring(16,17);
String subC4 = texto.substring(17,19);
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subC1.equals(table.getColumnName(n)) && (Integer.parseInt(subC2) == m )){
dato3 =(String)table.getValueAt(Integer.parseInt(subC2), n);
}
}
}//fin del for 1 concatenar
for (int n=1; n < 31; n++){
for (int m=0; m <= 60 ;m++){
if (subC3.equals(table.getColumnName(n)) && (Integer.parseInt(subC4) == m )){
dato4 =(String)table.getValueAt(Integer.parseInt(subC4), n);
fil2.setText(""+dato3+" "+dato4);
}
}
}//fin del for 2 concatenar
}//fin corchete concatenar
//Suma
if (subSuma.equals(suma))  {
String subSum1 = texto.substring(6,7);
String subSum2 = texto.substring(7,9);
String subSum3 = texto.substring(10,11);
String subSum4 = texto.substring(11,13);
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subSum1.equals(table.getColumnName(n)) && (Integer.parseInt(subSum2) == m )){
dato6 =(String)table.getValueAt(Integer.parseInt(subSum2), n);
}
}
}//fin for1
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subSum3.equals(table.getColumnName(n)) && (Integer.parseInt(subSum4) == m )){
dato7 =(String)table.getValueAt(Integer.parseInt(subSum4), n);
double d2 =Double.valueOf(dato6.trim()).doubleValue();
double d3 =Double.valueOf(dato7.trim()).doubleValue();
fil2.setText(""+ (d2 + d3));
}
}
}//fin for2
}//fin suma
//Resta
if (subRes.equals(resta))  {
String subR1 = texto.substring(7,8);
String subR2 = texto.substring(8,10);
String subR3 = texto.substring(11,12);
String subR4 = texto.substring(12,14);
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subR1.equals(table.getColumnName(n)) && (Integer.parseInt(subR2) == m )){
dato8 =(String)table.getValueAt(Integer.parseInt(subR2), n);
}
}
}//fin for1
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subR3.equals(table.getColumnName(n)) && (Integer.parseInt(subR4) == m )){
dato9 =(String)table.getValueAt(Integer.parseInt(subR4), n);
double d4 =Double.valueOf(dato8.trim()).doubleValue();
double d5 =Double.valueOf(dato9.trim()).doubleValue();
fil2.setText(""+(d4 - d5));
}
}
}//fin for2
}//fin Resta
//multiplicar
if (subMul.equals(multiplicar))  {
String subMu1 = texto.substring(13,14);
String subMu2 = texto.substring(14,16);
String subMu3 = texto.substring(17,18);
String subMu4 = texto.substring(18,20);
for (int n=1; n<31;n++){
for (int m=0; m <= 60 ;m++){
if (subMu1.equals(table.getColumnName(n)) && (Integer.parseInt(subMu2) == m )){
dato10 =(String)table.getValueAt(Integer.parseInt(subMu2), n);
}
}
}//fin del for 1 Multiplicar
for (int n=1; n < 31; n++){
for (int m=0; m <= 60 ;m++){
if (subMu3.equals(table.getColumnName(n)) && (Integer.parseInt(subMu4) == m )){
dato11 =(String)table.getValueAt(Integer.parseInt(subMu4), n);
double d6 =Double.valueOf(dato10.trim()).doubleValue();
double d7 =Double.valueOf(dato11.trim()).doubleValue();
fil2.setText(""+(d6*d7));
}
}
}//fin del for 2 Multiplicar
}//fin corchete Multiplicar
////**********************
}//fin corchete if de evento
}//fin de evento action performed
}//fin clase Manejador de eventos


//corchete de la clase xcl
}