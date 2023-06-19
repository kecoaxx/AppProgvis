﻿Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Admin
    Dim conn As New MySqlConnection With {.ConnectionString = "server=127.0.0.1;userid=root;password='Placeholder1';database=progvis"}
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim data_Table As New DataTable
    Dim gender As String


    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

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

        load_table()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timestring As String
        timestring = Date.Now.ToString("hh:mm:ss")
        Label1.Text = $"Welcome Admin | {timestring}"
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
                                    Jabatan = '{jabatan}'
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

        End If
    End Sub

    Private Sub load_table()
        Dim SDA As New MySqlDataAdapter
        Dim bindSource As New BindingSource
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim Query As String = "SELECT idUser As userID, NamaLengkap, Email, Username, Password, Jabatan, Gender, TglLahir FROM progvis.users"
            COMMAND = New MySqlCommand(Query, conn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(data_Table)
            bindSource.DataSource = data_Table
            DataGridView1.DataSource = bindSource
            SDA.Update(data_Table)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim SDA As New MySqlDataAdapter
        Dim bindSource As New BindingSource
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim Query As String = "SELECT * FROM progvis.users "
            COMMAND = New MySqlCommand(Query, conn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(data_Table)
            bindSource.DataSource = data_Table
            DataGridView1.DataSource = bindSource
            SDA.Update(data_Table)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
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
End Class