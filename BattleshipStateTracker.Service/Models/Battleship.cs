using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service.Models
{
    public class Battleship
    {
        public Battleship(Point startCoordinate, Point endCoordinate, List<Cell> cells)
        {
            StartCoordinate = startCoordinate;
            EndCoordinate = endCoordinate;
            Cells = cells;
        }

        public Point StartCoordinate { get; set; }
        public Point EndCoordinate { get; set; }
        public List<Cell> Cells { get; set; }
        
        public bool IsSunk
        {
            get
            {
                return Cells.All(c => c.Status == CellStatus.Hit);
            }
        }
    }
}