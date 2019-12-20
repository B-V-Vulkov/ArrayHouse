namespace ArrayHouse.Models
{
    using Commons.Enumerations;

    public class House : BaseModel
    {
        #region Declarations

        private int number;

        private string urlPicture;

        private HouseType houseType;

        private double xPosition;

        private double yPosition;

        #endregion

        #region Initializations
        #endregion

        #region Properties

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
                NotifyPropertyChanged();
            }
        }

        public string UrlPicture
        {
            get
            {
                return this.urlPicture;
            }
            set
            {
                this.urlPicture = value;
                NotifyPropertyChanged();
            }
        }

        public HouseType HouseType
        {
            get
            {
                return this.houseType;
            }
            set
            {
                this.houseType = value;
                NotifyPropertyChanged();
            }
        }

        public double XPosition
        {
            get
            {
                return this.xPosition;
            }
            set
            {
                this.xPosition = value;
                NotifyPropertyChanged();
            }
        }

        public double YPosition
        {
            get
            {
                return this.yPosition;
            }
            set
            {
                this.yPosition = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods
        #endregion
    }
}
