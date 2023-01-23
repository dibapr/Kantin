Imports MySql.Data.MySqlClient
Public Class TambahData
    Dim getID As Integer
    Private Sub TambahData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminDashboard
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Connection()
        With ComboBox1
            Dim CbMenu As New MySqlCommand
            CbMenu.Connection = Conn
            CbMenu.CommandText = "SELECT menu_type_name FROM menu_type"
            Dr = CbMenu.ExecuteReader()
            While Dr.Read()
                .Items.Add(Dr("menu_type_name"))
            End While
            Dr.Close()
        End With
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Input tidak boleh kosong", MessageBoxIcon.Warning, "Peringatan")
        Else
            Cmd = New MySqlCommand("SELECT COUNT(*) FROM menu_type WHERE menu_type_name = @menutype", Conn)
            Cmd.Parameters.AddWithValue("@menutype", TextBox1.Text)
            Dim result As Integer = Cmd.ExecuteScalar()
            Dim confirm As DialogResult = MessageBox.Show("Apakah anda yakin ingin menambahkan data tipe menu baru ini?", "Konfirmasi Data Baru", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                If result > 0 Then
                    MsgBox("Tipe menu '" & TextBox1.Text & "' sudah terdaftar.", MessageBoxIcon.Warning, "Peringatan")
                Else
                    Cmd = New MySqlCommand("INSERT INTO menu_type (menu_type_name) VALUES (@menutype)", Conn)
                    Cmd.Parameters.AddWithValue("@menutype", TextBox1.Text)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Anda telah berhasil membuat tipe menu baru", MessageBoxIcon.Information, "Input Data Baru Berhasil")
                    TextBox1.Clear()
                    ReloadMenuType()
                End If
            Else
                MsgBox("Anda membatalkan input tipe menu baru", MessageBoxIcon.Stop, "Gagal Menambahkan")
                TextBox1.Clear()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Input tidak boleh kosong", MessageBoxIcon.Warning, "Peringatan")
        Else
            Cmd = New MySqlCommand("SELECT COUNT(*) FROM menu WHERE menu_name = @menu", Conn)
            Cmd.Parameters.AddWithValue("@menu", TextBox2.Text)
            Dim result As Integer = Cmd.ExecuteScalar()
            Dim confirm As DialogResult = MessageBox.Show("Apakah anda yakin ingin menambahkan data menu baru ini?", "Konfirmasi Data Baru", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                If result > 0 Then
                    MsgBox("Menu '" & TextBox2.Text & "' sudah terdaftar.", MessageBoxIcon.Warning, "Peringatan")
                Else
                    Cmd = New MySqlCommand("INSERT INTO menu (id_menu_type, menu_name, price) VALUES (@id, @menu, @price)", Conn)
                    Cmd.Parameters.AddWithValue("@id", getID)
                    Cmd.Parameters.AddWithValue("@menu", TextBox2.Text)
                    Cmd.Parameters.AddWithValue("@price", TextBox3.Text)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Anda telah berhasil membuat menu baru", MessageBoxIcon.Information, "Input Data Baru Berhasil")
                    Call Clear()
                End If
            Else
                MsgBox("Anda membatalkan input menu baru", MessageBoxIcon.Stop, "Gagal Menambahkan")
                Call Clear()
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Cmd.CommandText = "SELECT id FROM menu_type WHERE menu_type_name = '" & ComboBox1.SelectedItem & "'"
        Dim reader As MySqlDataReader = Cmd.ExecuteReader()
        While reader.Read()
            getID = reader("id")
        End While
        reader.Close()
    End Sub
    Function ReloadMenuType()
        Cmd = New MySqlCommand("SELECT menu_type_name FROM menu_type", Conn)
        Dr = Cmd.ExecuteReader()
        ComboBox1.Items.Clear()
        While Dr.Read()
            ComboBox1.Items.Add(Dr("menu_type_name"))
        End While
        Dr.Close()
    End Function

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "1234567890"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Sub Clear()
        ComboBox1.Text = ""
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            GroupBox1.Enabled = True
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            GroupBox2.Enabled = True
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub KembaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembaliToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class