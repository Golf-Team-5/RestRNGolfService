using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestRNGolfService.Controllers;
using RestRNGolfService.Model;

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
            int expectedDistance = 300;

            //Act
            swingDataController.PostSwingDataAsDistance(testSwingData);

            //Assert
            Assert.AreEqual(expectedDistance, swingDataList[0]);
        }

    }
}
