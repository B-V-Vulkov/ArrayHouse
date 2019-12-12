using System.Collections.ObjectModel;

namespace ArrayHouse.Models
{
    public class MatrixHouseModel
    {
        public MatrixHouseModel()
        {
            this.Matrix = new ObservableCollection<ArrayHouseModel>();
        }

        public ObservableCollection<ArrayHouseModel> Matrix { get; set; }

        public void Add(ArrayHouseModel houseModel)
        {
            this.Matrix.Add(houseModel);
        }
    }
}
