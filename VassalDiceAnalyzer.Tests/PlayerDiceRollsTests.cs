using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using VassalDiceAnalyzer.Domain;
using Xunit;

namespace VassalDiceAnalyzer.Tests
{
    public class PlayerDiceRollsTests
    {
        [Fact]
        public void RollOf1FourAvaragesTo4()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll {PlayerName = "test", DicesRolled = 1, Fours = 1});

            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 4.0).Count);
        }

        [Fact]
        public void RollOf2FoursAvaragesTo4()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll {PlayerName = "test", DicesRolled = 2, Fours = 2});

            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 4.0).Count);
        }

        [Fact]
        public void RollOf1FourAnd1ThreeAvaragesTo3point5()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll {PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1});

            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 3.5).Count);
        }

        [Fact]
        public void CanAvarage2Rolls()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 3, Fours = 2, Ones = 1 });

            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 3.5).Count);
            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 3.0).Count);
        }

        [Fact]
        public void CanAvarage2RollsInTheSameRange()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 3, Fours = 2, Ones = 1 });

            Assert.Equal(2, playerRolls.RollAverages.Single(a => a.RangeMax == 3.5).Count);
            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 3.0).Count);
        }

        [Fact]
        public void AvarageJustAboveMinRangeValueIsReportedCorrectly()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 20, Twos = 19, Threes = 1});

            Assert.Equal(1, playerRolls.RollAverages.Single(a => a.RangeMax == 2.25).Count);
        }

        [Fact]
        public void RollAvaragesAppearInOrder()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });

            var firstSection = playerRolls.RollAverages.First();
            var lastSection = playerRolls.RollAverages.Last();

            Assert.Equal(1.0, firstSection.RangeMin);
            Assert.Equal(1.25, firstSection.RangeMax);
            Assert.Equal(5.75, lastSection.RangeMin);
            Assert.Equal(6.0, lastSection.RangeMax);

            var previousSection = playerRolls.RollAverages[0];
            foreach (var avarageSection in playerRolls.RollAverages.Skip(1))
            {
                Assert.Equal(previousSection.RangeMax, avarageSection.RangeMin);
                Assert.True(previousSection.RangeMax < avarageSection.RangeMax);

                previousSection = avarageSection;
            }
        }

        [Fact]
        public void CanCalculateAverageDicePoolSize()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 3, Fours = 2, Ones = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 4, Fours = 2, Ones = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 1, Fours = 2, Ones = 1 });

            Assert.Equal(2.5, playerRolls.AverageDicePoolSize);
        }

        [Fact]
        public void CanCalculateNrOfDiceRolls()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 3, Fours = 2, Ones = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 4, Fours = 2, Ones = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 1, Fours = 2, Ones = 1 });

            Assert.Equal(4, playerRolls.NrOfRolls);
        }

        [Fact]
        public void CanCalculateTotalAverageResult()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Twos = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 3, Fours = 2, Ones = 1 });
            Assert.Equal(3, playerRolls.TotalAverageResult);
        }

        [Fact]
        public void CanCalculateTotalAverageResultWithDecimalResult()
        {
            var playerRolls = new PlayerDiceRolls("test");
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 2, Fours = 1, Threes = 1 });
            playerRolls.AddDiceRoll(new DiceRoll { PlayerName = "test", DicesRolled = 4, Fours = 2, Threes = 2 });
            Assert.Equal(3.5, playerRolls.TotalAverageResult);
        }
    }
}
