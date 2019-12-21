﻿namespace ArrayHouse
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Media;

    using Services;
    using Commons;
    using Commons.Enumerations;
    using System.Collections.Generic;
    using Models;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        #region Declarations

        private HouseType defaultHouseType =>
            DefaultHouseTypeIsActive.IsChecked == true
            ? HouseType.Аctive
            : HouseType.Inactive;

        #endregion

        #region Initializations

        public MainWindow()
        {
            InitializeComponent();

            this.InitializationListOfHouses = new List<House>();

            InitializationListOfHouses.Add(new House { UrlPicture = UrlPicture.ACTIVE_HOUSE });

            this.HouseService = new HouseService();

            this.DataContext = this;
        }

        public string testImage { get; set; } = UrlPicture.ACTIVE_HOUSE;

        #endregion

        #region Properties

        public List<House> InitializationListOfHouses { get; set; }

        #endregion

        public HouseService HouseService { get; set; }

        public int currentNumberOFHouse { get; set; }

        public string testUrl { get; set; } = UrlPicture.ACTIVE_HOUSE;

        #region Methods

        private void CreateInitializationHouses(object sender, RoutedEventArgs e) 
        {
            InitializationListOfHouses.Clear();
            CanvasForInitializationHouses.Children.Clear();

            //get number of house
            int numberOfHouses = 10;

            //get default type of house
            HouseType defaultHouseType = HouseType.Аctive;

            //for (int i = 0; i < numberOfHouses; i++)
            //{
                InitializationListOfHouses.Add(new House
                {
                    Number = 0 + 1,
                    UrlPicture = UrlPicture.INACTIVE_HOUSE,
                    HouseType = defaultHouseType,
                    XPosition = (0 * 100),
                    YPosition = 0,
                });

                StackPanel stackPanel = new StackPanel();

                Image image = new Image();
                image.Width = 100;

                Binding binding = new Binding();
                binding.Source = InitializationListOfHouses[0].UrlPicture;
            binding.Path = new PropertyPath("InitializationListOfHouses[(0)].UrlPicture");
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                image.SetBinding(Image.SourceProperty, binding);

                Button button = new Button();
                button.Height = 30;
                button.Click += ChangePic;
                button.CommandParameter = 0;

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(button);

                Canvas.SetLeft(stackPanel, InitializationListOfHouses[0].XPosition);


                CanvasForInitializationHouses.Children.Add(stackPanel);
            //}

            CanvasForInitializationHouses.Width = 100 * numberOfHouses;












        }

        public void ChangePic(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.CommandParameter.ToString());

            InitializationListOfHouses[index].UrlPicture = UrlPicture.ACTIVE_HOUSE;
            InitializationListOfHouses[index].HouseType = HouseType.Аctive;


        }

        #endregion

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

            this.InitializationListOfHouses.Clear();

            var number = GetVerticalNumber(1);

           

            for (int i = 0; i < numberOfHouse; i++)
            {
                var test = ShapeService.Get();
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

        private void testsss(object sender, RoutedEventArgs e)
        {
            InitializationListOfHouses[0].UrlPicture = UrlPicture.INACTIVE_HOUSE;
        }
    }
}