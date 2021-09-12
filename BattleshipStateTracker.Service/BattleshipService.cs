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

        public async Task<Board> CreateBoard(string boardId, int size = 10)
        {
            var board = new Board(boardId,size);
            _boards.Add(board);
            return await Task.FromResult(board);
        }

        public async Task<Battleship> AddBattleShip(string boardId, Point startCoord, Point endCoord)
        {
            if (!ValidateAddBattleshipPosition(boardId, startCoord, endCoord))
            {
                return null;
            }
            
            var board = GetBoard(boardId);
            var cells = board.Cells.Where(c => c.Coordinate.X >= startCoord.X
                                               && c.Coordinate.Y >= startCoord.Y
                                               && c.Coordinate.X <= endCoord.X
                                               && c.Coordinate.Y <= endCoord.Y).ToList();

            foreach (var cell in cells)
            {
                if (IsCellOccupied(boardId, cell))
                {
                    return null;
                }
                cell.Status = CellStatus.Battleship;
            }

            var ship = new Battleship(startCoord, endCoord, cells);
            return await Task.FromResult(ship);
        }

        private bool ValidateAddBattleshipPosition(string boardId, Point startCoord, Point endCoord)
        {
            var board = GetBoard(boardId);
            if (!BattleshipHelper.IsValidCoordinate(board, startCoord) || !BattleshipHelper.IsValidCoordinate(board, endCoord))
            {
                return false;
            }

            if (!BattleshipHelper.IsShipHorizontalOrVertical(startCoord, endCoord))
            {
                return false;
            }

            return true;
        }

        public async Task<CellStatus?> Attack(string boardId, Point attackCoord)
        {
            var board = GetBoard(boardId);

            if (!BattleshipHelper.IsValidCoordinate(board, attackCoord))
            {
                return null;
            }
            
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

        private bool IsCellOccupied(string boardId, Cell cell)
        {
            if (cell.Status == CellStatus.Battleship)
            {
                return true;
            }

            return false;
        }

        private Board GetBoard(string boardId)
        {
            var board = _boards.FirstOrDefault(i => i.BoardId == boardId);
            return board;
        }
    }
}