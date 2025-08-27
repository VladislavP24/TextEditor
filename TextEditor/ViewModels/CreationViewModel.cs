using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using TextEditor.Interfaces;
using TextEditor.Models;
using TextEditor.Views;

namespace TextEditor.ViewModels
{
    public class CreationViewModel : ViewModelBase, IContentWindow
    {
        public CreationViewModel() 
        {
            SaveCommand = ReactiveCommand.Create<Window>(Save);
            ExitCommand = ReactiveCommand.Create<Window>(Exit);
            ChoiceCommand = ReactiveCommand.Create<Window, Task>(Choice);
            TextFile = new TextFile();
        }

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

        public ReactiveCommand<Window, Unit> SaveCommand { get; }
        public ReactiveCommand<Window, Unit> ExitCommand { get; }
        public ReactiveCommand<Window, Task> ChoiceCommand { get; }

        public void Save(Window window)
        {
            if (TextFile.Path == null || TextFile.Name == null)
            {
                ShowMessage(window, AlertEnum.Warning, "Провести сохрание невозможно. Не заполнен параметр пути или имя файла.");
                return;
            }

            try
            {
                string filePath = Path.Combine(TextFile.Path, TextFile.Name + ".txt");
                File.WriteAllText(filePath, TextFile.Text);
                ShowMessage(window, AlertEnum.Info, "Файл успешно создан!");
            }
            catch(Exception ex)
            {
                ShowMessage(window, AlertEnum.Error, ex.ToString());
                return;
            }
            
            Exit(window);
        }

        public void Exit(Window window) => window.Close();

        public async Task Choice(Window window)
        {
            var topLevel = TopLevel.GetTopLevel(window);
            if (topLevel is null) return;

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Выбор папки для сохранения",
                AllowMultiple = false
            });

            if (folders.Count > 0)
                TextFile.Path = folders[0].TryGetLocalPath();
        }
    }
}
