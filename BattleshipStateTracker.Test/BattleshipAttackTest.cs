using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Models.Enums;
using Xunit;

namespace BattleshipStateTracker.Test
{
    public class BattleshipAttackTest
    {
        private readonly BattleshipService _battleshipService;

        public BattleshipAttackTest()
        {
            _battleshipService = new BattleshipService();
        }
        
        [Fact]
        public async Task AttackBattleship()
        {
            _battleshipService.CreateBoard();
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip(startCoord, endCoord);
            var status = await _battleshipService.Attack(startCoord);

            Assert.Equal(CellStatus.Hit, status);
        }
    }
}