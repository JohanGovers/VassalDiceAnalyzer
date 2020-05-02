namespace VassalDiceAnalyzer.Domain
{
    public class DiceRoll
    {
        public string PlayerName { get; set; }
        public int DicesRolled { get; set; }
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }
    }
}
