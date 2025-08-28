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
    public class InfoViewModelTests
    {
        [AvaloniaFact]
        public void WindowDataFilling_AlertInfo_InfoWindow()
        {
            // Arrange
            var infoWindow = new InfoWindow();
            var infoViewModel = new InfoViewModel();
            infoWindow.DataContext = infoViewModel;
            infoWindow.Show();

            //Act
            infoViewModel.WindowDataFilling(AlertEnum.Info, "Файл успешно создан!");

            //Assert
            Assert.Equal("Информация", infoViewModel.Info);
            Assert.Equal("Файл успешно создан!", infoViewModel.Message);
        }

        [AvaloniaFact]
        public void WindowDataFilling_AlertError_InfoWindow()
        {
            // Arrange
            var infoWindow = new InfoWindow();
            var infoViewModel = new InfoViewModel();
            infoWindow.DataContext = infoViewModel;
            infoWindow.Show();

            //Act
            infoViewModel.WindowDataFilling(AlertEnum.Error, "Файл повреждён!");

            //Assert
            Assert.Equal("Ошибка", infoViewModel.Info);
            Assert.Equal("Файл повреждён!", infoViewModel.Message);
        }

        [AvaloniaFact]
        public void WindowDataFilling_MessageIsNull_InfoWindow()
        {
            // Arrange
            var infoWindow = new InfoWindow();
            var infoViewModel = new InfoViewModel();
            infoWindow.DataContext = infoViewModel;
            infoWindow.Show();

            //Act
            infoViewModel.WindowDataFilling(AlertEnum.Error, null);

            //Assert
            Assert.Equal("Ошибка", infoViewModel.Info);
            Assert.NotEqual("Файл повреждён!", infoViewModel.Message);
        }
    }
}
