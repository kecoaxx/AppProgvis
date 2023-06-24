Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports MySql.Data.MySqlClient


Public Class Login
    Public username As String = "1"
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader

    Private Function IsTrue() As String
        Dim count As Integer = 0
        Dim jabatan As String = ""

        While READER.Read()
            count += 1
            jabatan = READER("Jabatan").ToString()
            If jabatan = "Admin" Then
                jabatan = "1"
                Exit While
            End If
        End While

        Return jabatan
    End Function

    Private Sub OpenUserRoleForm(role As String)
        Select Case role
            Case "Admin"
                Admin.Show()
            Case "Manager"
                Manager.Show()
            Case "Kasir"
                Kasir.Show()
            Case "Koki"
                Koki.Show()
            Case "Pelayan"
                Pelayan.Show()
        End Select

        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim count As Integer = 0
            Dim userRole As String = ""

            Dim Query As String = $"SELECT * FROM progvis.users WHERE Username='{TextBox1.Text}' AND Password='{TextBox2.Text}'"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader

            While READER.Read()
                userRole = READER("Jabatan").ToString()
                count += 1
            End While

            If count = 1 Then
                username = TextBox1.Text
                OpenUserRoleForm(userRole)
            Else
                MessageBox.Show("Incorrect Username or Password")
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            MessageBox.Show("Connection to MySQL Test was Successful", "Testing connection to MySql")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub
End Class