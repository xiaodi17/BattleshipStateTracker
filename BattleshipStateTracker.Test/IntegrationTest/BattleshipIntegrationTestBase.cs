using BattleshipStateTracker.API.Controllers;
using BattleshipStateTracker.Service;
using Microsoft.Extensions.Logging;
using Moq;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class BattleshipControllerTestBase
    {
        protected BattleshipController _controller;
        private IBattleshipService _service;
        private ILogger<BattleshipController> _logger;

        protected BattleshipControllerTestBase()
        {
            _service = new BattleshipService();
            _logger = Mock.Of<ILogger<BattleshipController>>();
            _controller = new BattleshipController(_logger, _service);
        }
    }
}