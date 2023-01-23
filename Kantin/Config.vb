Imports MySql.Data.MySqlClient
Module Config
    Public Conn As MySqlConnection
    Public Cmd As MySqlCommand
    Public Ds As DataSet
    Public Da As MySqlDataAdapter
    Public Dr As MySqlDataReader
    Public Db As String
    Public Sub Connection()
        Db = "Server=localhost;user=root;password=;database=kantin"
        Conn = New MySqlConnection(Db)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function SQLTable(ByVal Source As String) As DataTable
        Try
            Dim Adp As New MySqlDataAdapter(Source, Conn)
            Dim Dt As New DataTable
            Adp.Fill(Dt)
            SQLTable = Dt
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message)
            SQLTable = Nothing
        End Try
    End Function
End Module
