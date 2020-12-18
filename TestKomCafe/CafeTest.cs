using System;
using _01_KomCafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKomCafe
{
    [TestClass]
    public class CafeTest
    {
        private CafeRepo _repo;
        private CafeLibrary _data;



        [TestInitialize]

        public void Arrange()
        {
            _repo = new CafeRepo();
            _data = new CafeLibrary(1, "BLT", "Bacon Lettuce and Tomato Sandwich", "Pork Bacon Lettuce, Tomato, Mayo and Rye Bread", 4.99);

            _repo.AddDatatoMenu(_data);
        }

        //add method
        [TestMethod]
        public void AddToListNull()
        {
            // Arrange 
            CafeLibrary data = new CafeLibrary();
            data.MealNumber = 1;
            CafeRepo repository = new CafeRepo();

            // Act 
            repository.AddDatatoMenu(data);
            CafeLibrary dataFromDir = repository.GetDataWithMealNumber(1);

            // Assert 
            Assert.IsNotNull(dataFromDir);
        }

         
        //Delete
        [TestMethod]
        public void DeleteContentTrue()
        {
            //Arrange

            //act
            bool deleteResult = _repo.RemoveDataFromDir(_data.MealNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
