Imports MySql.Data.MySqlClient

Public Class AdminDashboard
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Data.Show()
    End Sub

    Private Sub DaftarMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarMenuToolStripMenuItem.Click
        DaftarMenu.Show()
    End Sub

    Private Sub DataMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMenuToolStripMenuItem.Click
        Data.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub UserTerdaftarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserTerdaftarToolStripMenuItem.Click
        DaftarUser.Show()
    End Sub

    Private Sub TambahDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahDataToolStripMenuItem.Click
        TambahData.Show()
    End Sub

    Private Sub DaftarTipeMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarTipeMenuToolStripMenuItem.Click
        DaftarTipeMenu.Show()
    End Sub
    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        Laporan.Show()
    End Sub

    Private Sub AdminDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("Anda akan kembali ke halaman login, apakah anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            Conn.Close()
            Login.Show()
            Login.TextBox1.Clear()
            Login.TextBox2.Clear()
        End If
    End Sub
End Class