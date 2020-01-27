Module Serialization
    Public Function SerializeString(Data As String) As String
        Return Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Data))
    End Function
    Public Function DeserializeString(Data As String) As String
        Return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Data))
    End Function
    Public Function SerializeArray(Data As String()) As String
        Dim ConsolidatedString As String = ""
        For Each x In Data
            ConsolidatedString += SerializeString(x) + ":"
        Next
        Return SerializeString(ConsolidatedString.Remove(ConsolidatedString.Count - 1, 1))
    End Function

    Public Function DeserializeArray(Data As String) As String()
        Dim DataArray() As String = Split(DeserializeString(Data), ":")
        For x = 0 To DataArray.Length - 1
            DataArray(x) = DeserializeString(DataArray(x))
        Next
        Return DataArray
    End Function
    Public Function SerializeImage(Data As BitmapImage) As String
        Dim StreamBuffer(Data.StreamSource.Length) As Byte
        Data.StreamSource.Read(StreamBuffer, 0, StreamBuffer.Length)
        Return Convert.ToBase64String(StreamBuffer)
    End Function
    Public Function DeserializeImage(Data As String) As BitmapImage
        Dim StreamBuffer() As Byte = Convert.FromBase64String(Data)
        Dim Image As New BitmapImage
        Image.BeginInit()
        Image.StreamSource = New IO.MemoryStream(StreamBuffer)
        Image.EndInit()
        Return Image
    End Function
End Module