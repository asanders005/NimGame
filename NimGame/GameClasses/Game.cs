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

        public Game(GameDifficulty difficulty, string player1Name, string player2Name = "CPU", bool isPvC = false)
        {
            Console.WriteLine("Creating Game");

            gameDifficulty = difficulty;
            GameBoard = new Board((int)gameDifficulty);

            Players[0] = new Players.Player(player1Name, this);
            if (isPvC)
            {
                this.isPvC = true;
                Players[1] = new Players.CPU(this);
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
                playerActed = true;
                SwitchPlayer();
            }
        }
        
        public Game(Game other)
        {
            this.gameDifficulty = other.gameDifficulty;
            GameBoard = new Board((int)gameDifficulty);

            this.Players = other.Players;
            isPvC = other.isPvC;

            Random random = new Random();
            CurrentPlayer = random.Next(2);
            if (isPvC && CurrentPlayer == 1)
            {
                Players[CurrentPlayer].TakeTurn();
                playerActed = true;
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
            return false;
        }

        public void SwitchPlayer()
        {
            CheckWinner();
            if (!GameOver)
            {
                if (playerActed)
                {
                    CurrentPlayer = (CurrentPlayer == 0) ? 1 : 0;
                    playerActed = false;
                    GameBoard.DeselectRow();
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
                GameOver = true;
                return true;
            }

            return false;
        }

        public bool getIsPvC() { return isPvC; }

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
}
