using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HouseDemoMoving
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HouseWrapper = new ObservableCollection<StackPanel>();

            IndexesForUpDate = new Stack<int>();
            IndexesForUpDate.Push(1);
            IndexesForUpDate.Push(4);
            IndexesForUpDate.Push(5);
            IndexesForUpDate.Push(7);
            IndexesForUpDate.Push(12);
        }

        private ObservableCollection<StackPanel> HouseWrapper { get; set; }

        private Stack<int> IndexesForUpDate { get; set; }

        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {

            MyScroll.ScrollToEnd();

            MainCanvas.Children.Clear();

            int n = 0;

            for (int i = 0; i < 15; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Test";
                textBlock.Width = 100;

                this.HouseWrapper.Add(new StackPanel());
                HouseWrapper[i].Children.Add(textBlock);

                Canvas.SetLeft(HouseWrapper[i], n);

                MainCanvas.Children.Add(HouseWrapper[i]);

                n += 50;
            }
        }

        private void Move(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Stack<int> currentIndexes = new Stack<int>(IndexesForUpDate);

                while (currentIndexes.Count != 0)
                {
                    int currentI = currentIndexes.Pop();

                    Canvas.SetTop(HouseWrapper[currentI], i);
                }

                Thread.Sleep(10);
                Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            }
        }

        private readonly Action EmptyDelegate = delegate { };
    }
}
