using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class ReviewWindow : Window
{
    public ReviewWindow()
    {
        InitializeComponent();

        DataContext = new ReviewViewModel(this);
    }
}