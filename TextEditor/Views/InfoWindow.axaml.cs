using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TextEditor.ViewModels;

namespace TextEditor.Views;

public partial class InfoWindow : Window
{
    private readonly InfoViewModel _infoViewModel;
    public InfoWindow()
    {
        InitializeComponent();

        _infoViewModel = new InfoViewModel();
        DataContext = _infoViewModel;
    }

    internal void ShowWindow(AlertEnum alertType, string message, Window window = null)
    {
        _infoViewModel.WindowDataFilling(alertType, message);

        if (window == null) 
            this.Show();
        else
            this.ShowDialog(window);
    }
}