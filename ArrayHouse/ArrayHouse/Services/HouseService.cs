namespace ArrayHouse.Services
{
    using ArrayHouse.Models;
    using System.Collections.Generic;

    public class HouseService
    {
        private MatrixHouse Matrix;

        public LinkedList<int> List = new LinkedList<int>();

        public HouseService(int days, ArrayHouse currenArrayHouse)
        {
            Days = days;

            CurrenArrayHouse = currenArrayHouse;

            this.Matrix = new MatrixHouse();
        }

        public int Days { get; }

        public ArrayHouse CurrenArrayHouse { get; }

        public MatrixHouse GetMatrixHouseModel()
        {
            return Matrix;
        }
    }
}
