Class MainWindow
    Public VerticalScrollTracker As Double = 0
    Public ZeroedScrollOffset As Double = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Listbox1.AddHandler(ScrollViewer.ScrollChangedEvent, New ScrollChangedEventHandler(AddressOf ScrollChanged))
    End Sub
    Private Sub ScrollChanged(sender As Object, e As ScrollChangedEventArgs)
        VerticalScrollTracker += e.VerticalChange
        ZeroedScrollOffset = e.ExtentHeight - VerticalScrollTracker - e.ViewportHeight
    End Sub
    Private Sub TextBox_PreviewKeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            If Keyboard.Modifiers = ModifierKeys.Shift Then
                If MessageInputBox.Height <= 116 Then

                    MessageInputBox.Height += 16

                End If
                If MessageInputBox.LineCount >= 8 Then
                    MessageInputBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible
                End If
            Else
                MessageInputBox.Height = 20
                MessageInputBox.Text = ""
                e.Handled = True 'TODO: Implement message sending
            End If
        ElseIf e.Key = Key.Back Then
            If MessageInputBox.Text().Count > 0 AndAlso MessageInputBox.Text()(MessageInputBox.CaretIndex - 1) = vbLf Then
                If MessageInputBox.Height > 20 AndAlso MessageInputBox.LineCount <= 8 Then
                    MessageInputBox.Height -= 16
                    MessageInputBox.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
                End If
            End If
        ElseIf e.Key = Key.Delete Then
            If MessageInputBox.Text().Count > 0 AndAlso MessageInputBox.CaretIndex < MessageInputBox.Text().Count AndAlso MessageInputBox.Text()(MessageInputBox.CaretIndex) = vbCr Then
                If MessageInputBox.Height > 20 AndAlso MessageInputBox.LineCount <= 8 Then
                    MessageInputBox.Height -= 16
                    MessageInputBox.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
                End If
            End If
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Listbox1.Items.Clear()
        For x = 1 To 500
            AddMessage(New RenderedMessage With {.Username = "Joe" + x.ToString, .Forecolor = Color.FromArgb(255, 255, 255, 0), .Text = "test text test text test text test text." + "test text test text test text test text test text test text test text test text test text test text test text test text test text"})
        Next
    End Sub
    Sub AddMessage(Message As RenderedMessage)
        Listbox1.Items.Add(Message)
        If ZeroedScrollOffset <= 256 Then
            Listbox1.ScrollIntoView(Listbox1.Items(Listbox1.Items.Count - 1))
        End If
    End Sub

    Private Sub ConversationMenuButton(sender As Object, e As RoutedEventArgs)
        If ConversationMenu.Visibility = Visibility.Collapsed Then
            ConversationMenu.Visibility = Visibility.Visible
        Else
            ConversationMenu.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub AccountsDialogButton_Click(sender As Object, e As RoutedEventArgs) Handles AccountsDialogButton.Click
        With New Accounts
            .ShowInTaskbar = False
            .Owner = Me
            If .ShowDialog = True Then

            End If
        End With
    End Sub

    Private Sub SettingsDialogButton_Click(sender As Object, e As RoutedEventArgs) Handles SettingsDialogButton.Click
        With New Settings
            .ShowInTaskbar = False
            .Owner = Me
            If .ShowDialog = True Then

            End If
        End With
    End Sub
End Class
