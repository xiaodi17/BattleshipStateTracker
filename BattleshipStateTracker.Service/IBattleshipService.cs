using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service.Models;
using BattleshipStateTracker.Service.Models.Enums;

namespace BattleshipStateTracker.Service
{
    public interface IBattleshipService
    {
        void CreateBoard(int size = 10);
        Task<Battleship> AddBattleShip(Point startCoord, Point endCoord);
        Task<CellStatus> Attack(Point attackCoord);
    }
}