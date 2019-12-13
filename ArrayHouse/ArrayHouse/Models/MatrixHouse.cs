using System.Collections.ObjectModel;

namespace ArrayHouse.Models
{
    public class MatrixHouse
    {
        public MatrixHouse()
        {
            this.Matrix = new ObservableCollection<ArrayHouse>();
        }

        public ObservableCollection<ArrayHouse> Matrix { get; set; }

        public void Add(ArrayHouse houseModel)
        {
            this.Matrix.Add(houseModel);
        }
    }
}
