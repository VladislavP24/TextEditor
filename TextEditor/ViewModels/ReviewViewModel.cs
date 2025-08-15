using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _reviewWindow = reviewWindow;
            TextFile = new TextFile();
        }

        private readonly ReviewWindow _reviewWindow;

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
    }
}
