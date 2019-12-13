﻿namespace ArrayHouse.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Enumerations;

    public class HouseModel : INotifyPropertyChanged
    {
        #region Fields

        private int number;

        private string urlPicture;

        private HouseType houseType;

        public event PropertyChangedEventHandler PropertyChanged;

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

        #endregion

        #region Methods

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
