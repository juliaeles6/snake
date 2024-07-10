using Snake.View;
using Snake.ViewModel;
using System.Windows;

namespace Snake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow? _mainWindow;
        private MainViewModel _mainViewModel;

        public App()
        {
            Startup += OnStartUp;
        }

        private void OnStartUp(object sender, EventArgs e)
        {
            _mainViewModel = new MainViewModel();
            _mainWindow = new MainWindow()
            {
                DataContext = _mainViewModel
            };



            _mainWindow.Show();
        }
    }

}
