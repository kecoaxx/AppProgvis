Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class AdminKoki
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String

    Private Sub AdminKoki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        load_table(Q:="SELECT NamaMenu as 'Nama Menu', JenisMenu FROM progvis.menu",
                    R:=DataGridView1, S:="A")
        DataGridView1.ReadOnly = True

    End Sub

    Private Sub load_table(Q As String, R As Object, S As String)
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

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView1.Rows(e.RowIndex)

            Dim selectedValue As String = row.Cells("Nama Menu").Value.ToString()

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

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Clear()
    End Sub
End Class