using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestRNGolfService.Controllers;
using RestRNGolfService.Model;
using System;
using System.Collections.Generic;

namespace swingDataTest
{
    [TestClass]
    public class SwingDataTest
    {
        [TestMethod]
        public void SwingDataPostToListTest()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            List<int> swingDataList = SwingDataController.SwingDistanceList;
            swingDataList.Clear();

            SwingData testSwingData = new SwingData(7.8);
            int expectedLengthOfList = 1;

            //Act
            swingDataController.PostSwingDataAsDistance(testSwingData);


            //Assert
            Assert.AreEqual(expectedLengthOfList, swingDataList.Count);

        }

        [TestMethod]
        public void CalculateDistanceReturnsCorrectValueTest()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            List<int> swingDataList = SwingDataController.SwingDistanceList;
            swingDataList.Clear();

            SwingData testSwingData = new SwingData(10.01);
            int expectedDistance = 30;

            //Act
            swingDataController.PostSwingDataAsDistance(testSwingData);

            //Assert
            Assert.AreEqual(expectedDistance, swingDataList[0]);
        }

        [TestMethod]
        public void EmptySwingDataTest()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            SwingData emptySwingData = new SwingData();

            //Act
            try
            {
                swingDataController.PostSwingDataAsDistance(emptySwingData);

                //Assert
                Assert.Fail();
            }
            catch (Exception e)
            {

            }

        }

        [TestMethod]
        public void NegativeSwingDataTest()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            SwingData negativeSwingData = new SwingData(-8.0);

            //Act
            try
            {
                swingDataController.PostSwingDataAsDistance(negativeSwingData);
                //Assert
                Assert.Fail();
            }
            catch (Exception e)
            {


            }

        }



    }
}
