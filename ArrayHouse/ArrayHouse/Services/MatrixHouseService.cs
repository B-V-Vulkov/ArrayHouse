namespace ArrayHouse.Services
{
    using ArrayHouse.Models;
    using System.Collections.Generic;

    public class MatrixHouseService
    {
        private MatrixHouse Matrix;

        public LinkedList<int> List = new LinkedList<int>();

        public MatrixHouseService(int days, ArrayHouse currenArrayHouse)
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
