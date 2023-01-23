Public Class LoadingBar
    Private ProgressBar1 As New ProgressBar
    Private Timer1 As New Timer
    Private Label1 As New Label

    Public Sub New()
        ProgressBar1.Maximum = 100
        Timer1.Interval = 100
        Label1.Text = "0%"
        ' Add the controls to the form
        Me.Controls.Add(ProgressBar1)
        Me.Controls.Add(Timer1)
        Me.Controls.Add(Label1)
        ' Add the event handlers
        AddHandler Timer1.Tick, AddressOf Timer1_Tick
    End Sub
    Public Sub ShowLoading()
        ProgressBar1.Value = 0
        Timer1.Start()
        Me.ShowDialog()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        ProgressBar1.Increment(1)
        Label1.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            Me.Close()
        End If
    End Sub
End Class

End Class
