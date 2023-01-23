Imports MySql.Data.MySqlClient
Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        Cmd = New MySqlCommand("SELECT menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type", Conn)
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
        DataGridView1.Columns("menu_type_name").HeaderText = "Tipe Menu"
        DataGridView1.Columns("menu_name").HeaderText = "Nama Menu"
        DataGridView1.Columns("price").HeaderText = "Harga"
        HitungKeranjang()
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Login.Show()
        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Semua Menu" Then
            Cmd = New MySqlCommand("SELECT menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type", Conn)
            Da = New MySqlDataAdapter(Cmd)
            Ds = New DataSet()
            Da.Fill(Ds, "menu")
            DataGridView1.DataSource = Ds.Tables("menu")
        Else
            Cmd = New MySqlCommand("SELECT menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type WHERE menu_type_name = @menutype", Conn)
            Cmd.Parameters.AddWithValue("@menutype", ComboBox1.Text)
            Da = New MySqlDataAdapter(Cmd)
            Ds = New DataSet()
            Da.Fill(Ds, "menu")
            DataGridView1.DataSource = Ds.Tables("menu")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Order.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim search As String = TextBox1.Text
        Cmd = New MySqlCommand("SELECT menu_type.menu_type_name, menu.menu_name, menu.price FROM menu_type INNER JOIN menu ON menu_type.id = menu.id_menu_type WHERE menu.id LIKE '%" & search & "%' OR menu.menu_name LIKE '%" & search & "%' OR menu_type.menu_type_name LIKE '%" & search & "%'  OR menu.price LIKE '%" & search & "%'", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Dim Dt As New DataTable
        Da.Fill(Dt)
        DataGridView1.DataSource = Dt
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Keranjang.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EditUser.Show()
    End Sub
    Public Sub HitungKeranjang()
        Dim getCartRow As Integer = 0
        Cmd = New MySqlCommand("SELECT COUNT(*) FROM detail_transaksi", Conn)
        Dr = Cmd.ExecuteReader()
        While Dr.Read()
            getCartRow = Dr("COUNT(*)")
        End While
        Dr.Close()
        Button3.Text = "Lihat Keranjang " & "(" & getCartRow & ")"
    End Sub
End Class