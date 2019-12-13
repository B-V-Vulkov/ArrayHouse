namespace ArrayHouse
{
    using System.Windows;
    using System.Windows.Controls;

    using Services;
    using Commons;
    using Commons.Enumerations;
    using System;

    public partial class MainWindow : Window
    {
        private HouseType defaultHouseType =>
            DefaultHouseTypeIsActive.IsChecked == true 
            ? HouseType.Аctive 
            : HouseType.Inactive;

        public MainWindow()
        {
            InitializeComponent();

            this.HouseService = new HouseService();

            this.DataContext = HouseService;
        }

        public HouseService HouseService { get; set; }

        //TODO: Validate Method
        private int GetNumberOfHouse()
        {
            int numberOfHouse = 0;

            bool isValid = int.TryParse(NumberOfHouses.Text, out numberOfHouse);

            if (!isValid || numberOfHouse < 0 || numberOfHouse > 100)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_HOUSES;
                numberOfHouse = 0;
            }
            else
            {
                ErrorMessageBlock.Text = String.Empty;
            }

            return numberOfHouse;
        }

        private int GetDays()
        {
            int days = 0;

            bool isValid = int.TryParse(Days.Text, out days);

            if (!isValid || days < 0 || days > 100)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_DAYS;
                days = 0;
            }
            else
            {
                ErrorMessageBlock.Text = String.Empty;
            }

            return days;
        }

        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {
            int numberOfHouse = GetNumberOfHouse();

            if (numberOfHouse != 0)
            {
                HouseService.InitializeNewArrayHouse(numberOfHouse, defaultHouseType);
            }
        }

        private void ChangeHouseType(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int index = int.Parse(button.CommandParameter.ToString());

            HouseService.ReverseHouseType(index - 1);
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            int days = GetDays();

            if (days != 0)
            {
                HouseService.InitializeNewMatrixHouse(days);
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            int numberOfHouse = GetNumberOfHouse();

            if (numberOfHouse != 0)
            {
                HouseService.InitializeNewArrayHouse(numberOfHouse, defaultHouseType);
                HouseService.InitializeNewMatrixHouse(0);
            }
        }
    }
}