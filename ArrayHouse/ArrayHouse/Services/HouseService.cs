namespace ArrayHouse.Services
{
    using System.Collections.ObjectModel;

    using Models;
    using Commons;
    using Commons.Enumerations;

    public class HouseService
    {
        public HouseService()
        {
            this.ArrayHouse = new ObservableCollection<House>();
            this.MatrixHouse = new ObservableCollection<ArrayHouse>();
        }

        public ObservableCollection<House> ArrayHouse { get; set; }

        public ObservableCollection<ArrayHouse> MatrixHouse { get; set; }

        #region Methods

        public ObservableCollection<House> InitializeNewArrayHouse(int numberOfHouse, HouseType houseType)
        {
            this.ArrayHouse.Clear();

            string houseUrlPicture = houseType == HouseType.Аctive
                ? UrlPicture.ACTIVE_HOUSE 
                : UrlPicture.INACTIVE_HOUSE;

            for (int i = 1; i <= numberOfHouse; i++)
            {
                ArrayHouse.Add(new House
                {
                    Number = i,
                    HouseType = houseType,
                    UrlPicture = houseUrlPicture,
                });
            }

            return this.ArrayHouse;
        }

        public ObservableCollection<ArrayHouse> InitializeNewMatrixHouse(int days)
        {
            this.MatrixHouse.Clear();

            HouseType[] currentStatus = ReturnCurrentStatus();

            HouseType[] nextStatus = ReturnNextStatus(currentStatus);

            for (int i = 1; i <= days; i++)
            {
                ObservableCollection<House> nextRow = NexRowOfMatrix(nextStatus);

                MatrixHouse.Add(new ArrayHouse
                {
                    Day = i,
                    Houses = nextRow,
                });

                nextStatus = ReturnNextStatus(nextStatus);
            }

            return this.MatrixHouse;
        }

        public void ReverseHouseType(int index)
        {
            House currentHouse = ArrayHouse[index];
            HouseType currentType = currentHouse.HouseType;

            if (currentType == HouseType.Аctive)
            {
                currentHouse.HouseType = HouseType.Inactive;
                currentHouse.UrlPicture = UrlPicture.INACTIVE_HOUSE;
            }
            else
            {
                currentHouse.HouseType = HouseType.Аctive;
                currentHouse.UrlPicture = UrlPicture.ACTIVE_HOUSE;
            }
        }

        private HouseType[] ReturnCurrentStatus()
        {
            HouseType[] currentStatus = new HouseType[ArrayHouse.Count];

            for (int i = 0; i < ArrayHouse.Count; i++)
            {
                if (ArrayHouse[i].HouseType == HouseType.Аctive)
                {
                    currentStatus[i] = HouseType.Аctive;
                }
                else
                {
                    currentStatus[i] = HouseType.Inactive;
                }
            }

            return currentStatus;
        }

        private HouseType[] ReturnNextStatus(HouseType[] currentStatus)
        {
            int length = currentStatus.Length;

            HouseType[] nextStatus = new HouseType[length];

            if (currentStatus.Length == 1)
            {
                return new HouseType[] { HouseType.Inactive };
            }

            if (currentStatus[1] == HouseType.Inactive)
            {
                nextStatus[0] = HouseType.Inactive;
            }
            else
            {
                nextStatus[0] = HouseType.Аctive;
            }

            if (currentStatus[length - 2] == HouseType.Inactive)
            {
                nextStatus[length - 1] = HouseType.Inactive;
            }
            else
            {
                nextStatus[length - 1] = HouseType.Аctive;
            }

            if (currentStatus.Length != 2)
            {
                if (currentStatus[length - 3] == currentStatus[length - 1])
                {
                    nextStatus[length - 2] = HouseType.Inactive;
                }
                else
                {
                    nextStatus[length - 2] = HouseType.Аctive;
                }
            }



            for (int i = 2; i < length - 1; i++)
            {
                if (currentStatus[i] == currentStatus[i - 2])
                {
                    nextStatus[i - 1] = HouseType.Inactive;
                }
                else
                {
                    nextStatus[i - 1] = HouseType.Аctive;
                }
            }

            return nextStatus;
        }

        private ObservableCollection<House> NexRowOfMatrix(HouseType[] status)
        {
            ObservableCollection<House> nextRow = new ObservableCollection<House>();

            for (int i = 0; i < status.Length; i++)
            {
                HouseType currentType = status[i];

                string currentUrlPicture = currentType == HouseType.Аctive
                    ? UrlPicture.ACTIVE_HOUSE
                    : UrlPicture.INACTIVE_HOUSE;

                nextRow.Add(new House
                {
                    Number = i + 1,
                    HouseType = currentType,
                    UrlPicture = currentUrlPicture,
                });
            }

            return nextRow;
        }

        #endregion
    }
}
