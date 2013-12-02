Imports System
Imports System.Configuration
Imports System.Data
Imports System.XML
Imports System.Web
Imports System.Data.SqlClient

Namespace AWS.DB

    Public Class ConnectDB

        Function ConnectDB() As SqlConnection
            Dim ConnectString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyMastercoins.MDF;Integrated Security=True;User Instance=True"
            If My.Settings.ConnectString <> "" Then
                ConnectString = Trim(My.Settings.ConnectString)
            End If

            Dim myConn As New SqlConnection(ConnectString)
            Return myConn
        End Function

        Public Function SQLdataset(ByVal SQL As String) As DataSet
            Dim myConn = ConnectDB()
            Dim myCom As New SqlCommand(SQL, myConn)
            myConn.Open()
            Dim objAdapter1 As New SqlDataAdapter
            objAdapter1.SelectCommand = myCom
            Dim objDataset1 As New DataSet
            objAdapter1.Fill(objDataset1, "Data")
            myConn.Close()
            Return objDataset1
        End Function

        Function ymd(ByVal DateToConvert As DateTime) As String
            Dim DateTimeFormat As String = "yyyy/MM/dd hh:mm:ss tt"
            Return DateToConvert.ToString(DateTimeFormat)
            'Return DateToConvert.ToString
        End Function

        Public Sub SQLExecute(ByVal SQL As String)
            Dim myConn = ConnectDB()
            Dim myCom = New SqlCommand(SQL, myConn)
            myConn.Open()
            myCom.ExecuteNonQuery()
            myConn.Close()
        End Sub
        Public Function HTMLEncode(ByVal Value As String) As String
            Return Replace(Value, "'", "''")
        End Function
    End Class
End Namespace
