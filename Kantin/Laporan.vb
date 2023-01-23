Imports MySql.Data.MySqlClient

Public Class Laporan
    Private Sub KembaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembaliToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        Cmd = New MySqlCommand("SELECT user.username, header_transaksi.tanggal, header_transaksi.uang_masuk, header_transaksi.no_invoice FROM user INNER JOIN header_transaksi ON header_transaksi.id_user = user.id", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "header_transaksi")
        DataGridView1.DataSource = Ds.Tables("header_transaksi")
    End Sub
End Class