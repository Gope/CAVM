using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using IDevign.M3.CAVM.ViewModels;

namespace IDevign.M3.CAVM.App
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"Assets/photos/", "*.jpg");

            var mainWindow = new MainWindow
                {
                    // This represents an external (business) ViewModel
                    DataContext = new MainViewModel
                        {
                            Images = new ObservableCollection<string>(filePaths)
                        }
                };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
