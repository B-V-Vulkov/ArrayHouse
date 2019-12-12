namespace ArrayHouse.Services
{
    using ArrayHouse.Models;
    using System.Collections.Generic;

    public class HouseService
    {
        private MatrixHouseModel Matrix;

        public LinkedList<int> List = new LinkedList<int>();

        public HouseService(int days, ArrayHouseModel currenArrayHouse)
        {
            Days = days;

            CurrenArrayHouse = currenArrayHouse;

            this.Matrix = new MatrixHouseModel();
        }

        public int Days { get; }

        public ArrayHouseModel CurrenArrayHouse { get; }

        public MatrixHouseModel GetMatrixHouseModel()
        {
            return Matrix;
        }
    }
}
