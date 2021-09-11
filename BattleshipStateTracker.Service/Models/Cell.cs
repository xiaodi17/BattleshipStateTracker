using System.Drawing;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service.Models
{
    public class Cell
    {
        public CellStatus Status { get; set; }
        public Point Coordinate { get; }
        
        public Cell(int row, int column)
        {
            Coordinate = new Point(row, column);
            Status = CellStatus.Empty;
        }
    }
}