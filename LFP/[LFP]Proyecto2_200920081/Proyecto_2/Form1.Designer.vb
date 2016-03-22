<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Tokens = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eror = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalisisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TokensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErroresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LexicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SintacticosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Tokens, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Eror, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 24)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(525, 337)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(811, 326)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tokens
        '
        Me.Tokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tokens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.Tokens.Location = New System.Drawing.Point(534, 27)
        Me.Tokens.Name = "Tokens"
        Me.Tokens.Size = New System.Drawing.Size(240, 150)
        Me.Tokens.TabIndex = 8
        Me.Tokens.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "No"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Fila"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Columna"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "No.Token"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Token"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Patron"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Lexema"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Descripcion"
        Me.Column8.Name = "Column8"
        '
        'Eror
        '
        Me.Eror.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Eror.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.Eror.Location = New System.Drawing.Point(534, 170)
        Me.Eror.Name = "Eror"
        Me.Eror.Size = New System.Drawing.Size(240, 150)
        Me.Eror.TabIndex = 9
        Me.Eror.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "No"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Simbolo"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Columna"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Fila"
        Me.Column12.Name = "Column12"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Candara", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EdicionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(525, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnalisisToolStripMenuItem, Me.TokensToolStripMenuItem, Me.ErroresToolStripMenuItem, Me.ResultadoToolStripMenuItem})
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.EdicionToolStripMenuItem.Text = "Edicion"
        '
        'AnalisisToolStripMenuItem
        '
        Me.AnalisisToolStripMenuItem.Name = "AnalisisToolStripMenuItem"
        Me.AnalisisToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AnalisisToolStripMenuItem.Text = "Analisis"
        '
        'TokensToolStripMenuItem
        '
        Me.TokensToolStripMenuItem.Name = "TokensToolStripMenuItem"
        Me.TokensToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TokensToolStripMenuItem.Text = "Tokens"
        '
        'ErroresToolStripMenuItem
        '
        Me.ErroresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LexicosToolStripMenuItem, Me.SintacticosToolStripMenuItem})
        Me.ErroresToolStripMenuItem.Name = "ErroresToolStripMenuItem"
        Me.ErroresToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ErroresToolStripMenuItem.Text = "Errores"
        '
        'LexicosToolStripMenuItem
        '
        Me.LexicosToolStripMenuItem.Name = "LexicosToolStripMenuItem"
        Me.LexicosToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.LexicosToolStripMenuItem.Text = "Lexicos"
        '
        'SintacticosToolStripMenuItem
        '
        Me.SintacticosToolStripMenuItem.Name = "SintacticosToolStripMenuItem"
        Me.SintacticosToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SintacticosToolStripMenuItem.Text = "Sintacticos"
        '
        'ResultadoToolStripMenuItem
        '
        Me.ResultadoToolStripMenuItem.Name = "ResultadoToolStripMenuItem"
        Me.ResultadoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ResultadoToolStripMenuItem.Text = "Resultado"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 361)
        Me.Controls.Add(Me.Eror)
        Me.Controls.Add(Me.Tokens)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "bTex"
        CType(Me.Tokens, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Eror, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Tokens As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eror As System.Windows.Forms.DataGridView
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdicionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalisisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TokensToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErroresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LexicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SintacticosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResultadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
