using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BattleshipStateTracker.Service.Models;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service
{
    public class BattleshipService: IBattleshipService
    {
        public BattleshipService()
        {
        }

        public Board board { get; set; }
        public void CreateBoard(int size = 10)
        {
            board = new Board(size);
        }

        public async Task<Battleship> AddBattleShip(Point startCoord, Point endCoord)
        {
            var cells = board.Cells.Where(c => c.Coordinate.X >= startCoord.X
                                   && c.Coordinate.Y >= startCoord.Y
                                   && c.Coordinate.X <= endCoord.X
                                   && c.Coordinate.Y <= endCoord.Y).ToList();

            foreach (var cell in cells)
            {
                cell.Status = CellStatus.Battleship;
            }

            var ship = new Battleship(startCoord, endCoord, cells);
            return await Task.FromResult(ship);
        }
    }
}