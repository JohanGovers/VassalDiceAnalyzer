using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VassalDiceAnalyzer.Domain;

namespace VassalDiceAnalyzer.Data
{
    public interface IDiceRollRowParser
    {
        DiceRoll ParseRow(string row);
    }

    public class DiceRollRowParser : IDiceRollRowParser
    {
        public DiceRoll ParseRow(string row)
        {
            //Example: "* PlayerOne rolled 1 Dice - 2+:1  -  3+:0  -  4+:0  -  5+:0  -  6+:0";

            if (string.IsNullOrWhiteSpace(row)) return null;
            if (!row.Contains(" - ")) return null;
            if (!row.Contains(" rolled ")) return null;

            var parts = row.Split(" - ");
            var playerPart = parts[0];
            
            var result = new DiceRoll();
            result.PlayerName = playerPart.Substring(2, playerPart.IndexOf(" rolled ")-2);
            var nrOfDice = int.Parse(
                playerPart
                    .Split("rolled ")[1]
                    .Replace(" Dice", string.Empty));

            result.DicesRolled = nrOfDice;
            result.Sixes = ParseDicePart(parts[5]);
            result.Fives = ParseDicePart(parts[4])  - result.Sixes;
            result.Fours = ParseDicePart(parts[3]) - result.Sixes - result.Fives;
            result.Threes = ParseDicePart(parts[2]) - result.Sixes - result.Fives - result.Fours;
            result.Twos = ParseDicePart(parts[1])   - result.Sixes - result.Fives - result.Fours - result.Threes;
            result.Ones = result.DicesRolled        - result.Sixes - result.Fives - result.Fours - result.Threes - result.Twos;
          
            return result;
        }

        private int ParseDicePart(string part)
        {
            return int.Parse(part.Split(":")[1]);
        }
    }
}
