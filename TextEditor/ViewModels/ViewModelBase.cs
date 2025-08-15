using Avalonia.Controls;
using ReactiveUI;
using TextEditor.Views;

namespace TextEditor.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected void ShowMessage(Window window, AlertEnum alertType, string message)
    {
        InfoWindow infoWindow = new InfoWindow(alertType, message);
        infoWindow.ShowDialog(window);
    }
}
