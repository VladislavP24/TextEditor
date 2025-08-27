using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class RedactionWindow : Window
{
    private RedactionViewModel redactionViewModel { get; set; }
    public RedactionWindow()
    {
        InitializeComponent();

        redactionViewModel = new RedactionViewModel();
        DataContext = redactionViewModel;
    }


    public void TextBox_LostFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e) => redactionViewModel.DataFilling(this);

}