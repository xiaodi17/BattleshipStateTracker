using System.Collections.Generic;

namespace BattleshipStateTracker.Service.Models
{
    public class Board
    {
        public string BoardId { get; set; }
        public List<Cell> Cells { get; set; }
        
        public Board(string boardId, int size)
        {
            BoardId = boardId;
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