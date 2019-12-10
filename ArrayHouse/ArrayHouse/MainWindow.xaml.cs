using ArrayHouse.Models;
using ArrayHouse.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArrayHouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<HouseModel> Houses { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Houses = new ObservableCollection<HouseModel>();




            ArrayHouses.ItemsSource = this.Houses;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {

        }

<<<<<<< HEAD
        private void CreateNewArrayHouse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Houses.Clear();

            int n = int.Parse(NumberOfHouses.Text);

            if (n == 50)
            {
                NumberOfHouses.Foreground = Brushes.Red;
            }
            else
            {
                NumberOfHouses.Foreground = Brushes.Blue;
            }



            for (int i = 1; i <= n; i++)
            {
                Houses.Add(new HouseModel { HouseType = HouseType.Inactive, Number = i });
            }
        }

        private void NumberOfHouses_TextChanged(object sender, TextChangedEventArgs e)
        {
            NumberOfHouses.Foreground = Brushes.Blue;
        }

        private void NumberOfHouses_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            NumberOfHouses.Foreground = Brushes.Blue;
=======
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {


>>>>>>> fc5d7fcb25748042067f96de5d33b8bb3a4a6103
        }
    }
}
