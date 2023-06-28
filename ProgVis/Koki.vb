Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Koki
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String

    Private Sub Koki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        LoadTable(Q:="SELECT NamaMenu, JenisMenu, Tersedia FROM progvis.menu",
                    R:=DataGridView1)
        DataGridView1.ReadOnly = True
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.Width = 150
        Next

    End Sub

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
        Label1.Text = $"Welcome Admin | {timestring}"
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

    End Sub
End Class