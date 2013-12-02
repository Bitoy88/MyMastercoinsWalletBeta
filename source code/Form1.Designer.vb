<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.GVTrans = New System.Windows.Forms.DataGridView()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTxID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSendToBTCA = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSendCoins = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblCoinstoSend = New System.Windows.Forms.Label()
        Me.txtCoins = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabTransactions = New System.Windows.Forms.TabPage()
        Me.tabSendCoins = New System.Windows.Forms.TabPage()
        Me.tabSellCoins = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMinTransFee = New System.Windows.Forms.TextBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GVSell = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTimeLimit = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBTCSellPrice = New System.Windows.Forms.TextBox()
        Me.lblCoinstoSell = New System.Windows.Forms.Label()
        Me.cmdSellCoins = New System.Windows.Forms.Button()
        Me.txtAmount2 = New System.Windows.Forms.TextBox()
        Me.tabBuyCoins = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmounttoPurchase = New System.Windows.Forms.TextBox()
        Me.lblPurchaseOffer = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GVOfferstoSell = New System.Windows.Forms.DataGridView()
        Me.colSDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSCoinstoSell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSBTCDesired = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSTimeLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSSeller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblCurrentBlockTime = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAmounttoPay = New System.Windows.Forms.TextBox()
        Me.lblPay = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GVPurchasing = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTCPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtConnectString = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBTCWalletPP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBitcoindexe = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRPCPassword = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRPCUser = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRPCServer = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtRPCPort = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCoinType = New System.Windows.Forms.ComboBox()
        Me.cboAddress = New System.Windows.Forms.ComboBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtSha = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GVTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabTransactions.SuspendLayout()
        Me.tabSendCoins.SuspendLayout()
        Me.tabSellCoins.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuyCoins.SuspendLayout()
        CType(Me.GVOfferstoSell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GVPurchasing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GVTrans
        '
        Me.GVTrans.AllowUserToAddRows = False
        Me.GVTrans.AllowUserToDeleteRows = False
        Me.GVTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GVTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GVTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colIn, Me.colDescription, Me.colOut, Me.colTotalPrice, Me.colTxID})
        Me.GVTrans.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GVTrans.Location = New System.Drawing.Point(3, 3)
        Me.GVTrans.MultiSelect = False
        Me.GVTrans.Name = "GVTrans"
        Me.GVTrans.ReadOnly = True
        Me.GVTrans.Size = New System.Drawing.Size(614, 315)
        Me.GVTrans.TabIndex = 0
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "dTrans"
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 75
        '
        'colIn
        '
        Me.colIn.DataPropertyName = "AmountIn"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colIn.DefaultCellStyle = DataGridViewCellStyle2
        Me.colIn.HeaderText = "In"
        Me.colIn.Name = "colIn"
        Me.colIn.ReadOnly = True
        Me.colIn.Width = 75
        '
        'colDescription
        '
        Me.colDescription.DataPropertyName = "Description"
        Me.colDescription.HeaderText = "From/To"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 175
        '
        'colOut
        '
        Me.colOut.DataPropertyName = "AmountOut"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colOut.DefaultCellStyle = DataGridViewCellStyle3
        Me.colOut.HeaderText = "Out"
        Me.colOut.Name = "colOut"
        Me.colOut.ReadOnly = True
        Me.colOut.Width = 75
        '
        'colTotalPrice
        '
        Me.colTotalPrice.DataPropertyName = "TotalPrice"
        Me.colTotalPrice.HeaderText = "Total Price"
        Me.colTotalPrice.Name = "colTotalPrice"
        Me.colTotalPrice.ReadOnly = True
        Me.colTotalPrice.Width = 75
        '
        'colTxID
        '
        Me.colTxID.DataPropertyName = "TxID"
        Me.colTxID.HeaderText = "TXID"
        Me.colTxID.Name = "colTxID"
        Me.colTxID.ReadOnly = True
        Me.colTxID.Width = 120
        '
        'txtSendToBTCA
        '
        Me.txtSendToBTCA.Location = New System.Drawing.Point(149, 23)
        Me.txtSendToBTCA.Name = "txtSendToBTCA"
        Me.txtSendToBTCA.Size = New System.Drawing.Size(249, 20)
        Me.txtSendToBTCA.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Send to:"
        '
        'cmdSendCoins
        '
        Me.cmdSendCoins.Location = New System.Drawing.Point(149, 86)
        Me.cmdSendCoins.Name = "cmdSendCoins"
        Me.cmdSendCoins.Size = New System.Drawing.Size(104, 27)
        Me.cmdSendCoins.TabIndex = 10
        Me.cmdSendCoins.Text = "Send Coins"
        Me.cmdSendCoins.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(149, 49)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmount.Size = New System.Drawing.Size(84, 20)
        Me.txtAmount.TabIndex = 12
        Me.txtAmount.Text = "0"
        '
        'lblCoinstoSend
        '
        Me.lblCoinstoSend.AutoSize = True
        Me.lblCoinstoSend.Location = New System.Drawing.Point(38, 49)
        Me.lblCoinstoSend.Name = "lblCoinstoSend"
        Me.lblCoinstoSend.Size = New System.Drawing.Size(76, 13)
        Me.lblCoinstoSend.TabIndex = 11
        Me.lblCoinstoSend.Text = "Coins to Send:"
        '
        'txtCoins
        '
        Me.txtCoins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoins.Location = New System.Drawing.Point(504, 20)
        Me.txtCoins.Name = "txtCoins"
        Me.txtCoins.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCoins.Size = New System.Drawing.Size(156, 26)
        Me.txtCoins.TabIndex = 17
        Me.txtCoins.Text = "0.00000000"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabTransactions)
        Me.TabControl1.Controls.Add(Me.tabSendCoins)
        Me.TabControl1.Controls.Add(Me.tabSellCoins)
        Me.TabControl1.Controls.Add(Me.tabBuyCoins)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(36, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(628, 347)
        Me.TabControl1.TabIndex = 0
        '
        'tabTransactions
        '
        Me.tabTransactions.Controls.Add(Me.GVTrans)
        Me.tabTransactions.Location = New System.Drawing.Point(4, 22)
        Me.tabTransactions.Name = "tabTransactions"
        Me.tabTransactions.Size = New System.Drawing.Size(620, 321)
        Me.tabTransactions.TabIndex = 2
        Me.tabTransactions.Text = "Transactions"
        Me.tabTransactions.UseVisualStyleBackColor = True
        '
        'tabSendCoins
        '
        Me.tabSendCoins.Controls.Add(Me.cmdSendCoins)
        Me.tabSendCoins.Controls.Add(Me.Label4)
        Me.tabSendCoins.Controls.Add(Me.lblCoinstoSend)
        Me.tabSendCoins.Controls.Add(Me.txtAmount)
        Me.tabSendCoins.Controls.Add(Me.txtSendToBTCA)
        Me.tabSendCoins.Location = New System.Drawing.Point(4, 22)
        Me.tabSendCoins.Name = "tabSendCoins"
        Me.tabSendCoins.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSendCoins.Size = New System.Drawing.Size(620, 321)
        Me.tabSendCoins.TabIndex = 1
        Me.tabSendCoins.Text = "Send Coins"
        Me.tabSendCoins.UseVisualStyleBackColor = True
        '
        'tabSellCoins
        '
        Me.tabSellCoins.Controls.Add(Me.Label12)
        Me.tabSellCoins.Controls.Add(Me.txtMinTransFee)
        Me.tabSellCoins.Controls.Add(Me.Chart1)
        Me.tabSellCoins.Controls.Add(Me.Label6)
        Me.tabSellCoins.Controls.Add(Me.GVSell)
        Me.tabSellCoins.Controls.Add(Me.Label5)
        Me.tabSellCoins.Controls.Add(Me.txtTimeLimit)
        Me.tabSellCoins.Controls.Add(Me.Label13)
        Me.tabSellCoins.Controls.Add(Me.txtBTCSellPrice)
        Me.tabSellCoins.Controls.Add(Me.lblCoinstoSell)
        Me.tabSellCoins.Controls.Add(Me.cmdSellCoins)
        Me.tabSellCoins.Controls.Add(Me.txtAmount2)
        Me.tabSellCoins.Location = New System.Drawing.Point(4, 22)
        Me.tabSellCoins.Name = "tabSellCoins"
        Me.tabSellCoins.Size = New System.Drawing.Size(620, 321)
        Me.tabSellCoins.TabIndex = 3
        Me.tabSellCoins.Text = "Sell Coins for BTC"
        Me.tabSellCoins.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Trans. Fee"
        '
        'txtMinTransFee
        '
        Me.txtMinTransFee.Location = New System.Drawing.Point(134, 84)
        Me.txtMinTransFee.Name = "txtMinTransFee"
        Me.txtMinTransFee.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMinTransFee.Size = New System.Drawing.Size(84, 20)
        Me.txtMinTransFee.TabIndex = 40
        Me.txtMinTransFee.Text = "0.00001"
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(26, 149)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Price in BTC"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(577, 169)
        Me.Chart1.TabIndex = 38
        Me.Chart1.Text = "Chart1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Your Current Sell Offer"
        '
        'GVSell
        '
        Me.GVSell.AllowUserToAddRows = False
        Me.GVSell.AllowUserToDeleteRows = False
        Me.GVSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVSell.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column2})
        Me.GVSell.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.GVSell.Location = New System.Drawing.Point(268, 30)
        Me.GVSell.Name = "GVSell"
        Me.GVSell.ReadOnly = True
        Me.GVSell.RowHeadersVisible = False
        Me.GVSell.Size = New System.Drawing.Size(335, 104)
        Me.GVSell.TabIndex = 36
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "dTrans"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 75
        '
        'Column6
        '
        Me.Column6.HeaderText = "Coins to Sell"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 75
        '
        'Column7
        '
        Me.Column7.HeaderText = "Unit Price"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 65
        '
        'Column8
        '
        Me.Column8.HeaderText = "BTC Desired"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 75
        '
        'Column9
        '
        Me.Column9.HeaderText = "Time Limit"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 40
        '
        'Column2
        '
        Me.Column2.HeaderText = "Trans. Fee"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Time Limit:"
        '
        'txtTimeLimit
        '
        Me.txtTimeLimit.Location = New System.Drawing.Point(134, 60)
        Me.txtTimeLimit.Name = "txtTimeLimit"
        Me.txtTimeLimit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTimeLimit.Size = New System.Drawing.Size(84, 20)
        Me.txtTimeLimit.TabIndex = 35
        Me.txtTimeLimit.Text = "10"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "BTC Desired:"
        '
        'txtBTCSellPrice
        '
        Me.txtBTCSellPrice.Location = New System.Drawing.Point(134, 37)
        Me.txtBTCSellPrice.Name = "txtBTCSellPrice"
        Me.txtBTCSellPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBTCSellPrice.Size = New System.Drawing.Size(84, 20)
        Me.txtBTCSellPrice.TabIndex = 33
        Me.txtBTCSellPrice.Text = "0"
        '
        'lblCoinstoSell
        '
        Me.lblCoinstoSell.AutoSize = True
        Me.lblCoinstoSell.Location = New System.Drawing.Point(23, 14)
        Me.lblCoinstoSell.Name = "lblCoinstoSell"
        Me.lblCoinstoSell.Size = New System.Drawing.Size(68, 13)
        Me.lblCoinstoSell.TabIndex = 28
        Me.lblCoinstoSell.Text = "Coins to Sell:"
        '
        'cmdSellCoins
        '
        Me.cmdSellCoins.Location = New System.Drawing.Point(134, 110)
        Me.cmdSellCoins.Name = "cmdSellCoins"
        Me.cmdSellCoins.Size = New System.Drawing.Size(114, 24)
        Me.cmdSellCoins.TabIndex = 27
        Me.cmdSellCoins.Text = "Send Offer to Sell"
        Me.cmdSellCoins.UseVisualStyleBackColor = True
        '
        'txtAmount2
        '
        Me.txtAmount2.Location = New System.Drawing.Point(134, 14)
        Me.txtAmount2.Name = "txtAmount2"
        Me.txtAmount2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmount2.Size = New System.Drawing.Size(84, 20)
        Me.txtAmount2.TabIndex = 29
        Me.txtAmount2.Text = "0"
        '
        'tabBuyCoins
        '
        Me.tabBuyCoins.Controls.Add(Me.Label9)
        Me.tabBuyCoins.Controls.Add(Me.Label7)
        Me.tabBuyCoins.Controls.Add(Me.txtAmounttoPurchase)
        Me.tabBuyCoins.Controls.Add(Me.lblPurchaseOffer)
        Me.tabBuyCoins.Controls.Add(Me.Button2)
        Me.tabBuyCoins.Controls.Add(Me.GVOfferstoSell)
        Me.tabBuyCoins.Location = New System.Drawing.Point(4, 22)
        Me.tabBuyCoins.Name = "tabBuyCoins"
        Me.tabBuyCoins.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBuyCoins.Size = New System.Drawing.Size(620, 321)
        Me.tabBuyCoins.TabIndex = 5
        Me.tabBuyCoins.Text = "Buy Coins"
        Me.tabBuyCoins.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(468, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 122)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "If the Purchase offer is confirmed by the mastercoin protocol , it will be listed" & _
            " in the Payment tab.   You will need to go to the Payments tab and pay the Selle" & _
            "r to finalize the transaction."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Purchase:"
        '
        'txtAmounttoPurchase
        '
        Me.txtAmounttoPurchase.Location = New System.Drawing.Point(67, 261)
        Me.txtAmounttoPurchase.Name = "txtAmounttoPurchase"
        Me.txtAmounttoPurchase.Size = New System.Drawing.Size(64, 20)
        Me.txtAmounttoPurchase.TabIndex = 43
        '
        'lblPurchaseOffer
        '
        Me.lblPurchaseOffer.Location = New System.Drawing.Point(137, 261)
        Me.lblPurchaseOffer.Name = "lblPurchaseOffer"
        Me.lblPurchaseOffer.Size = New System.Drawing.Size(475, 49)
        Me.lblPurchaseOffer.TabIndex = 39
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(15, 287)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 23)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Send Purchase Offer"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GVOfferstoSell
        '
        Me.GVOfferstoSell.AllowUserToAddRows = False
        Me.GVOfferstoSell.AllowUserToDeleteRows = False
        Me.GVOfferstoSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVOfferstoSell.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSDate, Me.colSCoinstoSell, Me.colSUnitPrice, Me.colSBTCDesired, Me.colSTimeLimit, Me.colSSeller})
        Me.GVOfferstoSell.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.GVOfferstoSell.Location = New System.Drawing.Point(6, 6)
        Me.GVOfferstoSell.Name = "GVOfferstoSell"
        Me.GVOfferstoSell.ReadOnly = True
        Me.GVOfferstoSell.RowHeadersVisible = False
        Me.GVOfferstoSell.Size = New System.Drawing.Size(443, 249)
        Me.GVOfferstoSell.TabIndex = 37
        '
        'colSDate
        '
        Me.colSDate.DataPropertyName = "dTrans"
        Me.colSDate.HeaderText = "Date"
        Me.colSDate.Name = "colSDate"
        Me.colSDate.ReadOnly = True
        Me.colSDate.Width = 75
        '
        'colSCoinstoSell
        '
        Me.colSCoinstoSell.HeaderText = "Coins to Sell"
        Me.colSCoinstoSell.Name = "colSCoinstoSell"
        Me.colSCoinstoSell.ReadOnly = True
        Me.colSCoinstoSell.Width = 75
        '
        'colSUnitPrice
        '
        Me.colSUnitPrice.HeaderText = "Unit Price"
        Me.colSUnitPrice.Name = "colSUnitPrice"
        Me.colSUnitPrice.ReadOnly = True
        Me.colSUnitPrice.Width = 75
        '
        'colSBTCDesired
        '
        Me.colSBTCDesired.HeaderText = "BTC Desired"
        Me.colSBTCDesired.Name = "colSBTCDesired"
        Me.colSBTCDesired.ReadOnly = True
        Me.colSBTCDesired.Width = 75
        '
        'colSTimeLimit
        '
        Me.colSTimeLimit.HeaderText = "Time Limit"
        Me.colSTimeLimit.Name = "colSTimeLimit"
        Me.colSTimeLimit.ReadOnly = True
        Me.colSTimeLimit.Width = 40
        '
        'colSSeller
        '
        Me.colSSeller.HeaderText = "Seller"
        Me.colSSeller.Name = "colSSeller"
        Me.colSSeller.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblCurrentBlockTime)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtAmounttoPay)
        Me.TabPage2.Controls.Add(Me.lblPay)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.GVPurchasing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(620, 321)
        Me.TabPage2.TabIndex = 6
        Me.TabPage2.Text = "Payment"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblCurrentBlockTime
        '
        Me.lblCurrentBlockTime.Location = New System.Drawing.Point(139, 285)
        Me.lblCurrentBlockTime.Name = "lblCurrentBlockTime"
        Me.lblCurrentBlockTime.Size = New System.Drawing.Size(162, 19)
        Me.lblCurrentBlockTime.TabIndex = 50
        Me.lblCurrentBlockTime.Text = "Current Block Time:"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(312, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(302, 33)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Please pay within the block time limit.  If payment is not sent before the time l" & _
            "imit, the transaction is cancelled."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Pay:"
        '
        'txtAmounttoPay
        '
        Me.txtAmounttoPay.Location = New System.Drawing.Point(69, 257)
        Me.txtAmounttoPay.Name = "txtAmounttoPay"
        Me.txtAmounttoPay.Size = New System.Drawing.Size(64, 20)
        Me.txtAmounttoPay.TabIndex = 2
        '
        'lblPay
        '
        Me.lblPay.Location = New System.Drawing.Point(139, 257)
        Me.lblPay.Name = "lblPay"
        Me.lblPay.Size = New System.Drawing.Size(472, 23)
        Me.lblPay.TabIndex = 46
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(17, 283)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Send Payment"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GVPurchasing
        '
        Me.GVPurchasing.AllowUserToAddRows = False
        Me.GVPurchasing.AllowUserToDeleteRows = False
        Me.GVPurchasing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVPurchasing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.Column12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.BTCPaid, Me.Column1})
        Me.GVPurchasing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.GVPurchasing.Location = New System.Drawing.Point(9, 6)
        Me.GVPurchasing.Name = "GVPurchasing"
        Me.GVPurchasing.ReadOnly = True
        Me.GVPurchasing.RowHeadersVisible = False
        Me.GVPurchasing.Size = New System.Drawing.Size(608, 245)
        Me.GVPurchasing.TabIndex = 38
        Me.GVPurchasing.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "dTrans"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 75
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount to Purchase"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 75
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Unit Price"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Total BTC"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 75
        '
        'Column12
        '
        Me.Column12.HeaderText = "Transfer Fee"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 50
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Time Limit"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 50
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Seller"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'BTCPaid
        '
        Me.BTCPaid.HeaderText = "BTC Paid"
        Me.BTCPaid.Name = "BTCPaid"
        Me.BTCPaid.ReadOnly = True
        Me.BTCPaid.Width = 75
        '
        'Column1
        '
        Me.Column1.HeaderText = "Unpaid"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtConnectString)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtBTCWalletPP)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtBitcoindexe)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txtRPCPassword)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtRPCUser)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtRPCServer)
        Me.TabPage1.Controls.Add(Me.lblPort)
        Me.TabPage1.Controls.Add(Me.txtRPCPort)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(620, 321)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 145)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "DB Connect String:"
        '
        'txtConnectString
        '
        Me.txtConnectString.Location = New System.Drawing.Point(119, 142)
        Me.txtConnectString.Name = "txtConnectString"
        Me.txtConnectString.Size = New System.Drawing.Size(478, 20)
        Me.txtConnectString.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(158, 239)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(439, 55)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "The passphrase is not saved.  It is only sent directly to bitcoind.exe when you w" & _
            "ant to send a transaction.  "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Bitcoin Wallet Passphrase:"
        '
        'txtBTCWalletPP
        '
        Me.txtBTCWalletPP.Location = New System.Drawing.Point(161, 216)
        Me.txtBTCWalletPP.Name = "txtBTCWalletPP"
        Me.txtBTCWalletPP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtBTCWalletPP.Size = New System.Drawing.Size(436, 20)
        Me.txtBTCWalletPP.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Bitcond.exe:"
        '
        'txtBitcoindexe
        '
        Me.txtBitcoindexe.Location = New System.Drawing.Point(119, 29)
        Me.txtBitcoindexe.Name = "txtBitcoindexe"
        Me.txtBitcoindexe.Size = New System.Drawing.Size(478, 20)
        Me.txtBitcoindexe.TabIndex = 16
        Me.txtBitcoindexe.Text = "C:\Program Files (x86)\Bitcoin\daemon\bitcoind.exe"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "RPC Password:"
        '
        'txtRPCPassword
        '
        Me.txtRPCPassword.Location = New System.Drawing.Point(119, 119)
        Me.txtRPCPassword.Name = "txtRPCPassword"
        Me.txtRPCPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRPCPassword.Size = New System.Drawing.Size(226, 20)
        Me.txtRPCPassword.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "RPC User:"
        '
        'txtRPCUser
        '
        Me.txtRPCUser.Location = New System.Drawing.Point(119, 97)
        Me.txtRPCUser.Name = "txtRPCUser"
        Me.txtRPCUser.Size = New System.Drawing.Size(226, 20)
        Me.txtRPCUser.TabIndex = 13
        Me.txtRPCUser.Text = "bitcoinrpc"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(119, 166)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "RPC Server:"
        '
        'txtRPCServer
        '
        Me.txtRPCServer.Location = New System.Drawing.Point(119, 52)
        Me.txtRPCServer.Name = "txtRPCServer"
        Me.txtRPCServer.Size = New System.Drawing.Size(226, 20)
        Me.txtRPCServer.TabIndex = 8
        Me.txtRPCServer.Text = "127.0.0.1"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(18, 78)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(51, 13)
        Me.lblPort.TabIndex = 9
        Me.lblPort.Text = "RPC Port"
        '
        'txtRPCPort
        '
        Me.txtRPCPort.Location = New System.Drawing.Point(119, 75)
        Me.txtRPCPort.Name = "txtRPCPort"
        Me.txtRPCPort.Size = New System.Drawing.Size(52, 20)
        Me.txtRPCPort.TabIndex = 10
        Me.txtRPCPort.Text = "4332"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(32, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(375, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Currency:"
        '
        'cboCoinType
        '
        Me.cboCoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoinType.FormattingEnabled = True
        Me.cboCoinType.Items.AddRange(New Object() {"MSC", "TMSC"})
        Me.cboCoinType.Location = New System.Drawing.Point(433, 20)
        Me.cboCoinType.Name = "cboCoinType"
        Me.cboCoinType.Size = New System.Drawing.Size(69, 21)
        Me.cboCoinType.TabIndex = 2
        '
        'cboAddress
        '
        Me.cboAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAddress.FormattingEnabled = True
        Me.cboAddress.Location = New System.Drawing.Point(81, 17)
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.Size = New System.Drawing.Size(260, 21)
        Me.cboAddress.TabIndex = 1
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(386, 498)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(131, 23)
        Me.Button7.TabIndex = 28
        Me.Button7.Text = "Sha 256"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'txtSha
        '
        Me.txtSha.Location = New System.Drawing.Point(35, 498)
        Me.txtSha.Name = "txtSha"
        Me.txtSha.Size = New System.Drawing.Size(322, 20)
        Me.txtSha.TabIndex = 27
        Me.txtSha.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(539, 498)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(131, 23)
        Me.Button8.TabIndex = 29
        Me.Button8.Text = "Encode to BTC Address"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(43, 405)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(317, 22)
        Me.txtMessage.TabIndex = 31
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(364, 405)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(300, 22)
        Me.ProgressBar1.TabIndex = 32
        Me.ProgressBar1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 441)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCoins)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboCoinType)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.cboAddress)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.txtSha)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "MyMastercoins Wallet"
        CType(Me.GVTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabTransactions.ResumeLayout(False)
        Me.tabSendCoins.ResumeLayout(False)
        Me.tabSendCoins.PerformLayout()
        Me.tabSellCoins.ResumeLayout(False)
        Me.tabSellCoins.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuyCoins.ResumeLayout(False)
        Me.tabBuyCoins.PerformLayout()
        CType(Me.GVOfferstoSell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GVPurchasing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSendToBTCA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdSendCoins As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblCoinstoSend As System.Windows.Forms.Label
    Friend WithEvents txtCoins As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabSendCoins As System.Windows.Forms.TabPage
    Friend WithEvents tabTransactions As System.Windows.Forms.TabPage
    Friend WithEvents tabSellCoins As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBTCSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblCoinstoSell As System.Windows.Forms.Label
    Friend WithEvents cmdSellCoins As System.Windows.Forms.Button
    Friend WithEvents txtAmount2 As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents txtSha As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRPCServer As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtRPCPort As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRPCPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtRPCUser As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoinType As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddress As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTimeLimit As System.Windows.Forms.TextBox
    Friend WithEvents tabBuyCoins As System.Windows.Forms.TabPage
    Friend WithEvents GVTrans As System.Windows.Forms.DataGridView
    Friend WithEvents GVSell As System.Windows.Forms.DataGridView
    Friend WithEvents GVOfferstoSell As System.Windows.Forms.DataGridView
    Friend WithEvents GVPurchasing As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBitcoindexe As System.Windows.Forms.TextBox
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTxID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAmounttoPurchase As System.Windows.Forms.TextBox
    Friend WithEvents lblPurchaseOffer As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAmounttoPay As System.Windows.Forms.TextBox
    Friend WithEvents lblPay As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents colSDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSCoinstoSell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSBTCDesired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSTimeLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSSeller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMessage As System.Windows.Forms.Label
    Friend WithEvents lblCurrentBlockTime As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMinTransFee As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBTCWalletPP As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtConnectString As System.Windows.Forms.TextBox

End Class
