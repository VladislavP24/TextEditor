using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using TextEditor.Models;

namespace TextEditor.Interfaces
{
    public interface IContentWindow
    {
        string Info { get; set; }
        TextFile TextFile { get; set; }
        void Save(Window window);
        void Exit(Window window);
        Task Choice(Window window);
    }
}
