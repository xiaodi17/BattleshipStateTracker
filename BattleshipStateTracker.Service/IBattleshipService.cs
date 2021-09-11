using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service.Models;

namespace BattleshipStateTracker.Service
{
    public interface IBattleshipService
    {
        void CreateBoard(int size = 10);
        Task<Battleship> AddBattleShip(Point startCoord, Point endCoord);
    }
}