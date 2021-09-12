using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.API.Controllers;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Models;
using BattleshipStateTracker.Service.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BattleshipStateTracker.Test.WebAPI
{
    public class BattleshipControllerTest
    {
        private BattleshipController _controller;
        private IBattleshipService _service;
        private ILogger<BattleshipController> _logger;

        public BattleshipControllerTest()
        {
            _service = Mock.Of<IBattleshipService>();
            _logger = Mock.Of<ILogger<BattleshipController>>();
            _controller = new BattleshipController(_logger, _service);
        }
        
        [Fact]
        public async Task CreateController()
        {
            var response = await _controller.Create("A", 10);
            var okResult = response as OkResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}