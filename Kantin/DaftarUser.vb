Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class DaftarUser
    Private Sub DaftarUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminDashboard
        Connection()
        Cmd = New MySqlCommand("SELECT id, username FROM user", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "user")
        DataGridView1.DataSource = Ds.Tables("user")
    End Sub

    Private Sub KembaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembaliToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

    End Sub
End Class