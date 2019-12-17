using DemoCanvas.Views;
using System.Collections.Generic;

namespace DemoCanvas.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            People = new List<object>();

            People.Add(new
            {
                CanvasStartPosition = 0,
                CanvasEndPosition = 0,
                BeginTime = "0:0:0.0",

                Person = new Person 
                {
                    Name = "Person 1",
                    Age = 32,
                }
            });

            People.Add(new
            {
                CanvasStartPosition = 0,
                CanvasEndPosition = 20,
                BeginTime = "0:0:0.5",

                Person = new Person
                {
                    Name = "Person 2",
                    Age = 23,
                }
            });

            People.Add(new
            {
                CanvasStartPosition = 20,
                CanvasEndPosition = 40,
                BeginTime = "0:0:1.0",

                Person = new Person
                {
                    Name = "Person 3",
                    Age = 23,
                }
            });
        }

        public List<object> People { get; set; }
    }
}
