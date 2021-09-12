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
            if (IsCountingCellsFromBottomLeft(startCoord, endCoord))
            {
                return board.Cells.Where(c => c.Coordinate.X >= startCoord.X
                                               && c.Coordinate.Y >= startCoord.Y
                                               && c.Coordinate.X <= endCoord.X
                                               && c.Coordinate.Y <= endCoord.Y).ToList();
            } 
            
            return board.Cells.Where(c => c.Coordinate.X >= endCoord.X
                                          && c.Coordinate.Y >= endCoord.Y
                                          && c.Coordinate.X <= startCoord.X
                                          && c.Coordinate.Y <= startCoord.Y).ToList();
        }

        private static bool IsCountingCellsFromBottomLeft(Point startCoord, Point endCoord)
        {
            return startCoord.X == endCoord.X && startCoord.Y < endCoord.Y || startCoord.Y == endCoord.Y && startCoord.X < endCoord.X;
        }
        
        public static bool IsCellOccupied(Cell cell)
        {
            return cell.Status == CellStatus.Battleship;
        }
    }
}