Public Class RenderedMessage : Inherits ListBoxItem
    Private ContentPanel As New DockPanel
    Private Line1, Line2 As New Rectangle
    Private B2 As New Border
    Private Base_Username As New TextBlock : Public Property Username As String
        Get
            Return Base_Username.Text
        End Get
        Set(value As String)
            Base_Username.Text = value
        End Set
    End Property
    Private Base_Message As New TextBlock : Public Property Text As String
        Get
            Return Base_Message.Text
        End Get
        Set(value As String)
            Base_Message.Text = value
        End Set
    End Property
    Private Base_ProfilePicture As New Image : Public Property ProfilePicture As BitmapImage
        Get
            Return Base_ProfilePicture.Source
        End Get
        Set(value As BitmapImage)
            Base_ProfilePicture.Source = value
        End Set
    End Property
    Private Base_Image As New Image : Public Property Image As BitmapImage
        Get
            Return Base_Image.Source
        End Get
        Set(value As BitmapImage)
            Base_Image.Source = value
            If Base_Image.Source IsNot Nothing Then
                B2.Visibility = Windows.Visibility.Visible
            Else
                B2.Visibility = Windows.Visibility.Collapsed
            End If
        End Set
    End Property
    Private Base_BackColor As Color = Color.FromArgb(200, 255, 255, 255) : Public Property Backcolor As Color
        Get
            Return Base_BackColor
        End Get
        Set(value As Color)
            Base_BackColor = value
            Me.Background = New SolidColorBrush(Base_BackColor)
        End Set
    End Property
    Private Base_ForeColor As Color = Color.FromArgb(255, 0, 0, 0) : Public Property Forecolor As Color
        Get
            Return Base_ForeColor
        End Get
        Set(value As Color)
            Base_ForeColor = value
            Base_Message.Foreground = New SolidColorBrush(Base_ForeColor)
        End Set
    End Property
    Sub New()
        Me.IsEnabled = False
        Me.Padding = New Thickness(0)
        Me.Margin = New Thickness(0, 0, 1, 3)
        Me.Background = New SolidColorBrush(Base_BackColor)
        Me.BorderBrush = Brushes.Black
        Me.AddChild(ContentPanel)

        Dim B As New Border
        B.Child = Base_ProfilePicture
        B.BorderBrush = Brushes.Black
        B.Background = Brushes.White
        B.VerticalAlignment = Windows.VerticalAlignment.Top
        B.Height = 36
        B.BorderThickness = New Thickness(1)
        B.Padding = New Thickness(1)
        B.Margin = New Thickness(1)
        Base_ProfilePicture.Width = 32
        Base_ProfilePicture.Height = 32
        Base_ProfilePicture.VerticalAlignment = Windows.VerticalAlignment.Top
        ContentPanel.Children.Add(B)

        Line1.Width = 1
        Line1.Stroke = Brushes.Black
        Line1.VerticalAlignment = Windows.VerticalAlignment.Stretch
        ContentPanel.Children.Add(Line1)

        Base_Username.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
        DockPanel.SetDock(Base_Username, Dock.Top)
        Base_Username.Margin = New Thickness(2, 1, 1, 1)
        ContentPanel.Children.Add(Base_Username)

        Line2.Height = 1
        Line2.Stroke = Brushes.Black
        Line2.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
        DockPanel.SetDock(Line2, Dock.Top)
        ContentPanel.Children.Add(Line2)


        B2.Child = Base_Image
        B2.BorderBrush = Brushes.Black
        B2.Background = Brushes.White
        B2.HorizontalAlignment = Windows.HorizontalAlignment.Left
        B2.Height = 204
        B2.Width = 324
        B2.BorderThickness = New Thickness(1)
        B2.Padding = New Thickness(1)
        B2.Margin = New Thickness(1)
        Base_Image.Width = 320
        Base_Image.Height = 200
        DockPanel.SetDock(B2, Dock.Top)
        ContentPanel.Children.Add(B2)
        B2.Visibility = Windows.Visibility.Collapsed

        Base_Message.TextWrapping = TextWrapping.Wrap
        Base_Message.Foreground = New SolidColorBrush(Base_ForeColor)
        DockPanel.SetDock(Base_Message, Dock.Top)
        Base_Message.Margin = New Thickness(2, -2, 0, 1)

        ContentPanel.Children.Add(Base_Message)
    End Sub
End Class