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

            mainViewModel.People.Add(new Person("Pesho", 23, 0, 0));
            mainViewModel.People.Add(new Person("Ivan", 12, 0, 10));
            mainViewModel.People.Add(new Person("Gosho", 43, 10, 20));
            mainViewModel.People.Add(new Person("Misho", 83, 20, 30));
            mainViewModel.People.Add(new Person("Misho", 83, 30, 40));
            mainViewModel.People.Add(new Person("Misho", 83, 40, 50));
            mainViewModel.People.Add(new Person("Misho", 83, 50, 60));
        }
    }
}
