Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class Form1
    Dim err As String
    Dim lexema As String = ""
    Dim Preanalisis As String
    Dim stado As Integer = 0
    Dim tok As Integer = 1
    Dim i As Integer
    Dim fila As Integer = 1
    Dim colu As Integer = 0
    Dim c As Char
    Dim datos() As Char
    Dim texto As String
    Dim reserv, sintac As New ArrayList
    Dim stre As Stream = Nothing
    Dim pathi As String
    Dim pth As String

    'listas de tabla de tokens 
    Dim num, Filtok, Coltok, Numtok, Token, patron, lexis, descrip, realToken As New ArrayList
    'listas tabla errores
    Dim no, fil, col, ror As New ArrayList
    Dim n As Integer = 1
    Dim j As Integer = 1

    '**************************ANALISIS LEXICO*******************************

    Private Sub AnalisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalisisToolStripMenuItem.Click
        reserv.Add("CrearNuevoDocumento")
        reserv.Add("Caracteristicas")
        reserv.Add("TipoLetra")
        reserv.Add("TamanioLetra")
        reserv.Add("TamanioPagina")
        reserv.Add("CrearNuevaPagina")
        reserv.Add("InsertarTitulo")
        reserv.Add("InsertarParrafo")
        reserv.Add("InsertarLista")
        reserv.Add("InsertarImagen")
        reserv.Add("Normal")
        reserv.Add("Negrita")
        reserv.Add("Cursiva")


        Dim text As String = RichTextBox1.Text


        datos = text.ToCharArray(0, text.Length)

        For i As Integer = 0 To datos.Length - 1
            c = datos(i)
            Select Case stado
                '<-- Todos los simbolos-->
                Case 0
                    If c = ChrW(10) Then
                        fila += 1
                        colu = 0
                    ElseIf Char.IsLetter(c) Then
                        lexema += c
                        stado = 1
                        colu += 1
                    ElseIf Char.IsNumber(c) Then
                        lexema += c
                        stado = 2
                        colu += 1
                    ElseIf c = ChrW(34) Then
                        lexema += c
                        stado = 3
                        colu += 1
                    ElseIf c = "/" Then
                        lexema += c
                        stado = 6
                        colu += 1
                    ElseIf c = "(" Or c = ")" Or c = "{" Or c = "}" Or c = ";" Or c = "," Then
                        lexema += c
                        stado = 9
                        colu += 1
                    ElseIf Char.IsWhiteSpace(c) Then
                        colu += 1

                    Else
                        err = c
                        colu += 1
                        stado = 10
                    End If



                    '************************* PALABRAS RESERVADAS*******************************

                Case 1

                    If Char.IsLetter(c) Then
                        colu += 1
                        lexema += c
                    Else

                        If lexema = malditapalabrareservada(lexema) Then
                            If lexema = "CrearNuevoDocumento" Then
                                realToken.Add("1")
                            ElseIf lexema = "Caracteristicas" Then
                                realToken.Add("12")
                            ElseIf lexema = "TipoLetra" Then
                                realToken.Add("13")
                            ElseIf lexema = "TamanioLetra" Then
                                realToken.Add("14")
                            ElseIf lexema = "TamanioPagina" Then
                                realToken.Add("15")
                            ElseIf lexema = "CrearNuevaPagina" Then
                                realToken.Add("16")
                            ElseIf lexema = "InsertarTitulo" Then
                                realToken.Add("17")
                            ElseIf lexema = "InsertarParrafo" Then
                                realToken.Add("18")
                            ElseIf lexema = "InsertarLista" Then
                                realToken.Add("19")
                            ElseIf lexema = "InsertarImagen" Then
                                realToken.Add("20")
                            ElseIf lexema = "Normal" Then
                                realToken.Add("21")
                            ElseIf lexema = "Negrita" Then
                                realToken.Add("22")
                            ElseIf lexema = "Cursiva" Then
                                realToken.Add("23")
                            End If
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("1")
                            Token.Add(n_n(1))
                            patron.Add(Patrn(11))
                            lexis.Add(lexema)
                            descrip.Add(desc(1))
                            Tokens.Rows.Add(j, fila, colu, "1", n_n(1), Patrn(11), lexema, desc(1))
                            stado = 0
                            lexema = ""
                            j += 1
                            i = i - 1

                        Else
                            err = lexema
                            stado = 10
                            lexema = ""
                            i -= 1
                        End If

                    End If

                    '************************* NUMEROS*******************************

                Case 2
                    If Char.IsNumber(c) Then
                        colu += 1
                        lexema += c
                        ' ElseIf c = Chr(10) Or c = "(" Or c = ")" Or Char.IsWhiteSpace(c) Then
                    Else
                        num.Add(j)
                        Filtok.Add(fila)
                        Coltok.Add(colu)
                        Numtok.Add("8")
                        realToken.Add("8")
                        Token.Add(n_n(3))
                        patron.Add(Patrn(9))
                        lexis.Add(lexema)
                        descrip.Add(desc(3))
                        tokens.Rows.Add(j, fila, colu, "8", n_n(3), Patrn(9), lexema, desc(3))
                        lexema = ""
                        stado = 0
                        j += 1
                        i -= 1

                    End If

                    '************************* PALABRA Y PATH *******************************

                Case 3
                    If Char.IsLetter(c) Or Char.IsNumber(c) Or Char.IsWhiteSpace(c) Or c = "." Or c = "@" Or c = ":" Or c = "°" Or c = "¬" Or c = "!" Or c = "#" Or c = "$" Or c = "&" Or c = "?" Or c = "/" Or c = "¿" Or c = "¡" Or c = "¨" Or c = "´" Or c = "+" Or c = "*" Or c = "~" Or c = "[" Or c = "]" Or c = "^" Or c = "`" Or c = "-" Or c = "_" Or c = "|" Then
                        lexema += c
                        colu += 1
                    ElseIf c = ":" Or c = "\" Then
                        lexema += c
                        stado = 4
                    ElseIf c = Chr(34) Then
                        lexema += c
                        colu += 1
                        stado = 9
                    End If

                Case 4
                    If Char.IsLetter(c) Or c = "\" Then
                        lexema += c
                        stado = 5
                    End If

                Case 5
                    If c = Chr(34) Or Char.IsLetter(c) Or c = "\" Or c = "." Or c = "@" Or c = "°" Or c = "¬" Or c = "!" Or c = "#" Or c = "$" Or c = "&" Or c = "?" Or c = "¿" Or c = "¡" Or c = "¨" Or c = "´" Or c = "+" Or c = "*" Or c = "~" Or c = "[" Or c = "]" Or c = "^" Or c = "`" Or c = "-" Or c = "_" Or c = "|" Then
                        lexema += c
                    ElseIf Char.IsWhiteSpace(c) Or c = Chr(10) Or c = Chr(34) Or c = ")" Then
                        num.Add(j)
                        Filtok.Add(fila)
                        Coltok.Add(colu)
                        Numtok.Add("10")
                        realToken.Add("10")
                        Token.Add(n_n(10))
                        patron.Add(Patrn(10))
                        lexis.Add(lexema)
                        descrip.Add(desc(10))
                        Tokens.Rows.Add(j, fila, colu, "10", n_n(10), Patrn(10), lexema, desc(10))
                        lexema = ""
                        stado = 0
                        j += 1
                        i = i - 1

                    End If

                    '************************* COMENTARIO *******************************

                Case 6
                    If c = "*" Then
                        lexema += c
                        colu += 1
                        stado = 7
                    End If

                Case 7
                    If Char.IsLetter(c) Or Char.IsNumber(c) Then
                        lexema += c
                        colu += 1
                    ElseIf c = "*" Then
                        lexema += c
                        colu += 1
                        stado = 8
                    End If
                Case 8
                    If c = "/" Then
                        num.Add(j)
                        Filtok.Add(fila)
                        Coltok.Add(colu)
                        Numtok.Add("11")
                        Token.Add(n_n(2))
                        patron.Add(Patrn(8))
                        lexis.Add(lexema)
                        descrip.Add(desc(2))
                        tokens.Rows.Add(j, fila, colu, "11", n_n(2), Patrn(8), lexema, desc(2))
                        lexema = ""
                        stado = 0
                        '   j += 1
                    End If

                    '************************* STADO ACEPTACION *******************************

                Case 9

                    If c >= ChrW(32) Or c <= ChrW(126) Or c = ChrW(10) Then
                        If lexema = "(" Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("2")
                            realToken.Add("2")
                            Token.Add(n_n(4))
                            patron.Add(Patrn(1))
                            lexis.Add(lexema)
                            descrip.Add(desc(4))
                            tokens.Rows.Add(j, fila, colu, "2", n_n(4), Patrn(1), lexema, desc(4))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        ElseIf lexema = ")" Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("3")
                            realToken.Add("3")
                            Token.Add(n_n(5))
                            patron.Add(Patrn(2))
                            lexis.Add(lexema)
                            descrip.Add(desc(5))
                            tokens.Rows.Add(j, fila, colu, "3", n_n(5), Patrn(2), lexema, desc(5))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        ElseIf lexema = "," Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("4")
                            realToken.Add("4")
                            Token.Add(n_n(7))
                            patron.Add(Patrn(3))
                            lexis.Add(lexema)
                            descrip.Add(desc(7))
                            tokens.Rows.Add(j, fila, colu, "4", n_n(7), Patrn(3), lexema, desc(7))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        ElseIf lexema = "{" Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("5")
                            realToken.Add("5")
                            Token.Add(n_n(8))
                            patron.Add(Patrn(5))
                            lexis.Add(lexema)
                            descrip.Add(desc(8))
                            tokens.Rows.Add(j, fila, colu, "5", n_n(8), Patrn(5), lexema, desc(8))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        ElseIf lexema = "}" Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("6")
                            realToken.Add("6")
                            Token.Add(n_n(9))
                            patron.Add(Patrn(6))
                            lexis.Add(lexema)
                            descrip.Add(desc(9))
                            tokens.Rows.Add(j, fila, colu, "6", n_n(9), Patrn(6), lexema, desc(9))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        ElseIf lexema = ";" Then
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("7")
                            realToken.Add("7")
                            Token.Add(n_n(6))
                            patron.Add(Patrn(4))
                            lexis.Add(lexema)
                            descrip.Add(desc(6))
                            tokens.Rows.Add(j, fila, colu, "7", n_n(6), Patrn(4), lexema, desc(6))
                            lexema = ""
                            stado = 0
                            j += 1
                            i -= 1
                        Else
                            num.Add(j)
                            Filtok.Add(fila)
                            Coltok.Add(colu)
                            Numtok.Add("9")
                            realToken.Add("9")
                            Token.Add(n_n(11))
                            patron.Add(Patrn(7))
                            lexis.Add(lexema)
                            descrip.Add(desc(11))
                            tokens.Rows.Add(j, fila, colu, "9", n_n(11), Patrn(7), lexema, desc(11))
                            lexema = ""
                            stado = 0
                            j += 1
                            i = i - 1
                        End If
                    End If


                    '**************************STADO ERROR***********************************
                Case 10
                    If c >= ChrW(32) Or c <= ChrW(126) Or c = ChrW(10) Then
                        no.Add(n)
                        ror.Add(err)
                        col.Add(colu)
                        fil.Add(fila)
                        Eror.Rows.Add(n, err, colu, fila)
                        lexema = ""
                        err = ""
                        stado = 0
                        n += 1
                        i -= 1
                    End If

            End Select
        Next

        Dim stre As Stream = Nothing


    End Sub


    '****************************LIMPIA VARIABLES Y LISTAS ********************************** 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        err = ""
        lexema = ""
        stado = 0
        tok = 1
        i = 0
        fila = 1
        colu = 0

        'listas de tabla de tokens 
        num.Clear()
        Filtok.Clear()
        Coltok.Clear()
        Numtok.Clear()
        Token.Clear()
        patron.Clear()
        lexis.Clear()
        descrip.Clear()
        'listas tabla errores
        no.Clear()
        fil.Clear()
        col.Clear()
        ror.Clear()
        n = 1
        j = 1
        Tokens.Rows.Clear()
        Eror.Rows.Clear()


    End Sub

    '*************DESCRIPCION, PATRON , TOKEN***************
    Private Function desc(ByVal tokn As String)
        Select Case tokn
            Case 1
                Return "Palabra del Reservada de sistema"
            Case 2
                Return "Comentario"
            Case 3
                Return "Numero"
            Case 4
                Return "Parentesis Abierto"
            Case 5
                Return "Parentesis Cerrado"
            Case 6
                Return "Punto y coma"
            Case 7
                Return "Coma"
            Case 8
                Return "Llave Abierta"
            Case 9
                Return "Llave Cerrada"
            Case 10
                Return "Directorio"
            Case 11
                Return "Palabra"
        End Select
        Return ""
    End Function
    Private Function Patrn(ByVal pat As String)
        Select Case pat
            Case 1
                Return "("
            Case 2
                Return ")"
            Case 3
                Return ","
            Case 4
                Return ";"
            Case 5
                Return "{"
            Case 6
                Return "}"
            Case 7
                Return "'(L|D)+'"
            Case 8
                Return "/*(L|D)+*/"
            Case 9
                Return "N+"
            Case 10
                Return "L:\(L\)+"
            Case 11
                Return "L+"
        End Select
        Return ""
    End Function
    Private Function n_n(ByVal toks As String)
        Select Case toks
            Case 1
                Return "Reservada"
            Case 2
                Return "Comentario"
            Case 3
                Return "Numero"
            Case 4
                Return "Parentesis Abierto"
            Case 5
                Return "Parentesis Cerrado"
            Case 6
                Return "pto y coma"
            Case 7
                Return "Coma"
            Case 8
                Return "Llave Abierta"
            Case 9
                Return "Llave Cerrada"
            Case 10
                Return "Path"
            Case 11
                Return "Words"
        End Select
        Return ""
    End Function

    '*********PALABRAS RESERVADAS**********
    Private Function malditapalabrareservada(ByVal analisis As String)

        Dim w As Integer

        For w = 0 To reserv.Count - 1

            If ((reserv(w)).ToString = analisis) Then

                Return analisis

            End If



        Next

        Return "error"

    End Function

    '**************TABLA DE TOKENS Y ERRORES *******************


    Private Sub TokensToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TokensToolStripMenuItem.Click
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        


        pth = " C:\Users\Public\Documents\Tokens" & ".pdf"

        Dim docki As Document = New Document(PageSize.A4_LANDSCAPE, 20, 0, 50, 20)
        Try


            pdfw = PdfWriter.GetInstance(docki, New FileStream(pth, _
            FileMode.Create, FileAccess.Write, FileShare.None))

            docki.Open()

            docki.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_LEFT,
            "Nombre: Andrea Virginia Chavarría Guzmán"))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Carne: 2009-20081"))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Lenguajes Formales y de Programación"))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Sección: A-"))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "                                                                    TOKENS"))

            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docki.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))

            docki.Add(Tables())
            'Cerramos el documento.
            docki.Close()
            tokns()

        Catch ex As Exception

            Dialog1.Show()
            If docki.IsOpen() Then
                docki.Close()
                File.Delete(pth)

            End If



        End Try





    End Sub
    Private Function Tables()
        Dim tab As PdfPTable = New PdfPTable(8)

        tab.AddCell(New Paragraph("Numero", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Fila", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Columna", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("No.Token", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Tokens", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Patron", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Lexema", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Descrip.", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))

        For too As Integer = 0 To num.Count - 1

            tab.AddCell(New Paragraph(num(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(Filtok(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(Coltok(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(Numtok(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(Token(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(patron(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(lexis(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(descrip(too), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))

        Next

        Return tab



    End Function
    Private Function tokns()
        Dim arch As String
        arch = "C:\Users\Public\Documents\Tokens.pdf"
        Shell("C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe " & arch, vbMaximizedFocus)
    End Function


    Private Sub LexicosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LexicosToolStripMenuItem.Click
        Dim pdfw As iTextSharp.text.pdf.PdfWriter

        pathi = " C:\Users\Public\Documents\Errores" & ".pdf"



        Dim docko As Document = New Document(PageSize.A4, 20, 20, 50, 20)

        Try
            pdfw = PdfWriter.GetInstance(docko, New FileStream(pathi, _
            FileMode.Create, FileAccess.Write, FileShare.None))

            docko.Open()

            docko.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_LEFT,
            "Nombre: Andrea Virginia Chavarría Guzmán"))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Carne: 2009-20081"))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Lenguajes Formales y de Programación"))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "Sección: A-"))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Paragraph.GetInstance(PdfContentByte.ALIGN_CENTER, "                                                            ERRORES LEXICOS"))

            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))
            docko.Add(iTextSharp.text.Phrase.GetInstance(vbCrLf))

            docko.Add(Table())
            'Cerramos el documento.
            docko.Close()
            Lexic_errors()
        Catch ex As Exception
            Dialog1.Show()
            If docko.IsOpen() Then
                docko.Close()
                File.Delete(pathi)

            End If



        End Try


    End Sub
    Private Function Table()
        Dim tab As PdfPTable = New PdfPTable(4)

        tab.AddCell(New Paragraph("Numero", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Simbolo", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Fila", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))
        tab.AddCell(New Paragraph("Columna", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.ORANGE)))


        For errores As Integer = 0 To no.Count - 1


            tab.AddCell(New Paragraph((errores), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(ror(errores), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(fil(errores), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))
            tab.AddCell(New Paragraph(col(errores), FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.Bold, BaseColor.BLACK)))

        Next

        Return tab



    End Function
    Private Function Lexic_errors()
        Dim arh As String
        arh = "C:\Users\Public\Documents\Errores.pdf"
        Shell("C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe " & arh, vbMaximizedFocus)
    End Function


    '*********************************ABRIR Y GUARDAR****************************
    Private Sub AbrirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Archivos de texto|*.txt"
        OpenFileDialog1.Title = "File 2 Open??"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            RichTextBox1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

    Private Sub GuardarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Archivos de texto|*.txt"
        SaveFileDialog1.Title = "File 2 Save??"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

    '*********************************FUNCIONES DEL ANALISIS SINTACTICO******************************
    Private Function getToken()
        Try
            Dim lst As Integer = realToken(0).ToString
            realToken.RemoveAt(0)
            Return lst
        Catch ex As Exception
            Numtok.Add(20)
        End Try
    End Function

    Private Function grammar()
        Preanalisis = getToken()
        B_NEWdOC()

    End Function
    Private Function B_NEWdOC()
        parea(1)
        parea(2)
        parea(9)
        parea(4)
        parea(10)
        parea(3)
        parea(5)
        B_CARAC()
        parea(6)
        parea(7)

    End Function
    Private Function B_CARAC()
        parea(12)
        parea(2)
        parea(3)
        parea(5)
        ' caracteristica letra
        parea(13)
        parea(2)
        parea(9)
        parea(3)
        parea(7)
        ' caracteristica tamaño letra
        parea(14)
        parea(2)
        parea(8)
        parea(3)
        parea(7)
        'caracteristica tamaño pagina
        parea(15)
        parea(2)
        parea(9)
        parea(3)
        parea(7)
        ' fin de  caracteristicas 
        parea(6)
        parea(7)


    End Function
    Private Function B_NwPaG()
        parea(16)
        parea(2)
        parea(3)
        parea(5)
        B_insrtall()
        parea(6)
        parea(7)

    End Function
    Private Function B_insrtall()

    End Function

    Private Function parea(ByVal tok As Integer)
        If Preanalisis = tok Then
            Console.WriteLine("Acepted !!")
            Console.WriteLine(Preanalisis.ToString)
            Preanalisis = getToken()
        Else
            Console.WriteLine("error")
        End If

    End Function


    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub ResultadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultadoToolStripMenuItem.Click
        Console.WriteLine(grammar())
     
    End Sub
End Class
