using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.GameClasses
{
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
