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
            int targetRow = -1;
            int targetNumber = 0;
            switch (difficulty)
            {
                case CPUDifficulty.EASY:
                    targetRow = rand.Next(board.Rows.Length);
                    targetNumber = rand.Next(4);
                    for (int i = 0; i < targetNumber; i++)
                    {
                        board.UpdateRow(targetRow);
                    }
                    break;
                case CPUDifficulty.MEDIUM:
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
                    for (int i = 0; i < nimSumCounts.Length; i++)
                    {
                        if (nimSumCounts[i] % 2 == 1 && !nimSumAchievable)
                        {
                            nimSumAchievable = true;
                            targetNumber = (int)Math.Pow(2, i);
                        }
                        else
                        {
                            nimSumAchievable = false;
                        }
                    }
                    targetRow = rand.Next(board.Rows.Length);
                    if (nimSumAchievable)
                    {
                        for(int i = 0; i < targetNumber; i++)
                        {
                            board.UpdateRow(targetRow);
                        }
                    }
                    else
                    {
                        board.UpdateRow(targetRow);
                    }
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
                    for (int i = 0; i < nimSumCounts.Length; i++)
                    {
                        if (nimSumCounts[i] % 2 == 1 && !nimSumAchievable)
                        {
                            nimSumAchievable = true;
                            targetNumber = (int)Math.Pow(2, i);
                        }
                        else
                        {
                            nimSumAchievable = false;
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
