using System;
using _02_KomdoClaimsClassLibary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_TestKomClaim
{
    [TestClass]
    public class CafeTest
    {
        private ClaimRepo _repo;
        private ClaimLibary _data;



        [TestInitialize]

        public void Arrange()
        {
            _repo = new ClaimRepo();
            _data = new ClaimLibary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);

            _repo.AddDataToList(_data);
        }

        //add method
        [TestMethod]
        public void AddToList_Null()
        {
            // Arrange 
            ClaimLibary data = new ClaimLibary();
            data.ClaimID = 1;
            ClaimRepo repository = new ClaimRepo();

            // Act 
            repository.AddDataToList(data);
            ClaimLibary dataFromDir = repository.GetDataByClaimID(1);

            // Assert 
            Assert.IsNotNull(dataFromDir);
        }

        //Update
        [TestMethod]
        public void UpdateContentTrue()
        {
            //Arrange
            // TestInitialize
            ClaimLibary newData = new ClaimLibary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);


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
            ClaimLibary newContent = new ClaimLibary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18, 04, 25), new DateTime(18 / 04 / 27), true);


            //Act
            bool Result = _repo.UpdateDataFromDir(originalClaimID, newContent);

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
