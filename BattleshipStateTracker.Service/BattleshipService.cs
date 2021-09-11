using System;
using System.Collections.Generic;
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

        public List<Board> _boards = new List<Board>();

        public void CreateBoard(string boardId, int size = 10)
        {
            var board = new Board(boardId,size);
            _boards.Add(board);
        }

        public async Task<Battleship> AddBattleShip(string boardId, Point startCoord, Point endCoord)
        {
            var board = _boards.FirstOrDefault(i => i.BoardId == boardId);
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

        public async Task<CellStatus> Attack(string boardId, Point attackCoord)
        {
            var board = _boards.FirstOrDefault(i => i.BoardId == boardId);
            var cell = board.Cells.FirstOrDefault(c => c.Coordinate.X == attackCoord.X
                                              && c.Coordinate.Y == attackCoord.Y);
            if (cell.Status == CellStatus.Battleship)
            {
                cell.Status = CellStatus.Hit;
            }
            else
            {
                cell.Status = CellStatus.Miss;
            }

            return await Task.FromResult(cell.Status);
        }
    }
}