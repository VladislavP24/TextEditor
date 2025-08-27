using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using TextEditor.Interfaces;
using TextEditor.Models;
using TextEditor.Views;

namespace TextEditor.ViewModels
{
    public class InfoViewModel : ViewModelBase, IContentWindow
    {
        public InfoViewModel(AlertEnum alert, string message)
        {
            ExitCommand = ReactiveCommand.Create<Window>(Exit);
            _message = message;
            TypeAlertDefinition(alert);
        }

        public TextFile TextFile { get; set; }
        public ReactiveCommand<Window, Unit> ExitCommand { get; }

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }
        private string _message;

        public string Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }
        private string _info;

        public void Exit(Window window) => window.Close();

        public void Save(Window window) => throw new NotImplementedException();

        public void TypeAlertDefinition(AlertEnum alert)
        {
            switch (alert)
            {
                case AlertEnum.None:
                    Info = "Тест";
                    break;
                case AlertEnum.Warning:
                    Info = "Предупреждение";
                    break;
                case AlertEnum.Error:
                    Info = "Ошибка";
                    break;
                case AlertEnum.Info:
                    Info = "Информация";
                    break;
                default:
                    break;
            }
        }

        public Task Choice(Window window) => throw new NotImplementedException();
    }


    public enum AlertEnum
    {
        None = 0,
        Warning = 1,
        Error = 2,
        Info = 3
    }
}
