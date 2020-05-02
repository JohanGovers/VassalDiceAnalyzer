using System;
using VassalDiceAnalyzer.Data;
using Xunit;

namespace VassalDiceAnalyzer.Tests
{
    public class DiceRollRowParserTests
    {
        [Fact]
        public void CanParseRowWithOneResultOfEach()
        {
            var row = "* PlayerOne rolled 6 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:2  -  6+:1";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(6, result.DicesRolled);
            Assert.Equal(1, result.Ones);
            Assert.Equal(1, result.Twos);
            Assert.Equal(1, result.Threes);
            Assert.Equal(1, result.Fours);
            Assert.Equal(1, result.Fives);
            Assert.Equal(1, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneOne()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:0  -  3+:0  -  4+:0  -  5+:0  -  6+:0";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(1, result.Ones);
            Assert.Equal(0, result.Twos);
            Assert.Equal(0, result.Threes);
            Assert.Equal(0, result.Fours);
            Assert.Equal(0, result.Fives);
            Assert.Equal(0, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneTwo()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:0  -  4+:0  -  5+:0  -  6+:0";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(0, result.Ones);
            Assert.Equal(1, result.Twos);
            Assert.Equal(0, result.Threes);
            Assert.Equal(0, result.Fours);
            Assert.Equal(0, result.Fives);
            Assert.Equal(0, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneThree()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:1  -  4+:0  -  5+:0  -  6+:0";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(0, result.Ones);
            Assert.Equal(0, result.Twos);
            Assert.Equal(1, result.Threes);
            Assert.Equal(0, result.Fours);
            Assert.Equal(0, result.Fives);
            Assert.Equal(0, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneFour()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:1  -  4+:1  -  5+:0  -  6+:0";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(0, result.Ones);
            Assert.Equal(0, result.Twos);
            Assert.Equal(0, result.Threes);
            Assert.Equal(1, result.Fours);
            Assert.Equal(0, result.Fives);
            Assert.Equal(0, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneFive()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:1  -  4+:1  -  5+:1  -  6+:0";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(0, result.Ones);
            Assert.Equal(0, result.Twos);
            Assert.Equal(0, result.Threes);
            Assert.Equal(0, result.Fours);
            Assert.Equal(1, result.Fives);
            Assert.Equal(0, result.Sixes);
        }

        [Fact]
        public void CanParseRowWithOneSix()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:1  -  4+:1  -  5+:1  -  6+:1";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(1, result.DicesRolled);
            Assert.Equal(0, result.Ones);
            Assert.Equal(0, result.Twos);
            Assert.Equal(0, result.Threes);
            Assert.Equal(0, result.Fours);
            Assert.Equal(0, result.Fives);
            Assert.Equal(1, result.Sixes);
        }

        [Fact]
        public void CanParsePlayerName()
        {
            var row = "* PlayerOne rolled 1 Dice - 2+:1  -  3+:1  -  4+:1  -  5+:1  -  6+:1";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal("PlayerOne", result.PlayerName);
        }

        [Fact]
        public void CanParsePlayerNameWithSpace()
        {
            var row = "*  Player Two rolled 4 Dice - 2+:4  -  3+:2  -  4+:2  -  5+:1  -  6+:1";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Equal(" Player Two", result.PlayerName);
        }

        [Fact]
        public void ParsingNonDiceRollReturnsNull()
        {
            var row = "* Visiting Team rolls a 3 for direction and a 1 for distance *";

            var parser = new DiceRollRowParser();

            var result = parser.ParseRow(row);

            Assert.Null(result);
        }
    }
}
