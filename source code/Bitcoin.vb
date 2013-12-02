Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Numerics
Imports System.Data
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class Bitcoin

    Function getjson(ByVal PostURL As String) As String
        Dim request As WebRequest = WebRequest.Create(PostURL)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim result As String = ""
        Try
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            result = reader.ReadToEnd()
            reader.Close()
            response.Close()
        Catch ex As Exception

        End Try
        Return result
    End Function
    Function GetLastCheckBTC(ByVal LastProcess As String, ByRef BTCPrice As String, ByRef MSCPrice As String) As String
        If LastProcess = "" Then
            LastProcess = Now().ToString
        End If

        If MSCPrice = "" Then
            Dim SQL As String = "select * from z_Data"
            Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
            MSCPrice = DS.Tables(0).Rows(0).Item("MSCBTCPrice").ToString
        End If

        Dim LastProcessed As DateTime = DateTime.Parse(LastProcess)
        If BTCPrice = "" Or DateDiff(DateInterval.Hour, LastProcessed, Now) > 4 Then
            BTCPrice = GetBTCPrice().ToString
            LastProcess = Now().ToString
        End If

        Return LastProcess
    End Function
    Function GetBTCPrice() As Double
        Dim BTCPrice As Long = 0
        Try
            Dim json As String = (New Bitcoin).getjson("https://www.bitstamp.net/api/ticker/")
            Dim obj As New JObject
            obj = JsonConvert.DeserializeObject(json)
            BTCPrice = CDbl(obj.Item("last"))
        Catch ex As Exception
            BTCPrice = 0
        End Try
        Return BTCPrice
    End Function
    Function GetBlockCount() As Long
        Dim BlockCount As Long = 0
        Try
            BlockCount = CInt((New Bitcoin).getjson("http://blockchain.info/q/getblockcount"))
        Catch ex As Exception
            BlockCount = 0
        Finally
            If BlockCount > 0 Then
                Dim SQL As String = "update z_Data set BlockNumber =" & BlockCount
                Call (New AWS.DB.ConnectDB).SQLExecute(SQL)
            Else
                Dim SQL As String = "select BlockNumber from z_Data "
                Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                BlockCount = DS.Tables(0).Rows(0).Item("BlockNumber")
            End If
        End Try
        Return BlockCount
    End Function
    Function GetAddress(ByVal address As String) As DataSet
        Dim SQL As String = "select * from z_Address where z_Address.Address = '" + address + "'"
        Return (New AWS.DB.ConnectDB).SQLdataset(SQL)
    End Function

    Function GetCurrency(ByVal CurrencyID As Integer) As String
        Dim Currency As String = "Unknown ID" + CurrencyID.ToString
        Select Case CurrencyID
            Case 1
                Currency = "MSC"
            Case 2
                Currency = "TMSC"
        End Select
        Return Currency
    End Function
    Public Function StringAsUtf8Bytes(ByVal strData As String) As Byte()
        Dim bytes() As Byte
        ' get unicode string as bytes
        bytes = Encoding.UTF8.GetBytes(strData)
        ' return byte data
        Return bytes
    End Function
    Function stringtohex(ByVal s1 As String) As Byte()
        Dim i As Integer
        Dim res As Byte() = Bitcoin.StringtoByte(s1)
        For i = 0 To s1.Length - 1
            res(i) = Bitcoin.chartohex(s1.Substring(i, 1))
        Next
        Return res
    End Function
    Function ObsXor(ByVal s1 As String, ByVal s2 As String) As String
        Dim i As Integer
        Dim Hex1 As Byte() = stringtohex(s1)
        Dim Hex2 As Byte() = stringtohex(s2)
        Dim Res As String = ""
        For i = 0 To s1.Length - 1
            Dim Ans As Byte = Hex1(i) Xor Hex2(i)
            Res += inttohex(Ans)
        Next
        Return Res
    End Function
    Function GetHash(ByVal Address As String) As String
        '        Address = Address.ToUpper
        Dim Bytes1 As Byte() = StringAsUtf8Bytes(Address)
        'Sha Them
        Dim sha256 As SHA256 = New SHA256Managed()
        Dim hash1 As Byte() = sha256.ComputeHash(Bytes1)
        Return BytetoHexString(hash1)
    End Function
    Function BytetoHexString(ByVal hash1 As Byte()) As String
        Dim Res As String = ""
        For Each Char1 As Integer In hash1
            Dim Hex1 As Integer = Char1 Mod 16
            Dim Hex2 As Integer = (Char1 - Hex1) / 16
            Res += inttohex(Hex2) + inttohex(Hex1)
        Next
        Return Res
    End Function
    Function MSCData(ByVal RawHexDataString As String, ByVal Address As String) As String
        Dim hash1 As String = GetHash(Address)
        Dim Obsfuscated As String = ObsXor(RawHexDataString, hash1)
        Return Obsfuscated
    End Function
    Function Hash160toAddress(ByVal Hash160 As String) As String
        Hash160 = "00" + Hash160
        Dim Bytes As Byte() = StringtoByte(Hash160)
        Dim dataResult As String = Space(CInt(Hash160.Length / 2))
        Dim Bytes2 As Byte() = StringtoByte(dataResult)
        For Index As Integer = 0 To Hash160.Length - 1 Step 2
            Dim Index2 As Integer = CInt(Index / 2)
            Bytes2(Index2) = chartohex(Chr(Bytes(Index))) * 16 + chartohex(Chr(Bytes(Index + 1)))
        Next
        Return Encode(AddCheckSum(Bytes2))
    End Function


    Function EncodeStringtoBTCAddress(ByVal DataString As String) As String
        If DataString.Length = 66 Then
            Dim Bytes As Byte() = Bitcoin.StringtoByte(DataString)
            Dim dataResult As String = Space(33)
            Dim Bytes2 As Byte() = Bitcoin.StringtoByte(dataResult)
            For Index As Integer = 0 To DataString.Length - 1 Step 2
                Dim Index2 As Integer = CInt(Index / 2)
                Bytes2(Index2) = Bitcoin.chartohex(Chr(Bytes(Index))) * 16 + Bitcoin.chartohex(Chr(Bytes(Index + 1)))
            Next
            Return EncodeWithCheckSum(Bytes2)
        Else
            Return "Data String is not 66 " + DataString.Length.ToString
        End If
    End Function
    Function inttohex(ByVal char1 As Integer) As String
        Select Case char1
            Case 10
                Return "a"
            Case 11
                Return "b"
            Case 12
                Return "c"
            Case 13
                Return "d"
            Case 14
                Return "e"
            Case 15
                Return "f"
            Case Else
                Return char1.ToString
        End Select

    End Function
    Function DecodeBTCAddresstoHexString(ByVal DataString As String) As String
        Dim Bytes As Byte() = Decode(DataString)
        Dim Res As String = ""
        For Each Char1 As Integer In Bytes
            Dim Hex1 As Integer = Char1 Mod 16
            Dim Hex2 As Integer = (Char1 - Hex1) / 16
            Res += inttohex(Hex2) + inttohex(Hex1)
        Next
        Return Res
    End Function

    Public Shared Function BytetoString(ByVal B As Byte()) As String
        Return System.Text.Encoding.ASCII.GetString(B)
    End Function
    Public Shared Function StringtoByte(ByVal S As String) As Byte()
        Return System.Text.Encoding.ASCII.GetBytes(S)
    End Function
    Private Const Digits As String = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz"
    Public Shared Function chartohex(ByVal C As Char) As Integer
        Select Case C
            Case "0"
                Return 0
            Case "1"
                Return 1
            Case "2"
                Return 2
            Case "3"
                Return 3
            Case "4"
                Return 4
            Case "5"
                Return 5
            Case "6"
                Return 6
            Case "7"
                Return 7
            Case "8"
                Return 8
            Case "9"
                Return 9
            Case "a"
                Return 10
            Case "b"
                Return 11
            Case "c"
                Return 12
            Case "d"
                Return 13
            Case "e"
                Return 14
            Case "f"
                Return 15
            Case Else
                Return vbNull
        End Select
    End Function

    Private Shared Function GetCheckSum(ByVal data As Byte()) As Byte()

        Dim sha256 As SHA256 = New SHA256Managed()
        Dim hash1 As Byte() = sha256.ComputeHash(data)
        Dim hash2 As Byte() = sha256.ComputeHash(hash1)

        Dim result = New Byte(3) {}
        Buffer.BlockCopy(hash2, 0, result, 0, result.Length)

        Return result
    End Function
    Public Shared Function ConcatArrays(Of T)(ByVal ParamArray arrays As T()()) As T()

        Dim result = New T(arrays.Sum(Function(arr) arr.Length) - 1) {}
        Dim offset As Integer = 0
        For i As Integer = 0 To arrays.Length - 1
            Dim arr = arrays(i)
            Buffer.BlockCopy(arr, 0, result, offset, arr.Length)
            offset += arr.Length
        Next
        Return result
    End Function
    Public Shared Function AddCheckSum(ByVal data As Byte()) As Byte()
        Dim checkSum As Byte() = GetCheckSum(data)
        Dim dataWithCheckSum As Byte() = ConcatArrays(data, checkSum)
        Return dataWithCheckSum
    End Function
    Public Shared Function EncodeWithCheckSum(ByVal data As Byte()) As String
        Return Encode(AddCheckSum(data))
    End Function
    Public Shared Function Encode(ByVal data As Byte()) As String
        ' Decode byte[] to BigInteger
        Dim intData As BigInteger = 0
        Dim i As Integer = 0
        For i = 0 To data.Length - 1
            intData = intData * 256 + data(i)
        Next

        ' Encode BigInteger to Base58 string
        Dim result As String = ""
        While intData > 0
            Dim remainder As Integer = CInt(intData Mod 58)
            intData /= 58
            result = Digits(remainder) & result
        End While
        i = 0
        ' Append `1` for each leading 0 byte
        While i < data.Length AndAlso data(i) = 0
            result = "1"c & result
            i += 1
        End While
        Return result
    End Function
    Public Function Decode(ByVal s As String) As Byte()

        ' Decode Base58 string to BigInteger 
        Dim intData As BigInteger = 0
        For i As Integer = 0 To s.Length - 1
            Dim digit As Integer = Digits.IndexOf(s(i))
            'Slow
            If digit < 0 Then
                Throw New FormatException(String.Format("Invalid Base58 character `{0}` at position {1}", s(i), i))
            End If
            intData = intData * 58 + digit
        Next

        Dim leadingZeroCount As Integer = s.TakeWhile(Function(c) c = "1"c).Count()
        Dim leadingZeros = Enumerable.Repeat(CByte(0), leadingZeroCount)
        ' to big endian
        Dim bytesWithoutLeadingZeros = intData.ToByteArray().Reverse().SkipWhile(Function(b) b = 0)
        'strip sign byte
        Dim result = leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray()
        Return result
    End Function

End Class
