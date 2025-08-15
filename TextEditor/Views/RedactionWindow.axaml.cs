using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class RedactionWindow : Window
{
    public RedactionWindow()
    {
        InitializeComponent();

        DataContext = new RedactionViewModel(this);
    }
}