Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Order
    Dim idMenu As Integer
    Dim price As Integer
    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        With ComboBox1
            Cmd.CommandText = "SELECT menu_type_name FROM menu_type"
            Dr = Cmd.ExecuteReader()
            While Dr.Read()
                .Items.Add(Dr("menu_type_name"))
            End While
            Dr.Close()
        End With

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Enabled = True
        Dim idType As Integer
        Cmd.CommandText = "SELECT id FROM menu_type WHERE menu_type_name = '" & ComboBox1.SelectedItem & "'"
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            idType = Dr("id")
        End While
        Dr.Close()
        Select Case idType
            Case idType
                With ComboBox2
                    .Items.Clear()
                    Cmd.CommandText = "SELECT menu_name FROM menu WHERE id_menu_type =" & idType
                    Dr = Cmd.ExecuteReader()
                    While Dr.Read()
                        .Items.Add(Dr("menu_name"))
                    End While
                    Dr.Close()
                End With
        End Select
        ComboBox2.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Cmd.CommandText = "SELECT price FROM menu WHERE menu_name ='" & ComboBox2.SelectedItem & "'"
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            price = Dr("price")
            TextBox1.Text = price
        End While
        Dr.Close()
        Cmd.CommandText = "SELECT id FROM menu WHERE menu_name ='" & ComboBox2.SelectedItem & "'"
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            idMenu = Dr("id")
        End While
        Dr.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Input tidak boleh kosong", MessageBoxIcon.Warning, "Peringatan")
        Else
            Connection()
            Cmd = New MySqlCommand("SELECT COUNT(*) FROM detail_transaksi WHERE id_menu = @idMenu", Conn)
            Cmd.Parameters.AddWithValue("@idMenu", idMenu)
            Dim result As Integer = Cmd.ExecuteScalar()
            If result > 0 Then
                MsgBox("Menu sudah dikeranjang, tambah qty melalui keranjang.", MessageBoxIcon.Warning, "Peringatan")
            Else
                Cmd = New MySqlCommand("INSERT INTO detail_transaksi (id_menu, price) VALUES (@idMenu, @price)", Conn)
                Cmd.Parameters.AddWithValue("@idMenu", idMenu)
                Cmd.Parameters.AddWithValue("@price", price)
                Cmd.ExecuteNonQuery()
                MsgBox("Menu berhasil ditambahkan ke keranjang.", MessageBoxIcon.Information, "Tambah Keranjang")
                Home.HitungKeranjang()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Keranjang.Show()
    End Sub
End Class