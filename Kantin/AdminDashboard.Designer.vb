<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LihatDaftarMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarTipeMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserTerdaftarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TambahDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataMenuToolStripMenuItem, Me.LihatDaftarMenuToolStripMenuItem, Me.TambahDataToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataMenuToolStripMenuItem
        '
        Me.DataMenuToolStripMenuItem.Name = "DataMenuToolStripMenuItem"
        Me.DataMenuToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataMenuToolStripMenuItem.Text = "Data"
        '
        'LihatDaftarMenuToolStripMenuItem
        '
        Me.LihatDaftarMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DaftarMenuToolStripMenuItem, Me.DaftarTipeMenuToolStripMenuItem, Me.UserTerdaftarToolStripMenuItem})
        Me.LihatDaftarMenuToolStripMenuItem.Name = "LihatDaftarMenuToolStripMenuItem"
        Me.LihatDaftarMenuToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.LihatDaftarMenuToolStripMenuItem.Text = "Lihat Daftar"
        '
        'DaftarMenuToolStripMenuItem
        '
        Me.DaftarMenuToolStripMenuItem.Name = "DaftarMenuToolStripMenuItem"
        Me.DaftarMenuToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DaftarMenuToolStripMenuItem.Text = "Daftar Menu"
        '
        'DaftarTipeMenuToolStripMenuItem
        '
        Me.DaftarTipeMenuToolStripMenuItem.Name = "DaftarTipeMenuToolStripMenuItem"
        Me.DaftarTipeMenuToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DaftarTipeMenuToolStripMenuItem.Text = "Daftar Tipe Menu"
        '
        'UserTerdaftarToolStripMenuItem
        '
        Me.UserTerdaftarToolStripMenuItem.Name = "UserTerdaftarToolStripMenuItem"
        Me.UserTerdaftarToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.UserTerdaftarToolStripMenuItem.Text = "User Terdaftar"
        '
        'TambahDataToolStripMenuItem
        '
        Me.TambahDataToolStripMenuItem.Name = "TambahDataToolStripMenuItem"
        Me.TambahDataToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.TambahDataToolStripMenuItem.Text = "Tambah Data"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AdminDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LihatDaftarMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DaftarMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserTerdaftarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TambahDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DaftarTipeMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
End Class
