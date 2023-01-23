Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Forms.DataFormats
Imports MySql.Data.MySqlClient
Public Class Keranjang
    Dim deleteButtonColumn As New DataGridViewButtonColumn()
    Dim menuID As String
    Dim combo As DataGridViewComboBoxCell
    Dim sum As Double = 0
    Private Sub Keranjang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AllowUserToOrderColumns = False
        Connection()
        Cmd = New MySqlCommand("SELECT menu.menu_name, detail_transaksi.price FROM menu INNER JOIN detail_transaksi ON detail_transaksi.id_menu = menu.id", Conn)
        Da = New MySqlDataAdapter(Cmd)
        Ds = New DataSet()
        Da.Fill(Ds, "detail_transaksi")
        DataGridView1.DataSource = Ds.Tables("detail_transaksi")
        Dim CbQty As New DataGridViewComboBoxColumn()
        CbQty.CellTemplate = New DataGridViewComboBoxCell()
        CbQty.HeaderText = "Qty."
        CbQty.Name = "qty"
        CbQty.ValueType = GetType(Double)
        CbQty.DataSource = New List(Of Double)(New Double() {1, 2, 3, 4, 5})
        DataGridView1.Columns.Add(CbQty)
        For Each row As DataGridViewRow In DataGridView1.Rows
            combo = row.Cells(CbQty.Name)
            combo.Value = combo.Items(0)
        Next
        Dim subHarga As New DataGridViewTextBoxColumn()
        subHarga.HeaderText = "Sub Harga"
        subHarga.Name = "sub_harga"
        DataGridView1.Columns.Add(subHarga)
        DataGridView1.Columns("menu_name").HeaderText = "Nama Menu"
        DataGridView1.Columns("price").HeaderText = "Harga Satuan"
        deleteButtonColumn.HeaderText = "Delete"
        deleteButtonColumn.Text = "Delete"
        deleteButtonColumn.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(deleteButtonColumn)
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim column1Value As Double = Double.Parse(row.Cells(1).Value.ToString())
            Dim column2Value As Double = Double.Parse(row.Cells(2).Value.ToString())
            Dim resultValue As Double = column1Value * column2Value
            row.Cells(3).Value = resultValue
            sum += Double.Parse(row.Cells(3).Value)
        Next
        TextBox1.Text = sum
        AddHandler DataGridView1.CellValueChanged,
        Sub(senderDataGridView As Object, ev As DataGridViewCellEventArgs)
            If ev.RowIndex >= 0 AndAlso ev.ColumnIndex = CbQty.Index Then
                Dim column1Value As Double = Double.Parse(DataGridView1.Rows(ev.RowIndex).Cells(1).Value.ToString())
                Dim column2Value As Double = Double.Parse(DataGridView1.Rows(ev.RowIndex).Cells(2).Value.ToString())
                Dim resultValue As Double = column1Value * column2Value
                DataGridView1.Rows(ev.RowIndex).Cells(3).Value = resultValue
                sum = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    sum += Double.Parse(row.Cells(3).Value)
                Next
                TextBox1.Text = sum
            End If
        End Sub
        For Each row As DataGridViewRow In DataGridView1.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.ReadOnly = True
            Next
            row.Cells(2).ReadOnly = False
        Next
        AddHandler DataGridView1.ColumnHeaderMouseClick,
        Sub(senderDataGridView As Object, ev As DataGridViewCellMouseEventArgs)
            DataGridView1.Sort(DataGridView1.Columns(ev.ColumnIndex), ListSortDirection.Ascending)
        End Sub
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = deleteButtonColumn.Index Then
            Dim primaryKeyValue As String = DataGridView1(0, e.RowIndex).Value.ToString()
            Cmd = New MySqlCommand("SELECT detail_transaksi.id, detail_transaksi.id_menu, menu.menu_name FROM detail_transaksi INNER JOIN menu ON menu.id = detail_transaksi.id_menu WHERE menu.menu_name = @primaryKey", Conn)
            Cmd.Parameters.AddWithValue("@primaryKey", primaryKeyValue)
            Dr = Cmd.ExecuteReader()
            While Dr.Read()
                menuID = Dr("id_menu")
            End While
            Dr.Close()
            Cmd = New MySqlCommand("DELETE FROM detail_transaksi WHERE id_menu = '" & menuID & "'", Conn)
            Cmd.ExecuteNonQuery()
            DataGridView1.Rows.RemoveAt(e.RowIndex)
            MsgBox("Anda menghapus menu dari keranjang anda", MessageBoxIcon.Warning, "Menu Dihapus")
            sum = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                sum += Double.Parse(row.Cells(3).Value)
            Next
            TextBox1.Text = sum
            Home.HitungKeranjang()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Keranjang anda sudah kosong.", MessageBoxIcon.Warning, "Menu Dihapus")
        Else
            Cmd = New MySqlCommand("TRUNCATE TABLE detail_transaksi", Conn)
            Cmd.ExecuteNonQuery()
            Home.HitungKeranjang()
            MsgBox("Anda menghapus semua item dari keranjang anda", MessageBoxIcon.Warning, "Semua Item Keranjang Terhapus")
            Cmd = New MySqlCommand("SELECT menu.menu_name, detail_transaksi.price FROM menu INNER JOIN detail_transaksi ON detail_transaksi.id_menu = menu.id", Conn)
            Da = New MySqlDataAdapter(Cmd)
            Ds = New DataSet()
            Da.Fill(Ds, "detail_transaksi")
            DataGridView1.DataSource = Ds.Tables("detail_transaksi")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Keranjang anda masih kosong, silahkan belanja dulu", MessageBoxIcon.Warning, "Keranjang Kosong")
        Else
            Pembelian.Show()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Invoice.DataGridView1.Rows.Add()
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    Invoice.DataGridView1(j, i).Value = DataGridView1(j, i).Value
                Next
            Next
            Invoice.DataGridView1.Columns.RemoveAt(4)
        End If

    End Sub
End Class