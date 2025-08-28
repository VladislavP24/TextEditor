using Avalonia.Controls;
using ReactiveUI;
using TextEditor.Views;

namespace TextEditor.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public void ShowMessage(Window window, AlertEnum alertType, string message)
    {
        InfoWindow infoWindow = new InfoWindow();

        if (alertType == AlertEnum.Info)
            infoWindow.ShowWindow(alertType, message);
        else
            infoWindow.ShowWindow(alertType, message, window);
    }
}
