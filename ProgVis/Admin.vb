Imports System.Threading
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Admin
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String
    Dim username As String = Login.username
    Dim NamaLengkap As String = LoadQuery(Q:=$"select NamaLengkap from progvis.users where Username = {username}")



    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        DataGridView2.ReadOnly = True

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim Query As String = "SELECT * FROM progvis.users"
        COMMAND = New MySqlCommand(Query, conn)
        READER = COMMAND.ExecuteReader

        While READER.Read()
            If Not READER.IsDBNull(0) Then
                Dim name As String = READER.GetString("NamaLengkap")
                ComboBox1.Items.Add(name)
            End If
        End While

        READER.Close()
        conn.Close()

        idTextBox.ReadOnly = True
        LoadTable(Q:="SELECT * FROM progvis.users",
                    R:=DataGridView1)
        LoadTable(Q:="SELECT * FROM progvis.menu",
                    R:=DataGridView2)
        LoadTable(Q:="SELECT * FROM progvis.pesanan",
                    R:=DataGridView3)
    End Sub
    ' FUNGSI LOAD TABLE DISINI
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timestring As String
        timestring = Date.Now.ToString("hh:mm:ss")
        Label1.Text = $"Welcome {NamaLengkap} | {timestring}"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim id As String = idTextBox.Text
            Dim username As String = usernameTextBox.Text
            Dim email As String = emailTextBox.Text
            Dim namalengkap As String = namalengkapTextBox.Text
            Dim password As String = passwordTextBox.Text
            Dim jabatan As String = jabatanDroplist.Text

            Dim Query As String = $"INSERT INTO progvis.users (idUser, NamaLengkap, 
                                    Email, Username, Password, Jabatan, Gender, TglLahir) 
                                    VALUES ('{id}', '{namalengkap}', '{email}', 
                                    '{username}', '{password}', '{jabatan}', 
                                    '{gender}','{DateTimePicker1.Text}')"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader

            MessageBox.Show("Data Saved")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim id As String = idTextBox.Text
            Dim username As String = usernameTextBox.Text
            Dim email As String = emailTextBox.Text
            Dim namalengkap As String = namalengkapTextBox.Text
            Dim password As String = passwordTextBox.Text
            Dim jabatan As String = jabatanDroplist.Text


            Dim Query As String = $"UPDATE progvis.users SET 
                                    NamaLengkap = '{namalengkap}',
                                    Email = '{email}',
                                    Username = '{username}',
                                    Password = '{password}',
                                    Jabatan = '{jabatan}',
                                    Gender = '{gender}'
                                    WHERE idUser = '{id}'"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader

            MessageBox.Show("Data Updated")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim id As String = idTextBox.Text
            Dim username As String = usernameTextBox.Text
            Dim email As String = emailTextBox.Text
            Dim namalengkap As String = namalengkapTextBox.Text
            Dim password As String = passwordTextBox.Text
            Dim jabatan As String = jabatanDroplist.Text

            Dim Query As String = $"DELETE FROM progvis.users
                                    WHERE idUser = '{id}'"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader

            MessageBox.Show("Data Deleted")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim combo As String = ComboBox1.Text
        Dim Query As String = $"SELECT * FROM progvis.users where NamaLengkap = '{combo}'"
        COMMAND = New MySqlCommand(Query, conn)
        READER = COMMAND.ExecuteReader

        While READER.Read()
            Dim genderRead As String = READER.GetString("Gender")
            idTextBox.Text = READER.GetString("idUser")
            namalengkapTextBox.Text = READER.GetString("NamaLengkap")
            emailTextBox.Text = READER.GetString("Email")
            usernameTextBox.Text = READER.GetString("Username")
            passwordTextBox.Text = READER.GetString("Password")
            jabatanDroplist.Text = READER.GetString("Jabatan")
            DateTimePicker1.Text = READER.GetString("TglLahir")
            If genderRead = "Male" Then
                male.Select()
            ElseIf genderRead = "Female" Then
                female.Select()
            End If
        End While

        READER.Close()
        conn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow

            row = DataGridView1.Rows(e.RowIndex)

            idTextBox.Text = row.Cells("idUser").Value.ToString()
            namalengkapTextBox.Text = row.Cells("NamaLengkap").Value.ToString()
            emailTextBox.Text = row.Cells("Email").Value.ToString()
            usernameTextBox.Text = row.Cells("Username").Value.ToString()
            passwordTextBox.Text = row.Cells("Password").Value.ToString()
            jabatanDroplist.Text = row.Cells("Jabatan").Value.ToString()
            Dim genderRead As String = row.Cells("Gender").Value.ToString()
            If genderRead = "Male" Then
                male.Select()
            ElseIf genderRead = "Female" Then
                female.Select()
            End If

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LoadTable(Q:="SELECT * FROM progvis.users", R:=DataGridView1
                   )
    End Sub

    Private Sub male_CheckedChanged(sender As Object, e As EventArgs) Handles male.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub female_CheckedChanged(sender As Object, e As EventArgs) Handles female.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim dialogResult1 As DialogResult = MessageBox.Show(DateTimePicker1.Value.ToString(), "Message", MessageBoxButtons.OK)
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        idTextBox.Clear()
        namalengkapTextBox.Clear()
        emailTextBox.Clear()
        usernameTextBox.Clear()
        passwordTextBox.Clear()
        jabatanDroplist.ResetText()
        DateTimePicker1.ResetText()
        ComboBox1.ResetText()
        male.Checked = False
        female.Checked = False
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView2.Rows(e.RowIndex)

            Dim selectedValue As String = row.Cells("NamaMenu").Value.ToString()

            ' Check if the value already exists in the RichTextBox
            If Not RichTextBox1.Text.Contains(selectedValue) Then
                ' Append the value to the RichTextBox
                If RichTextBox1.Text.Trim() <> "" Then
                    RichTextBox1.Text += ", "
                End If
                RichTextBox1.Text += selectedValue.TrimEnd()
            End If
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim menuname As String = String.Join(", ", RichTextBox1.Text.Split(","c).Select(Function(item) """" + item.Trim() + """"))
            LoadTable(Q:="UPDATE progvis.menu SET Tersedia='N'", R:=DataGridView2)
            LoadTable(Q:=$"UPDATE progvis.menu SET Tersedia='Y' WHERE NamaMenu IN ({menuname})",
                        R:=DataGridView2)
            LoadTable(Q:="select * from progvis.menu", R:=DataGridView2)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs)
        LoadTable(Q:="UPDATE progvis.menu SET Tersedia='N'; select * from progvis.menu", R:=DataGridView2)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        LoadTable(Q:="select * from progvis.menu where Tersedia='Y'", R:=DataGridView2)
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        LoadTable(Q:="SELECT * FROM progvis.pesanan",
                    R:=DataGridView3)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

End Class