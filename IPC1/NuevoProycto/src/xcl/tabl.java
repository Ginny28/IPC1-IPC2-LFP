package xcl;
import javax.swing.table.DefaultTableModel;
/**
 * @author nelson
 */
//Modelo de datos
public final class tabl extends DefaultTableModel{
//Constructor de clase tabl
public tabl(){
        super(60,33);
        Iniciar_Tabla();
    }
//Iniciar tabla
    public void Iniciar_Tabla(){
    for (int row=0; row < super.getRowCount(); row++){
    for(int col=0; col<super.getColumnCount(); col++){
    super.setValueAt("", row, col);
    super.getValueAt(row, col);
            }
      }
    }
//Columna no editable
    @Override
public boolean isCellEditable(int fil, int col){
if (0 == col){
return false;
    }
for (int a=1; a<=33; a++){
if (a == col)
return true;
}
return super.isCellEditable(fil, col);
};

//Hacignar tipo de valor por Columna
    @Override
public Class getColumnClass(int columna)
   {
    int c;
    for (c = 1 ; c<31; c++){
    if (columna == 0) return Integer.class;
    if (columna == c) return String.class;
       }
return String.class;
}
//corchete final de la clase
}



