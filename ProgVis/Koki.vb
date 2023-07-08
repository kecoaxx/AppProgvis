Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Koki
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String
    Dim status As String
    Dim username As String = Login.username
    Dim NamaLengkap As String = LoadQuery(Q:=$"select NamaLengkap from progvis.users where Username = {username}")

    Private Sub Koki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadTable(Q:="SELECT NamaMenu, JenisMenu, Tersedia FROM progvis.menu",
                    R:=DataGridView1)
        LoadTable(Q:="SELECT NamaMenu, NomorMeja, StatusPesanan, number FROM progvis.detail_pesanan",
                    R:=DataGridView2)
        DataGridView1.ReadOnly = True
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.Width = 150
        Next

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim menuname As String = String.Join(", ", RichTextBox1.Text.Split(","c).Select(Function(item) """" + item.Trim() + """"))
            LoadTable(Q:="UPDATE progvis.menu SET Tersedia='N'", R:=DataGridView1)
            LoadTable(Q:=$"UPDATE progvis.menu SET Tersedia='Y' WHERE NamaMenu IN ({menuname})",
                        R:=DataGridView1)
            LoadTable(Q:="select NamaMenu, JenisMenu, Tersedia from progvis.menu", R:=DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView1.Rows(e.RowIndex)

            Dim selectedValue As String = row.Cells("NamaMenu").Value.ToString()

            ' Check if the value already exists in the RichTextBox
            If Not RichTextBox1.Text.Contains(selectedValue) Then
                ' Append the value to the RichTextBox
                If RichTextBox1.Text.Trim() <> "" Then
                    RichTextBox1.Text += ", "
                End If
                RichTextBox1.Text += selectedValue
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView2.Rows(e.RowIndex)
            Dim genderRead As String = row.Cells("StatusPesanan").Value.ToString()
            If genderRead = "Belum" Then
                RadioButton1.Select()
            ElseIf genderRead = "Dalam Proses" Then
                RadioButton2.Select()
            ElseIf genderRead = "Selesai" Then
                RadioButton3.Select()
            End If
            TextBox1.Text = row.Cells("number").Value.ToString()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        status = "Belum"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        status = "Dalam Proses"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        status = "Selesai"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LoadTable(Q:="SELECT NamaMenu, NomorMeja, StatusPesanan, number FROM progvis.detail_pesanan",
                    R:=DataGridView2)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Pilih dari tabel terlebih dahulu")
        Else
            LoadQuery($"UPDATE progvis.detail_pesanan SET StatusPesanan = '{status}' where `number` = '{TextBox1.Text}'")
            LoadTable(Q:="SELECT NamaMenu, NomorMeja, StatusPesanan, number FROM progvis.detail_pesanan",
                      R:=DataGridView2)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadTable(Q:="select NamaMenu, JenisMenu, Tersedia from progvis.menu where tersedia = 'Y'", R:=DataGridView1)
    End Sub
End Class