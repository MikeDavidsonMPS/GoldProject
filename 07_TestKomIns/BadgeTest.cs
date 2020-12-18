using System;
using _03_KomInsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomInsTest
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepo _repo;
        private BadgeAccessDir _data;



        [TestInitialize]

        public void Arrange()
        {
            _repo = new BadgeRepo();
            _data = new BadgeAccessDir(12345, "A7");

            _repo.AddDataToList(_data);
        }

        //add method
        [TestMethod]
        public void AddToList()
        {
            // Arrange 
            BadgeAccessDir data = new BadgeAccessDir();
            data.BadgeID = 12345;
            BadgeRepo repository = new BadgeRepo();

            // Act 
            repository.AddDataToList(data);
            BadgeAccessDir dataFromDir = repository.GetDataByBadgeID(12345);

            // Assert 
            Assert.IsNotNull(dataFromDir);
        }

        //Update
        [TestMethod]
        public void UpdateContentTrue()
        {
            //Arrange
            // TestInitialize
            BadgeAccessDir newData = new BadgeAccessDir(42345, "A7");


            //Act
            bool Result = _repo.UpdateExistingBadgeDir(12345, newData);

            //Assert
            Assert.IsTrue(Result);
        }

        //Update
        [DataTestMethod]
        public void UpdateDataFromDir(int originalBadgeID, bool Update)
        {
            //Arrange
            // TestInitialize
            BadgeAccessDir newData = new BadgeAccessDir(42345, "A7");


            //Act
            bool Result = _repo.UpdateExistingBadgeDir(originalBadgeID, newData);

            //Assert
            Assert.AreEqual(Update, Result);
        }
        
        
        //Display
        [TestMethod]
        public void DisplayIsTrue()
        {
            // Arrange 
            BadgeAccessDir data = new BadgeAccessDir(12345, "A7");
            BadgeRepo repository = new BadgeRepo();

            // Act 
            repository.GetBadgeAccessDir(data);
            BadgeAccessDir dataFromDir = repository.GetBadgeAccessDir(12345);

            // Assert 
            Assert.IsNotNull(dataFromDir);

        }


        //Delete
        [TestMethod]
        public void DeleteContentTrue()
        {
            //Arrange

            //act
            bool deleteResult = _repo.RemoveDataFromBadgeDir(_data.BadgeID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
