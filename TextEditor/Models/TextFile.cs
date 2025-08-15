using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace TextEditor.Models
{
    public class TextFile : ReactiveObject
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        private string _name;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate
        {
            get => _createDate;
            set => this.RaiseAndSetIfChanged(ref _createDate, value);
        }
        private DateTime _createDate;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path
        {
            get => _path;
            set => this.RaiseAndSetIfChanged(ref _path, value);
        }
        private string _path;

        /// <summary>
        /// Содержание файла
        /// </summary>
        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }
        private string _text;
    }
}
