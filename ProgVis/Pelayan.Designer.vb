<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pelayan
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.nomormeja = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.iddetail = New System.Windows.Forms.TextBox()
        Me.idpesan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.namamakanan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.idmakanan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.quantity = New System.Windows.Forms.TextBox()
        Me.nomordetail = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 29)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Welcome | 23:59:59"
        '
        'Timer1
        '
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(17, 41)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 41)
        Me.Button4.TabIndex = 53
        Me.Button4.Text = "Sign Out"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'nomormeja
        '
        Me.nomormeja.Location = New System.Drawing.Point(479, 25)
        Me.nomormeja.Name = "nomormeja"
        Me.nomormeja.Size = New System.Drawing.Size(121, 22)
        Me.nomormeja.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(485, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Nomor Meja"
        '
        'iddetail
        '
        Me.iddetail.Location = New System.Drawing.Point(479, 71)
        Me.iddetail.Name = "iddetail"
        Me.iddetail.Size = New System.Drawing.Size(121, 22)
        Me.iddetail.TabIndex = 59
        '
        'idpesan
        '
        Me.idpesan.Location = New System.Drawing.Point(609, 25)
        Me.idpesan.Name = "idpesan"
        Me.idpesan.ReadOnly = True
        Me.idpesan.Size = New System.Drawing.Size(121, 22)
        Me.idpesan.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(480, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 16)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "ID Detail Pesanan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(617, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "ID Pesanan"
        '
        'namamakanan
        '
        Me.namamakanan.Location = New System.Drawing.Point(479, 260)
        Me.namamakanan.Name = "namamakanan"
        Me.namamakanan.ReadOnly = True
        Me.namamakanan.Size = New System.Drawing.Size(121, 22)
        Me.namamakanan.TabIndex = 64
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(490, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Nama Makanan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(624, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 16)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "qty"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(493, 292)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 51)
        Me.Button2.TabIndex = 68
        Me.Button2.Text = "ADD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'idmakanan
        '
        Me.idmakanan.Location = New System.Drawing.Point(609, 216)
        Me.idmakanan.Name = "idmakanan"
        Me.idmakanan.ReadOnly = True
        Me.idmakanan.Size = New System.Drawing.Size(121, 22)
        Me.idmakanan.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(620, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "id nama makanan"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(624, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 16)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "qty"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(479, 71)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(121, 22)
        Me.TextBox2.TabIndex = 59
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(490, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 16)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Nama Makanan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(617, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 16)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "ID Pesanan"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(480, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 16)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "ID Detail Pesanan"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(485, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = "Nomor Meja"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(609, 216)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(121, 22)
        Me.TextBox6.TabIndex = 69
        '
        'DataGridView3
        '
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView3.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersWidth = 10
        Me.DataGridView3.RowTemplate.Height = 24
        Me.DataGridView3.Size = New System.Drawing.Size(462, 390)
        Me.DataGridView3.TabIndex = 51
        Me.DataGridView3.UseWaitCursor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(620, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 16)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "id nama makanan"
        '
        'DataGridView4
        '
        Me.DataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridView4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView4.Location = New System.Drawing.Point(750, 6)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowHeadersWidth = 10
        Me.DataGridView4.RowTemplate.Height = 24
        Me.DataGridView4.Size = New System.Drawing.Size(329, 390)
        Me.DataGridView4.TabIndex = 63
        Me.DataGridView4.UseWaitCursor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(627, 57)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 51)
        Me.Button8.TabIndex = 72
        Me.Button8.Text = "Generate"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(574, 292)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 73
        Me.Button9.Text = "MODIFY"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(574, 321)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 74
        Me.Button11.Text = "DELETE"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(652, 292)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 51)
        Me.Button12.TabIndex = 75
        Me.Button12.Text = "COMMIT"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(493, 99)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 51)
        Me.Button13.TabIndex = 76
        Me.Button13.Text = "cari"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(17, 104)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1093, 440)
        Me.TabControl1.TabIndex = 77
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.nomordetail)
        Me.TabPage1.Controls.Add(Me.DataGridView3)
        Me.TabPage1.Controls.Add(Me.Button13)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.idpesan)
        Me.TabPage1.Controls.Add(Me.nomormeja)
        Me.TabPage1.Controls.Add(Me.Button12)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Button11)
        Me.TabPage1.Controls.Add(Me.iddetail)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.DataGridView4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.namamakanan)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TextBox6)
        Me.TabPage1.Controls.Add(Me.quantity)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.idmakanan)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1085, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pesanan"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button14)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.TextBox7)
        Me.TabPage2.Controls.Add(Me.DataGridView5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1085, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Status"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(670, 198)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(113, 48)
        Me.Button14.TabIndex = 3
        Me.Button14.Text = "Cari"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(667, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(242, 32)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "ID Detail Pesanan"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(670, 154)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(113, 38)
        Me.TextBox7.TabIndex = 1
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.ReadOnly = True
        Me.DataGridView5.RowHeadersWidth = 51
        Me.DataGridView5.RowTemplate.Height = 24
        Me.DataGridView5.Size = New System.Drawing.Size(638, 399)
        Me.DataGridView5.TabIndex = 0
        '
        'Timer2
        '
        '
        'quantity
        '
        Me.quantity.Location = New System.Drawing.Point(609, 260)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(121, 22)
        Me.quantity.TabIndex = 66
        '
        'nomordetail
        '
        Me.nomordetail.Location = New System.Drawing.Point(697, 172)
        Me.nomordetail.Name = "nomordetail"
        Me.nomordetail.ReadOnly = True
        Me.nomordetail.Size = New System.Drawing.Size(33, 22)
        Me.nomordetail.TabIndex = 77
        '
        'Pelayan
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1140, 554)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Pelayan"
        Me.Text = "Pelayan"
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button4 As Button
    Friend WithEvents nomormeja As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents iddetail As TextBox
    Friend WithEvents idpesan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents namamakanan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents idmakanan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents Label13 As Label
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Button14 As Button
    Friend WithEvents quantity As TextBox
    Friend WithEvents nomordetail As TextBox
End Class
