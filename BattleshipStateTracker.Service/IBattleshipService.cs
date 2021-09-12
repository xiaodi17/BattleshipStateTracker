using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service.Models;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service
{
    public interface IBattleshipService
    {
        Task<Board> CreateBoard(string boardId, int size = 10);
        Task<Battleship> AddBattleShip(string boardId, Point startCoord, Point endCoord);
        Task<CellStatus?> Attack(string boardId, Point attackCoord);
        Task<List<Board>> Reset();
    }
}