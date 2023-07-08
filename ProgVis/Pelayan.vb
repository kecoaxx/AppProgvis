Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Pelayan

    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim username As String = Login.username
    Dim iduser As String = LoadQuery($"select idUser from progvis.users where Username = {username}")
    Dim NamaLengkap As String = LoadQuery(Q:=$"select NamaLengkap from progvis.users where Username = {username}")

    Private Sub Pelayan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Interval = 1000
        Timer1.Enabled = True
        Timer2.Enabled = True
        LoadTable(Q:="select NamaMenu as 'Nama Menu', JenisMenu as 'Jenis Menu', HargaMenu as 'Harga Menu', idMenu from progvis.menu where Tersedia='Y'",
                  R:=DataGridView3)
        LoadTable(Q:="select NamaMenu as 'Nama Menu', idDetailPesanan, StatusPesanan as 'Status Pesanan' from progvis.detail_pesanan",
                  R:=DataGridView5)

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timestring As String
        timestring = Date.Now.ToString("hh:mm:ss")
        Label1.Text = $"Welcome {NamaLengkap} | {timestring}"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick, DataGridView3.CellContentClick
        If nomormeja.Text = "" Then
            MessageBox.Show("Masukkan nomor meja")
        Else
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = DataGridView3.Rows(e.RowIndex)
                namamakanan.Text = row.Cells("Nama Menu").Value.ToString()
                TextBox6.Text = row.Cells("idMenu").Value.ToString()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim pelNoMeja As String = nomormeja.Text
            Dim pelIdDetail As String = iddetail.Text
            Dim pelIdPesanan As String = idpesan.Text
            Dim pelNamaMakanan As String = namamakanan.Text
            Dim pelIdMakanan As String = TextBox6.Text
            Dim hargaqty As String = LoadQuery($"select HargaMenu from progvis.menu where NamaMenu = '{pelNamaMakanan}'")
            Dim pelQty As String = Integer.Parse(quantity.Text) * hargaqty

            LoadQuery($"INSERT INTO `progvis`.`detail_pesanan` (idDetailPesanan, idMenu, NamaMenu, HargaMenu, NomorMeja, qty) 
                        Values ('{pelIdDetail}','{pelIdMakanan}','{pelNamaMakanan}','{pelQty}','{pelNoMeja}','{quantity.Text}')")
            LoadTable(Q:=$"select NamaMenu as 'Nama Menu', qty as 'QTY' ,HargaMenu as 'Harga Menu', idMenu , number from progvis.detail_pesanan where idDetailPesanan = '{pelIdDetail}'",
                      R:=DataGridView4)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub namamakanan_TextChanged(sender As Object, e As EventArgs) Handles namamakanan.TextChanged
        quantity.Clear()
        quantity.Text = "1"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If nomormeja.Text = "" Then
            MessageBox.Show("Masukkan nomor meja")
        Else
            Dim pesananid As String
            Dim isnulldetail As String = LoadQuery("select idDetailPesanan from progvis.detail_pesanan order by idDetailPesanan desc")
            If isnulldetail = "" Then
                iddetail.Text = "D001"
            Else
                Dim currentId As Integer = Integer.Parse(isnulldetail.Substring(1))
                Dim nextId As Integer = currentId + 1
                iddetail.Text = "D" + nextId.ToString("D3")
            End If
            LoadQuery($"UPDATE `progvis`.`pesanan` SET idUser = '{iduser}' WHERE idPesanan = '{idpesan.Text}';
                        INSERT INTO `progvis`.`pesanan` (NomorMeja) VALUES ({nomormeja.Text})")
            'LoadQuery($"")
            pesananid = LoadQuery($" select idPesanan from `progvis`.`pesanan` where NomorMeja = '{nomormeja.Text}' order by idPesanan desc")
            idpesan.Text = pesananid
            LoadQuery($"UPDATE `progvis`.`pesanan` SET idDetailPesanan = '{iddetail.Text}' WHERE idPesanan = '{idpesan.Text}';")
        End If
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick, DataGridView4.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView4.Rows(e.RowIndex)
            namamakanan.Text = row.Cells("Nama Menu").Value.ToString()
            TextBox6.Text = row.Cells("idMenu").Value.ToString()
            quantity.Text = row.Cells("QTY").Value.ToString()
            nomordetail.Text = row.Cells("number").Value.ToString()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim pelNoMeja As String = nomormeja.Text
            Dim pelIdDetail As String = iddetail.Text
            Dim pelIdPesanan As String = idpesan.Text
            Dim pelNamaMakanan As String = namamakanan.Text
            Dim pelIdMakanan As String = idmakanan.Text
            Dim hargaqty As String = LoadQuery($"select HargaMenu from progvis.menu where NamaMenu = '{pelNamaMakanan}'")
            Dim pelQty As String = Integer.Parse(quantity.Text) * hargaqty

            LoadQuery($"UPDATE `progvis`.`detail_pesanan`
                        SET
                        idMenu = '{pelIdMakanan}',
                        NamaMenu = '{pelNamaMakanan}',
                        HargaMenu = '{pelQty}',
                        NomorMeja = '{pelNoMeja}'
                        WHERE
                        idMenu = '{pelIdMakanan}'")
            LoadTable(Q:=$"select NamaMenu as 'Nama Menu', qty as 'QTY' ,HargaMenu as 'Harga Menu', idMenu, number from progvis.detail_pesanan where idDetailPesanan = '{pelIdDetail}'",
                      R:=DataGridView4)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button11.Click
        LoadQuery($"DELETE FROM progvis.detail_pesanan WHERE number = '{nomordetail.Text}'")
        LoadTable(Q:=$"select NamaMenu as 'Nama Menu', qty as 'QTY' ,HargaMenu as 'Harga Menu', idMenu, number from progvis.detail_pesanan where idDetailPesanan = '{iddetail.Text}'",
                  R:=DataGridView4)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button12.Click

        nomormeja.Clear()
        iddetail.Clear()
        TextBox6.Clear()
        namamakanan.Clear()
        idpesan.Clear()
        quantity.Clear()
        LoadQuery($"select NamaMenu as 'Nama Menu', idDetailPesanan, StatusPesanan as 'Status Pesanan' from progvis.detail_pesanan where 1 = 0")
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        LoadTable($"select NamaMenu as 'Nama Menu', qty as 'QTY' ,HargaMenu as 'Harga Menu', idMenu , number from progvis.detail_pesanan where idDetailPesanan = '{iddetail.Text}'",
                  DataGridView4)
        nomormeja.Text = LoadQuery($"select NomorMeja from progvis.detail_pesanan where idDetailPesanan = '{iddetail.Text}'")
        idpesan.Text = LoadQuery($"select IdPesanan from progvis.pesanan where idDetailPesanan = '{iddetail.Text}'")
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        LoadTable(Q:=$"select NamaMenu as 'Nama Menu', idDetailPesanan, StatusPesanan as 'Status Pesanan' from progvis.detail_pesanan where idDetailPesanan = '{TextBox7.Text}'", R:=DataGridView5)
    End Sub
End Class