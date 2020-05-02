using System;
using System.Collections.Generic;
using System.Linq;
using VassalDiceAnalyzer.Domain;

namespace VassalDiceAnalyzer.Data
{
    public interface IVassalLogParser
    {
        List<PlayerDiceRolls> ParseLog(string log);
    }

    public class VassalLogParser : IVassalLogParser
    {
        private readonly IDiceRollRowParser _rowParser;

        public VassalLogParser(IDiceRollRowParser rowParser)
        {
            _rowParser = rowParser;
        }

        public List<PlayerDiceRolls> ParseLog(string log)
        {
            var result = new List<PlayerDiceRolls>();
            if (string.IsNullOrWhiteSpace(log))
            {
                return result;
            }

            var rows = log.Split('\n');
            foreach (var row in rows)
            {
                var roll = _rowParser.ParseRow(row);
                if (roll != null) AddRollToPlayer(result, roll);
            }

            return result;
        }

        private void AddRollToPlayer(List<PlayerDiceRolls> playerDiceRolls, DiceRoll roll)
        {
            var playerEntry = playerDiceRolls.SingleOrDefault(x => x.PlayerName == roll.PlayerName);

            if (playerEntry == null)
            {
                playerEntry = new PlayerDiceRolls(roll.PlayerName);
                playerDiceRolls.Add(playerEntry);
            }

            playerEntry.AddDiceRoll(roll);
        }
    }
}
