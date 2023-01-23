Imports MySql.Data.MySqlClient
Public Class DaftarMenu
    Dim getID As Integer
    Private Sub DaftarMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminDashboard
        Connection()
        Cmd = New MySqlCommand("SELECT menu.id, menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu.id_menu_type = menu_type.id", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "menu")
        DataGridView1.DataSource = Ds.Tables("menu")
        With ComboBox1
            .Items.Add("Semua Menu")
            Dim CbMenuType As New MySqlCommand
            CbMenuType.Connection = Conn
            CbMenuType.CommandText = "SELECT menu_type_name FROM menu_type"
            Dr = CbMenuType.ExecuteReader()
            While Dr.Read()
                .Items.Add(Dr("menu_type_name"))
            End While
            Dr.Close()
        End With
        With ComboBox2
            Dim CbMenuType As New MySqlCommand
            CbMenuType.Connection = Conn
            CbMenuType.CommandText = "SELECT menu_type_name FROM menu_type"
            Dr = CbMenuType.ExecuteReader()
            While Dr.Read()
                .Items.Add(Dr("menu_type_name"))
            End While
            Dr.Close()
        End With
        DataGridView1.Columns("menu_type_name").HeaderText = "Tipe Menu"
        DataGridView1.Columns("menu_name").HeaderText = "Nama Menu"
        DataGridView1.Columns("price").HeaderText = "Harga"
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Semua Menu" Then
            Cmd = New MySqlCommand("SELECT menu.id, menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type", Conn)
            Da = New MySqlDataAdapter(Cmd)
            Ds = New DataSet()
            Da.Fill(Ds, "menu")
            DataGridView1.DataSource = Ds.Tables("menu")
        Else
            Cmd = New MySqlCommand("SELECT menu.id, menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type WHERE menu_type_name = @menutype", Conn)
            Cmd.Parameters.AddWithValue("@menutype", ComboBox1.Text)
            Da = New MySqlDataAdapter(Cmd)
            Ds = New DataSet()
            Da.Fill(Ds, "menu")
            DataGridView1.DataSource = Ds.Tables("menu")
        End If
    End Sub
    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox2.Text = selectedRow.Cells("id").Value.ToString()
            TextBox3.Text = selectedRow.Cells("menu_name").Value.ToString()
            ComboBox2.Text = selectedRow.Cells("menu_type_name").Value.ToString()
            TextBox5.Text = selectedRow.Cells("price").Value.ToString()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim confirm As DialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data menu ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                MsgBox("Anda berhasil menghapus menu", MessageBoxIcon.Warning, "Data Dihapus")
                Dim baris As DataGridViewRow = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex)
                Dim id As Integer = CType(baris.Cells("id").Value, Integer)
                Cmd = New MySqlCommand("DELETE FROM menu WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", id)
                Cmd.ExecuteNonQuery()
                ReloadMenu()
                DataGridView1.Rows.Remove(baris)
            Else
                MsgBox("Anda membatalkan hapus data menu", MessageBoxIcon.Stop, "Gagal Menghapus")
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Terdapat input kosong, data tidak akan terupdate", MessageBoxIcon.Warning, "Input Kosong")
        Else
            If MessageBox.Show("Apakah anda yakin ingin mengedit data menu ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Cmd = New MySqlCommand("UPDATE menu SET id_menu_type = @idtype, menu_name = @menu, price = @price WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@idtype", getID)
                Cmd.Parameters.AddWithValue("@menu", TextBox3.Text)
                Cmd.Parameters.AddWithValue("@price", TextBox5.Text)
                Cmd.ExecuteNonQuery()
                ReloadMenu()
                MsgBox("Anda berhasil edit data menu", MessageBoxIcon.Information, "Berhasil Edit")
                GroupBox2.Enabled = False
            Else
                MsgBox("Anda membatalkan edit data menu", MessageBoxIcon.Stop, "Gagal Edit")
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = True
        GroupBox1.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox2.Enabled = False
        GroupBox1.Enabled = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Cmd.CommandText = "SELECT id FROM menu_type WHERE menu_type_name = '" & ComboBox2.SelectedItem & "'"
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            getID = Dr("id")
        End While
        Dr.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim search As String = TextBox1.Text
        Cmd = New MySqlCommand("SELECT menu.id, menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type WHERE menu.id LIKE '%" & search & "%' OR menu.menu_name LIKE '%" & search & "%' OR menu_type.menu_type_name LIKE '%" & search & "%'  OR menu.price LIKE '%" & search & "%'", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Dim Dt As New DataTable
        Da.Fill(Dt)
        DataGridView1.DataSource = Dt
    End Sub
    Function ReloadMenu()
        Cmd = New MySqlCommand("SELECT menu.id, menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "menu")
        DataGridView1.DataSource = Ds.Tables("menu")
    End Function

    Private Sub KembaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembaliToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class