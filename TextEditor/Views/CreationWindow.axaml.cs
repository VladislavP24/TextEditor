using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class CreationWindow : Window
{
    public CreationWindow()
    {
        InitializeComponent();

        DataContext = new CreationViewModel();
    }
}