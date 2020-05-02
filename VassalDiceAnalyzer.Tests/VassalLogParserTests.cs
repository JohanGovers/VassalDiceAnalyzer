using VassalDiceAnalyzer.Data;
using Xunit;

namespace VassalDiceAnalyzer.Tests
{
    public class VassalLogParserTests
    {
        [Fact]
        public void CanParse2RowsWithOneResultOfEach()
        {
            var log = "* PlayerOne rolled 12 Dice - 2+:10  -  3+:8  -  4+:6  -  5+:4  -  6+:2\n* PlayerOne rolled 6 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:2  -  6+:1";

            var parser = new VassalLogParser(new DiceRollRowParser());

            var result = parser.ParseLog(log);

            Assert.Single(result);
            Assert.Equal("PlayerOne", result[0].PlayerName);
            
            Assert.Equal(18, result[0].TotalDicesRolled);
            Assert.Equal(3, result[0].TotalOnesRolled);
            Assert.Equal(3, result[0].TotalTwosRolled);
            Assert.Equal(3, result[0].TotalThreesRolled);
            Assert.Equal(3, result[0].TotalFoursRolled);
            Assert.Equal(3, result[0].TotalFivesRolled);
            Assert.Equal(3, result[0].TotalSixesRolled);
        }

        [Fact]
        public void CanSkipNonDiceRolls()
        {
            var log = "\n\n* PlayerOne rolled 12 Dice - 2+:10  -  3+:8  -  4+:6  -  5+:4  -  6+:2\n* Visiting Team rolls a 3 for direction and a 1 for distance *";

            var parser = new VassalLogParser(new DiceRollRowParser());

            var result = parser.ParseLog(log);

            Assert.Single(result);
            Assert.Equal("PlayerOne", result[0].PlayerName);

            Assert.Equal(2, result[0].TotalOnesRolled);
            Assert.Equal(2, result[0].TotalTwosRolled);
            Assert.Equal(2, result[0].TotalThreesRolled);
            Assert.Equal(2, result[0].TotalFoursRolled);
            Assert.Equal(2, result[0].TotalFivesRolled);
            Assert.Equal(2, result[0].TotalSixesRolled);
        }

        [Fact]
        public void CanParse2Players()
        {
            var log = "* PlayerOne rolled 12 Dice - 2+:10  -  3+:8  -  4+:6  -  5+:4  -  6+:2\n*  Player Two rolled 6 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:2  -  6+:1";

            var parser = new VassalLogParser(new DiceRollRowParser());

            var result = parser.ParseLog(log);

            Assert.Equal(2, result.Count);
            Assert.Equal("PlayerOne", result[0].PlayerName);
            Assert.Equal(" Player Two", result[1].PlayerName);

            Assert.Equal(2, result[0].TotalOnesRolled);
            Assert.Equal(2, result[0].TotalTwosRolled);
            Assert.Equal(2, result[0].TotalThreesRolled);
            Assert.Equal(2, result[0].TotalFoursRolled);
            Assert.Equal(2, result[0].TotalFivesRolled);
            Assert.Equal(2, result[0].TotalSixesRolled);

            Assert.Equal(1, result[1].TotalOnesRolled);
            Assert.Equal(1, result[1].TotalTwosRolled);
            Assert.Equal(1, result[1].TotalThreesRolled);
            Assert.Equal(1, result[1].TotalFoursRolled);
            Assert.Equal(1, result[1].TotalFivesRolled);
            Assert.Equal(1, result[1].TotalSixesRolled);
        }
    }
}
