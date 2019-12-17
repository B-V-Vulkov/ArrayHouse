using System;
using System.Windows.Media.Animation;

namespace DemoCanvas.Views
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double CanvasStartPosition { get; set; }

        public double CanvasEndPosition { get; set; }

        public string BeginTime { get; set; }

        public Person()
        {
        }
    }
}
