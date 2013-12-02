Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Text
Imports System.IO
Imports Org.BouncyCastle.Math.EC
Imports System.Security.Cryptography

Public Class mlib
    '/////////////
    '///STRUCTURES
    '/////////////
    Public publickeybytes As Byte()
    Public multisig As Boolean
    Dim isvalidtx As Boolean
    Public Class bitcoinrpcconnection
        Public bitcoinrpcserver As String
        Public bitcoinrpcport As Integer
        Public bitcoinrpcuser As String
        Public bitcoinrpcpassword As String
    End Class
    Public Class result_validate
        Public isvalid As Boolean
        Public address As String
        Public ismine As Boolean
        Public isscript As Boolean
        Public pubkey As String
        Public iscompressed As Boolean
        Public account As String
    End Class
    Public Class validate
        Public result As result_validate
        Public err As Object
        Public id As String
    End Class
    Public Class blockhash
        Public id As String
        Public err As Object
        Public result As String
    End Class
    Public Class mastercointx_selloffer
        Public txid As String
        Public fromadd As String
        Public type As String
        Public blocktime As Long
        Public valid As Integer
        Public curtype As Integer
        Public minfee As Long
        Public timelimit As Integer
        Public saleamount As Long
        Public offeramount As Long
    End Class
    Public Class mastercointx_acceptoffer
        Public txid As String
        Public toadd As String
        Public fromadd As String
        Public purchaseamount As Long
        Public type As String
        Public blocktime As Long
        Public valid As Integer
        Public curtype As Integer
    End Class
    Public Class mastercointx
        Public txid As String
        Public toadd As String
        Public fromadd As String
        Public value As Long
        Public type As String
        Public blocktime As Long
        Public valid As Integer
        Public curtype As Integer
    End Class
    Public Class result_block
        Public hash As String
        Public confirmations As Integer
        Public size As Integer
        Public height As Integer
        Public version As Integer
        Public merkleroot As String
        Public tx As List(Of String)
        Public time As Long
        Public nonce As Long
        Public bits As String
        Public difficulty As Double
        Public previousblockhash As String
        Public nextblockhash As String
    End Class
    Public Class Block
        Public result As result_block
        Public err As Object
        Public id As String
    End Class
    Public Class bttx
        Public data As String
        Public hash As String
        Public depends
        Public fee As Long
        Public sigops As Integer
    End Class
    Public Class result_blocktemplate
        Public version As Integer
        Public previousblockhash As String
        Public transactions As List(Of bttx)
        Public coinbaseasux
        Public coinbasevalue As Long
        Public target As String
        Public mintime As Long
        Public mutable
        Public noncerange As String
        Public sigoplimit As Integer
        Public sizelimit As Long
        Public curtime As Long
        Public bits As String
        Public height As Integer
    End Class
    Public Class blocktemplate
        Public result As result_blocktemplate
        Public err As Object
        Public id As String
    End Class
    Public Class ScriptSig
        Public asm As String
        Public hex As String
    End Class
    Public Class Vin
        Public txid As String
        Public vout As Integer
        Public scriptSig As ScriptSig
        Public sequence As Object
    End Class
    Public Class ScriptPubKey
        Public asm As String
        Public hex As String
        Public reqSigs As Integer
        Public type As String
        Public addresses As List(Of String)
    End Class
    Public Class Vout
        Public value As Double
        Public n As Integer
        Public scriptPubKey As ScriptPubKey
    End Class
    Public Class result_txn
        Public hex As String
        Public txid As String
        Public version As Integer
        Public locktime As Integer
        Public vin As List(Of Vin)
        Public vout As List(Of Vout)
        Public blockhash As String
        Public confirmations As Integer
        Public time As Integer
        Public blocktime As Integer
    End Class
    Public Class txn
        Public result As result_txn
        Public err As Object
        Public id As String
    End Class
    Public Class result_unspent
        Public txid As String
        Public vout As Integer
        Public address As String
        Public account As String
        Public scriptpubkey As String
        Public amount As Double
        Public confirmations As Integer
    End Class
    Public Class unspent
        Public result As List(Of result_unspent)
        Public err As Object
        Public id As String
    End Class
    Public Class isvalid
        Public result As result_isvalid
        Public err As Object
        Public id As String
    End Class
    Public Class result_isvalid
        Public isvalid As String
    End Class
    Public Class blockcount
        Public result As String
        Public err As Object
        Public id As String
    End Class
    Public Class result_blockcount
        Public result As Int64
    End Class
    Public Class rcvaddress
        Public result As List(Of result_rcvaddress)
        Public err As Object
        Public id As String
    End Class
    Public Class result_rcvaddress
        Public address As String
        Public account As String
        Public amount As Double
        Public confirmations As Integer
    End Class
    Public Class btcaddressbal
        Public address As String
        Public amount As Double
        Public uamount As Double
    End Class
    Public Class signedresult
        Public hex As String
        Public complete As Boolean
    End Class

    Public Class signedtx
        Public result As signedresult
    End Class

    Public Class broadcasttx
        Public result As String
    End Class


    Public cleartextpacket As String

    '////////////
    '///FUNCTIONS
    '////////////
    Public Function ToByteArray(ByVal base58 As String) As Byte()
        Dim bi2 As New Org.BouncyCastle.Math.BigInteger("0")
        Dim b58 As String = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz"

        For Each c As Char In base58
            If b58.IndexOf(c) <> -1 Then
                bi2 = bi2.Multiply(New Org.BouncyCastle.Math.BigInteger("58"))
                bi2 = bi2.Add(New Org.BouncyCastle.Math.BigInteger(b58.IndexOf(c).ToString()))
            Else
                Return Nothing
            End If
        Next

        Dim bb As Byte() = bi2.ToByteArrayUnsigned()

        ' interpret leading '1's as leading zero bytes
        For Each c As Char In base58
            If c <> "1"c Then
                Exit For
            End If
            Dim bbb As Byte() = New Byte(bb.Length) {}
            Array.Copy(bb, 0, bbb, 1, bb.Length)
            bb = bbb
        Next
        Return bb
    End Function

    Public Function FromByteArray(ByVal ba As Byte()) As String
        Dim addrremain As New Org.BouncyCastle.Math.BigInteger(1, ba)

        Dim big0 As New Org.BouncyCastle.Math.BigInteger("0")
        Dim big58 As New Org.BouncyCastle.Math.BigInteger("58")

        Dim b58 As String = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz"

        Dim rv As String = ""

        While addrremain.CompareTo(big0) > 0
            Dim d As Integer = Convert.ToInt32(addrremain.[Mod](big58).ToString())
            addrremain = addrremain.Divide(big58)
            rv = b58.Substring(d, 1) & rv
        End While

        ' handle leading zeroes
        For Each b As Byte In ba
            If b <> 0 Then
                Exit For
            End If

            rv = "1" & rv
        Next
        Return rv
    End Function

    Public Function multisigbarray(ByVal key As String)
        Dim parts(key.Length \ 2 - 1) As String
        Dim larray As New List(Of Byte)
        For x As Integer = 0 To key.Length - 1 Step 2
            parts(x \ 2) = key.Substring(x, 2)
            larray.Add(Byte.Parse(parts(x \ 2), System.Globalization.NumberStyles.HexNumber))
        Next
        Dim barray As Byte() = larray.ToArray
        Return barray
    End Function

    Public Function rpccall(ByVal bitcoin_con As bitcoinrpcconnection, ByVal method As String, ByVal param0 As String, ByVal param1 As String, ByVal param2 As String, ByVal param3 As String) As String
        Dim Ans As String = ""
        Dim BitcoindExe As String = "C:\Program Files (x86)\Bitcoin\daemon\bitcoind.exe"
        If InStr(BitcoindExe, "bitcoind.exe") > 0 Then
            Try
                Dim process = New Process()
                process.StartInfo.FileName = BitcoindExe
                Dim params As String = ""
                If param1 <> "0" Then
                    params += param1 + " "
                End If
                If param2 <> "0" Then
                    params += param2 + " "
                End If
                If param3 <> "0" Then
                    params += param3
                End If

                Dim arg As String = "-rpcconnect=" + bitcoin_con.bitcoinrpcserver + " -rpcport=" + bitcoin_con.bitcoinrpcport.ToString + " -rpcuser=" + bitcoin_con.bitcoinrpcuser + " -rpcpassword=" + bitcoin_con.bitcoinrpcpassword + " " + method + " " + params
                process.StartInfo.Arguments = arg
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True
                process.StartInfo.RedirectStandardOutput = True
                process.Start()
                Ans = process.StandardOutput.ReadToEnd().ToString
                process.WaitForExit()
            Catch e As Exception
                'exception thrown 
                MsgBox("Exception thrown: " & e.Message.ToString)
            End Try
        End If
        Return Ans
    End Function

    Public Function rpccallOld(ByVal bitcoin_con, ByVal method, ByVal param0, ByVal param1, ByVal param2, ByVal param3)
        Try
            Dim webRequest1 As HttpWebRequest = WebRequest.Create("http://" & bitcoin_con.bitcoinrpcserver.ToString & ":" & bitcoin_con.bitcoinrpcport.ToString)
            webRequest1.Credentials = New NetworkCredential(bitcoin_con.bitcoinrpcuser.ToString, bitcoin_con.bitcoinrpcpassword.ToString)
            webRequest1.ContentType = "application/json-rpc"
            webRequest1.Method = "POST"
            Dim joe As New JObject()
            joe.Add(New JProperty("jsonrpc", "1.0"))
            joe.Add(New JProperty("id", "1"))
            joe.Add(New JProperty("method", method))
            Dim props As New JArray()
            'add appropriate number of params (param0 is parameter count)
            If param0 = 0 Then
                joe.Add(New JProperty("params", New JArray()))
            End If
            If param0 = 1 Then
                props.Add(param1)
                joe.Add(New JProperty("params", props))
            End If
            If param0 = 2 Then
                props.Add(param1)
                props.Add(param2)
                joe.Add(New JProperty("params", props))
            End If
            If param0 = 3 Then
                props.Add(param1)
                props.Add(param2)
                props.Add(param3)
                joe.Add(New JProperty("params", props))
            End If
            '// serialize json for the request

            Dim s As String = JsonConvert.SerializeObject(joe)
            Dim bytearray As Byte() = Encoding.UTF8.GetBytes(s)
            webRequest1.ContentLength = bytearray.Length
            Dim datastream As Stream = webRequest1.GetRequestStream()
            datastream.Write(bytearray, 0, bytearray.Length)
            datastream.Close()

            Dim webResponse1 As WebResponse = webRequest1.GetResponse()
            Dim returnstream As Stream = webResponse1.GetResponseStream()
            Dim rreader As StreamReader = New StreamReader(returnstream, Encoding.UTF8)
            Dim responsestring As String = rreader.ReadToEnd()
            Return (responsestring)
        Catch e As Exception
            'exception thrown 
            MsgBox("Exception thrown in bitcoin rpc call: " & e.Message.ToString)
        End Try
    End Function

    Public Function getmastercointransaction(ByVal bitcoin_con As bitcoinrpcconnection, ByVal txid As String, ByVal txtype As String)
        Dim tx As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, txid, 1, 0))
        'was it a purchase to consider as generate?
        If txtype = "generate" Then
            Dim txinputs As Integer
            Dim txhighvalue As Integer
            Dim txinputadd(1000) As String
            Dim txinputamount(1000) As Double
            Dim exoamount As Double
            txinputs = 0
            'calculate input addresses 
            Dim vins() As Vin = tx.result.vin.ToArray
            'get inputs
            For i = 0 To UBound(vins)
                'loop through each vin getting txid
                Dim vinresults As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, vins(i).txid.ToString, 1, 0))
                Dim voutnum As Integer = vins(i).vout
                'loop through vinresults until voutnum is located and grab address
                Dim voutarray() As Vout = vinresults.result.vout.ToArray
                For k = 0 To UBound(voutarray)
                    If voutarray(k).n = voutnum Then
                        'check we haven't seen this input address before
                        If txinputadd.Contains(voutarray(k).scriptPubKey.addresses(0).ToString) Then
                            'get location of address and increase amount
                            For p = 0 To txinputs
                                If txinputadd(p) = voutarray(k).scriptPubKey.addresses(0).ToString Then
                                    txinputamount(p) = txinputamount(p) + voutarray(k).value
                                    If txinputamount(p) > txinputamount(txhighvalue) Then txhighvalue = p
                                End If
                            Next
                        Else
                            txinputs = txinputs + 1
                            txinputamount(txinputs) = voutarray(k).value
                            If txinputamount(txinputs) > txinputamount(txhighvalue) Then txhighvalue = txinputs
                            txinputadd(txinputs) = voutarray(k).scriptPubKey.addresses(0).ToString
                        End If
                    End If
                Next
            Next
            If txinputs > 0 Then
                'calculate MSC purchased
                Dim vouts() As Vout = tx.result.vout.ToArray
                'loop through each output and get the value and address
                For i = 0 To UBound(vouts)
                    Try
                        If vouts(i).scriptPubKey.addresses(0).ToString = "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                            exoamount = vouts(i).value
                        End If
                    Catch e As Exception
                        MsgBox("Exeption thrown looping outputs : " & e.Message)
                    End Try
                Next

                Dim dif As Long = 1377993600 - tx.result.blocktime
                Dim bonus As Double = 0.1 * (dif / 604800)
                If bonus < 0 Then bonus = 0 'avoid negative bonus
                Dim totalmscexo As Double = exoamount * 100 * (1 + bonus) * 100000000
                Dim returnobj As New mastercointx
                returnobj.blocktime = tx.result.blocktime
                returnobj.fromadd = "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P"
                returnobj.toadd = txinputadd(txhighvalue)
                returnobj.txid = tx.result.txid
                returnobj.type = "generate"
                returnobj.value = totalmscexo
                returnobj.valid = 1
                returnobj.curtype = 0
                Return returnobj
            End If
        End If

        'sell offer
        If txtype = "selloffer" Then
            Dim txinputs As Integer
            Dim txhighvalue As Integer
            Dim txinputadd(1000) As String
            Dim txinputamount(1000) As Double
            Dim exoamount As Double
            Dim pubkeyhex As String
            txinputs = 0
            'calculate input addresses 
            Dim vins() As Vin = tx.result.vin.ToArray
            'get inputs
            For i = 0 To UBound(vins)
                'loop through each vin getting txid
                Dim vinresults As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, vins(i).txid.ToString, 1, 0))
                Dim voutnum As Integer = vins(i).vout
                'loop through vinresults until voutnum is located and grab address
                Dim voutarray() As Vout = vinresults.result.vout.ToArray
                For k = 0 To UBound(voutarray)
                    If voutarray(k).n = voutnum Then
                        'check we haven't seen this input address before
                        If txinputadd.Contains(voutarray(k).scriptPubKey.addresses(0).ToString) Then
                            'get location of address and increase amount
                            For p = 0 To txinputs
                                If txinputadd(p) = voutarray(k).scriptPubKey.addresses(0).ToString Then
                                    txinputamount(p) = txinputamount(p) + voutarray(k).value
                                    If txinputamount(p) > txinputamount(txhighvalue) Then txhighvalue = p
                                End If
                            Next
                        Else
                            txinputs = txinputs + 1
                            txinputamount(txinputs) = voutarray(k).value
                            If txinputamount(txinputs) > txinputamount(txhighvalue) Then txhighvalue = txinputs
                            txinputadd(txinputs) = voutarray(k).scriptPubKey.addresses(0).ToString
                        End If
                    End If
                Next
            Next
            If txinputs > 0 Then
                Dim vouts() As Vout = tx.result.vout.ToArray
                If UBound(vouts) > 0 Then 'we have outputs to work if
                    'loop through and get the data pubkeys
                    Dim outputs As New DataTable
                    outputs.Columns.Add("pubkeys", GetType(String))

                    For i = 0 To UBound(vouts)
                        Try
                            If vouts(i).scriptPubKey.type = "multisig" And vouts(i).scriptPubKey.addresses(0).ToString <> "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                                Dim asmvars As String() = vouts(i).scriptPubKey.asm.ToString.Split(" ")
                                If asmvars.Count = 5 Then
                                    outputs.Rows.Add(asmvars(2))
                                End If
                                If asmvars.Count = 6 Then
                                    outputs.Rows.Add(asmvars(2))
                                    outputs.Rows.Add(asmvars(3))
                                End If
                            End If
                        Catch e As Exception
                            MsgBox("Exception thrown enumerating outputs: " & Trim(vouts(i).scriptPubKey.addresses(0).ToString) & " : " & e.Message)
                        End Try
                    Next
                    isvalidtx = False
                    If outputs.Rows.Count > 0 And outputs.Rows.Count < 3 Then 'we have data to work with
                        '/// multisig
                        '1 remaining output
                        If outputs.Rows.Count = 1 Then
                            cleartextpacket = decryptmastercoinpacket(txinputadd(txhighvalue), 1, outputs.Rows(0).Item(0).ToString.Substring(2, 62))
                            isvalidtx = True
                        End If
                        '2 remaining outputs
                        If outputs.Rows.Count = 2 Then
                            cleartextpacket = decryptmastercoinpacket(txinputadd(txhighvalue), 1, outputs.Rows(0).Item(0).ToString.Substring(2, 62))
                            cleartextpacket = cleartextpacket & decryptmastercoinpacket(txinputadd(txhighvalue), 2, outputs.Rows(1).Item(0).ToString.Substring(2, 62)).Substring(2, 60)
                            'MsgBox(cleartextpacket)
                            isvalidtx = True
                            'otherwise ambiguous
                        End If
                    Else
                        If isvalidtx = False Then  '### fall back to peek and decode
                            'peek and decode routine here
                        End If
                    End If

                    'is tx valid? 
                    If isvalidtx = True Then
                        'decode transaction
                        Dim barray As Byte()
                        barray = multisigbarray(cleartextpacket)
                        Dim transbytes() As Byte = {barray(1), barray(2), barray(3), barray(4)}
                        Dim curidbytes() As Byte = {barray(5), barray(6), barray(7), barray(8)}
                        Dim saleamountbytes() As Byte = {barray(9), barray(10), barray(11), barray(12), barray(13), barray(14), barray(15), barray(16)}
                        Dim offeramountbytes() As Byte = {barray(17), barray(18), barray(19), barray(20), barray(21), barray(22), barray(23), barray(24)}
                        Dim timelimitbyte As Byte = barray(25)
                        Dim minfeebytes() As Byte = {barray(26), barray(27), barray(28), barray(29), barray(30), barray(31), barray(32), barray(33)}

                        'handle endianness
                        If BitConverter.IsLittleEndian = True Then
                            Array.Reverse(transbytes)
                            Array.Reverse(curidbytes)
                            Array.Reverse(saleamountbytes)
                            Array.Reverse(offeramountbytes)
                            Array.Reverse(minfeebytes)
                        End If

                        If BitConverter.ToUInt32(transbytes, 0) = 20 Then
                            Dim returnobj As New mastercointx_selloffer

                            returnobj.blocktime = tx.result.blocktime
                            returnobj.fromadd = txinputadd(txhighvalue)
                            returnobj.txid = tx.result.txid
                            returnobj.type = "selloffer"
                            returnobj.curtype = BitConverter.ToUInt32(curidbytes, 0)
                            returnobj.valid = 0
                            returnobj.saleamount = BitConverter.ToUInt64(saleamountbytes, 0)
                            returnobj.offeramount = BitConverter.ToUInt64(offeramountbytes, 0)
                            returnobj.timelimit = timelimitbyte
                            returnobj.minfee = BitConverter.ToUInt64(minfeebytes, 0)
                            Return (returnobj)
                        End If
                    End If
                End If
            End If
        End If

        'accept offer
        If txtype = "acceptoffer" Then
            Dim txinputs As Integer
            Dim txhighvalue As Integer
            Dim txinputadd(1000) As String
            Dim txinputamount(1000) As Double
            Dim toadd As String
            Dim exoamount As Double
            Dim pubkeyhex As String
            txinputs = 0
            'calculate input addresses 
            Dim vins() As Vin = tx.result.vin.ToArray
            'get inputs
            For i = 0 To UBound(vins)
                'loop through each vin getting txid
                Dim vinresults As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, vins(i).txid.ToString, 1, 0))
                Dim voutnum As Integer = vins(i).vout
                'loop through vinresults until voutnum is located and grab address
                Dim voutarray() As Vout = vinresults.result.vout.ToArray
                For k = 0 To UBound(voutarray)
                    If voutarray(k).n = voutnum Then
                        'check we haven't seen this input address before
                        If txinputadd.Contains(voutarray(k).scriptPubKey.addresses(0).ToString) Then
                            'get location of address and increase amount
                            For p = 0 To txinputs
                                If txinputadd(p) = voutarray(k).scriptPubKey.addresses(0).ToString Then
                                    txinputamount(p) = txinputamount(p) + voutarray(k).value
                                    If txinputamount(p) > txinputamount(txhighvalue) Then txhighvalue = p
                                End If
                            Next
                        Else
                            txinputs = txinputs + 1
                            txinputamount(txinputs) = voutarray(k).value
                            If txinputamount(txinputs) > txinputamount(txhighvalue) Then txhighvalue = txinputs
                            txinputadd(txinputs) = voutarray(k).scriptPubKey.addresses(0).ToString
                        End If
                    End If
                Next
            Next
            If txinputs > 0 Then
                Dim vouts() As Vout = tx.result.vout.ToArray
                If UBound(vouts) > 0 Then 'we have outputs to work if
                    'loop through and get the data pubkeys
                    Dim outputs As New DataTable
                    Dim pubkeys As New DataTable
                    outputs.Columns.Add("address", GetType(String))
                    pubkeys.Columns.Add("pubkey", GetType(String))
                    For i = 0 To UBound(vouts)
                        Try
                            If vouts(i).scriptPubKey.type = "pubkeyhash" And vouts(i).scriptPubKey.addresses(0).ToString <> txinputadd(txhighvalue) And vouts(i).scriptPubKey.addresses(0).ToString <> "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then 'found destination address
                                outputs.Rows.Add(Trim(vouts(i).scriptPubKey.addresses(0).ToString))
                            End If
                            If vouts(i).scriptPubKey.type = "multisig" And vouts(i).scriptPubKey.addresses(0).ToString <> "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                                Dim asmvars As String() = vouts(i).scriptPubKey.asm.ToString.Split(" ")
                                If asmvars.Count = 5 Then
                                    pubkeys.Rows.Add(asmvars(2))
                                End If
                            End If
                        Catch e As Exception
                            MsgBox("Exception thrown enumerating outputs: " & Trim(vouts(i).scriptPubKey.addresses(0).ToString) & " : " & e.Message)
                        End Try
                    Next
                    isvalidtx = False
                    If outputs.Rows.Count = 1 Then 'there should only be one pubkeyhash output after we've removed exodus and change (sender)
                        If pubkeys.Rows.Count > 0 And pubkeys.Rows.Count < 2 Then 'we have data to work with
                            '/// multisig
                            '1 remaining output
                            If pubkeys.Rows.Count = 1 Then
                                cleartextpacket = decryptmastercoinpacket(txinputadd(txhighvalue), 1, pubkeys.Rows(0).Item(0).ToString.Substring(2, 62))
                                isvalidtx = True
                            End If
                        Else
                            If isvalidtx = False Then  '### fall back to peek and decode
                                'peek and decode routine here
                            End If
                        End If

                        'is tx valid? 
                        If isvalidtx = True Then
                            'decode transaction
                            Dim barray As Byte()
                            barray = multisigbarray(cleartextpacket)
                            Dim transbytes() As Byte = {barray(1), barray(2), barray(3), barray(4)}
                            Dim curidbytes() As Byte = {barray(5), barray(6), barray(7), barray(8)}
                            Dim purchaseamountbytes() As Byte = {barray(9), barray(10), barray(11), barray(12), barray(13), barray(14), barray(15), barray(16)}

                            'handle endianness
                            If BitConverter.IsLittleEndian = True Then
                                Array.Reverse(transbytes)
                                Array.Reverse(curidbytes)
                                Array.Reverse(purchaseamountbytes)
                            End If

                            If BitConverter.ToUInt32(transbytes, 0) = 22 Then
                                Dim returnobj As New mastercointx_acceptoffer

                                returnobj.blocktime = tx.result.blocktime
                                returnobj.fromadd = txinputadd(txhighvalue)
                                returnobj.toadd = outputs.Rows(0).Item(0)
                                returnobj.txid = tx.result.txid
                                returnobj.type = "acceptoffer"
                                returnobj.curtype = BitConverter.ToUInt32(curidbytes, 0)
                                returnobj.valid = 0
                                returnobj.purchaseamount = BitConverter.ToUInt64(purchaseamountbytes, 0)
                                Return (returnobj)
                            End If
                        End If
                    End If
                End If
            End If
        End If

        'simple send
        If txtype = "send" Then
            Dim txinputs As Integer
            Dim txhighvalue As Integer
            Dim txinputadd(1000) As String
            Dim txinputamount(1000) As Double
            Dim exoamount As Double
            Dim pubkeyhex As String
            txinputs = 0
            'calculate input addresses 
            Dim vins() As Vin = tx.result.vin.ToArray
            'get inputs
            For i = 0 To UBound(vins)
                'loop through each vin getting txid
                Dim vinresults As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, vins(i).txid.ToString, 1, 0))
                Dim voutnum As Integer = vins(i).vout
                'loop through vinresults until voutnum is located and grab address
                Dim voutarray() As Vout = vinresults.result.vout.ToArray
                For k = 0 To UBound(voutarray)
                    If voutarray(k).n = voutnum Then
                        'check we haven't seen this input address before
                        If txinputadd.Contains(voutarray(k).scriptPubKey.addresses(0).ToString) Then
                            'get location of address and increase amount
                            For p = 0 To txinputs
                                If txinputadd(p) = voutarray(k).scriptPubKey.addresses(0).ToString Then
                                    txinputamount(p) = txinputamount(p) + voutarray(k).value
                                    If txinputamount(p) > txinputamount(txhighvalue) Then txhighvalue = p
                                End If
                            Next
                        Else
                            txinputs = txinputs + 1
                            txinputamount(txinputs) = voutarray(k).value
                            If txinputamount(txinputs) > txinputamount(txhighvalue) Then txhighvalue = txinputs
                            txinputadd(txinputs) = voutarray(k).scriptPubKey.addresses(0).ToString
                        End If
                    End If
                Next
            Next
            If txinputs > 0 Then
                multisig = False
                Dim vouts() As Vout = tx.result.vout.ToArray
                If UBound(vouts) > 0 Then 'we have outputs to work if
                    'loop through each output and find the exodus address
                    For i = 0 To UBound(vouts)
                        Try
                            If vouts(i).scriptPubKey.addresses(0).ToString = "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                                exoamount = vouts(i).value 'amount of msc fee
                            End If
                        Catch e As Exception
                            MsgBox("Exception thrown detecting fee amounts: " & e.Message)
                        End Try
                    Next
                    'loop through and find the remainder of output addresses
                    Dim outputs As New DataTable
                    outputs.Columns.Add("Address", GetType(String))
                    outputs.Columns.Add("Amount", GetType(Double))
                    outputs.Columns.Add("Seqnum", GetType(Integer))

                    For i = 0 To UBound(vouts)
                        Try
                            If vouts(i).scriptPubKey.type = "multisig" And vouts(i).scriptPubKey.addresses(0).ToString <> "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                                multisig = True
                                Dim asmvars As String() = vouts(i).scriptPubKey.asm.ToString.Split(" ")
                                pubkeyhex = asmvars(2)
                            End If
                            If vouts(i).scriptPubKey.type = "pubkeyhash" And vouts(i).scriptPubKey.addresses(0).ToString <> "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then 'found data or destination address with matching transaction value
                                'get address sequence no
                                Dim rowbarray As Byte()
                                rowbarray = ToByteArray(Trim(vouts(i).scriptPubKey.addresses(0).ToString))
                                'add to table
                                outputs.Rows.Add(Trim(vouts(i).scriptPubKey.addresses(0).ToString), vouts(i).value, rowbarray(1))
                            End If
                        Catch e As Exception
                            MsgBox("Exception thrown enumerating outputs: " & Trim(vouts(i).scriptPubKey.addresses(0).ToString) & " : " & e.Message)
                        End Try
                    Next
                    'order the packets
                    outputs.DefaultView.Sort = "Seqnum"
                    Dim output(3) As String
                    Dim outputseq(3) As Integer
                    Dim txdataaddress As String
                    Dim txrefaddress As String
                    Dim txchangeaddress As String
                    isvalidtx = False
                    If outputs.Rows.Count > 0 And outputs.Rows.Count < 4 Then 'we have data to work with
                        '### first see if change is easy to detect and drop it from outputs
                        Dim exooutputamounts As Integer = 0
                        Dim nonexooutputamounts As Integer = 0
                        Dim changeoutput As Integer
                        For i = 0 To outputs.Rows.Count - 1
                            If outputs.Rows(i).Item(1) = exoamount Then
                                exooutputamounts = exooutputamounts + 1
                            Else
                                nonexooutputamounts = nonexooutputamounts + 1
                                changeoutput = i
                            End If
                        Next
                        If exooutputamounts = 2 And nonexooutputamounts = 1 Then 'two the same as exodus amount and one odd one out - we can drop the change output
                            outputs.Rows(changeoutput).Delete()
                        End If

                        Dim outid As Integer = 1
                        For Each row In outputs.DefaultView
                            outputseq(outid) = row("Seqnum")
                            output(outid) = row("Address")
                            outid = outid + 1
                        Next

                        If multisig = True Then
                            '/// multisig
                            '1 remaining output
                            If outputs.Rows.Count = 1 Then
                                txrefaddress = outputs.Rows(0).Item(0)
                                isvalidtx = True
                            End If
                            '2 remaining outputs
                            If outputs.Rows.Count = 2 Then
                                If output(1) = txinputadd(txhighvalue) Then 'txinputadd(txhighvalue) is the from address
                                    txchangeaddress = output(1)
                                    txrefaddress = output(2)
                                    isvalidtx = True
                                End If
                                If output(2) = txinputadd(txhighvalue) Then
                                    txchangeaddress = output(2)
                                    txrefaddress = output(1)
                                    isvalidtx = True
                                End If
                                'otherwise ambiguous
                            End If
                        Else
                            '/// non-multisig
                            '2 remaining outputs
                            If outputs.Rows.Count = 2 Then
                                If outputseq(2) - outputseq(1) = 1 Then
                                    txdataaddress = output(1)
                                    txrefaddress = output(2)
                                    isvalidtx = True
                                End If
                                'handle 255
                                If (outputseq(2) = 255 And outputseq(1) = 0) Then
                                    txdataaddress = output(2)
                                    txrefaddress = output(1)
                                    isvalidtx = True
                                End If
                            End If
                            '3 remaining outputs
                            If outputs.Rows.Count = 3 Then
                                If outputseq(2) - outputseq(1) = 1 And outputseq(3) - outputseq(2) <> 1 Then
                                    txdataaddress = output(1)
                                    txrefaddress = output(2)
                                    txchangeaddress = output(3)
                                    isvalidtx = True
                                End If
                                If outputseq(3) - outputseq(2) = 1 And outputseq(2) - outputseq(1) <> 1 Then
                                    txdataaddress = output(2)
                                    txrefaddress = output(3)
                                    txchangeaddress = output(1)
                                    isvalidtx = True
                                End If
                                'handle 255
                                If (outputseq(3) = 255 And outputseq(1) = 0) And (outputseq(2) - outputseq(1) <> 1 And outputseq(3) - outputseq(2) <> 1) Then
                                    txdataaddress = output(3)
                                    txrefaddress = output(1)
                                    txchangeaddress = output(2)
                                    isvalidtx = True
                                End If
                            End If
                            If isvalidtx = False Then  '### fall back to peek and decode
                                'peek and decode routine here
                            End If
                        End If

                        'is tx valid? 
                        If isvalidtx = True Then

                            'decode transaction
                            Dim barray As Byte()
                            'multisig?
                            If multisig = True Then
                                Dim cleartext As String = decryptmastercoinpacket(txinputadd(txhighvalue), 1, pubkeyhex.Substring(2, 62))
                                cleartext = "02" & cleartext
                                barray = multisigbarray(cleartext)
                            Else 'not multisig
                                barray = ToByteArray(Trim(txdataaddress))
                            End If
                            Dim transbytes() As Byte = {barray(2), barray(3), barray(4), barray(5)}
                            Dim curidbytes() As Byte = {barray(6), barray(7), barray(8), barray(9)}
                            Dim amountbytes() As Byte = {barray(10), barray(11), barray(12), barray(13), barray(14), barray(15), barray(16), barray(17)}
                            'handle endianness
                            If BitConverter.IsLittleEndian = True Then
                                Array.Reverse(transbytes)
                                Array.Reverse(curidbytes)
                                Array.Reverse(amountbytes)
                            End If

                            If BitConverter.ToUInt32(transbytes, 0) = 0 Then
                                Dim returnobj As New mastercointx
                                returnobj.blocktime = tx.result.blocktime
                                returnobj.fromadd = txinputadd(txhighvalue)
                                returnobj.toadd = txrefaddress
                                returnobj.txid = tx.result.txid
                                returnobj.type = "simple"
                                returnobj.curtype = BitConverter.ToUInt32(curidbytes, 0)
                                returnobj.valid = 0
                                returnobj.value = BitConverter.ToUInt64(amountbytes, 0)
                                Return returnobj
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Public Function decryptmastercoinpacket(ByVal fromadd As String, ByVal seqnum As Integer, ByVal pubkeyhex As String)
        Dim shahash As String = fromadd
        For i = 1 To seqnum
            shahash = sha256hash(shahash)
        Next
        Dim cleartext As String
        Dim a As Short
        For a = 1 To 61 Step 2
            Dim byte1 As Byte = Convert.ToByte(Mid(shahash, (a), 2), 16)
            Dim byte2 As Byte = Convert.ToByte(Mid(pubkeyhex, (a), 2), 16)
            cleartext = cleartext & (byte1 Xor byte2).ToString("X2")
        Next
        Return cleartext
    End Function
    Public Function encryptmastercoinpacket(ByVal fromadd As String, ByVal seqnum As Integer, ByVal pubkeyhex As String)
        Dim shahash As String = fromadd
        Dim obfuscated As String
        For i = 1 To seqnum
            shahash = sha256hash(shahash)
        Next
        Dim a As Short
        For a = 1 To 61 Step 2
            Dim byte1 As Byte = Convert.ToByte(Mid(shahash, (a), 2), 16)
            Dim byte2 As Byte = Convert.ToByte(Mid(pubkeyhex, (a), 2), 16)
            obfuscated = obfuscated & (byte1 Xor byte2).ToString("X2")
        Next
        Return obfuscated
    End Function
    Public Function sha256hash(ByVal text As String)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Dim sha256prov As HashAlgorithm = New SHA256CryptoServiceProvider()
        Dim hashbytes As Byte() = sha256prov.ComputeHash(bytes)
        Dim hash As New StringBuilder
        For Each b As Byte In hashbytes
            hash.AppendFormat("{0:X2}", b)
        Next
        Return hash.ToString()
    End Function
    Public Function validateecdsa(ByVal pubkey As String)
        Dim validpoint As Boolean = False
        'check ecdsa validity
        Try
            Dim barray As Byte() = multisigbarray(pubkey)
            Dim ps = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1")
            Dim point = ps.Curve.DecodePoint(barray)

            Dim ysquared = point.Y.Multiply(point.Y)
            Dim xcubed = point.X.Multiply(point.X).Multiply(point.X)
            Dim xcurvea = point.X.Multiply(ps.Curve.A)
            Dim final = xcubed.Add(xcurvea).Add(ps.Curve.B)
            If ysquared.Equals(final) Then
                Return True
            Else
                Return False
            End If

        Catch e As Exception
            Return False
        End Try

    End Function

    Public Function getrandombyte()
        Dim s As String = "1234567890ABCDEF"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 2
            Dim idx As Integer = r.Next(0, 16)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Public Function encodetx(ByVal bitcoin_con As bitcoinrpcconnection, ByVal fromadd As String, ByVal toadd As String, ByVal curtype As Integer, ByVal amount As Long)
        Dim txhex, fromtxid As String
        Dim fromtxvout As Integer = -1
        Dim fromtxamount As Double = -1
        Dim changeamount As Long
        Dim txfee As Long = 6000
        Dim totaltxfee As Long = 50000 'include 0.0002 miner fee
        Dim encodedpubkey, frompubkey As String
        Dim isvalidecdsa As Boolean

        'calculate encoded public key for tx
        encodedpubkey = "01" 'compressedkey+seqnum
        encodedpubkey = encodedpubkey + "00000000" 'simple send
        encodedpubkey = encodedpubkey + i32tohexlittle(curtype)
        encodedpubkey = encodedpubkey + i64tohexlittle(amount)
        encodedpubkey = encodedpubkey + "0000000000000000000000000000" 'padding

        'obfuscate public key
        encodedpubkey = encryptmastercoinpacket(fromadd, 1, encodedpubkey)

        'build full key
        encodedpubkey = "02" & encodedpubkey & "00" 'last 00 will be rotated immediately

        'validate ECDSA point
        isvalidecdsa = False
        Do While isvalidecdsa = False
            Dim rbyte As String = getrandombyte()
            encodedpubkey = encodedpubkey.Substring(0, 64) & rbyte
            isvalidecdsa = validateecdsa(encodedpubkey)
        Loop

        'get public key for from address
        Try

            Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, fromadd, 0, 0)
            Dim validate As JObject = JsonConvert.DeserializeObject(json)

            frompubkey = validate.Item("pubkey")
            If validate.Item("iscompressed").ToString = "False" Then
                'compress public key
                frompubkey = frompubkey.Substring(2, 128)
                If Val(Right(frompubkey, 1)) Mod 2 Then
                    frompubkey = "03" & Left(frompubkey, 64)
                Else
                    frompubkey = "02" & Left(frompubkey, 64)
                End If
            End If
        Catch e As Exception
            MsgBox("Exeption thrown validating key: " & e.Message)
        End Try
        If frompubkey = "" Then
            MsgBox("Error locating public key for from address.")
            Exit Function
        End If

        'lookup unspent for from address
        Dim json3 As String = (New Bitcoin).getjson("http://blockchain.info/unspent?active=" + fromadd)
        Dim obj As JObject = JsonConvert.DeserializeObject(json3)
        Dim jOut As JArray = JsonConvert.DeserializeObject(obj.Item("unspent_outputs").ToString)
        For Each Tran In jOut
            If Val(Tran.Item("value")) > totaltxfee Then
                json3 = (New Bitcoin).getjson("http://blockchain.info/tx-index/" & Tran.Item("tx_index").ToString & "?format=json")
                Dim jHash As JObject = JsonConvert.DeserializeObject(json3)
                '                If jHash.Item("addr") = fromadd Then
                'http://blockchain.info/tx-index/98418277
                fromtxid = jHash.Item("hash")
                fromtxvout = Tran.Item("tx_output_n")
                fromtxamount = Tran.Item("value")
                '            End If
            End If
        Next

        If fromtxid = "" Or fromtxvout < 0 Or fromtxamount < 0 Then
            MsgBox("Insufficient funds for fee at from address.")
            Exit Function
        End If

        'handle change
        changeamount = (fromtxamount) - totaltxfee

        'build tx hex raw
        txhex = "01000000" 'version
        txhex = txhex & "01" 'vin count
        txhex = txhex & txidtohex(fromtxid) 'input txid hex
        txhex = txhex & i32tohex(fromtxvout) 'input vout 00000000
        txhex = txhex & "00" 'scriptsig length
        txhex = txhex & "ffffffff" 'sequence

        txhex = txhex & "04" 'number of vouts, future: cater for 3 outs (no change) - since we check txin for >totaltxfee there will always be change for now

        'change output
        txhex = txhex & i64tohex(changeamount) 'changeamount value
        txhex = txhex & "19" 'length - 25 bytes
        txhex = txhex & "76a914" & addresstopubkey(fromadd) & "88ac" 'change scriptpubkey
        'exodus output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914946cb2e08075bcbaf157e47bcb67eb2b2339d24288ac" 'exodus scriptpubkey
        'reference/destination output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914" & addresstopubkey(toadd) & "88ac" 'data scriptpubkey 

        'multisig output
        txhex = txhex & i64tohex(txfee * 2)
        txhex = txhex & "47" 'length - ??bytes?? calculate
        txhex = txhex & "51" '???
        txhex = txhex & "21" '???
        txhex = txhex & frompubkey 'first multisig address
        txhex = txhex & "21" '???
        txhex = txhex & encodedpubkey 'second multisig address
        txhex = txhex & "52ae" '???
        txhex = txhex & "00000000" 'locktime

        Return txhex
    End Function

    Public Function encodeselltx(ByVal bitcoin_con As bitcoinrpcconnection, ByVal fromadd As String, ByVal curtype As Integer, ByVal saleamount As Long, ByVal offeramount As Long, ByVal minfee As Long, ByVal timelimit As Integer)
        Dim txhex, fromtxid As String
        Dim fromtxvout As Integer = -1
        Dim fromtxamount As Double = -1
        Dim changeamount As Long
        Dim txfee As Long = 6000
        Dim totaltxfee As Long = 50000
        Dim encodedpubkey, encodedpubkey2, frompubkey As String
        Dim isvalidecdsa As Boolean
        Dim minfeestr, timelimitstr As String

        'first pubkey
        encodedpubkey = "01" 'compressedkey+seqnum
        encodedpubkey = encodedpubkey + "00000014" 'simple send
        encodedpubkey = encodedpubkey + i32tohexlittle(curtype)
        encodedpubkey = encodedpubkey + i64tohexlittle(saleamount)
        encodedpubkey = encodedpubkey + i64tohexlittle(offeramount)
        timelimitstr = Conversion.Hex(timelimit)
        If Len(timelimitstr) = 1 Then timelimitstr = "0" & timelimitstr
        encodedpubkey = encodedpubkey + timelimitstr
        minfeestr = i64tohexlittle(minfee)
        encodedpubkey = encodedpubkey + minfeestr.Substring(0, 10)

        'second pubkey
        encodedpubkey2 = "02" 'compressedkey+seqnum
        encodedpubkey2 = encodedpubkey2 + minfeestr.Substring(10, 6)
        encodedpubkey2 = encodedpubkey2 + "00000000000000000000000000000000000000000000000000000000" 'padding

        'obfuscate public keys
        encodedpubkey = encryptmastercoinpacket(fromadd, 1, encodedpubkey)
        encodedpubkey2 = encryptmastercoinpacket(fromadd, 2, encodedpubkey2)

        'build full keys
        encodedpubkey = "02" & encodedpubkey & "00" 'last 00 will be rotated immediately
        encodedpubkey2 = "02" & encodedpubkey2 & "00" 'last 00 will be rotated immediately


        'validate ECDSA points
        isvalidecdsa = False
        Do While isvalidecdsa = False
            Dim rbyte As String = getrandombyte()
            encodedpubkey = encodedpubkey.Substring(0, 64) & rbyte
            isvalidecdsa = validateecdsa(encodedpubkey)
        Loop

        isvalidecdsa = False
        Do While isvalidecdsa = False
            Dim rbyte As String = getrandombyte()
            encodedpubkey2 = encodedpubkey2.Substring(0, 64) & rbyte
            isvalidecdsa = validateecdsa(encodedpubkey2)
        Loop

        'get public key for from address
        Try

            Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, fromadd, 0, 0)
            Dim validate As JObject = JsonConvert.DeserializeObject(json)

            frompubkey = validate.Item("pubkey")
            If validate.Item("iscompressed").ToString = "False" Then
                'compress public key
                frompubkey = frompubkey.Substring(2, 128)
                If Val(Right(frompubkey, 1)) Mod 2 Then
                    frompubkey = "03" & Left(frompubkey, 64)
                Else
                    frompubkey = "02" & Left(frompubkey, 64)
                End If
            End If
        Catch e As Exception
            MsgBox("Exeption thrown  encodeselltx  validating key: " & e.Message)
        End Try
        If frompubkey = "" Then
            MsgBox("Error locating public key for from address.")
            Exit Function
        End If


        'lookup unspent for from address
        Dim json3 As String = (New Bitcoin).getjson("http://blockchain.info/unspent?active=" + fromadd)
        Dim obj As JObject = JsonConvert.DeserializeObject(json3)
        Dim jOut As JArray = JsonConvert.DeserializeObject(obj.Item("unspent_outputs").ToString)
        For Each Tran In jOut
            'And Tran.Item("addr") = fromadd
            If Val(Tran.Item("value")) > totaltxfee Then
                json3 = (New Bitcoin).getjson("http://blockchain.info/tx-index/" & Tran.Item("tx_index").ToString & "?format=json")
                Dim jHash As JObject = JsonConvert.DeserializeObject(json3)
                '                If jHash.Item("addr") = fromadd Then
                fromtxid = jHash.Item("hash")
                fromtxvout = Tran.Item("tx_output_n")
                fromtxamount = Tran.Item("value")
                '            End If
            End If
        Next

        If fromtxid = "" Or fromtxvout < 0 Or fromtxamount < 0 Then
            MsgBox("Insufficient funds for fee at from address.")
            Exit Function
        End If

        'handle change
        changeamount = (fromtxamount) - totaltxfee

        'build tx hex raw
        txhex = "01000000" 'version
        txhex = txhex & "01" 'vin count
        txhex = txhex & txidtohex(fromtxid) 'input txid hex
        txhex = txhex & i32tohex(fromtxvout) 'input vout 00000000
        txhex = txhex & "00" 'scriptsig length
        txhex = txhex & "ffffffff" 'sequence

        txhex = txhex & "03" 'number of vouts, future: cater for 3 outs (no change) - since we check txin for >totaltxfee there will always be change for now

        'change output
        txhex = txhex & i64tohex(changeamount) 'changeamount value
        txhex = txhex & "19" 'length - 25 bytes
        txhex = txhex & "76a914" & addresstopubkey(fromadd) & "88ac" 'change scriptpubkey
        'exodus output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914946cb2e08075bcbaf157e47bcb67eb2b2339d24288ac" 'exodus scriptpubkey

        'multisig output
        txhex = txhex & i64tohex(txfee * 3)
        txhex = txhex & "69" 'length - ??bytes?? calculate
        txhex = txhex & "51" '???
        txhex = txhex & "21" '???
        txhex = txhex & frompubkey 'first multisig address
        txhex = txhex & "21" '???
        txhex = txhex & encodedpubkey 'second multisig address
        txhex = txhex & "21" '???
        txhex = txhex & encodedpubkey2 'third multisig address
        txhex = txhex & "53ae" '???
        txhex = txhex & "00000000" 'locktime
        txhex = LCase(txhex)
        Return txhex
    End Function
    Public Function encodeaccepttx(ByVal bitcoin_con As bitcoinrpcconnection, ByVal fromadd As String, ByVal toadd As String, ByVal curtype As Integer, ByVal purchaseamount As Long)
        Dim txhex, fromtxid As String
        Dim fromtxvout As Integer = -1
        Dim fromtxamount As Double = -1
        Dim changeamount As Long
        Dim txfee As Long = 6000
        Dim totaltxfee As Long = 50000 'include 0.0002 miner fee
        Dim encodedpubkey, frompubkey As String
        Dim isvalidecdsa As Boolean

        'calculate encoded public key for tx
        encodedpubkey = "01" 'compressedkey+seqnum
        encodedpubkey = encodedpubkey + "00000016" 'simple send
        encodedpubkey = encodedpubkey + i32tohexlittle(curtype)
        encodedpubkey = encodedpubkey + i64tohexlittle(purchaseamount)
        encodedpubkey = encodedpubkey + "0000000000000000000000000000" 'padding

        'obfuscate public key
        encodedpubkey = encryptmastercoinpacket(fromadd, 1, encodedpubkey)

        'build full key
        encodedpubkey = "02" & encodedpubkey & "00" 'last 00 will be rotated immediately

        'validate ECDSA point
        isvalidecdsa = False
        Do While isvalidecdsa = False
            Dim rbyte As String = getrandombyte()
            encodedpubkey = encodedpubkey.Substring(0, 64) & rbyte
            isvalidecdsa = validateecdsa(encodedpubkey)
        Loop

        'get public key for from address
        Try

            Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, fromadd, 0, 0)
            Dim validate As JObject = JsonConvert.DeserializeObject(json)

            frompubkey = validate.Item("pubkey")
            If validate.Item("iscompressed").ToString = "False" Then
                'compress public key
                frompubkey = frompubkey.Substring(2, 128)
                If Val(Right(frompubkey, 1)) Mod 2 Then
                    frompubkey = "03" & Left(frompubkey, 64)
                Else
                    frompubkey = "02" & Left(frompubkey, 64)
                End If
            End If
        Catch e As Exception
            MsgBox("Exeption thrown  encodeselltx  validating key: " & e.Message)
        End Try
        If frompubkey = "" Then
            MsgBox("Error locating public key for from address.")
            Exit Function
        End If

        'lookup unspent for from address
        Dim json3 As String = (New Bitcoin).getjson("http://blockchain.info/unspent?active=" + fromadd)
        Dim obj As JObject = JsonConvert.DeserializeObject(json3)
        Dim jOut As JArray = JsonConvert.DeserializeObject(obj.Item("unspent_outputs").ToString)
        For Each Tran In jOut
            'And Tran.Item("addr") = fromadd
            If Val(Tran.Item("value")) > totaltxfee Then
                json3 = (New Bitcoin).getjson("http://blockchain.info/tx-index/" & Tran.Item("tx_index").ToString & "?format=json")
                Dim jHash As JObject = JsonConvert.DeserializeObject(json3)
                '                If jHash.Item("addr") = fromadd Then
                fromtxid = jHash.Item("hash")
                fromtxvout = Tran.Item("tx_output_n")
                fromtxamount = Tran.Item("value")
                '            End If
            End If
        Next

        If fromtxid = "" Or fromtxvout < 0 Or fromtxamount < 0 Then
            MsgBox("Insufficient funds for fee at from address.")
            Exit Function
        End If

        'handle change
        changeamount = (fromtxamount) - totaltxfee

        'build tx hex raw
        txhex = "01000000" 'version
        txhex = txhex & "01" 'vin count
        txhex = txhex & txidtohex(fromtxid) 'input txid hex
        txhex = txhex & i32tohex(fromtxvout) 'input vout 00000000
        txhex = txhex & "00" 'scriptsig length
        txhex = txhex & "ffffffff" 'sequence

        txhex = txhex & "04" 'number of vouts, future: cater for 3 outs (no change) - since we check txin for >totaltxfee there will always be change for now

        'change output
        txhex = txhex & i64tohex(changeamount) 'changeamount value
        txhex = txhex & "19" 'length - 25 bytes
        txhex = txhex & "76a914" & addresstopubkey(fromadd) & "88ac" 'change scriptpubkey
        'exodus output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914946cb2e08075bcbaf157e47bcb67eb2b2339d24288ac" 'exodus scriptpubkey
        'reference/destination output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914" & addresstopubkey(toadd) & "88ac" 'data scriptpubkey 

        'multisig output
        txhex = txhex & i64tohex(txfee * 2)
        txhex = txhex & "47" 'length - ??bytes?? calculate
        txhex = txhex & "51" '???
        txhex = txhex & "21" '???
        txhex = txhex & frompubkey 'first multisig address
        txhex = txhex & "21" '???
        txhex = txhex & encodedpubkey 'second multisig address
        txhex = txhex & "52ae" '???
        txhex = txhex & "00000000" 'locktime
        txhex = LCase(txhex)
        Return txhex
    End Function

    Public Function encodepaymenttx(ByVal bitcoin_con As bitcoinrpcconnection, ByVal fromadd As String, ByVal toadd As String, ByVal amounttopay As Double)
        Dim txhex, fromtxid As String
        Dim fromtxvout As Integer = -1
        Dim fromtxamount As Double = -1
        Dim changeamount As Long
        Dim txfee As Long = 6000
        Dim encodedpubkey, frompubkey As String
        Dim SatAmounttoPay As Long = amounttopay * 100000000


        'get public key for from address
        Try

            Dim json As String = (New mlib).rpccall(bitcoin_con, "validateaddress", 1, fromadd, 0, 0)
            Dim validate As JObject = JsonConvert.DeserializeObject(json)

            frompubkey = validate.Item("pubkey")
            If validate.Item("iscompressed").ToString = "False" Then
                'compress public key
                frompubkey = frompubkey.Substring(2, 128)
                If Val(Right(frompubkey, 1)) Mod 2 Then
                    frompubkey = "03" & Left(frompubkey, 64)
                Else
                    frompubkey = "02" & Left(frompubkey, 64)
                End If
            End If
        Catch e As Exception
            MsgBox("Exeption thrown validating key: " & e.Message)
        End Try
        If frompubkey = "" Then
            MsgBox("Error locating public key for from address.")
            Exit Function
        End If

        'lookup unspent for from address
        Dim json3 As String = (New Bitcoin).getjson("http://blockchain.info/unspent?active=" + fromadd)
        Dim obj As JObject = JsonConvert.DeserializeObject(json3)
        Dim jOut As JArray = JsonConvert.DeserializeObject(obj.Item("unspent_outputs").ToString)
        For Each Tran In jOut
            If Val(Tran.Item("value")) > SatAmounttoPay + txfee Then
                json3 = (New Bitcoin).getjson("http://blockchain.info/tx-index/" & Tran.Item("tx_index").ToString & "?format=json")
                Dim jHash As JObject = JsonConvert.DeserializeObject(json3)
                '                If jHash.Item("addr") = fromadd Then
                'http://blockchain.info/tx-index/98418277
                fromtxid = jHash.Item("hash")
                fromtxvout = Tran.Item("tx_output_n")
                fromtxamount = Tran.Item("value")
                '            End If
            End If
        Next

        If fromtxid = "" Or fromtxvout < 0 Or fromtxamount < 0 Then
            MsgBox("Insufficient funds for fee at from address.")
            Exit Function
        End If

        'handle change
        changeamount = (fromtxamount) - (SatAmounttoPay + txfee)

        'build tx hex raw
        txhex = "01000000" 'version
        txhex = txhex & "01" 'vin count
        txhex = txhex & txidtohex(fromtxid) 'input txid hex
        txhex = txhex & i32tohex(fromtxvout) 'input vout 00000000
        txhex = txhex & "00" 'scriptsig length
        txhex = txhex & "ffffffff" 'sequence

        txhex = txhex & "03" 'number of vouts, future: cater for 3 outs (no change) - since we check txin for >totaltxfee there will always be change for now

        'change output
        txhex = txhex & i64tohex(changeamount) 'changeamount value
        txhex = txhex & "19" 'length - 25 bytes
        txhex = txhex & "76a914" & addresstopubkey(fromadd) & "88ac" 'change scriptpubkey
        'exodus output
        txhex = txhex & i64tohex(txfee)
        txhex = txhex & "19"
        txhex = txhex & "76a914946cb2e08075bcbaf157e47bcb67eb2b2339d24288ac" 'exodus scriptpubkey
        'reference/destination output
        txhex = txhex & i64tohex(SatAmounttoPay)
        txhex = txhex & "19"
        txhex = txhex & "76a914" & addresstopubkey(toadd) & "88ac" 'data scriptpubkey 

        Return txhex
    End Function


    Public Function getaddresses(ByVal bitcoin_con As bitcoinrpcconnection)
        Dim addresslist As New List(Of btcaddressbal)
        Dim plainaddresslist As New List(Of String)

        'first use listreceivedbyaddress 0 true to get 'all addresses'
        Dim addresses As rcvaddress = JsonConvert.DeserializeObject(Of rcvaddress)(rpccall(bitcoin_con, "listreceivedbyaddress", 2, 0, True, 0))
        For Each result In addresses.result
            plainaddresslist.Add(result.address.ToString)
        Next
        'since documentation is wrong and this does not list all addresses (eg change), use listunspent to gather up any addresses not returned by listreceivedbyaddress
        Dim listunspent As unspent = JsonConvert.DeserializeObject(Of unspent)(rpccall(bitcoin_con, "listunspent", 2, 0, 999999, 0))
        For Each result In listunspent.result
            If Not plainaddresslist.Contains(result.address.ToString) Then 'avoid duplicates
                plainaddresslist.Add(result.address.ToString)
            End If
        Next
        'loop through plainaddresslist and get balances to create addresslist object
        For Each address In plainaddresslist
            Dim addressbal As Double = 0
            Dim uaddressbal As Double = 0
            For Each result In listunspent.result
                If result.address.ToString = address.ToString Then
                    If result.confirmations = 0 Then
                        uaddressbal = uaddressbal + result.amount
                    Else
                        addressbal = addressbal + result.amount
                    End If
                End If
            Next
            Dim addressobj As New btcaddressbal
            addressobj.address = address.ToString
            addressobj.amount = addressbal
            addressobj.uamount = uaddressbal
            addresslist.Add(addressobj)
        Next

        Return addresslist
    End Function
    Public Function getblock(ByVal bitcoin_con As bitcoinrpcconnection, ByVal blockhash As String)
        Try
            Dim block As Block = JsonConvert.DeserializeObject(Of Block)(rpccall(bitcoin_con, "getblock", 1, blockhash, 1, 0))
            Return block
        Catch e As Exception
            MsgBox("Exeption thrown getting block : " & e.Message)
        End Try
    End Function
    Public Function getblocktemplate(ByVal bitcoin_con As bitcoinrpcconnection)
        Try
            Dim blocktemplate As blocktemplate = JsonConvert.DeserializeObject(Of blocktemplate)(rpccall(bitcoin_con, "getblocktemplate", 0, 0, 0, 0))
            Return blocktemplate
        Catch e As Exception
            MsgBox("Exeption thrown getting blocktemplate : " & e.Message)
        End Try
    End Function
    Public Function getblockcount(ByVal bitcoin_con As bitcoinrpcconnection)
        Dim blockcount As blockcount = JsonConvert.DeserializeObject(Of blockcount)(rpccall(bitcoin_con, "getblockcount", 0, 0, 1, 0))
        Return blockcount
    End Function
    Public Function getblockhash(ByVal bitcoin_con As bitcoinrpcconnection, ByVal block As Integer)
        Try
            Dim blockhash As blockhash = JsonConvert.DeserializeObject(Of blockhash)(rpccall(bitcoin_con, "getblockhash", 1, block, 1, 0))
            Return blockhash
        Catch e As Exception
            MsgBox("Exeption thrown getting block hash : " & e.Message)
        End Try
    End Function
    Public Function gettransaction(ByVal bitcoin_con As bitcoinrpcconnection, ByVal txid As String)
        Try
            Dim tx As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, txid, 1, 0))
            Return tx
        Catch e As Exception
            MsgBox("Exeption throwngetting transaction (" & txid & ") : " & e.Message)
        End Try
    End Function
    Public Function ismastercointx(ByVal bitcoin_con As bitcoinrpcconnection, ByVal txid As String)

        Dim tx As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, txid, 1, 0))
        Dim vouts() As Vout = tx.result.vout.ToArray
        Dim ismultisig As Boolean = False
        Dim ismsc As Boolean = False
        Dim txtype As String
        Dim pubkeyhex As String = ""
        Try
            For i = 0 To UBound(vouts)
                If Not IsNothing(vouts(i).scriptPubKey.addresses) Then
                    If vouts(i).scriptPubKey.addresses(0).ToString = "1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P" Then
                        ismsc = True
                    End If
                    'see if Class B
                    If vouts(i).scriptPubKey.type = "multisig" Then 'we get away with using the first input to check tx type for now
                        ismultisig = True
                        ismsc = True
                        Dim asmvars As String() = vouts(i).scriptPubKey.asm.ToString.Split(" ")
                        If pubkeyhex = "" Then pubkeyhex = asmvars(2)
                    End If
                End If
            Next

            If ismsc = True Then
                Dim txinputs As Integer
                Dim txhighvalue As Integer
                Dim txinputadd(1000) As String
                Dim txinputamount(1000) As Double
                Dim exoamount As Double
                txinputs = 0
                'calculate input addresses 
                Dim vins() As Vin = tx.result.vin.ToArray
                'get inputs
                For i = 0 To UBound(vins)
                    'loop through each vin getting txid
                    Dim vinresults As txn = JsonConvert.DeserializeObject(Of txn)(rpccall(bitcoin_con, "getrawtransaction", 2, vins(i).txid.ToString, 1, 0))
                    Dim voutnum As Integer = vins(i).vout
                    'loop through vinresults until voutnum is located and grab address
                    Dim voutarray() As Vout = vinresults.result.vout.ToArray
                    For k = 0 To UBound(voutarray)
                        If voutarray(k).n = voutnum Then
                            'check we haven't seen this input address before
                            If txinputadd.Contains(voutarray(k).scriptPubKey.addresses(0).ToString) Then
                                'get location of address and increase amount
                                For p = 0 To txinputs
                                    If txinputadd(p) = voutarray(k).scriptPubKey.addresses(0).ToString Then
                                        txinputamount(p) = txinputamount(p) + voutarray(k).value
                                        If txinputamount(p) > txinputamount(txhighvalue) Then txhighvalue = p
                                    End If
                                Next
                            Else
                                txinputs = txinputs + 1
                                txinputamount(txinputs) = voutarray(k).value
                                If txinputamount(txinputs) > txinputamount(txhighvalue) Then txhighvalue = txinputs
                                txinputadd(txinputs) = voutarray(k).scriptPubKey.addresses(0).ToString
                            End If
                        End If
                    Next
                Next
                If txinputs > 0 Then
                    'get tx type
                    If ismultisig = False Then
                        'class A, always simple send/generate
                        Return "simple"
                        Exit Function
                    Else
                        'class B, check transaction type
                        'decode transaction
                        Dim cleartext As String = decryptmastercoinpacket(txinputadd(txhighvalue), 1, pubkeyhex.Substring(2, 62))
                        cleartext = "02" & cleartext
                        Dim barray As Byte()
                        barray = multisigbarray(cleartext)
                        Dim transbytes() As Byte = {barray(2), barray(3), barray(4), barray(5)}

                        'handle endianness
                        If BitConverter.IsLittleEndian = True Then
                            Array.Reverse(transbytes)
                        End If


                        Dim transtype As Integer = BitConverter.ToUInt32(transbytes, 0)
                        If transtype = 0 Then
                            Return "simple"
                            Exit Function
                        End If
                        If transtype = 20 Then
                            Return "selloffer"
                            Exit Function
                        End If
                        If transtype = 22 Then
                            Return "acceptoffer"
                            Exit Function
                        End If
                    End If
                End If


            End If
            Return "None"
        Catch e As Exception
            'MsgBox("Exeption thrown checking if " & txid & " is a Mastercoin transaction: " & e.Message)
            'Allow exception for original multisig (can't decode properly) - come back and trap this properly
            Return "None"
        End Try
    End Function
    Public Function addresstopubkey(ByVal address As String)
        Dim hex() As Byte = ToByteArray(address)
        If Not ((hex Is Nothing) OrElse Not (hex.Length <> 21)) Then
            Dim pubkey As String = bytearraytostring(hex, 1, 20)
            Return pubkey
        End If
    End Function
    Public Function txidtohex(ByVal txid As String)
        Dim hex() As Byte = StringToByteArray(txid)
        Array.Reverse(hex)
        If ((hex IsNot Nothing) And (hex.Length = 32)) Then
            Dim txidhex As String = bytearraytostring(hex, 0, 32)
            Return txidhex
        End If
    End Function
    Public Function bytearraytostring(ByVal ba() As Byte, ByVal offset As Integer, ByVal count As Integer)
        Dim rv As String = ""
        Dim usedcount As Integer = 0
        Dim i As Integer = offset
        Do While (usedcount < count)
            rv = (rv + (String.Format("{0:X2}", ba(i))))
            i = i + 1
            usedcount = usedcount + 1
        Loop
        rv = LCase(rv)
        Return rv
    End Function
    Public Function i64tohex(ByVal amount As Long)
        Dim amountbytes() As Byte = BitConverter.GetBytes(amount)
        Dim amounthex As String = bytearraytostring(amountbytes, 0, 8)
        Return amounthex
    End Function
    Public Function i32tohex(ByVal amount As Integer)
        Dim amountbytes() As Byte = BitConverter.GetBytes(amount)
        Dim amounthex As String = bytearraytostring(amountbytes, 0, 4)
        Return amounthex
    End Function
    Public Function i64tohexlittle(ByVal amount As Long)
        Dim amountbytes() As Byte = BitConverter.GetBytes(amount)
        Array.Reverse(amountbytes)
        Dim amounthex As String = bytearraytostring(amountbytes, 0, 8)
        Return amounthex
    End Function
    Public Function i32tohexlittle(ByVal amount As Integer)
        Dim amountbytes() As Byte = BitConverter.GetBytes(amount)
        Array.Reverse(amountbytes)
        Dim amounthex As String = bytearraytostring(amountbytes, 0, 4)
        Return amounthex
    End Function
    Public Function StringToByteArray(ByVal hex As [String]) As Byte()
        Dim NumberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(NumberChars \ 2 - 1) {}
        For i As Integer = 0 To NumberChars - 1 Step 2
            bytes(i \ 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next
        Return bytes
    End Function

End Class
