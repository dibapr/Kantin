Public Class Loading
    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(3)
        Label2.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            Me.Hide()
            Login.Show()
        End If
    End Sub
End Class