Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Input tidak boleh kosong")
        Else
            Connection()
            Cmd = New MySqlCommand("SELECT COUNT(*) FROM user WHERE username=@username AND password=@password", Conn)
            Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
            Cmd.Parameters.AddWithValue("@password", TextBox2.Text)
            Dim result As Integer = Cmd.ExecuteScalar()
            If result > 0 Then
                Dim Cmd2 As New MySqlCommand("SELECT id_user_level FROM user WHERE username = @username", Conn)
                Cmd2.Parameters.AddWithValue("@username", TextBox1.Text)
                Dim user_level As Integer = Cmd2.ExecuteScalar()
                If user_level = 1 Then
                    MsgBox("Anda login sebagai admin!", MessageBoxIcon.Information)
                    AdminDashboard.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                Else
                    Dim getId As Integer
                    Cmd = New MySqlCommand("SELECT id FROM user WHERE username = @username", Conn)
                    Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                    Dr = Cmd.ExecuteReader()
                    While Dr.Read()
                        getId = Dr("id")
                    End While
                    Dr.Close()
                    Dim userName As String
                    Cmd = New MySqlCommand("SELECT username FROM user WHERE id = @id", Conn)
                    Cmd.Parameters.AddWithValue("@id", getId)
                    Dr = Cmd.ExecuteReader()
                    While Dr.Read()
                        userName = Dr("username")
                    End While
                    MsgBox("Selamat datang, " & userName & "!", MessageBoxIcon.Information)
                    Me.Hide()
                    Home.Show()
                    Home.Label2.Text = userName
                    Invoice.Label7.Text = userName
                    Dr.Close()
                End If
            Else
                MsgBox("Username atau password salah.", MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Register.Show()
        Me.Hide()
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Connection()
        Dim result As DialogResult = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            Loading.Close()
            Cmd = New MySqlCommand("TRUNCATE TABLE detail_transaksi", Conn)
            Cmd.ExecuteNonQuery()
        End If
    End Sub
End Class