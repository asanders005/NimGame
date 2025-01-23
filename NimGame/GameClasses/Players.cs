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

        public Player(string playerName, Game game)
        {
            PlayerName = playerName;
            this.game = game;
        }

        virtual public void TakeTurn() { }

        protected Game game;
    }

    public class CPU : Player
    {
        public CPU(Game game) : base("CPU", game) { }

        override public void TakeTurn()
        {
            if (!game.GameOver)
            {
                int targetRow = 0;
                int targetNumber = 0;

                do
                {
                    targetRow = rand.Next(game.GameBoard.Rows.Length);
                } while (game.GameBoard.Rows[targetRow] == 0);
                targetNumber = rand.Next(4) + 1;
                for (int i = 0; i <= targetNumber; i++)
                {
                    game.GameBoard.UpdateRow(targetRow);
                }
                        
                game.CheckWinner();
            }
        }



        private Random rand = new Random();
        private int[] nimSumCounts = new int[4];
        private bool nimSumAchievable = false;
    }
}
