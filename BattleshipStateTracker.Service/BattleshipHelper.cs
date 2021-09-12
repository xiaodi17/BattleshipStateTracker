using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleshipStateTracker.Service.Models;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service
{
    public static class BattleshipHelper
    {
        public static bool IsValidCoordinate(Board board, Point coordinate) =>
            coordinate.X >= 0
            && coordinate.X < board.Size
            && coordinate.Y >= 0
            && coordinate.Y < board.Size;

        private static bool IsShipHorizontalOrVertical(Point startCoord, Point endCoord)
        {
            return startCoord.X == endCoord.X || startCoord.Y == endCoord.Y;
        }
        
        public static bool ValidateAddBattleshipPosition(Board board, Point startCoord, Point endCoord)
        {
            if (!IsValidCoordinate(board, startCoord) ||
                !IsValidCoordinate(board, endCoord))
                return false;
            
            return IsShipHorizontalOrVertical(startCoord, endCoord);
        }
        
        public static List<Cell> GetCellsByStartAndEndCoordinates(Board board, Point startCoord, Point endCoord)
        {
            var cells = new List<Cell>();
            if (startCoord.X == endCoord.X && startCoord.Y < endCoord.Y)
            {
                cells = board.Cells.Where(c => c.Coordinate.X >= startCoord.X
                                               && c.Coordinate.Y >= startCoord.Y
                                               && c.Coordinate.X <= endCoord.X
                                               && c.Coordinate.Y <= endCoord.Y).ToList();
            } else if (startCoord.Y == endCoord.Y && startCoord.X < endCoord.X)
            {
                cells = board.Cells.Where(c => c.Coordinate.X >= startCoord.X
                                               && c.Coordinate.Y >= startCoord.Y
                                               && c.Coordinate.X <= endCoord.X
                                               && c.Coordinate.Y <= endCoord.Y).ToList();
            } else if (startCoord.X == endCoord.X && startCoord.Y > endCoord.Y)
            {
                cells = board.Cells.Where(c => c.Coordinate.X >= endCoord.X
                                               && c.Coordinate.Y >= endCoord.Y
                                               && c.Coordinate.X <= startCoord.X
                                               && c.Coordinate.Y <= startCoord.Y).ToList();
            } else if (startCoord.Y == endCoord.Y && startCoord.X > endCoord.X)
            {
                cells = board.Cells.Where(c => c.Coordinate.X >= endCoord.X
                                               && c.Coordinate.Y >= endCoord.Y
                                               && c.Coordinate.X <= startCoord.X
                                               && c.Coordinate.Y <= startCoord.Y).ToList();
            }
            
            return cells;
        }
        
        public static bool IsCellOccupied(Cell cell)
        {
            return cell.Status == CellStatus.Battleship;
        }
    }
}