namespace ArrayHouse.Services
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class ShapeService
    {
        public static Grid GetHorizontalLineWithNumber(int number)
        {
            Grid wrapper = new Grid();
            wrapper.Width = 100;
            wrapper.Height = 20;
            wrapper.VerticalAlignment = VerticalAlignment.Center;
            wrapper.HorizontalAlignment = HorizontalAlignment.Center;
            wrapper.ColumnDefinitions.Add(new ColumnDefinition());
            wrapper.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            wrapper.ColumnDefinitions.Add(new ColumnDefinition());

            TextBlock text = new TextBlock();
            text.Text = number.ToString();
            text.Foreground = new SolidColorBrush(Color.FromRgb(14, 138, 164));
            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;

            Line firstLine = CreateHorizontalLine();
            Line secondLine = CreateHorizontalLine();

            Grid.SetColumn(text, 1);
            Grid.SetColumn(firstLine, 0);
            Grid.SetColumn(firstLine, 2);

            wrapper.Children.Add(text);
            wrapper.Children.Add(firstLine);
            wrapper.Children.Add(secondLine);

            return wrapper;
        }

        public static Grid GetVerticalLineWithNumber(int number)
        {
            Grid wrapper = new Grid();
            wrapper.Width = 20;
            wrapper.Height = 80;
            wrapper.VerticalAlignment = VerticalAlignment.Center;
            wrapper.HorizontalAlignment = HorizontalAlignment.Center;
            wrapper.RowDefinitions.Add(new RowDefinition());
            wrapper.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            wrapper.RowDefinitions.Add(new RowDefinition());

            TextBlock text = new TextBlock();
            text.Text = number.ToString();
            text.Foreground = new SolidColorBrush(Color.FromRgb(14, 138, 164));
            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;

            Line firstLine = CreateVerticalLine();
            Line secondLine = CreateVerticalLine();

            Grid.SetRow(text, 1);
            Grid.SetRow(firstLine, 0);
            Grid.SetRow(firstLine, 2);

            wrapper.Children.Add(text);
            wrapper.Children.Add(firstLine);
            wrapper.Children.Add(secondLine);

            return wrapper;
        }

        public static Image GetImage()
        {
            Image image = new Image();
            image.Width = 90;
            image.Height = 70;
            image.Margin = new Thickness(0, 5, 0, 0);

            return image;
        }

        public static Button GetButton()
        {
            Button button = new Button();
            button.Content = "Change";
            Style style = Application.Current.FindResource("ChangeButton") as Style;
            button.Style = style;

            return button;
        }

        private static Line CreateHorizontalLine()
        {
            Line line = new Line();
            line.X2 = 40;
            line.Margin = new Thickness(5);
            line.Stroke = Brushes.White;
            line.StrokeThickness = 1;
            line.VerticalAlignment = VerticalAlignment.Center;

            return line;
        }

        private static Line CreateVerticalLine()
        {
            Line line = new Line();
            line.Y2 = 40;
            line.Margin = new Thickness(5);
            line.Stroke = Brushes.White;
            line.StrokeThickness = 1;
            line.HorizontalAlignment = HorizontalAlignment.Center;

            return line;
        }
    }
}
