namespace ArrayHouse.Models
{
    using System.Collections.ObjectModel;

    public class ArrayHouse
    {
        #region Constructors

        public ArrayHouse()
        {
            this.Houses = new ObservableCollection<HouseModel>();
        }

        public ArrayHouse(int day, ObservableCollection<HouseModel> houses)
        {
            this.Day = day;
            this.Houses = houses;
        }

        #endregion

        #region Properties

        public int Day { get; set; }

        public ObservableCollection<HouseModel> Houses { get; set; }

        public int Count => Houses.Count;

        #endregion

        #region Methods

        public void Add(HouseModel house)
        {
            this.Houses.Add(house);
        }

        #endregion
    }
}
