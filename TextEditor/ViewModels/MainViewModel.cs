using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Reactive;
using TextEditor.Views;

namespace TextEditor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel() 
    {
        CreationCommand = ReactiveCommand.Create(Create);
        RedactionCommand = ReactiveCommand.Create(Edit);
        ReviewCommand = ReactiveCommand.Create(Review);
        ExitCommand = ReactiveCommand.Create(Exit);
    }

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
    private string _greeting = "Text Editor";


    public ReactiveCommand<Unit, Unit> CreationCommand { get; }
    public ReactiveCommand<Unit, Unit> RedactionCommand { get; }
    public ReactiveCommand<Unit, Unit> ReviewCommand { get; }
    public ReactiveCommand<Unit, Unit> ExitCommand { get; }


    private void Create()
    {
        CreationWindow window = new CreationWindow();
        window.ShowDialog(GetWindow());
    }

    private void Edit()
    {
        RedactionWindow window = new RedactionWindow();
        window.ShowDialog(GetWindow());
    }

    private void Review()
    {
        ReviewWindow window = new ReviewWindow();
        window.Show();
    }

    private void Exit()
    {
        GetWindow().Close();
    }

    private Window GetWindow() => ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
}
