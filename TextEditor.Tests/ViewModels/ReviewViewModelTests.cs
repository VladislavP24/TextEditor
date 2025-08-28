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
    public class ReviewViewModelTests
    {
        [AvaloniaFact]
        public void DataFilling_WindowIsNull_DoesNotThrow()
        {
            // Arrange
            var reviewWindow = new ReviewWindow();
            var reviewViewModel = new ReviewViewModel();
            reviewWindow.DataContext = reviewViewModel;
            reviewWindow.Show();

            //Act
            reviewViewModel.DataFilling(null);

            //Assert
            Assert.True(true);
        }

        [AvaloniaFact]
        public async Task Choice_TopLevelIsNull_DoesNotThrow()
        {
            // Arrange
            var reviewWindow = new ReviewWindow();
            var reviewViewModel = new ReviewViewModel();
            reviewWindow.DataContext = reviewViewModel;
            reviewWindow.Show(); ;

            //Act
            await reviewViewModel.Choice(null);

            //Assert
            Assert.True(true);
        }
    }
}
