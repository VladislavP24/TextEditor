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
    public class RedactionViewModel : ViewModelBase, IContentWindow
    {
        public RedactionViewModel(RedactionWindow redactionWindow)
        {
            SaveCommand = ReactiveCommand.Create(Save);
            ExitCommand = ReactiveCommand.Create(Exit);

            _redactionWindow = redactionWindow;
            TextFile = new TextFile();
        }

        private RedactionWindow _redactionWindow;

        public string Info
        {
            get => _info;
            set => this.RaiseAndSetIfChanged(ref _info, value);
        }
        private string _info = "Изменение текстового файла";

        public string Path
        {
            get => _path;
            set
            {
                this.RaiseAndSetIfChanged(ref _path, value);
               // DataFilling();
            }
        }
        private string _path;

        public TextFile TextFile
        {
            get => _textFile;
            set => this.RaiseAndSetIfChanged(ref _textFile, value);
        }
        private TextFile _textFile;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }


        public void DataFilling()
       {
            if (!Path.EndsWith(".txt") || !File.Exists(Path))
            {
                ShowMessage(_redactionWindow, AlertEnum.Warning, "По пути, указанный Вами, ничего не найдено. Также может быть не правильно указан файл с данным расширением!");
                return;
            }    

            FileInfo fileInfo = new FileInfo(Path);

            TextFile.Name = fileInfo.Name.Replace(".txt", "");
            TextFile.CreateDate = fileInfo.CreationTime;
            TextFile.Path = fileInfo.DirectoryName;
            TextFile.Text = File.ReadAllText(Path);
        }

        public void Save()
        {
            if (!File.Exists(Path) || Path == null)
            {
                ShowMessage(_redactionWindow, AlertEnum.Warning, "Путь к файлу не найден. Также был удалён сам файл, который Вы отредактировали!");
                return;
            }

            try
            {
                File.Delete(Path);
                File.WriteAllText(TextFile.Path + '\\' + TextFile.Name + ".txt", TextFile.Text);
                ShowMessage(_redactionWindow, AlertEnum.Info, "Файл успешно отредактирован!");
            }
            catch (Exception ex)
            {
                ShowMessage(_redactionWindow, AlertEnum.Error, ex.ToString());
                return;
            }

            Exit();
        }

        public void Exit() => _redactionWindow.Close();
    }
}
