namespace DemoCanvas.Views
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double CanvasStartPosition { get; set; }

        public double CanvasEndPosition { get; set; }

        public Person(string name, int age, double canvasStartPosition, double canvasEndPosition)
        {
            Name = name;
            Age = age;
            CanvasStartPosition = canvasStartPosition;
            CanvasEndPosition = canvasEndPosition;
        }
    }
}
