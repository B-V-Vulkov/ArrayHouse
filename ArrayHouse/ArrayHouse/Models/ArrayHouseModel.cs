namespace ArrayHouse.Models
{
    using System.Collections.ObjectModel;

    public class ArrayHouseModel
    {
        public ArrayHouseModel()
        {
            this.ArrayHouse = new ObservableCollection<HouseModel>();
        }

        public ArrayHouseModel(ObservableCollection<HouseModel> houseModels)
        {
            this.ArrayHouse = houseModels;
        }

        public int Day { get; set; }

        public ObservableCollection<HouseModel> ArrayHouse { get; set; }

        public int Count => ArrayHouse.Count;
    }
}
