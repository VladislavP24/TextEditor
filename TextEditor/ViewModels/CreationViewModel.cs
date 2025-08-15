using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using TextEditor.Interfaces;
using TextEditor.Models;
using TextEditor.Views;

namespace TextEditor.ViewModels
{
    public class CreationViewModel : ViewModelBase, IContentWindow
    {
        public CreationViewModel(CreationWindow creationWindow) 
        {
            SaveCommand = ReactiveCommand.Create(Save);
            ExitCommand = ReactiveCommand.Create(Exit);

            _creationWindow = creationWindow;
            TextFile = new TextFile();
        }

        private CreationWindow _creationWindow;

        public string Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }
        private string _info = "Создание нового текстового файла";

        public TextFile TextFile
        {
            get => _textFile;
            set => this.RaiseAndSetIfChanged(ref _textFile, value);
        }
        private TextFile _textFile;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }

        public void Save()
        {
            if (TextFile.Path == null || TextFile.Name == null)
            {
                ShowMessage(_creationWindow, AlertEnum.Warning, "Провести сохрание невозможно. Не заполнен параметр пути или имя файла.");
                return;
            }

            try
            {
                File.WriteAllText(TextFile.Path + '\\' + TextFile.Name + ".txt", TextFile.Text);
                ShowMessage(_creationWindow, AlertEnum.Info, "Файл успешно создан!");
            }
            catch(Exception ex)
            {
                ShowMessage(_creationWindow, AlertEnum.Error, ex.ToString());
                return;
            }
            
            Exit();
        }

        public void Exit() => _creationWindow.Close();
    }
}
