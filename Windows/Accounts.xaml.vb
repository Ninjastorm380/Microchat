Public Class Accounts
    Private Sub TabControl_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Me.Title = "Microchat - " + e.AddedItems(0).Tag.ToString
    End Sub

    Private Sub LoginRecoveryButtonClicked(sender As Object, e As RoutedEventArgs)
        AccountFramesManager.SelectedIndex = 1
    End Sub

    Private Sub ReturnToLoginButtonClicked(sender As Object, e As RoutedEventArgs)
        AccountFramesManager.SelectedIndex = 0
    End Sub
End Class
