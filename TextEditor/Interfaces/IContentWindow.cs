using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Models;

namespace TextEditor.Interfaces
{
    public interface IContentWindow
    {
        string Info { get; set; }
        TextFile TextFile { get; set; }
        void Save();
        void Exit();
        Task Choice();
    }
}
