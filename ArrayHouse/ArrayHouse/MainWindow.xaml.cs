using ArrayHouse.Models;
using ArrayHouse.Models.Enumerations;
using ArrayHouse.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ArrayHouse
{
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

        MatrixHouse Matrix { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.Houses = new ObservableCollection<HouseModel>();

            this.Matrix = new MatrixHouse();

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

        private void Execute(object sender, RoutedEventArgs e)
        {
            int[] currentStatus = new int[numberOfHouse];
            int[] nextStatus = new int[currentStatus.Length];

            for (int i = 0; i < numberOfHouse; i++)
            {
                if (Houses[i].HouseType == HouseType.Аctive)
                {
                    currentStatus[i] = 1;
                }
            }

            if (currentStatus[1] == 0)
            {
                nextStatus[0] = 0;
            }
            else
            {
                nextStatus[0] = 1;
            }

            if (currentStatus[currentStatus.Length - 2] == 0)
            {
                nextStatus[nextStatus.Length - 1] = 0;
            }
            else
            {
                nextStatus[nextStatus.Length - 1] = 1;
            }

            if (currentStatus[currentStatus.Length - 3] == currentStatus[currentStatus.Length - 1])
            {
                nextStatus[nextStatus.Length - 2] = 0;
            }
            else
            {
                nextStatus[nextStatus.Length - 2] = 1;
            }

            for (int i = 2; i < currentStatus.Length - 1; i++)
            {
                if (currentStatus[i] == currentStatus[i - 2])
                {
                    nextStatus[i - 1] = 0;
                }
                else
                {
                    nextStatus[i - 1] = 1;
                }
            }

            Models.ArrayHouse arrayHouseModel = new Models.ArrayHouse();

            for (int i = 0; i < numberOfHouse; i++)
            {
                var currentType = HouseType.Аctive;
                var currentUrlPicture = URL_PICTURE_ACTIVE_HOUSE;

                if (nextStatus[i] == 0)
                {
                    currentType = HouseType.Inactive;
                    currentUrlPicture = URL_PICTURE_INACTIVE_HOUSE;
                }

                HouseModel currentHouse = new HouseModel
                {
                    Number = i,
                    HouseType = currentType,
                    UrlPicture = currentUrlPicture,
                };

                arrayHouseModel.Add(currentHouse);
            }

            Matrix.Add(arrayHouseModel);


        }

        private void Reset(object sender, RoutedEventArgs e)
        {

        }
    }
}