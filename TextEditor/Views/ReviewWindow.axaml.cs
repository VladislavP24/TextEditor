using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class ReviewWindow : Window
{
    private ReviewViewModel reviewViewModel { get; set; }
    public ReviewWindow()
    {
        InitializeComponent();

        DataContext = new ReviewViewModel(this);
    }

    public void TextBox_LostFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e) => reviewViewModel.DataFilling();
}