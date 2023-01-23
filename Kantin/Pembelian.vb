Public Class Pembelian
    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Keranjang.TextBox1.Text
        Keranjang.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Int(TextBox2.Text) - Int(TextBox1.Text) < 0 Then
            MsgBox("Uang yang anda inputkan tidak cukup.", MessageBoxIcon.Stop, "Uang Tidak Cukup")
        Else
            Invoice.Show()
            Invoice.Label14.Text = TextBox1.Text
            Invoice.Label15.Text = TextBox2.Text
            Invoice.Label16.Text = Int(TextBox2.Text) - Int(TextBox1.Text)
            Me.Hide()
            Keranjang.Close()
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Pembelian_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Keranjang.Enabled = True
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "1234567890"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
End Class