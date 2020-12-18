using System;
using _02_KomdoClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_TestKomClaim
{
    [TestClass]
    public class ClaimTest
    {
        private ClaimRepo _repo;
        private ClaimLibrary _data;



        [TestInitialize]

        public void Arrange()
        {
            _repo = new ClaimRepo();
            _data = new ClaimLibrary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);

            _repo.AddDataToList(_data);
        }

        //add method
        [TestMethod]
        public void AddToList()
        {
            // Arrange 
            ClaimLibrary data = new ClaimLibrary();
            data.ClaimID = 1;
            ClaimRepo repository = new ClaimRepo();

            // Act 
            repository.AddDataToList(data);
            ClaimLibrary dataFromDir = repository.GetDataByClaimID(1);

            // Assert 
            Assert.IsNotNull(dataFromDir);
        }

        //Update
        [TestMethod]
        public void UpdateContentTrue()
        {
            //Arrange
            // TestInitialize
            ClaimLibrary newData = new ClaimLibrary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);


            //Act
            bool updateResult = _repo.UpdateDataFromDir(1, newData);

            //Assert
            Assert.IsTrue(updateResult);
        }

        //Update
        [DataTestMethod]
        public void UpdateDataFromDir(int originalClaimID, bool Update)
        {
            //Arrange
            // TestInitialize
            ClaimLibrary newData = new ClaimLibrary(2, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);


            //Act
            bool Result = _repo.UpdateDataFromDir(originalClaimID, newData);

            //Assert
            Assert.AreEqual(Update, Result);
        }

        //Delete
        [TestMethod]
        public void DeleteContentTrue()
        {
            //Arrange

            //act
            bool deleteResult = _repo.RemoveDataFromDir(_data.ClaimID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
    
}
