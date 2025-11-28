using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Gambling;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class GamblingRoomTest
    {

        [Fact]
        public void Test_GamblingRoom_Creation()
        {

            // Arrange
            GamblingRoom gamblingRoom = new GamblingRoom();
            gamblingRoom.SelectGame(Game.BLACKJACK, 50);
            Game expectedGame = Game.BLACKJACK;

            // Act & Assert
            Assert.Equal(gamblingRoom.game, expectedGame); // If no exception is thrown, the test passes
        }
        [Fact]
        public void Test_GamblingRoom_SelectGame_Roulette()
        {
            // Arrange
            GamblingRoom gamblingRoom = new GamblingRoom();
            gamblingRoom.SelectGame(Game.ROULETTE, 100);
            Game expectedGame = Game.ROULETTE;
            // Act & Assert
            Assert.Equal(gamblingRoom.game, expectedGame); // If no exception is thrown, the test passes

        }
        [Fact]
        public void Test_GamblingRoom_SelectGame_Slott()
        {
            // Arrange
            GamblingRoom gamblingRoom = new GamblingRoom();
            gamblingRoom.SelectGame(Game.SLOTT, 200);
            Game expectedGame = Game.SLOTT;
            // Act & Assert
            Assert.Equal(gamblingRoom.game, expectedGame); // If no exception is thrown, the test passes
        }
        [Fact]
        public void Test_GamblingRoom_SelectGame_RussianRoulette()
        {
            // Arrange
            GamblingRoom gamblingRoom = new GamblingRoom();
            gamblingRoom.SelectGame(Game.RUSSIANROULETTE, 300);
            Game expectedGame = Game.RUSSIANROULETTE;
            // Act & Assert
            Assert.Equal(gamblingRoom.game, expectedGame); // If no exception is thrown, the test passes
        }
        
        
        [Fact]
        public void Test_GamblingRoom_SelectGame_NegativeBet_ThrowsArgumentException()
        {
            // Arrange
            GamblingRoom gamblingRoom = new GamblingRoom();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => gamblingRoom.SelectGame((Game)(1), 0));
        }
        
    }
}
