namespace ArrayHouse.Models
{
    using System.Collections.ObjectModel;

    public class ArrayHouse
    {
        #region Constructors

        public ArrayHouse()
        {
            this.Houses = new ObservableCollection<House>();
        }

        public ArrayHouse(int day, ObservableCollection<House> houses)
        {
            this.Day = day;
            this.Houses = houses;
        }

        #endregion

        #region Properties

        public int Day { get; set; }

        public ObservableCollection<House> Houses { get; set; }

        public int Count => Houses.Count;

        #endregion

        #region Methods

        public void Add(House house)
        {
            this.Houses.Add(house);
        }

        public void Clear()
        {
            this.Houses.Clear();
        }

        #endregion
    }
}
