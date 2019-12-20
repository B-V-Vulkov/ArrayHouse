namespace ArrayHouse.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BaseModel : INotifyPropertyChanged
    {
        #region Declarations

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Initializations
        #endregion

        #region Properties
        #endregion

        #region Methods

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
