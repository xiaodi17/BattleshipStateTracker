using System.Collections.Generic;

namespace BattleshipStateTracker.Service.Models
{
    public class Board
    {
        public List<Cell> Cells { get; set; }
        
        public Board(int size)
        {
            Cells = new List<Cell>();
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Cells.Add(new Cell(i, j));
                }
            }
        }
    }
}