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
        public int CurrentPlayer { get; private set; }
        public Players.Player[] Players { get; private set; } = new Players.Player[2];
        public bool GameOver { get; private set; }

        public Game(GameDifficulty difficulty, string player1Name, string player2Name = "CPU", bool isPvC = false, Players.CPUDifficulty cpu_difficulty = GameClasses.Players.CPUDifficulty.MEDIUM)
        {
            Console.WriteLine("Creating Game");

            gameDifficulty = difficulty;
            GameBoard = new Board((int)gameDifficulty);

            Players[0] = new Players.Player(player1Name, this);
            if (isPvC)
            {
                this.isPvC = true;
                Players[1] = new Players.CPU(cpu_difficulty, this);
            }
            else
            {
                Players[1] = new Players.Player(player2Name, this);
            }

            Random random = new Random();
            CurrentPlayer = random.Next(2);
            if (isPvC && CurrentPlayer == 1)
            {
                Players[CurrentPlayer].TakeTurn();
                SwitchPlayer();
            }
        }

        public bool UpdateBoard(int row)
        {
            if (!GameOver)
            {
                if (GameBoard.UpdateRow(row))
                {
                    playerActed = true;
                    return true;
                }
            }
            CheckWinner();
            return false;
        }

        public void SwitchPlayer()
        {
            if (!GameOver)
            {
                if (playerActed)
                {
                    CurrentPlayer = (CurrentPlayer == 0) ? 1 : 0;
                    playerActed = false;
                    GameBoard.DeselectRow();
                    Console.WriteLine("Passing Turn");
                    if (isPvC && CurrentPlayer == 1)
                    {
                        Players[1].TakeTurn();
                        playerActed = true;
                        SwitchPlayer();
                    }
                }
            }
        }

        public bool CheckWinner()
        {
            if (GameBoard.IsEmpty())
            {
                Winner = (CurrentPlayer == 0) ? Players[1].PlayerName : Players[0].PlayerName;
                Console.WriteLine($"{Winner} Wins!");
                GameOver = true;
                return true;
            }

            return false;
        }

        public string GetPlayerName(int player)
        {
            return players[player].PlayerName;
        }
        public string GetCurrentPlayerName()
        {
            return players[currentPlayer].PlayerName;
        }

        private bool isPvC = false;
        public Board GameBoard { get; private set; }
        private readonly GameDifficulty gameDifficulty;

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

        public void UpdateRow(int row, int count)
        {
            if ((row == selectedRow || selectedRow == -1) && Rows[row] > 0 && count < Rows[row])
            {
                selectedRow = row;
                Rows[row] = count;
            }
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
