using System.Collections.Generic;

namespace DemoBehavior
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            People = new List<Person>();

            People.Add(new Person { Name = "Ivan 1" });
            People.Add(new Person { Name = "Ivan 2" });
            People.Add(new Person { Name = "Ivan 3" });
            People.Add(new Person { Name = "Ivan 4" });
        }

        public List<Person> People { get; set; }
    }
}
