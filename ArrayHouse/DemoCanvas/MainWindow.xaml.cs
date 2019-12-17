using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DemoCanvas.ViewModels;
using DemoCanvas.Views;

namespace DemoCanvas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel mainViewModel = new MainViewModel();

            DataContext = mainViewModel;

            mainViewModel.People.Add(new Person
            {
                Name = "Ivan",
                CanvasStartPosition = 0,
                CanvasEndPosition = 0,
                BeginTime = "0:0:0.0",
            });

            mainViewModel.People.Add(new Person
            {
                Name = "Pesho",
                CanvasStartPosition = 0,
                CanvasEndPosition = 20,
                BeginTime = "0:0:0.5",
            });

        }

        private void MyTextBlock_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
