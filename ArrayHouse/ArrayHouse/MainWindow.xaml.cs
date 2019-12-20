namespace ArrayHouse
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Media;

    using Services;
    using Commons;
    using Commons.Enumerations;
    using System.Collections.Generic;
    using ArrayHouse.Models;
    using System.Windows.Media;
    using System.Windows.Shapes;

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

            this.InitializeHouses = new List<House>();

            this.DataContext = HouseService;
        }

        public List<House> InitializeHouses { get; set; }

        public HouseService HouseService { get; set; }

        public int currentNumberOFHouse { get; set; }

        //TODO: Validate Method
        private int GetNumberOfHouse()
        {
            int numberOfHouse = 0;

            bool isValid = int.TryParse(NumberOfHouses.Text, out numberOfHouse);

            if (!isValid || numberOfHouse <= 0 || numberOfHouse > 100)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_HOUSES;
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

            if (!isValid || days <= 0 || days > 100)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_DAYS;
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

            this.InitializeHouses.Clear();

            var number = GetVerticalNumber(1);

            InitializeCanvas.Children.Add(number);

            for (int i = 0; i < numberOfHouse; i++)
            {

            }

            //if (numberOfHouse != 0)
            //{
            //    HouseService.InitializeNewArrayHouse(numberOfHouse, defaultHouseType);
            //    currentNumberOFHouse = numberOfHouse;
            //}
        }

        private UIElement GetPicture()
        {
            Image image = new Image();

            return image;
        }

        private UIElement GetVerticalNumber(int number)
        {
            Grid grid = new Grid();
            grid.Width = 100;
            grid.Height = 20;

            grid.ColumnDefinitions.Add(new ColumnDefinition ());
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition ());

            TextBlock textBlock = new TextBlock();
            textBlock.Text = number.ToString();
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(14, 138, 164));

            Line firstLine = CreateHorizontalLine();
            Line secondLine = CreateHorizontalLine();

            Grid.SetColumn(firstLine, 0);
            Grid.SetColumn(textBlock, 1);
            Grid.SetColumn(firstLine, 2);

            grid.Children.Add(textBlock);
            grid.Children.Add(firstLine);
            grid.Children.Add(secondLine);

            return grid;
        }

        private Line CreateHorizontalLine()
        {
            Line line = new Line();
            line.X2 = 40;
            line.Margin = new Thickness(5);
            line.Stroke = Brushes.White;
            line.StrokeThickness = 1;
            line.VerticalAlignment = VerticalAlignment.Center;

            return line;
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
            if (currentNumberOFHouse != 0)
            {
                HouseService.InitializeNewArrayHouse(currentNumberOFHouse, defaultHouseType);
                HouseService.InitializeNewMatrixHouse(0);
            }
        }
    }
}