namespace ArrayHouse.Services
{
    using Models;
    using Models.Enumerations;
    using System.Collections.ObjectModel;

    public class ArrayHouseService
    {
        public ObservableCollection<HouseModel> ArrayHouse { get; set; }

        public ArrayHouseService()
        {
            this.ArrayHouse = new ObservableCollection<HouseModel>();
        }

        public ObservableCollection<HouseModel> CreateNewArrayHouse(int numberOfHouse, HouseType houseType)
        {
            for (int i = 1; i <= numberOfHouse; i++)
            {
                ArrayHouse.Add(new HouseModel
                {
                    Number = i,
                    HouseType = houseType,
                    UrlPicture = UrlPictureRepository.URL_PICTURE_ACTIVE_HOUSE,
                });
            }

            return this.ArrayHouse;

        }

    }
}
