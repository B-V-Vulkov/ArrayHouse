using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HouseDemoMoving
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private StackPanel stackPanel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
        }

        StackPanel StackPanel
        {
            get
            {
                return this.stackPanel;
            }
            set
            {
                this.stackPanel = value;
                NotifyPropertyChanged();
            }
        }



        private void CreateNewArrayHouse(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();

            int n = 0;

            for (int i = 0; i < 10; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Test";

                this.StackPanel = new StackPanel();
                StackPanel.Children.Add(textBlock);

                Canvas.SetLeft(StackPanel, n);

                MainCanvas.Children.Add(StackPanel);

                n += 50;
            }
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Canvas.SetTop(StackPanel, i);
                Thread.Sleep(10);
                this.UpdateLayout();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
