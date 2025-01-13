using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.GameClasses.Players
{
    public class Player
    {
        public string PlayerName { get; protected set; }

        public Player(string playerName)
        {
            PlayerName = playerName;
        }

        virtual public void TakeTurn(ref Board board) { }
    }

    public class CPU : Player
    {
        public CPU(CPUDifficulty cpu_difficulty) : base("CPU") 
        {
            difficulty = cpu_difficulty;

            switch (difficulty)
            {
                case CPUDifficulty.EASY:
                    PlayerName = "Easy CPU";
                    break;
                case CPUDifficulty.MEDIUM:
                    PlayerName = "Medium CPU";
                    break;
                case CPUDifficulty.HARD:
                    PlayerName = "Hard CPU";
                    break;
                default:
                    PlayerName = "CPU";
                    break;
            }
        }

        override public void TakeTurn(ref Board board)
        {
            switch (difficulty)
            {
                case CPUDifficulty.EASY:
                    break;
                case CPUDifficulty.MEDIUM:
                    break;
                case CPUDifficulty.HARD:
                    foreach (var rowCount in board.Rows) 
                    {
                        if ((rowCount & 0b0001) != 0)
                        {
                            nimSumCounts[3]++;
                        }
                        if ((rowCount & 0b0010) != 0)
                        {
                            nimSumCounts[2]++;
                        }
                        if ((rowCount & 0b0100) != 0)
                        {
                            nimSumCounts[1]++;
                        }
                        if ((rowCount & 0b1000) != 0)
                        {
                            nimSumCounts[0]++;
                        }
                    }
                    break;
            }
        }

        private CPUDifficulty difficulty;

        private Random rand = new Random();
        private int[] nimSumCounts = new int[4];
        private bool nimSumAchievable = false;
    }

    public enum CPUDifficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
}
