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
    public class RedactionViewModel : ViewModelBase, IContentWindow
    {
        public RedactionViewModel()
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
        private string _info = "Изменение текстового файла";

        public string PathFile
        {
            get => _pathFile;
            set
            {
                this.RaiseAndSetIfChanged(ref _pathFile, value);
               // DataFilling();
            }
        }
        private string _pathFile;

        public TextFile TextFile
        {
            get => _textFile;
            set => this.RaiseAndSetIfChanged(ref _textFile, value);
        }
        private TextFile _textFile;

        public ReactiveCommand<Window, Unit> SaveCommand { get; }
        public ReactiveCommand<Window, Unit> ExitCommand { get; }
        public ReactiveCommand<Window, Task> ChoiceCommand { get; }


        public void DataFilling(Window window)
       {
            if (PathFile is null) return;

            if (!PathFile.EndsWith(".txt") || !File.Exists(PathFile))
            {
                ShowMessage(window, AlertEnum.Warning, "По пути, указанный Вами, ничего не найдено. Также может быть не правильно указан файл с данным расширением!");
                return;
            }    

            FileInfo fileInfo = new FileInfo(PathFile);

            TextFile.Name = fileInfo.Name.Replace(".txt", "");
            TextFile.CreateDate = fileInfo.CreationTime;
            TextFile.Path = fileInfo.DirectoryName;
            TextFile.Text = File.ReadAllText(PathFile);
        }

        public void Save(Window window)
        {
            if (!File.Exists(PathFile) || PathFile is null)
            {
                ShowMessage(window, AlertEnum.Warning, "Путь к файлу не найден. Также был удалён сам файл, который Вы отредактировали!");
                return;
            }

            try
            {
                File.Delete(PathFile);
                string filePath = Path.Combine(TextFile.Path, TextFile.Name + ".txt");
                File.WriteAllText(filePath, TextFile.Text);
                ShowMessage(window, AlertEnum.Info, "Файл успешно отредактирован!");
            }
            catch (Exception ex)
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

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Выбор текстового файла",
                AllowMultiple = false,
                FileTypeFilter = new[] { new FilePickerFileType("Text Files") { Patterns = new[] { "*.txt", "*.text" } } }                                     
            });

            if (files.Count > 0)
            {
                PathFile = files[0].TryGetLocalPath();
                DataFilling(window);
            }
        }
    }
}
