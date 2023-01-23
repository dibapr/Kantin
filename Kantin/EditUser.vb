Imports MySql.Data.MySqlClient
Public Class EditUser
    Private Sub EditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        TextBox1.Text = Home.Label2.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim getIdUser As Integer
        Cmd = New MySqlCommand("SELECT id FROM user WHERE username = @getUsername", Conn)
        Cmd.Parameters.AddWithValue("@getUsername", TextBox1.Text)
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            getIdUser = Dr("id")
        End While
        Dr.Close()
        If TextBox2.Text = "" Then
            If TextBox3.Text <> TextBox4.Text Then
                MsgBox("Konfirmasi password tidak cocok", MessageBoxIcon.Warning, "Peringatan")
            Else
                'Kalo update password doang
                Cmd = New MySqlCommand("UPDATE user SET password = @newpassword WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", getIdUser)
                Cmd.Parameters.AddWithValue("@newpassword", TextBox4.Text)
                Cmd.ExecuteNonQuery()
                MsgBox("Anda berhasil mengubah password anda", MessageBoxIcon.Information, "Edit User")
                Reset()
            End If
        ElseIf TextBox3.Text = "" And TextBox4.Text = "" Then
            'Kalo update username doang
            If TextBox2.Text = TextBox1.Text Then
                MsgBox("Anda tidak dapat mengubah ke username yang sama", MessageBoxIcon.Warning, "Peringatan")
            Else
                Cmd = New MySqlCommand("UPDATE user SET username = @newusername WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", getIdUser)
                Cmd.Parameters.AddWithValue("@newusername", TextBox2.Text)
                Cmd.ExecuteNonQuery()
                MsgBox("Anda berhasil mengubah username anda", MessageBoxIcon.Information, "Edit User")
                Me.TextBox1.Text = Me.TextBox2.Text
                Home.Label2.Text = Me.TextBox2.Text
                Reset()
            End If
        Else
                If TextBox3.Text <> TextBox4.Text Then
                MsgBox("Konfirmasi password tidak cocok", MessageBoxIcon.Warning, "Peringatan")
            Else
                'Kalo update dua-duanya
                Cmd = New MySqlCommand("UPDATE user SET username = @newusername, password = @newpassword WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", getIdUser)
                Cmd.Parameters.AddWithValue("@newusername", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@newpassword", TextBox4.Text)
                Cmd.ExecuteNonQuery()
                MsgBox("Anda berhasil mengubah username dan password anda", MessageBoxIcon.Information, "Edit User")
                Me.TextBox1.Text = Me.TextBox2.Text
                Home.Label2.Text = Me.TextBox2.Text
                Reset()
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox4.Enabled = True
        If TextBox3.Text = "" Then
            TextBox4.Enabled = False
        End If
    End Sub
    Sub Reset()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub
End Class