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
        //test relateret til Hitting The Ball

        #region Swing Tests
        
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

        #endregion

        //Tests relateret til Current Hit Score

        #region Score Tests

        [TestMethod]
        public void ScoreCalculationTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            ScoreCalculator.NoOfSwings = 4;
        
            int expectedScore = 600;

            //Act 
            swingDataController.GetScore(3);

            //Assert
            Assert.AreEqual(expectedScore, ScoreCalculator.Score);
            ScoreCalculator.Score = 0;
            ScoreCalculator.NoOfSwings = 0;
            
        }

        [TestMethod]
        public void HoleInOneTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            ScoreCalculator.NoOfSwings = 1;

            int expectedScore = 2000;

            //Act 
            swingDataController.GetScore(3);


            //Assert
            Assert.AreEqual(expectedScore, ScoreCalculator.Score);
            ScoreCalculator.Score = 0;
            ScoreCalculator.NoOfSwings = 0;
        }

        [TestMethod]
        public void ParTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            ScoreCalculator.NoOfSwings = 3;

            int expectedScore = 1000;

            //Act 
            swingDataController.GetScore(4);

            //Assert
            Assert.AreEqual(expectedScore, ScoreCalculator.Score);
            ScoreCalculator.Score = 0;
            ScoreCalculator.NoOfSwings = 0;
        }

        [TestMethod]
        public void NoNegativeScoreTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            ScoreCalculator.NoOfSwings = 14;

            int expectedScore = 0;

            //Act 
            swingDataController.GetScore(5);


            //Assert
            Assert.AreEqual(expectedScore, ScoreCalculator.Score);
            ScoreCalculator.Score = 0;
            ScoreCalculator.NoOfSwings = 0;
        }

        [TestMethod]
        public void ResetSwingsTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            int expectedNoOfSwings = 0;
            ScoreCalculator.NoOfSwings = 5;

            //Act
            swingDataController.ResetSwings();

            //Assert
            Assert.AreEqual(expectedNoOfSwings, ScoreCalculator.NoOfSwings);
        }
        #endregion



    }
}
