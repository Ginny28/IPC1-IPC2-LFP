package xcl;
import java.awt.Color;
import java.awt.Component;
import javax.swing.*;
import javax.swing.table.DefaultTableCellRenderer;

/**
 * @author nelson
 */

public class colorCel extends DefaultTableCellRenderer{


    @Override
public Component getTableCellRendererComponent (final JTable table, Object obj, boolean isSelected, boolean hasFocus, int row, int column) {
Component cell = super.getTableCellRendererComponent(table, obj, isSelected, hasFocus, row, column);

if (isSelected) {
cell.setBackground(Color.BLUE);
			}
else {
if (column % 2 == 0) {
cell.setBackground(Color.PINK);
}
else {
cell.setBackground(Color.LIGHT_GRAY);
}
}
return cell;
}

}
