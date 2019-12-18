using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace HouseDemoMoving
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = House;

            //Thread thread = new Thread(new ThreadStart(ChangePosition));
            //thread.Start();
        }

        public House House = new House 
        {
            Number = 1,
            XPosition = 0,
            YPosition = 0,
        };

        public void ChangePosition()
        {
            for (int i = 0; i < 1000; i++)
            {
                House.YPosition += 0.1;
                Thread.Sleep(1);
            }
        }

        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {
            House house = new House
            {
                Number = 1,
                XPosition = 0,
                YPosition = 0,
            };

            Canvas canvas = new Canvas();

            int xPosition = 0;

            for (int i = 0; i < 10; i++)
            {
                StackPanel stackPanel = new StackPanel();
                canvas.Children.Add(stackPanel);

                stackPanel.Children.Add(new TextBlock { Text = house.Number.ToString() });

                Canvas.SetLeft(stackPanel, xPosition);
                xPosition += 100;
            }

            MainGrid.Children.Add(canvas);
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            House house = new House
            {
                Number = 1,
                XPosition = 0,
                YPosition = 0,
            };

            Canvas canvas = new Canvas();

            double xPosition = house.XPosition;

            for (int i = 0; i < 10; i++)
            {
                StackPanel stackPanel = new StackPanel();
                canvas.Children.Add(stackPanel);

                stackPanel.Children.Add(new TextBlock { Text = house.Number.ToString() });

                Canvas.SetLeft(stackPanel, xPosition);
                xPosition += 100;
            }

            for (int i = 0; i < 100; i++)
            {
                house.YPosition = i;
            }

            MainGrid.Children.Add(canvas);
        }
    }
}
