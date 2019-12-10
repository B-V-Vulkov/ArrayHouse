namespace ArrayHouse.ViewModel
{
    using System.Collections.ObjectModel;

    using Models;
    using Models.Enumerations;

    public class HouseViewModel
    {
        public HouseViewModel()
        {
            this.Houses = new ObservableCollection<HouseModel>();

            Houses.Add(new HouseModel { HouseType = HouseType.Inactive });
        }

        public ObservableCollection<HouseModel> Houses { get; set; }

    }
}
