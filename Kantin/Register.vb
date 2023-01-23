Imports MySql.Data.MySqlClient

Public Class Register
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Input tidak boleh kosong", MessageBoxIcon.Warning, "Peringatan")
        Else
            If CheckBox1.Checked = False Then
                MsgBox("Anda belum menyetujui ketentuan.", MessageBoxIcon.Warning, "Peringatan")
            Else
                Connection()
                Cmd = New MySqlCommand("SELECT COUNT(*) FROM user WHERE username = @username", Conn)
                Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                Dim result As Integer = Cmd.ExecuteScalar()
                If result > 0 Then
                    MsgBox("Username '" & TextBox1.Text & "' sudah terdaftar.", MessageBoxIcon.Warning, "Peringatan")
                Else
                    Cmd = New MySqlCommand("INSERT INTO user (id_user_level, username, password) VALUES (2, @username, @password)", Conn)
                    Cmd.Parameters.AddWithValue("@username", TextBox1.Text)
                    Cmd.Parameters.AddWithValue("@password", TextBox2.Text)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Anda telah berhasil membuat akun baru", MessageBoxIcon.Information, "Register berhasil")
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If
            End If
        End If
    End Sub
End Class