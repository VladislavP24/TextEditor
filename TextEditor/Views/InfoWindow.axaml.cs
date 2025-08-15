using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class InfoWindow : Window
{
    public InfoWindow()
    {
        InitializeComponent();
    }

    public InfoWindow(AlertEnum alert, string message)
    {
        InitializeComponent();

        DataContext = new InfoViewModel(this, alert, message);
    }
}