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
        public void SwingDataPostToVariable()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            int swingData;
            

            SwingData testSwingData = new SwingData(7.8);
            int expectedValueOfVariable = 23;

            //Act
            swingDataController.PostSwingDataAsDistance(testSwingData);
            swingData = SwingDataController.FinalSwingDistance;

            //Assert
            Assert.AreEqual(expectedValueOfVariable, swingData);

        }

        [TestMethod]
        public void CalculateDistanceReturnsCorrectValueTest()
        {
            //Arrange
            RestRNGolfService.Controllers.SwingDataController swingDataController = new SwingDataController();
            int swingData;
            

            SwingData testSwingData = new SwingData(10.01);
            int expectedDistance = 30;

            //Act
            swingDataController.PostSwingDataAsDistance(testSwingData);
            swingData = SwingDataController.FinalSwingDistance;

            //Assert
            Assert.AreEqual(expectedDistance, swingData);
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
            int NoOfSwings = 4;
        
            int expectedScore = 600;

            //Act 
            swingDataController.GetScore(3, NoOfSwings);

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
            int NoOfSwings = 1;

            int expectedScore = 2000;

            //Act 
            swingDataController.GetScore(3, NoOfSwings);


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
            int NoOfSwings = 3;

            int expectedScore = 1000;

            //Act 
            swingDataController.GetScore(4, NoOfSwings);

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
            int NoOfSwings = 14;

            int expectedScore = 0;

            //Act 
            swingDataController.GetScore(5, NoOfSwings);


            //Assert
            Assert.AreEqual(expectedScore, ScoreCalculator.Score);
            ScoreCalculator.Score = 0;
            ScoreCalculator.NoOfSwings = 0;
        }

        
        #endregion

        #region DatabaseMethodTests

        [TestMethod]
        public void GetPlayersFromDatabase()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            int expectedCount = 0;


            //Act
            List<Player> playerList = swingDataController.GetLeaderboard();

            //Assert
            Assert.AreNotEqual(expectedCount, playerList.Count);
        }

        [TestMethod]
        public void GetSinglePlayerTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            Player expectedPlayer = swingDataController.GetLeaderboard()[0];

            //Act
            Player singlePlayer = swingDataController.GetSinglePlayer("Kri");


            //Assert
            Assert.AreEqual(expectedPlayer.PlayerId, singlePlayer.PlayerId);
        }

        [TestMethod]
        public void PostPlayerToDatabaseTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();
            Player playerToBePosted = new Player("Kia", 8, 3500);


            //Act
            swingDataController.PostPlayerScore(playerToBePosted);
            Player expectedPlayerFromDatabase = swingDataController.GetSinglePlayer("Kia");

            //Assert
            Assert.AreEqual(playerToBePosted.PlayerName, expectedPlayerFromDatabase.PlayerName);

        }

        [TestMethod]
        public void DeletePlayerFromDatabaseTest()
        {
            //Arrange
            SwingDataController swingDataController = new SwingDataController();


            //Act
            Player playerToBeDeleted = swingDataController.GetSinglePlayer("Kia");
            swingDataController.DeletePlayerFromDB(playerToBeDeleted.PlayerId);
            Player playerShouldNotExist = swingDataController.GetSinglePlayer(playerToBeDeleted.PlayerName);

            //Assert
            try
            {
                Assert.AreEqual(playerToBeDeleted.PlayerId, playerShouldNotExist.PlayerId);
                Assert.Fail();
            }
            catch (Exception e)
            {
                
            }
            
        }

        #endregion

    }
}
