Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class Invoice
    Private Sub Invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        Label4.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Dim randomNumber As New Random()
        Dim generatedNumber As Integer = randomNumber.Next(11111111, 99999999)
        Label5.Text = generatedNumber
        Dim getID As Integer
        Cmd = New MySqlCommand("SELECT id FROM user WHERE username ='" & Home.Label2.Text & "'", Conn)
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            getID = Dr("id")
        End While
        Dr.Close()
        Cmd = New MySqlCommand("INSERT INTO header_transaksi (id_user, tanggal, uang_masuk, no_invoice) VALUES (@userid, @tanggal, @uangmasuk, @invoice)", Conn)
        Cmd.Parameters.AddWithValue("@userid", getID)
        Cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd"))
        Cmd.Parameters.AddWithValue("@uangmasuk", Pembelian.TextBox1.Text)
        Cmd.Parameters.AddWithValue("@invoice", Label5.Text)
        Cmd.ExecuteNonQuery()
        Cmd = New MySqlCommand("TRUNCATE TABLE detail_transaksi", Conn)
        Cmd.ExecuteNonQuery()
        Home.HitungKeranjang()
    End Sub

    Private Sub Invoice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Pembelian.Close()
    End Sub
End Class