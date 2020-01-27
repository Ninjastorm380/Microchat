Imports System

Friend Module LevenshteinDistance
    Function Compute(ByVal s As String, ByVal t As String) As Integer
        Dim n = s.Length
        Dim m = t.Length
        Dim d = New Integer(n + 1 - 1, m + 1 - 1) {}

        If n = 0 Then
            Return m
        End If

        If m = 0 Then
            Return n
        End If

        Dim i = 0

        While i <= n
            d(i, 0) = Math.Min(Threading.Interlocked.Increment(i), i - 1)
        End While

        Dim j = 0

        While j <= m
            d(0, j) = Math.Min(Threading.Interlocked.Increment(j), j - 1)
        End While

        For i = 1 To n

            For j = 1 To m
                Dim cost = If(t(j - 1) = s(i - 1), 0, 1)
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function
End Module
