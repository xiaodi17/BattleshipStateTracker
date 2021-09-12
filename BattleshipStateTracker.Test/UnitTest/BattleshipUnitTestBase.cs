using BattleshipStateTracker.Service;

namespace BattleshipStateTracker.Test.UnitTest
{
    public class BattleshipUnitTestBase
    {
        protected BattleshipService _battleshipService;

        protected BattleshipUnitTestBase()
        {
            _battleshipService = new BattleshipService();
        }
    }
}