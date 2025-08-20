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
    public class ReviewViewModel : ViewModelBase, IContentWindow
    {
        public ReviewViewModel(ReviewWindow reviewWindow)
        {
            ExitCommand = ReactiveCommand.Create(Exit);
            ChoiceCommand = ReactiveCommand.Create(Choice);

            _reviewWindow = reviewWindow;
            TextFile = new TextFile();
        }

        private readonly ReviewWindow _reviewWindow;

        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
        public ReactiveCommand<Unit, Task> ChoiceCommand { get; }

        public string Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }
        private string _info = "Просмотр текстового файла";

        public string Path
        {
            get => _path;
            set
            {
                this.RaiseAndSetIfChanged(ref _path, value);
                DataFilling();
            }
        }
        private string _path;

        public TextFile TextFile
        {
            get => _textFile;
            set => this.RaiseAndSetIfChanged(ref _textFile, value);
        }
        private TextFile _textFile;


        public void DataFilling()
        {
            if (Path == null)
                return;

            if (!Path.EndsWith(".txt") || !File.Exists(Path))
            {
                ShowMessage(_reviewWindow, AlertEnum.Warning, "По пути, указанный Вами, ничего не найдено. Также может быть не правильно указан файл с данным расширением!");
                return;
            }

            FileInfo fileInfo = new FileInfo(Path);

            TextFile.Name = fileInfo.Name.Replace(".txt", "");
            TextFile.CreateDate = fileInfo.CreationTime;
            TextFile.Path = fileInfo.DirectoryName;
            TextFile.Text = File.ReadAllText(Path);
        }

        public void Exit() => _reviewWindow.Close();

        public void Save() => throw new NotImplementedException();

        public async Task Choice()
        {
            var topLevel = TopLevel.GetTopLevel(_reviewWindow);
            if (topLevel is null) return;

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Выбор текстового файла",
                AllowMultiple = false,
                FileTypeFilter = new[] { new FilePickerFileType("Text Files") { Patterns = new[] { "*.txt", "*.text" } } }
            });

            if (files.Count > 0)
            {
                Path = files[0].TryGetLocalPath();
                DataFilling();
            }
        }
    }
}
