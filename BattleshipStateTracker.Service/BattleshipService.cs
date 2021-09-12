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
        public List<Board> _boards = new List<Board>();

        public async Task<Board> CreateBoard(string boardId, int size = 10)
        {
            if (string.IsNullOrEmpty(boardId))
                return null;
            
            var board = new Board(boardId, size);
            _boards.Add(board);
            return await Task.FromResult(board);
        }

        public async Task<Battleship> AddBattleShip(string boardId, Point startCoord, Point endCoord)
        {
            var board = GetBoard(boardId);
            if (board == null)
            {
                return null;
            }
            
            if (!BattleshipHelper.ValidateAddBattleshipPosition(board, startCoord, endCoord))
                return null;

            var cells = BattleshipHelper.GetCellsByStartAndEndCoordinates(board, startCoord, endCoord);

            foreach (var cell in cells)
            {
                if (BattleshipHelper.IsCellOccupied(cell))
                    return null;
                
                cell.Status = CellStatus.Battleship;
            }

            var ship = new Battleship(startCoord, endCoord, cells);
            return await Task.FromResult(ship);
        }

        public async Task<CellStatus?> Attack(string boardId, Point attackCoord)
        {
            var board = GetBoard(boardId);

            if (!BattleshipHelper.IsValidCoordinate(board, attackCoord))
                return null;
            
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

        public async Task<List<Board>> Reset()
        {
            _boards = new List<Board>();
            return await Task.FromResult(_boards);
        }

        private Board GetBoard(string boardId)
        {
            var board = _boards.FirstOrDefault(i => i.BoardId == boardId);
            return board;
        }
    }
}