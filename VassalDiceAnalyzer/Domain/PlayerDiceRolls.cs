using System;
using System.Collections.Generic;
using System.Linq;

namespace VassalDiceAnalyzer.Domain
{
    public class PlayerDiceRolls
    {
        private List<DiceRoll> DiceRolls { get; } = new List<DiceRoll>();

        public PlayerDiceRolls(string playerName)
        {
            PlayerName = playerName;
        }

        public string PlayerName { get; }

        public float TotalAverageResult
        {
            get
            {
                return DiceRolls.Sum(r =>
                           r.Ones + 2 * r.Twos + 3 * r.Threes + 4 * r.Fours + 5 * r.Fives + 6 * r.Sixes) /
                       (float)DiceRolls.Sum(r => r.DicesRolled);
            }
        }

        public int TotalDicesRolled
        {
            get { return DiceRolls.Sum(r => r.DicesRolled); }
        }

        public int NrOfRolls => DiceRolls.Count;

        public float AverageDicePoolSize
        {
            get { return (float)DiceRolls.Average(r => r.DicesRolled); }
        }

        public int TotalOnesRolled
        {
            get { return DiceRolls.Sum(r => r.Ones); }
        }

        public int TotalTwosRolled
        {
            get { return DiceRolls.Sum(r => r.Twos); }
        }

        public int TotalThreesRolled
        {
            get { return DiceRolls.Sum(r => r.Threes); }
        }

        public int TotalFoursRolled
        {
            get { return DiceRolls.Sum(r => r.Fours); }
        }

        public int TotalFivesRolled
        {
            get { return DiceRolls.Sum(r => r.Fives); }
        }

        public int TotalSixesRolled
        {
            get { return DiceRolls.Sum(r => r.Sixes); }
        }

        // TODO: Move to separate file or top of class
        public struct RollAvarageSection
        {
            public float RangeMin;
            public float RangeMax;
            public int Count;
        }

        public RollAvarageSection[] RollAverages
        {
            get
            {
                var rollAvarages =  DiceRolls
                    .Select(r =>
                        ((float) r.Ones + r.Twos * 2 + r.Threes * 3 + r.Fours * 4 + r.Fives * 5 + r.Sixes * 6) /
                        r.DicesRolled)
                    .ToArray();

                var stepSize = 0.25f;

                // Range should be 1.25, 1.5, ..., 5.5, 5.75, 6.0 (step size 0.25).
                var rangeOfMaxValues = Enumerable.Range(5, 20).Select(r => r / (1/stepSize)).ToArray();
                var grouped = rangeOfMaxValues.Select(rangeMax => new RollAvarageSection
                {
                    RangeMin = rangeMax - stepSize,
                    RangeMax = rangeMax,
                    Count = rollAvarages.Count(rollAverage => (rangeMax - stepSize) < rollAverage && rollAverage <= rangeMax) //Note: Very inefficient. Loops through the data a lot.
                });

                return grouped.ToArray();
            }
        }

        public void AddDiceRoll(DiceRoll roll)
        {
            if (roll.PlayerName != PlayerName)
            {
                throw new ArgumentException($"Cannot add rolls for a different player. Trying to add rolls for {roll.PlayerName} to results for {PlayerName}.");
            }

            DiceRolls.Add(roll);
        }
    }
}
