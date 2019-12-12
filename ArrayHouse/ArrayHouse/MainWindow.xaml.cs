using ArrayHouse.Models;
using ArrayHouse.Models.Enumerations;
using ArrayHouse.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        #region Private

        private const string URL_PICTURE_ACTIVE_HOUSE = "./Resources/Images/Houses/ActiveHouse.png";

        private const string URL_PICTURE_INACTIVE_HOUSE = "./Resources/Images/Houses/INActiveHouse.png";

        private int numberOfHouse =>
            int.Parse(NumberOfHouses.Text);

        private HouseType defaultHouseType =>
            DefaultHouseTypeIsActive.IsChecked == true ? HouseType.Аctive : HouseType.Inactive;

        private string defaultHouseUrlPicture =>
            DefaultHouseTypeIsActive.IsChecked == true ? URL_PICTURE_ACTIVE_HOUSE : URL_PICTURE_INACTIVE_HOUSE;

        private int days => int.Parse(Days.Text);
        private int currentDay;

        public HouseService service { get; set; }

        #endregion

        public ObservableCollection<HouseModel> Houses { get; set; }

        MatrixHouseModel Matrix { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.Houses = new ObservableCollection<HouseModel>();

            this.Matrix = new MatrixHouseModel();

            Array.ItemsSource = Houses;

            this.DataContext = Matrix;
        }

        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {
            this.Houses.Clear();

            for (int i = 1; i <= numberOfHouse; i++)
            {
                Houses.Add(new HouseModel
                {
                    Number = i,
                    HouseType = defaultHouseType,
                    UrlPicture = defaultHouseUrlPicture,
                });
            }
        }

        private void ChangeHouseType(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int number = int.Parse(button.CommandParameter.ToString());

            HouseType currentHouseType = Houses[number -1].HouseType;

            if (currentHouseType == HouseType.Аctive)
            {
                Houses[number - 1].UrlPicture = URL_PICTURE_INACTIVE_HOUSE;
                Houses[number - 1].HouseType = HouseType.Inactive;
            }
            else
            {
                Houses[number - 1].UrlPicture = URL_PICTURE_ACTIVE_HOUSE;
                Houses[number - 1].HouseType = HouseType.Аctive;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= days; i++)
            {
                var currentArray = new ArrayHouseModel(Houses);
                this.Matrix.Add(currentArray);
            }
        }
    }
}