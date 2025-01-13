using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.GameClasses
{
    public class Game
    {
        public string? Winner { get; private set; }

        public Game(GameDifficulty difficulty, string player1Name, string player2Name = "CPU", bool isPvC = false, Players.CPUDifficulty cpu_difficulty = Players.CPUDifficulty.MEDIUM)
        {
            Console.WriteLine("Creating Game");

            gameDifficulty = difficulty;
            gameBoard = new Board((int)gameDifficulty);

            players[0] = new Players.Player(player1Name);
            if (isPvC)
            {
                this.isPvC = true;
                players[1] = new Players.CPU(cpu_difficulty);
            }
            else
            {
                players[1] = new Players.Player(player2Name);
            }

            Random random = new Random();
            currentPlayer = random.Next(2);
            players[currentPlayer].TakeTurn(ref gameBoard);
        }

        public void UpdateBoard(int row)
        {
            if (gameBoard.UpdateRow(row)) playerActed = true;
        }

        public void SwitchPlayer()
        {
            if (playerActed)
            {
                currentPlayer = (currentPlayer == 0) ? 1 : 0;
                playerActed = false;
                gameBoard.DeselectRow();
                Console.WriteLine("Passing Turn");
                if (isPvC && currentPlayer == 1)
                {
                    players[1].TakeTurn(ref gameBoard);
                }
            }
        }

        public bool CheckWinner()
        {
            if (gameBoard.IsEmpty())
            {
                Winner = (currentPlayer == 0) ? players[1].PlayerName : players[0].PlayerName;
                Console.WriteLine($"{Winner} Wins!");
                return true;
            }

            return false;
        }

        private Players.Player[] players = new Players.Player[2];
        private bool isPvC = false;
        private Board gameBoard;
        private readonly GameDifficulty gameDifficulty;

        private int currentPlayer;
        private bool playerActed = false;
    }

    public enum GameDifficulty
    {
        EASY = 3,
        MEDIUM,
        HARD
    }

    public class Board
    {
        public Board(int rowCount)
        {
            Rows = new int[rowCount];
            int rowTotal = 1;
            if (rowCount == 5)
            {
                rowTotal = 3;
            }
            for (int i = 0; i < rowCount; i++)
            {
                Rows[i] = rowTotal;
                rowTotal += 2;
            }
        }

        public bool UpdateRow(int row)
        {
            if (row + 1 > Rows.Length) return false;

            if ((row == selectedRow || selectedRow == -1) && Rows[row] > 0)
            {
                selectedRow = row;
                Rows[row]--;
                Console.WriteLine($"Row {row} has {Rows[row]} stones remaining");
                return true;
            }

            return false;
        }

        public void DeselectRow() { selectedRow = -1; }

        public bool IsEmpty()
        {
            foreach (var rowCount in Rows)
            {
                if (rowCount > 0) return false;
            }

            return true;
        }

        public int[] Rows { get; private set; }
        private int selectedRow = -1;
    }
}
