﻿using System.IO;
using System.Threading.Tasks;

namespace VassalDiceAnalyzer.Data.Samples
{
    public interface ISampleDataLoader
    {
        Task<string> GetSample1Async();
        Task<string> GetSample2Async();
    }

    public class SampleDataLoader : ISampleDataLoader
    {
        public async Task<string> GetSample1Async()
        {
            return await Task.FromResult(@"

 - Guild Ball version 8.5

  Welcome to the VASSAL server
  

 For help, see the VASSAL Forum at http://www.vassalengine.org/forum

 - Waiting for Game Info...
 - Synchronization complete
* Player One rolled 11 Dice - 2+:8  -  3+:7  -  4+:4  -  5+:3  -  6+:1
* Player One rolled 7 Dice - 2+:5  -  3+:5  -  4+:3  -  5+:2  -  6+:1
* Player Two rolled 5 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:2  -  6+:1
* Player One rolled 4 Dice - 2+:2  -  3+:1  -  4+:1  -  5+:1  -  6+:1
* Player One rolled 6 Dice - 2+:6  -  3+:6  -  4+:6  -  5+:5  -  6+:1
* Player Two rolled 9 Dice - 2+:8  -  3+:8  -  4+:6  -  5+:6  -  6+:1
* Player Two rolled 5 Dice - 2+:4  -  3+:2  -  4+:1  -  5+:1  -  6+:0
* Player Two rolled 5 Dice - 2+:4  -  3+:2  -  4+:1  -  5+:1  -  6+:0
* Player One rolled 7 Dice - 2+:4  -  3+:3  -  4+:2  -  5+:0  -  6+:0
* Player One rolled 7 Dice - 2+:7  -  3+:6  -  4+:4  -  5+:3  -  6+:1
* Player One rolled 7 Dice - 2+:6  -  3+:5  -  4+:4  -  5+:0  -  6+:0
* Player Two rolled 4 Dice - 2+:4  -  3+:3  -  4+:1  -  5+:0  -  6+:0
* The Visiting Team has scored a Goal! Score is now 0:1
* Visiting Team rolls a 3 for direction and a 1 for distance *
* Player Two rolled 10 Dice - 2+:9  -  3+:8  -  4+:7  -  5+:3  -  6+:3
* Player Two rolled 12 Dice - 2+:12  -  3+:11  -  4+:6  -  5+:4  -  6+:2
* Visiting Team has taken-out 1 Player 
* Player Two rolled 6 Dice - 2+:6  -  3+:6  -  4+:3  -  5+:1  -  6+:1
* Player Two rolled 6 Dice - 2+:4  -  3+:3  -  4+:3  -  5+:2  -  6+:2
* Visiting Team has taken-out 2 Players 
* Player Two rolled 7 Dice - 2+:7  -  3+:7  -  4+:5  -  5+:5  -  6+:2
* Player Two rolled 6 Dice - 2+:5  -  3+:5  -  4+:4  -  5+:3  -  6+:0
* Visiting Team has taken-out 3 Players 
* Player Two rolled 6 Dice - 2+:6  -  3+:6  -  4+:4  -  5+:3  -  6+:2
* Player Two rolled 7 Dice - 2+:4  -  3+:4  -  4+:4  -  5+:1  -  6+:1
* Player One rolled 7 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:2  -  6+:1
* Player One rolled 7 Dice - 2+:6  -  3+:6  -  4+:4  -  5+:3  -  6+:1
* Player One rolled 8 Dice - 2+:7  -  3+:5  -  4+:5  -  5+:4  -  6+:1
* Home Team has taken-out 1 Player 
* Player Two rolled 5 Dice - 2+:5  -  3+:5  -  4+:5  -  5+:4  -  6+:0");
        }

        public async Task<string> GetSample2Async()
        {
            return await Task.FromResult(@"

 - Guild Ball version 8.5

  Welcome to the VASSAL server
  

 For help, see the VASSAL Forum at http://www.vassalengine.org/forum

 - Waiting for Game Info...
 - Synchronization complete
 - Waiting for Game Info...
 - Synchronization complete
 - Waiting for Game Info...
 - Synchronization complete
* Player Two rolled 7 Dice - 2+:7  -  3+:7  -  4+:6  -  5+:5  -  6+:2
* Player One rolled 14 Dice - 2+:11  -  3+:10  -  4+:9  -  5+:5  -  6+:2
* Player One rolled 11 Dice - 2+:8  -  3+:6  -  4+:5  -  5+:4  -  6+:2
* Player Two rolled 4 Dice - 2+:3  -  3+:3  -  4+:3  -  5+:2  -  6+:1
* Player One rolled 10 Dice - 2+:8  -  3+:6  -  4+:4  -  5+:2  -  6+:2
* Player Two rolled 8 Dice - 2+:6  -  3+:5  -  4+:4  -  5+:3  -  6+:3
* Player Two rolled 8 Dice - 2+:8  -  3+:7  -  4+:7  -  5+:5  -  6+:3
* Player Two rolled 8 Dice - 2+:5  -  3+:3  -  4+:2  -  5+:1  -  6+:1
* New Turn: Home Team gains [+0] Inf  -  Visiting Team gains [+0] Inf *
* New Turn: Home Team gains [+0] Inf  -  Visiting Team gains [+0] Inf *
* Player One rolled 5 Dice - 2+:4  -  3+:3  -  4+:1  -  5+:0  -  6+:0
* Player Two rolled 5 Dice - 2+:5  -  3+:5  -  4+:4  -  5+:1  -  6+:0
* Player One rolled 5 Dice - 2+:3  -  3+:2  -  4+:1  -  5+:1  -  6+:0
* Player Two rolled 9 Dice - 2+:6  -  3+:4  -  4+:4  -  5+:1  -  6+:0
* Player Two rolled 9 Dice - 2+:9  -  3+:9  -  4+:7  -  5+:2  -  6+:2
* Player Two rolled 9 Dice - 2+:8  -  3+:8  -  4+:7  -  5+:4  -  6+:3
* Home Team has taken-out 5 Mascots 
* Player Two rolled 11 Dice - 2+:9  -  3+:9  -  4+:8  -  5+:6  -  6+:3
* Player Two rolled 11 Dice - 2+:9  -  3+:9  -  4+:7  -  5+:4  -  6+:3
* Player Two rolled 8 Dice - 2+:7  -  3+:5  -  4+:5  -  5+:3  -  6+:2
* Player One rolled 5 Dice - 2+:3  -  3+:3  -  4+:3  -  5+:2  -  6+:2
* Player One rolled 5 Dice - 2+:5  -  3+:5  -  4+:4  -  5+:4  -  6+:4
* Player One rolled 5 Dice - 2+:3  -  3+:2  -  4+:2  -  5+:2  -  6+:0
* Player Two rolled 6 Dice - 2+:5  -  3+:5  -  4+:5  -  5+:4  -  6+:3
* Player Two rolled 5 Dice - 2+:5  -  3+:2  -  4+:1  -  5+:1  -  6+:1
* Player One rolled 5 Dice - 2+:5  -  3+:3  -  4+:0  -  5+:0  -  6+:0
* Player Two rolled 4 Dice - 2+:2  -  3+:2  -  4+:2  -  5+:2  -  6+:1
* Player Two rolled 5 Dice - 2+:4  -  3+:2  -  4+:2  -  5+:0  -  6+:0
* Player Two rolled 5 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:3  -  6+:1
* Player Two rolled 6 Dice - 2+:4  -  3+:2  -  4+:2  -  5+:2  -  6+:2
* Home Team has taken-out 1 Player and 5 Mascots 
* Player One rolled 7 Dice - 2+:5  -  3+:4  -  4+:3  -  5+:3  -  6+:2
* Player Two rolled 4 Dice - 2+:4  -  3+:3  -  4+:2  -  5+:1  -  6+:0
* Player One rolled 7 Dice - 2+:7  -  3+:6  -  4+:4  -  5+:1  -  6+:0
* Player One rolled 7 Dice - 2+:6  -  3+:6  -  4+:4  -  5+:2  -  6+:2
* Player One rolled 7 Dice - 2+:6  -  3+:4  -  4+:4  -  5+:3  -  6+:2
* Player One rolled 7 Dice - 2+:5  -  3+:4  -  4+:2  -  5+:1  -  6+:0
* Visiting Team has taken-out 2 Players 
* Player Two rolled 6 Dice - 2+:4  -  3+:2  -  4+:1  -  5+:1  -  6+:0
* Player Two rolled 8 Dice - 2+:6  -  3+:3  -  4+:1  -  5+:1  -  6+:0
* Player Two rolled 8 Dice - 2+:5  -  3+:4  -  4+:2  -  5+:2  -  6+:2
* Player Two rolled 9 Dice - 2+:8  -  3+:5  -  4+:4  -  5+:3  -  6+:2
* Player Two rolled 5 Dice - 2+:4  -  3+:4  -  4+:4  -  5+:4  -  6+:3
* Player One rolled 8 Dice - 2+:7  -  3+:7  -  4+:5  -  5+:3  -  6+:3
* Player Two rolled 4 Dice - 2+:4  -  3+:4  -  4+:3  -  5+:0  -  6+:0
* Player One rolled 9 Dice - 2+:9  -  3+:8  -  4+:7  -  5+:6  -  6+:2
* Player One rolled 8 Dice - 2+:7  -  3+:4  -  4+:3  -  5+:2  -  6+:1
* Player One rolled 8 Dice - 2+:7  -  3+:4  -  4+:4  -  5+:2  -  6+:1
* Player One rolled 8 Dice - 2+:7  -  3+:5  -  4+:4  -  5+:3  -  6+:2
* Player One rolled 8 Dice - 2+:7  -  3+:6  -  4+:3  -  5+:3  -  6+:1
* Visiting Team has taken-out 3 Players 
* Player Two rolled 3 Dice - 2+:2  -  3+:2  -  4+:2  -  5+:2  -  6+:2
* Player Two rolled 7 Dice - 2+:7  -  3+:7  -  4+:6  -  5+:4  -  6+:1
* Player Two rolled 7 Dice - 2+:4  -  3+:3  -  4+:2  -  5+:1  -  6+:1
* Player Two rolled 7 Dice - 2+:6  -  3+:5  -  4+:3  -  5+:3  -  6+:1
* Player Two rolled 7 Dice - 2+:7  -  3+:5  -  4+:3  -  5+:2  -  6+:0
* Player Two rolled 5 Dice - 2+:4  -  3+:4  -  4+:4  -  5+:4  -  6+:3
* Player Two rolled 7 Dice - 2+:6  -  3+:4  -  4+:1  -  5+:0  -  6+:0
* Player Two rolled 7 Dice - 2+:4  -  3+:2  -  4+:1  -  5+:1  -  6+:0
* Player Two rolled 7 Dice - 2+:7  -  3+:5  -  4+:4  -  5+:4  -  6+:3
* Player Two rolled 7 Dice - 2+:7  -  3+:6  -  4+:5  -  5+:2  -  6+:2
* Player Two rolled 7 Dice - 2+:5  -  3+:4  -  4+:2  -  5+:1  -  6+:1
* Home Team has taken-out 2 Players and 5 Mascots 
* Player Two rolled 7 Dice - 2+:6  -  3+:5  -  4+:3  -  5+:3  -  6+:3
* Visiting Team has taken-out 4 Players 
* Player Two rolled 7 Dice - 2+:6  -  3+:5  -  4+:3  -  5+:1  -  6+:1
* Player Two rolled 7 Dice - 2+:6  -  3+:3  -  4+:1  -  5+:1  -  6+:1
* Player Two rolled 7 Dice - 2+:7  -  3+:7  -  4+:3  -  5+:1  -  6+:1
* Player Two rolled 7 Dice - 2+:6  -  3+:5  -  4+:4  -  5+:3  -  6+:2
* Player Two rolled 13 Dice - 2+:9  -  3+:8  -  4+:6  -  5+:5  -  6+:4
* Player Two rolled 7 Dice - 2+:7  -  3+:6  -  4+:4  -  5+:1  -  6+:0
* Player Two rolled 7 Dice - 2+:7  -  3+:6  -  4+:5  -  5+:3  -  6+:3
* Home Team has taken-out 3 Players and 5 Mascots 
* Player One rolled 5 Dice - 2+:3  -  3+:3  -  4+:2  -  5+:1  -  6+:1
* Home Team rolls a 2 for direction and a 4 for distance *
* Player Two rolled 4 Dice - 2+:3  -  3+:2  -  4+:1  -  5+:1  -  6+:1
* Player One rolled 5 Dice - 2+:5  -  3+:5  -  4+:3  -  5+:3  -  6+:1
* Player One rolled 5 Dice - 2+:3  -  3+:2  -  4+:2  -  5+:1  -  6+:1
* Player Two rolled 9 Dice - 2+:7  -  3+:5  -  4+:4  -  5+:3  -  6+:1
* Player Two rolled 9 Dice - 2+:8  -  3+:6  -  4+:5  -  5+:4  -  6+:3
* Player Two rolled 9 Dice - 2+:8  -  3+:7  -  4+:7  -  5+:5  -  6+:2
* Player Two rolled 9 Dice - 2+:7  -  3+:6  -  4+:4  -  5+:3  -  6+:2
* Home Team has taken-out 4 Players and 5 Mascots");
        }
    }
}
