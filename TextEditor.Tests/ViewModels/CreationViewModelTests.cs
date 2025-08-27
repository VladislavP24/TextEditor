using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Headless.XUnit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using TextEditor.ViewModels;
using TextEditor.Views;
using Xunit;

namespace TextEditor.Tests
{
    public class CreationViewModelTests
    {

        [AvaloniaFact]
        public void Save_NullPath_CloseWindow()
        {
            // Arrange
            var creationWindow = new CreationWindow();
            var creationViewModel = new CreationViewModel();
            creationWindow.DataContext = creationViewModel;
            creationWindow.Show();

            creationViewModel.TextFile.Name = "TestFile";
            creationViewModel.TextFile.Path = null;

            //Act
            creationViewModel.Save(creationWindow);

            //Assert
            Assert.True(creationWindow.IsVisible);
        }


        [AvaloniaFact]
        public void Save_NullName_CloseWindow()
        {
            // Arrange
            var creationWindow = new CreationWindow();
            var creationViewModel = new CreationViewModel();
            creationWindow.DataContext = creationViewModel;
            creationWindow.Show();

            creationViewModel.TextFile.Name = null;
            creationViewModel.TextFile.Path = "C:\\Users\\vladi\\Downloads";

            //Act
            creationViewModel.Save(creationWindow);

            //Assert
            Assert.True(creationWindow.IsVisible);
        }

        [AvaloniaFact]
        public void Save_FullData_CloseWindow()
        {
            // Arrange
            var creationWindow = new CreationWindow();
            var creationViewModel = new CreationViewModel();
            creationWindow.DataContext = creationViewModel;
            creationWindow.Show();

            creationViewModel.TextFile.Name = "TextFile";
            creationViewModel.TextFile.Path = "C:\\Users\\vladi\\Downloads";

            //Act
            creationViewModel.Save(creationWindow);

            //Assert
            Assert.False(creationWindow.IsVisible);
        }
    }
}
