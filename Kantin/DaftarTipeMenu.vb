Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class DaftarTipeMenu
    Private Sub DaftarTipeMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminDashboard
        Connection()
        Cmd = New MySqlCommand("SELECT * FROM menu_type", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "menu_type")
        DataGridView1.DataSource = Ds.Tables("menu_type")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim search As String = TextBox1.Text
        Cmd = New MySqlCommand("SELECT * FROM menu_type WHERE id LIKE '%" & search & "%' OR menu_type_name LIKE '%" & search & "%'", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Dim Dt As New DataTable
        Da.Fill(Dt)
        DataGridView1.DataSource = Dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = True
        GroupBox1.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox2.Enabled = False
        GroupBox1.Enabled = True
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox2.Text = selectedRow.Cells("id").Value.ToString()
            TextBox3.Text = selectedRow.Cells("menu_type_name").Value.ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim confirm As DialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data tipe menu ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                MsgBox("Anda berhasil menghapus tipe menu", MessageBoxIcon.Warning, "Data Dihapus")
                Dim baris As DataGridViewRow = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex)
                Dim id As Integer = CType(baris.Cells("id").Value, Integer)
                Cmd = New MySqlCommand("DELETE FROM menu_type WHERE id = @id", Conn)
                Cmd.Parameters.AddWithValue("@id", id)
                Cmd.ExecuteNonQuery()
                DataGridView1.Rows.Remove(baris)
                ReloadMenu()
            Else
                MsgBox("Anda membatalkan hapus data tipe menu", MessageBoxIcon.Stop, "Gagal Menghapus")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Then
            MsgBox("Terdapat input kosong, data tidak akan terupdate", MessageBoxIcon.Warning, "Input Kosong")
        Else
            If MessageBox.Show("Apakah anda yakin ingin mengedit data tipe menu ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Cmd = New MySqlCommand("UPDATE menu_type SET menu_type_name = @menu WHERE id = @id ", Conn)
                Cmd.Parameters.AddWithValue("@id", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@menu", TextBox3.Text)
                Cmd.ExecuteNonQuery()
                ReloadMenu()
                MsgBox("Anda berhasil edit data menu", MessageBoxIcon.Information, "Berhasil Edit")
                GroupBox2.Enabled = False
            Else
                MsgBox("Anda membatalkan edit data menu", MessageBoxIcon.Stop, "Gagal Edit")
            End If
        End If
    End Sub
    Function ReloadMenu()
        Cmd = New MySqlCommand("SELECT * FROM menu_type", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "menu")
        DataGridView1.DataSource = Ds.Tables("menu")
    End Function

    Private Sub KembaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembaliToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class