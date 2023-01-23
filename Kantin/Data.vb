Imports MySql.Data.MySqlClient

Public Class Data
    Private Sub Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminDashboard
        Me.WindowState = FormWindowState.Maximized
        Connection()
        Cmd = New MySqlCommand("SELECT COUNT(*) FROM menu", Conn)
        Dim rowMenuCount As Integer = Cmd.ExecuteScalar()
        Label4.Text = rowMenuCount
        Dim Cmd2 As New MySqlCommand("SELECT COUNT(*) FROM user", Conn)
        Dim rowUserCount As Integer = Cmd2.ExecuteScalar()
        Label8.Text = rowUserCount
        Dim Cmd3 As New MySqlCommand("SELECT COUNT(*) FROM menu_type", Conn)
        Dim rowMenuTypeCount As Integer = Cmd3.ExecuteScalar()
        Label6.Text = rowMenuTypeCount
        Dim Cmd4 As New MySqlCommand("SELECT SUM(uang_masuk) FROM header_transaksi", Conn)
        Dim sum As Double = Convert.ToDouble(Cmd4.ExecuteScalar())
        Label9.Text = "Rp." & sum
    End Sub
End Class