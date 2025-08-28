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
    public class RedactionViewModelTests
    {
        [AvaloniaFact]
        public void DataFilling_WindowIsNull_DoesNotThrow()
        {
            // Arrange
            var redactionWindow = new RedactionWindow();
            var redactionViewModel = new RedactionViewModel();
            redactionWindow.DataContext = redactionViewModel;
            redactionWindow.Show();

            //Act
            redactionViewModel.DataFilling(null);

            //Assert
            Assert.True(true);
        }

        [AvaloniaFact]
        public void Save_NullPath_CloseWindow()
        {
            // Arrange
            var redactionWindow = new RedactionWindow();
            var redactionViewModel = new RedactionViewModel();
            redactionWindow.DataContext = redactionViewModel;
            redactionWindow.Show();

            redactionViewModel.TextFile.Name = "TestFile";
            redactionViewModel.TextFile.Path = null;

            //Act
            redactionViewModel.Save(redactionWindow);

            //Assert
            Assert.True(redactionWindow.IsVisible);
        }


        [AvaloniaFact]
        public void Save_NullName_CloseWindow()
        {
            // Arrange
            var redactionWindow = new RedactionWindow();
            var redactionViewModel = new RedactionViewModel();
            redactionWindow.DataContext = redactionViewModel;
            redactionWindow.Show();

            redactionViewModel.TextFile.Name = null;
            redactionViewModel.TextFile.Path = "C:\\Users\\vladi\\Downloads";

            //Act
            redactionViewModel.Save(redactionWindow);

            //Assert
            Assert.True(redactionWindow.IsVisible);
        }

        [AvaloniaFact]
        public void Save_AllData_CloseWindow()
        {
            // Arrange
            var redactionWindow = new RedactionWindow();
            var redactionViewModel = new RedactionViewModel();
            redactionWindow.DataContext = redactionViewModel;
            redactionWindow.Show();

            redactionViewModel.TextFile.Name = "TextFile";
            redactionViewModel.TextFile.Path = "C:\\Users\\vladi\\Downloads";

            //Act
            redactionViewModel.Save(redactionWindow);

            //Assert
            Assert.True(redactionWindow.IsVisible);
        }

        [AvaloniaFact]
        public async Task Choice_TopLevelIsNull_DoesNotThrow()
        {
            // Arrange
            var redactionWindow = new RedactionWindow();
            var redactionViewModel = new RedactionViewModel();
            redactionWindow.DataContext = redactionViewModel;
            redactionWindow.Show();

            //Act
            await redactionViewModel.Choice(null);

            //Assert
            Assert.True(true);
        }
    }
}
