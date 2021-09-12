using System.Drawing;
using BattleshipStateTracker.Service.Models;

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
    }
}