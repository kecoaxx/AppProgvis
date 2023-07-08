Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class Kasir
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String
    Dim username As String = Login.username
    Dim NamaLengkap As String = LoadQuery(Q:=$"select NamaLengkap from progvis.users where Username = {username}")
    Dim idUser As String = LoadQuery(Q:=$"select idUser from progvis.users where Username = {username}")
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Dim dataRows As List(Of DataRow)
    Dim WithEvents PD As New PrintDocument

    Private Sub Kasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadTable($"select idDetailPesanan, NamaMenu as 'Nama Menu',qty, HargaMenu as 'Harga Menu' from progvis.detail_pesanan", DataGridView1)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timestring As String
        timestring = Date.Now.ToString("hh:mm:ss")
        Label1.Text = $"Welcome {NamaLengkap} | {timestring}"
    End Sub

    Private Function LoadQuery(Q As String) As String
        Dim result As String = "" ' Initialize the result variable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim Query As String = Q
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader

            If READER.Read() Then ' Check if there is a row returned
                result = READER.GetString(0) ' Assuming the NamaLengkap column is the first column in the query result
            End If

            READER.Close() ' Close the data reader after retrieving the value
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close() ' Always close the connection
        End Try

        Return result ' Return the retrieved value
    End Function

    Private Sub LoadTable(Q As String, R As Object, Optional S As String = "A")
        Dim SDA As New MySqlDataAdapter
        Dim bindSource As New BindingSource
        Dim table As New DataTable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim Query As String = Q
            COMMAND = New MySqlCommand(Query, conn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(table)
            bindSource.DataSource = table
            R.DataSource = bindSource
            SDA.Update(table)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        If Not String.IsNullOrEmpty(S) Then
            table.TableName = S
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadTable($"select NamaMenu as 'Nama Menu',qty, HargaMenu as 'Harga Menu' from progvis.detail_pesanan WHERE idDetailPesanan = '{TextBox1.Text}'", DataGridView1)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("masukkan id detail pesanan")
        Else
            ' Retrieve data from MySQL database based on the specified idDetailPesanan
            Dim idDetailPesanan As String = TextBox1.Text ' Assumes the TextBox contains the idDetailPesanan input
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim command As New MySqlCommand("SELECT NamaMenu, qty, HargaMenu, idDetailPesanan, NomorMeja FROM detail_pesanan WHERE idDetailPesanan = @id", conn)
            command.Parameters.AddWithValue("@id", idDetailPesanan)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            dataRows = table.Rows.Cast(Of DataRow)().ToList()

            If dataRows.Count > 0 Then ' If there are rows with the specified idDetailPesanan
                changelongpaper()
                PPD.Document = PD
                PPD.ShowDialog()

                ' Update the values of "id pesanan" and "No Meja" in the PrintPage event handler

            Else
                MessageBox.Show("Data not found for the specified idDetailPesanan.")
            End If
            conn.Close()
            LoadQuery($"Update progvis.pesanan Set TotalHarga = '{t_price}' where idDetailPesanan ='{TextBox1.Text}';
                        Update progvis.pesanan Set idUser = '{idUser}' where idDetailPesanan = '{TextBox1.Text}'")


        End If

    End Sub

    Sub changelongpaper()
        longpaper = 0
        longpaper = dataRows.Count * 15
        longpaper = longpaper + 210
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        ' Font alignment
        Dim right As New StringFormat
        Dim center As New StringFormat
        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "----------------------------------------------------------------------------"
        e.Graphics.DrawString("SESAJAENN", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("Fakultas Teknik Prodi Elektro", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("Tel 08872202869", f8, Brushes.Black, centermargin, 40, center)

        e.Graphics.DrawString("ID Pesanan", f10, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f10, Brushes.Black, 70, 60)
        e.Graphics.DrawString(dataRows(0)("idDetailPesanan").ToString(), f10, Brushes.Black, 100, 60)

        e.Graphics.DrawString("No Meja", f10, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f10, Brushes.Black, 70, 75)
        e.Graphics.DrawString(dataRows(0)("NomorMeja").ToString(), f10, Brushes.Black, 100, 75)

        e.Graphics.DrawString("Kasir", f10, Brushes.Black, 0, 90)
        e.Graphics.DrawString(":", f10, Brushes.Black, 70, 90)
        e.Graphics.DrawString($"{NamaLengkap}", f10, Brushes.Black, 100, 90)

        e.Graphics.DrawString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), f10, Brushes.Black, 0, 105)

        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 120)

        Dim height As Integer = 0 ' DGV position
        For Each row As DataRow In dataRows
            height += 30
            e.Graphics.DrawString(row("NamaMenu").ToString(), f10, Brushes.Black, 25, 100 + height)
            e.Graphics.DrawString(row("qty").ToString(), f10, Brushes.Black, 0, 100 + height)
            Dim price As Integer = Integer.Parse(row("HargaMenu").ToString())
            e.Graphics.DrawString(price.ToString(), f10, Brushes.Black, rightmargin, 100 + height, right)
        Next

        Dim height2 As Integer
        height2 = 110 + height
        sumprice() ' Call the sumprice sub
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
        e.Graphics.DrawString("Total: " & Format(t_price, "## ##0"), f10b, Brushes.Black, rightmargin, 15 + height2, right)
        e.Graphics.DrawString(t_qty, f10b, Brushes.Black, 0, 15 + height2)

        e.Graphics.DrawString("Terima Kasih Sudah Berkunjung", f10b, Brushes.Black, centermargin, 40 + height2, center)
        e.Graphics.DrawString("-Sesajaenn-", f10b, Brushes.Black, centermargin, 55 + height2, center)
    End Sub

    Dim t_price As Long
    Dim t_qty As Long

    Sub sumprice()
        Dim countprice As Long = 0
        For Each row As DataRow In dataRows
            countprice += (Integer.Parse(row("HargaMenu").ToString()) * Integer.Parse(row("qty").ToString()))
        Next
        t_price = countprice

        Dim countqty As Long
        For Each row As DataRow In dataRows
            countqty += Integer.Parse(row("qty").ToString())
        Next
        t_qty = countqty
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadTable("select idDetailPesanan, NamaMenu as 'Nama Menu',qty, HargaMenu as 'Harga Menu' from progvis.detail_pesanan", DataGridView1)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("idDetailPesanan").Value.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Login.Show()
    End Sub
End Class