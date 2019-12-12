namespace ArrayHouse.Models
{
    using System.Collections.ObjectModel;

    public class ArrayHouseModel
    {
        public ArrayHouseModel(int day)
        {
            this.Day = day;
            this.ArrayHouse = new ObservableCollection<HouseModel>();
        }

        public int Day { get; set; }

        public ObservableCollection<HouseModel> ArrayHouse { get; set; }
    }
}
