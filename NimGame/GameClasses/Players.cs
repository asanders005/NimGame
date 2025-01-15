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
            int targetRow = 0;
            int targetNumber = 0;
            switch (difficulty)
            {
                case CPUDifficulty.EASY:
                    do
                    {
                        targetRow = rand.Next(board.Rows.Length);
                    } while (board.Rows[targetRow] == 0);
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
                    do
                    {
                        targetRow = rand.Next(board.Rows.Length);
                    } while (board.Rows[targetRow] == 0);
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
                    if (CheckWinningPosition(board.Rows))
                    {
                        do
                        {
                            targetRow = rand.Next(board.Rows.Length);
                        }
                        while (board.Rows[targetRow] == 0);
                        board.UpdateRow(targetRow);
                    }
                    else
                    {
                        bool winningPos = false;
                        while (!winningPos)
                        {
                            int[] tempRows = board.Rows;
                            targetRow %= board.Rows.Length;
                            while (board.Rows[targetRow] == 0) targetRow = (targetRow + 1) % board.Rows.Length;

                            int tempCount = tempRows[targetRow];
                            while (!CheckWinningPosition(tempRows) && tempRows[targetRow] != 0) tempRows[targetRow]--;

                            if (!CheckWinningPosition(tempRows)) tempRows[targetRow] = tempCount;
                            else
                            {
                                board.UpdateRow(targetRow, tempRows[targetRow]);
                                winningPos = true;
                            }
                        }
                    }
                    break;
            }
        }

        private bool CheckWinningPosition(int[] rows)
        {
            bool match = false;
            bool oneLeft = false;
            switch (rows.Length)
            {
                case 3:
                    match = (rows[0] ^ rows[1] ^ rows[2]) == 0;
                    oneLeft = (rows[0] | rows[1] | rows[2]) == 1;
                    return match ^ oneLeft;
                case 4:
                    match = (rows[0] ^ rows[1] ^ rows[2]) == 0;
                    oneLeft = (rows[0] | rows[1] | rows[2]) == 1;
                    return match ^ oneLeft;
                case 5:
                    match = (rows[0] ^ rows[1] ^ rows[2]) == 0;
                    oneLeft = (rows[0] | rows[1] | rows[2]) == 1;
                    return match ^ oneLeft;
            }

            return false;
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
