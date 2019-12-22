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
    using Models;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;
    using System.Threading;

    public partial class MainWindow : Window
    {
        #region Declarations

        private HouseType defaultType;

        private string defaultUrlPicture;

        #endregion

        #region Initializations

        public MainWindow()
        {
            InitializeComponent();

            this.InitializationList = new List<House>();

            this.DataContext = this;
        }

        #endregion

        #region Properties

        public List<House> InitializationList { get; set; }

        #endregion

        #region Methods

        private void CreateInitializationList(object sender, RoutedEventArgs e) 
        {
            //Validate Inputs
            if (!IsValidInputs())
            {
                return;
            }

            //Reset
            InitializationList.Clear();
            InitializationPanel.Children.Clear();

            //Add vertical Line for start day
            Grid verticalLine = ShapeService.GetVerticalLineWithNumber(0);
            InitializationPanel.Children.Add(verticalLine);

            //Set defaultType
            defaultType = DefaultHouseTypeIsActive.IsChecked == true
                ? HouseType.Аctive
                : HouseType.Inactive;

            //Set defaultUrlPicture
            defaultUrlPicture = defaultType == HouseType.Аctive
                ? UrlPicture.ACTIVE_HOUSE
                : UrlPicture.INACTIVE_HOUSE;

            //Get number of elements
            int numberOfElements = int.Parse(NumberOfHouses.Text);

            for (int i = 0; i < numberOfElements; i++)
            {
                InitializationList.Add(new House
                {
                    Number = i + 1,
                    UrlPicture = defaultUrlPicture,
                    HouseType = defaultType,
                });

                StackPanel wrapper = new StackPanel();

                Grid horizontalLine = ShapeService.GetHorizontalLineWithNumber(i + 1);
                Image image = ShapeService.GetImage();
                Binding binding = new Binding();
                binding.Source = InitializationList;
                binding.Path = new PropertyPath($"[{i}].UrlPicture");
                image.SetBinding(Image.SourceProperty, binding);
                Button button = ShapeService.GetButton();
                button.Click += ReverseImage;
                button.CommandParameter = i;

                wrapper.Children.Add(horizontalLine);
                wrapper.Children.Add(image);
                wrapper.Children.Add(button);

                InitializationPanel.Children.Add(wrapper);
            }
        }

        private void ReverseImage(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.CommandParameter.ToString());

            var currentType = InitializationList[index].HouseType;

            if (currentType == HouseType.Аctive)
            {
                InitializationList[index].UrlPicture = UrlPicture.INACTIVE_HOUSE;
                InitializationList[index].HouseType = HouseType.Inactive;
            }
            else
            {
                InitializationList[index].UrlPicture = UrlPicture.ACTIVE_HOUSE;
                InitializationList[index].HouseType = HouseType.Аctive;
            }
        }

        #endregion

        private void Play(object sender, RoutedEventArgs e)
        {
            //Reset
            PlaygroundCanvas.Children.Clear();

            Grid verticalLine = ShapeService.GetVerticalLineWithNumber(0);
            Canvas.SetTop(verticalLine, 20);
            PlaygroundCanvas.Children.Add(verticalLine);

            List<Image> racerList = new List<Image>();

            //Create start day
            for (int i = 0; i < InitializationList.Count; i++)
            {
                Grid horizontalLine = ShapeService.GetHorizontalLineWithNumber(i + 1);
                Canvas.SetLeft(horizontalLine, 20 + (i * 100));

                Image image = ShapeService.GetImage();
                image.Source = new BitmapImage(new Uri(UrlPicture.ACTIVE_HOUSE, UriKind.Relative));
                Canvas.SetLeft(image, 20 + (i * 100));
                Canvas.SetTop(image, 20);

                racerList.Add(image);

                PlaygroundCanvas.Children.Add(horizontalLine);
                PlaygroundCanvas.Children.Add(image);
            }

            //Get number of days
            int numberOfDays = int.Parse(NumberOfDays.Text);

            for (int i = 1; i <= numberOfDays; i++)
            {
                //Create vertical line for next day
                Grid currentDay = ShapeService.GetVerticalLineWithNumber(i);
                Canvas.SetTop(currentDay, 20 + (i * 90));
                PlaygroundCanvas.Children.Add(currentDay);

                //To Add Get Method
                var moveList = new List<int>() { 1, 2, 3, 5 };

                for (int j = 1; j <= 90; j++)
                {
                    Stack<int> currentIndexes = new Stack<int>(moveList);

                    while (currentIndexes.Count != 0)
                    {
                        int index = currentIndexes.Pop();

                        var currentPosition = Canvas.GetTop(racerList[index]);

                        Canvas.SetTop(racerList[index], currentPosition + j);
                    }

                    Thread.Sleep(10);
                    this.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                }
            }
        }

        private readonly Action EmptyDelegate = delegate { };

        private void Reset(object sender, RoutedEventArgs e)
        {
            foreach (var element in InitializationList)
            {
                element.UrlPicture = defaultUrlPicture;
                element.HouseType = defaultType;
            }

            PlaygroundCanvas.Children.Clear();
        }

        private bool IsValidInputs()
        {
            int numberOfElements = 0;
            int numberOfDays = 0;

            bool isValidNumberOfElements = 
                int.TryParse(NumberOfHouses.Text, out numberOfElements);

            bool isValidNumberOfDays =
                int.TryParse(NumberOfDays.Text, out numberOfDays);

            if (!isValidNumberOfElements || numberOfElements > 100 || numberOfElements < 1)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_HOUSES;
                return false;
            }
            else if (!isValidNumberOfDays || numberOfDays > 100 || numberOfDays < 1)
            {
                ErrorMessageBlock.Text = ErrorMessage.INVALID_NUMBER_OF_DAYS;
                return false;
            }

            ErrorMessageBlock.Text = String.Empty;
            return true;
        }
    }
}