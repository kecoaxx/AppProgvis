Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Pelayan

    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim username As String = Login.username
    Dim NamaLengkap As String = LoadQuery(Q:=$"select NamaLengkap from progvis.users where Username = {username}")

    Private Sub Pelayan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Timer1.Enabled = True
        LoadTable(Q:="select NamaMenu as 'Nama Menu', JenisMenu as 'Jenis Menu', HargaMenu as 'Harga Menu' from progvis.menu where Tersedia='Y'",
                  R:=DataGridView1)

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
        Dim namalengkap As String = LoadQuery($"select NamaLengkap from progvis.users where Username = {username}")
        Label1.Text = $"Welcome {namalengkap} | {timestring}"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            Dim hehe As String
            row = DataGridView1.Rows(e.RowIndex)
            hehe = row.Cells("Nama Menu").Value.ToString()
            Dim itemExists As Boolean = False
            For Each dgvRow As DataGridViewRow In DataGridView2.Rows
                If dgvRow.Cells("nama").Value IsNot Nothing AndAlso dgvRow.Cells("nama").Value.ToString() = hehe Then
                    itemExists = True
                    Exit For
                End If
            Next

            ' Add a new row only if the item doesn't exist
            If Not itemExists Then
                Dim rowIndex As Integer = DataGridView2.Rows.Add()
                Dim namaColumnIndex As Integer = DataGridView2.Columns("nama").Index
                DataGridView2.Rows(rowIndex).Cells(namaColumnIndex).Value = hehe
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim combo As String = ComboBox1.Text
        LoadQuery($"select * from progvis.menu where JenisMenu  = {combo}'")

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If nomormeja.Text = "" Then
            MessageBox.Show("Please Input Table Number")
        End If

        Dim detailid As String
        Dim pesananid As String
        LoadQuery($"INSERT INTO `progvis`.`detail_pesanan` (NomorMeja) VALUES ({nomormeja.Text})")
        detailid = LoadQuery($" select idDetailPesanan from `progvis`.`detail_pesanan` where NomorMeja = '{nomormeja.Text}' order by Time desc")
        iddetail.Text = detailid
        LoadQuery($"INSERT INTO `progvis`.`pesanan` (NomorMeja) VALUES ({nomormeja.Text})")
        pesananid = LoadQuery($" select idPesanan from `progvis`.`pesanan` where NomorMeja = '{nomormeja.Text}' order by WaktuOrder desc")
        idpesan.Text = pesananid
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub DataGridView2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class