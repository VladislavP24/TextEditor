using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Headless.XUnit;
using TextEditor.ViewModels;
using TextEditor.Views;
using Xunit;

namespace TextEditor.Tests.ViewModels
{
    public class ViewModelBaseTests
    {
        [AvaloniaFact]
        public void ShowMessage_WindowIsNotNull_DoesNotThrow()
        {
            // Arrange
            var viewModelBase = new ViewModelBase();
            var creationWindow = new CreationWindow();
            creationWindow.Show();

            //Act
            viewModelBase.ShowMessage(creationWindow, AlertEnum.Error, "Файл повреждён");

            //Assert
            Assert.True(creationWindow.IsActive);
        }

        [AvaloniaFact]
        public void ShowMessage_WindowIsNull_DoesNotThrow()
        {
            // Arrange
            var viewModelBase = new ViewModelBase();
            var creationWindow = new CreationWindow();
            creationWindow.Show();

            //Act
            viewModelBase.ShowMessage(creationWindow, AlertEnum.Info, "Файл повреждён");

            //Assert
            Assert.False(creationWindow.IsActive);
        }
    }
}
