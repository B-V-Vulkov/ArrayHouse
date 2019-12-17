using DemoCanvas.Views;
using System.Collections.Generic;
using System.Threading;

namespace DemoCanvas.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }
    }
}
