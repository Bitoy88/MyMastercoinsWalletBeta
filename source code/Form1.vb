'Bitoy (c) 2013 

Imports System
Imports System.IO
Imports System.Net
Imports System.Numerics
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography

Class Form1
    Const SendType As Integer = 0
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Text += " 1.0"
        txtRPCServer.Text = My.Settings.RPCServer
        txtRPCPort.Text = My.Settings.RPCPort
        txtRPCUser.Text = My.Settings.RPCUser
        txtRPCPassword.Text = My.Settings.RPCPassword
        txtBitcoindexe.Text = My.Settings.BitcoindExe
        If txtBitcoindexe.Text = "" Then
            txtBitcoindexe.Text = "C:\Program Files (x86)\Bitcoin\daemon\bitcoind.exe"
        End If
        txtConnectString.Text = My.Settings.ConnectString
        GetWalletMSCAddress()
        cboAddress.Text = cboAddress.Items(0)
        cboCoinType.Text = "TMSC"
        clearprogbar()
    End Sub


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendCoins.Click
        If Val(txtAmount.Text) > 0 Then

            Dim result = MessageBox.Show("Are you sure you want to send " + txtAmount.Text + " " + cboCoinType.Text + " to " + txtSendToBTCA.Text, "Send Coins", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim CoinType As Integer = GetCurrencyInt(cboCoinType.Text)
                Dim SatAmount As BigInteger = Val(txtAmount.Text) * 100000000

                Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
                bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
                bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
                bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
                bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text

                ResetProgbar(5)

                Try
                    updateprogbar()
                    Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, txtSendToBTCA.Text, 0, 0)
                    Dim validater As JObject = JsonConvert.DeserializeObject(json)
                    If validater.Item("isvalid") = "True" Then 'address is valid
                        txtMessage.Text = "Recipient address is valid."
                        'push out to masterchest lib to encode the tx
                        updateprogbar()
                        Dim rawtx As String = (New mlib).encodetx(bitcoin_con, cboAddress.Text, txtSendToBTCA.Text, CoinType, SatAmount)
                        'is rawtx empty
                        If rawtx <> "" Then
                            updateprogbar()
                            Dim resp As String = (New mlib).rpccall(bitcoin_con, "walletlock", 0, 0, 0, 0)
                            resp = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                            'try and sign transaction
                            Try
                                updateprogbar()
                                Dim json2 As String = (New mlib).rpccall(bitcoin_con, "signrawtransaction", 1, rawtx, 0, 0)
                                Dim signedtxn As JObject = JsonConvert.DeserializeObject(json2)
                                If signedtxn.Item("complete").ToString() = "True" Then
                                    Dim resp2 As String = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                                    updateprogbar()
                                    Dim broadcasttx As String = (New mlib).rpccall(bitcoin_con, "sendrawtransaction", 1, signedtxn.Item("hex").ToString, 0, 0)
                                    If broadcasttx <> "" Then
                                        MsgBox("Transaction sent, ID: " & broadcasttx)
                                    Else
                                        txtMessage.Text = "Error sending transaction."
                                    End If
                                Else
                                    txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct."
                                End If
                            Catch ex As Exception
                                txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct.  " & ex.Message
                            End Try
                        Else
                            txtMessage.Text = "Raw transaction is empty - stopping."
                        End If
                    Else
                        txtMessage.Text = "Build transaction failed.  Recipient address is not valid."
                    End If
                Catch ex As Exception
                    MsgBox("Exeption thrown : " & ex.Message)
                End Try
                clearprogbar()
            End If
        Else
            txtMessage.Text = "Please enter an amount to send."
        End If
    End Sub

    
    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSellCoins.Click
        Dim result = MessageBox.Show("Are you sure you want to sell " + txtAmount2.Text + " " + cboCoinType.Text + " for " + txtBTCSellPrice.Text + " btc", "Sell Coins", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim CoinType As Integer = GetCurrencyInt(cboCoinType.Text)
            Dim SatTransactionFee As BigInteger = Val(txtMinTransFee.Text) * 100000000
            Dim SatAmount As BigInteger = Val(txtAmount2.Text) * 100000000
            Dim SatBTCAmount As BigInteger = Val(txtBTCSellPrice.Text) * 100000000

            Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
            bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
            bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
            bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
            bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text

            ResetProgbar(5)
            updateprogbar()
            Dim rawtx As String = (New mlib).encodeselltx(bitcoin_con, cboAddress.Text, CoinType, _
                    SatAmount, SatBTCAmount, SatTransactionFee, Val(txtTimeLimit.Text))
            'is rawtx empty
            If rawtx <> "" Then
                updateprogbar()
                Dim resp As String = (New mlib).rpccall(bitcoin_con, "walletlock", 0, 0, 0, 0)
                resp = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                'try and sign transaction
                Try
                    updateprogbar()
                    Dim json2 As String = (New mlib).rpccall(bitcoin_con, "signrawtransaction", 1, rawtx, 0, 0)
                    Dim signedtxn As JObject = JsonConvert.DeserializeObject(json2)
                    If signedtxn.Item("complete").ToString() = "True" Then
                        txtMessage.Text = "Signing appears successful."
                        updateprogbar()
                        Dim resp2 As String = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                        updateprogbar()
                        Dim broadcasttx As String = (New mlib).rpccall(bitcoin_con, "sendrawtransaction", 1, signedtxn.Item("hex").ToString, 0, 0)
                        If broadcasttx <> "" Then
                            MsgBox("Transaction sent, ID: " & broadcasttx)
                        Else
                            MsgBox("Error sending transaction. Raw transaction in the clipboard")
                            My.Computer.Clipboard.SetText(signedtxn.Item("hex").ToString)
                        End If
                    Else
                        txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct."
                    End If
                Catch ex As Exception
                    txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct.  " & ex.Message
                End Try
            Else
                txtMessage.Text = "Raw transaction is empty - stopping."
            End If
            clearprogbar()
        End If

    End Sub

    Function GetCurrencyInt(ByVal Currency As String) As Integer
        Dim CurrencyInt As Integer = 0
        Select Case Currency
            Case "MSC"
                CurrencyInt = 1
            Case "TMSC"
                CurrencyInt = 2
        End Select
        Return CurrencyInt
    End Function

    Structure BitcoinAddressAccount
        Dim strAddress As String
        Dim strAccount As String
        Dim strCusNum As String
        Public Overrides Function ToString() As String
            Return strCusNum
        End Function
    End Structure

    Public strAddress As List(Of BitcoinAddressAccount) = New List(Of BitcoinAddressAccount)


    Sub GetWalletMSCAddress()

        Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
        bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
        bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
        bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
        bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text

        Dim json As String = (New mlib).rpccall(bitcoin_con, "listreceivedbyaddress 0", 2, "true", 0, 0)
        If json = "" Then
            MsgBox("Can't access the bitcoin server.   Please run 'bitcoin-qt.exe -server'")
            Timer1.Enabled = False
        Else
            Dim obj As JArray = JsonConvert.DeserializeObject(json)
            For Each subitem In obj
                Dim carec As BitcoinAddressAccount = New BitcoinAddressAccount
                carec.strAddress = subitem("address")
                carec.strAccount = subitem("account")
                strAddress.Add(carec)
                cboAddress.Items.Add(subitem("address"))
            Next
            Timer1.Enabled = True

        End If

    End Sub
    



    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)

        bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
        bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
        bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
        bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text

        Dim test As String = (New mlib).rpccall(bitcoin_con, "getinfo", 0, 0, 0, 0)
        If test = "" Then
            MsgBox("Can't connect to the server.")
        End If

        My.Settings.RPCServer = txtRPCServer.Text
        My.Settings.RPCPort = txtRPCPort.Text
        My.Settings.RPCUser = txtRPCUser.Text
        My.Settings.RPCPassword = txtRPCPassword.Text
        My.Settings.BitcoindExe = txtBitcoindexe.Text
        My.Settings.ConnectString = txtConnectString.Text
        My.Settings.Save()
        MsgBox("Settings updated.")

    End Sub

 
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoinType.SelectedIndexChanged

        tabSellCoins.Text = "Sell " + cboCoinType.Text
        tabBuyCoins.Text = "Buy " + cboCoinType.Text
        tabSendCoins.Text = "Send " + cboCoinType.Text
        lblCoinstoSell.Text = cboCoinType.Text + " to Sell:"
        lblCoinstoSend.Text = cboCoinType.Text + " to Send:"
        cmdSellCoins.Text = "Sell " + cboCoinType.Text
        cmdSendCoins.Text = "Send " + cboCoinType.Text
        GetTransactions()
    End Sub


    Private Sub cboAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddress.SelectedIndexChanged
        GetTransactions()
    End Sub
    Sub GetTransactions()

        ResetProgbar(5)
        Dim AddressID As Integer = (New mymastercoins).GetAddressID(cboAddress.Text)
        Dim Sql As String = ""
        Dim DS As DataSet
        Dim CurrencyID As Integer = GetCurrencyInt(cboCoinType.Text)
        txtCoins.Text = "0.00"
        If AddressID > 0 Then
            With GVTrans
                .Columns("colIn").DefaultCellStyle.Format = "########.########"
                .Columns("colOut").DefaultCellStyle.Format = "########.########"
                .Columns("colTotalPrice").DefaultCellStyle.Format = "########.########"
                .Columns("colTotalPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .RowHeadersVisible = False
                .AutoGenerateColumns = False
            End With


            Sql = "SELECT *" + _
                    " FROM z_Transactions LEFT OUTER JOIN z_Exodus ON z_Transactions.ExodusID = z_Exodus.ExodusID " & _
                    " where AddressID=" + AddressID.ToString + " and CurrencyID=" + CurrencyID.ToString + _
                    " order by z_Transactions.dtrans"
            updateprogbar()
            DS = (New AWS.DB.ConnectDB).SQLdataset(Sql)
            If DS.Tables(0).DefaultView.Count > 0 Then
                GVTrans.DataSource = DS.Tables(0).DefaultView
                GVTrans.Visible = True
                txtCoins.Text = (New mymastercoins).GetAddressBalance(AddressID, CurrencyID)
                txtMessage.Text = ""
            Else
                GVTrans.Visible = False
                txtMessage.Text = "No transactions found"
            End If



            With GVSell
                .RowHeadersVisible = False
                .AutoGenerateColumns = False

                .Columns(1).DefaultCellStyle.Format = "########.########"
                .Columns(2).DefaultCellStyle.Format = "########.########"
                .Columns(3).DefaultCellStyle.Format = "########.########"
                .Columns(4).DefaultCellStyle.Format = "####"
                .Columns(5).DefaultCellStyle.Format = "########.########"
                .AutoGenerateColumns = False
                .Columns(0).DataPropertyName = "dTrans"
                .Columns(1).DataPropertyName = "Available"
                .Columns(2).DataPropertyName = "UnitPrice"
                .Columns(3).DataPropertyName = "BTCDesired"
                .Columns(4).DataPropertyName = "TimeLimit"
                .Columns(5).DataPropertyName = "TransFee"

            End With



            Sql = "SELECT z_CurrencyforSale.*,00000000.00000000 as UnitPrice" + _
    " FROM z_CurrencyforSale " + _
    " WHERE  CurrencyID = " + CurrencyID.ToString + " and IsNewOffer=1 " + _
    " and AddressID=" + AddressID.ToString + " and CurrencyID=" + CurrencyID.ToString + _
    " order by dtrans desc"
            updateprogbar()
            DS = (New AWS.DB.ConnectDB).SQLdataset(Sql)
            If DS.Tables(0).DefaultView.Count > 0 Then
                For Each Row1 In DS.Tables(0).Rows
                    Row1.item("UnitPrice") = Row1.item("BTCDesired") / Row1.item("AmountforSale")
                Next
                GVSell.DataSource = DS.Tables(0).DefaultView
                GVSell.Visible = True
            Else
                GVSell.Visible = False
            End If
        Else
            GVTrans.Visible = False
            GVSell.Visible = False
        End If
        Sql = "SELECT CONVERT (date, dTrans) AS DTrans, SUM(PurchasedAmount) AS TCOINS , SUM(PurchasedAmount*UnitPrice) AS TBTC,  00000.0000000 as ABTC FROM z_PurchasingCurrency WHERE (CurrencyID = " + CurrencyID.ToString + ") GROUP BY CONVERT (date, dTrans)"
        updateprogbar()
        DS = (New AWS.DB.ConnectDB).SQLdataset(Sql)
        If DS.Tables(0).DefaultView.Count > 0 Then
            For Each Row1 In DS.Tables(0).Rows
                Row1.item("ABTC") = Row1.item("TBTC") / Row1.item("TCOINS")
            Next
            Chart1.DataSource = DS.Tables(0)
            Chart1.Series("Price in BTC").XValueMember = "DTrans"
            Chart1.Series("Price in BTC").YValueMembers = "ABTC"
            Chart1.DataBind()
            Chart1.Visible = True
            '            Chart2.Series("Volume").XValueMember = "DTrans"
            '            Chart2.Series("Volume").YValueMembers = "TCOINS"
            '           Chart2.DataBind()
            '          Chart2.Visible = True
        Else
            '            Chart2.Visible = False
            Chart1.Visible = False
        End If



        With GVOfferstoSell
            .Columns("colSCoinstoSell").DefaultCellStyle.Format = "########.########"
            .Columns("colSUnitPrice").DefaultCellStyle.Format = "########.########"
            .Columns("colSBTCDesired").DefaultCellStyle.Format = "########.########"
            .Columns("colSTimeLimit").DefaultCellStyle.Format = "####"
            .AutoGenerateColumns = False
            .Columns(0).DataPropertyName = "dTrans"
            .Columns(1).DataPropertyName = "Available"
            .Columns(2).DataPropertyName = "UnitPrice"
            .Columns(3).DataPropertyName = "TotalPrice"
            .Columns(4).DataPropertyName = "TimeLimit"
            .Columns(4).Width = 50
            .Columns(5).DataPropertyName = "Seller"
            .RowHeadersVisible = False
        End With

        Sql = "SELECT z_CurrencyforSale.*, BTCDesired/AmountforSale as UnitPrice, (BTCDesired/AmountforSale)*Available as TotalPrice,space(100) as Seller" + _
" FROM z_CurrencyforSale " + _
" WHERE  CurrencyID = " + CurrencyID.ToString + " and IsNewOffer=1 " + _
" order by UnitPrice"
        updateprogbar()
        DS = (New AWS.DB.ConnectDB).SQLdataset(Sql)
        If DS.Tables(0).DefaultView.Count > 0 Then
            For Each DT In DS.Tables(0).Rows
                DT.item("Seller") = (New mymastercoins).GetAddress(DT.item("AddressID"))
            Next
            GVOfferstoSell.DataSource = DS.Tables(0).DefaultView
            GVOfferstoSell.Visible = True
        Else
            GVOfferstoSell.Visible = False
        End If

        '        Dim CurrentBlockNo As Integer = (New Bitcoin).GetBlockCount()
        Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
        bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
        bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
        bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
        bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text
        Dim CurrentBlockNo As String = (New mlib).rpccall(bitcoin_con, "getblockcount", 0, 0, 0, 0)


        '        Dim CurrentBlockNo As Integer = 0
        Sql = "SELECT *, space(40) as Seller, TotalBTC-Paid as UnPaid," + CurrentBlockNo.ToString + " as CurrentBlockNo" + _
        " FROM z_PurchasingCurrency " + _
        " WHERE  CurrencyID = " + CurrencyID.ToString + _
        " and MaxBlockNo>=" + CurrentBlockNo.ToString + _
        " and AddressID=" + AddressID.ToString + _
        " order by dtrans desc"


        With GVPurchasing
            .Columns(1).DefaultCellStyle.Format = "########.########"
            .Columns(2).DefaultCellStyle.Format = "########.########"
            .Columns(3).DefaultCellStyle.Format = "########.########"
            .Columns(4).DefaultCellStyle.Format = "##.########"
            .Columns(5).DefaultCellStyle.Format = "####"
            .Columns(7).DefaultCellStyle.Format = "########.########"
            .Columns(8).DefaultCellStyle.Format = "########.########"
            .AutoGenerateColumns = False
            .Columns(0).DataPropertyName = "dTrans"
            .Columns(1).DataPropertyName = "PurchasedAmount"
            .Columns(2).DataPropertyName = "UnitPrice"
            .Columns(3).DataPropertyName = "TotalBTC"
            .Columns(4).DataPropertyName = "TransFee"
            .Columns(5).DataPropertyName = "MaxBlockNo"
            .Columns(6).DataPropertyName = "Seller"
            .Columns(7).DataPropertyName = "Paid"
            .Columns(8).DataPropertyName = "UnPaid"
            .RowHeadersVisible = False
        End With

        DS = (New AWS.DB.ConnectDB).SQLdataset(Sql)
        updateprogbar()
        If DS.Tables(0).DefaultView.Count > 0 Then
            For Each DT In DS.Tables(0).Rows
                DT.item("Seller") = (New mymastercoins).GetAddress(DT.item("SellerID"))
            Next
            GVPurchasing.DataSource = DS.Tables(0).DefaultView
            GVPurchasing.Visible = True
        Else
            GVPurchasing.Visible = False
        End If
        lblCurrentBlockTime.Text = "Current Block Time: " + (New Bitcoin).GetBlockCount.ToString
        clearprogbar()
    End Sub

    Private Sub GVOfferstoSell_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GVOfferstoSell.RowEnter
        txtAmounttoPurchase.Text = Format(GVOfferstoSell.Rows(e.RowIndex).Cells(1).Value, "########.########")
        lblPurchaseOffer.Text = cboCoinType.Text + "  Total Btc " + Format(GVOfferstoSell.Rows(e.RowIndex).Cells(3).Value, "########.########") + " ( " + _
            Format(GVOfferstoSell.Rows(e.RowIndex).Cells(3).Value, "########.########") + " per " + cboCoinType.Text + " )  " + _
            "  Seller: " + GVOfferstoSell.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub txtAmounttoPurchase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmounttoPurchase.TextChanged
        If Not GVOfferstoSell.CurrentRow Is Nothing Then
            If Val(txtAmounttoPurchase.Text) < 0 Or Val(txtAmounttoPurchase.Text) > GVOfferstoSell.CurrentRow.Cells(1).Value Then
                lblPurchaseOffer.Text = "Amount must be less than or equal to " + Format(GVOfferstoSell.CurrentRow.Cells(1).Value, "########.########") + " " + cboCoinType.Text
            Else
                Dim UnitPrice As Double = GVOfferstoSell.CurrentRow.Cells(2).Value
                Dim TotalBTC As Double = Val(txtAmounttoPurchase.Text) * UnitPrice
                lblPurchaseOffer.Text = cboCoinType.Text + "  Total Btc " + Format(TotalBTC, "########.########") + " ( " + _
                    Format(UnitPrice, "########.########") + " per " + cboCoinType.Text + ") " + _
                    "  Seller: " + GVOfferstoSell.CurrentRow.Cells(5).Value
            End If
        End If
    End Sub



    Private Sub GVPurchasing_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GVPurchasing.RowEnter

        txtAmounttoPay.Text = Format(GVPurchasing.Rows(e.RowIndex).Cells(3).Value, "########.########")
        lblPay.Text = "btc to " + GVPurchasing.Rows(e.RowIndex).Cells(6).Value + ".  You get " + Format(GVPurchasing.Rows(e.RowIndex).Cells(1).Value, "########.########") + " " + cboCoinType.Text + " (" + _
            Format(GVPurchasing.Rows(e.RowIndex).Cells(2).Value, "########.########") + " per " + cboCoinType.Text + ")"
    End Sub
    Private Sub txtAmounttoPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmounttoPay.TextChanged
        If Not GVPurchasing.CurrentRow Is Nothing Then
            If Val(txtAmounttoPay.Text) < 0 Or Val(txtAmounttoPay.Text) > GVPurchasing.CurrentRow.Cells(3).Value Then
                lblPay.Text = "Amount must be less than " + Format(GVPurchasing.CurrentRow.Cells(3).Value, "########.########")
            Else
                Dim UnitPrice As Double = GVPurchasing.CurrentRow.Cells(2).Value
                Dim Coins As Double = Val(txtAmounttoPay.Text) / UnitPrice
                lblPay.Text = "btc to " + GVPurchasing.CurrentRow.Cells(6).Value + ".  You get " + Format(Coins, "########.########") + " " + cboCoinType.Text + " (" + _
                    Format(UnitPrice, "########.########") + " per " + cboCoinType.Text + " )"
            End If
        End If
    End Sub

    Function triplequote(ByVal addr As String)
        Return """""""" + addr + """"""""
    End Function
    Sub ResetProgbar(ByVal Num As Integer)
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = Num
        ProgressBar1.Visible = True
    End Sub
    Sub updateprogbar()
        ProgressBar1.Value += 1
    End Sub
    Sub clearprogbar()
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Recipient As String = GVPurchasing.CurrentRow.Cells(6).Value
        Dim txFee As String = GVPurchasing.CurrentRow.Cells(4).Value
        Dim result = MessageBox.Show("Are you sure you want to send " + txtAmounttoPay.Text + " btc to " + Recipient, "Send Btc Payment", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
            bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
            bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
            bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
            bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text

            Dim json As String = ""
            Dim resp As String = ""

            ResetProgbar(4)
            Dim SendMany As String = "{" + triplequote(Recipient) + ":" + FormatNumber(txtAmounttoPay.Text, 8) + "," + triplequote("1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P") + ":0.00006}"
            Dim temp As String = (New mlib).rpccall(bitcoin_con, "settxfee", 1, txFee, 0, 0)

            updateprogbar()
            resp = (New mlib).rpccall(bitcoin_con, "walletlock", 0, 0, 0, 0)
            updateprogbar()
            resp = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)

            Dim Account As String = ""
            For Each BTCAddress In strAddress
                If BTCAddress.strAddress = cboAddress.Text Then
                    Account = BTCAddress.strAccount
                    Exit For
                End If
            Next

            updateprogbar()
            json = (New mlib).rpccall(bitcoin_con, "sendmany", 2, """" + Account + """", SendMany, 0)
            If json <> "" Then
                MsgBox("Payment Sent." + json)
            Else
                MsgBox("Sending error. " + SendMany)
                My.Computer.Clipboard.SetText(SendMany)
            End If
            updateprogbar()
            clearprogbar()

            If False Then
                Try
                    json = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, txtSendToBTCA.Text, 0, 0)
                    Dim validater As JObject = JsonConvert.DeserializeObject(json)
                    If validater.Item("isvalid") = "True" Then 'address is valid
                        txtMessage.Text = "Recipient address is valid."
                        'push out to masterchest lib to encode the tx
                        Dim rawtx As String = (New mlib).encodepaymenttx(bitcoin_con, cboAddress.Text, txtSendToBTCA.Text, Val(txtAmounttoPay.Text))
                        'is rawtx empty
                        If rawtx <> "" Then
                            resp = (New mlib).rpccall(bitcoin_con, "walletlock", 0, 0, 0, 0)
                            resp = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                            'try and sign transaction
                            Try
                                Dim json2 As String = (New mlib).rpccall(bitcoin_con, "signrawtransaction", 1, rawtx, 0, 0)
                                Dim signedtxn As JObject = JsonConvert.DeserializeObject(json2)
                                If signedtxn.Item("complete").ToString() = "True" Then
                                    Dim resp2 As String = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                                    Dim broadcasttx As String = (New mlib).rpccall(bitcoin_con, "sendrawtransaction", 1, signedtxn.Item("hex").ToString, 0, 0)
                                    If broadcasttx <> "" Then
                                        MsgBox("Transaction sent, ID: " & broadcasttx)
                                    Else
                                        txtMessage.Text = "Error sending transaction."
                                        My.Computer.Clipboard.SetText(signedtxn.Item("hex").ToString)
                                    End If
                                Else
                                    txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct."
                                    My.Computer.Clipboard.SetText(rawtx)
                                End If
                            Catch ex As Exception
                                txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct.  " & ex.Message
                                My.Computer.Clipboard.SetText(rawtx)
                            End Try
                        Else
                            txtMessage.Text = "Raw transaction is empty - stopping."
                        End If
                    Else
                        txtMessage.Text = "Build transaction failed.  Recipient address is not valid."
                    End If
                Catch ex As Exception
                    MsgBox("Exeption thrown : " & ex.Message)
                End Try


            End If


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim CurrencyID As Integer = GetCurrencyInt(cboCoinType.Text)
        Dim result = MessageBox.Show("Are you sure you want to purchase " + txtAmounttoPurchase.Text + " " + cboCoinType.Text + "?", "Purchase Offer", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim bitcoin_con As mlib.bitcoinrpcconnection = (New mlib.bitcoinrpcconnection)
            bitcoin_con.bitcoinrpcserver = txtRPCServer.Text
            bitcoin_con.bitcoinrpcport = CInt(txtRPCPort.Text)
            bitcoin_con.bitcoinrpcuser = txtRPCUser.Text
            bitcoin_con.bitcoinrpcpassword = txtRPCPassword.Text
            Dim Seller As String = GVOfferstoSell.CurrentRow.Cells(5).Value

            ResetProgbar(7)
            updateprogbar()
            Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, Seller, 0, 0)
            Dim validater As JObject = JsonConvert.DeserializeObject(json)
            If validater.Item("isvalid") = "True" Then 'address is valid
                updateprogbar()
                Dim rawtx As String = (New mlib).encodeaccepttx(bitcoin_con, cboAddress.Text, Seller, CurrencyID, Val(txtAmounttoPurchase.Text) * 100000000)
                If rawtx <> "" Then
                    updateprogbar()
                    Dim dontcareresponse = (New mlib).rpccall(bitcoin_con, "walletlock", 0, 0, 0, 0)
                    updateprogbar()
                    Dim resp As String = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                    'try and sign transaction
                    Try
                        updateprogbar()
                        Dim json2 As String = (New mlib).rpccall(bitcoin_con, "signrawtransaction", 1, rawtx, 0, 0)
                        Dim signedtxn As JObject = JsonConvert.DeserializeObject(json2)
                        If signedtxn.Item("complete").ToString() = "True" Then
                            txtMessage.Text = "Signing appears successful."
                            Dim resp2 As String = (New mlib).rpccall(bitcoin_con, "walletpassphrase", 2, Trim(txtBTCWalletPP.Text), "15", 0)
                            updateprogbar()
                            Dim broadcasttx As String = (New mlib).rpccall(bitcoin_con, "sendrawtransaction", 1, signedtxn.Item("hex").ToString, 0, 0)
                            If broadcasttx <> "" Then
                                txtMessage.Text = "Transaction sent, ID: " & broadcasttx
                            Else
                                txtMessage.Text = "Error sending transaction."
                            End If
                        Else
                            txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct."
                        End If
                    Catch ex As Exception
                        txtMessage.Text = "Failed to sign transaction.  Ensure wallet passphrase is correct.  " & ex.Message
                    End Try
                Else
                    txtMessage.Text = "Raw transaction is empty - stopping."
                End If
            Else
                txtMessage.Text = "Build transaction failed.  Recipient address is not valid."
            End If

        End If
        clearprogbar()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = 900000
        ProgressBar1.Visible = True
        txtMessage.Text = "Getting Exodus Trasactions..."
        Call (New mymastercoins).GetExodusTrans(ProgressBar1)
        txtMessage.Text = "Processing Transactions ..."
        Call (New mymastercoins).ProcessTransactions(ProgressBar1)
        txtMessage.Text = "Transactions Processed"
        ProgressBar1.Visible = False
        GetTransactions()
    End Sub

End Class
