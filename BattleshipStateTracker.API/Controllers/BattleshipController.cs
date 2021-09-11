using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;

namespace BattleshipStateTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipController : ControllerBase
    {
        private readonly IBattleshipService _battleshipService;

        private readonly ILogger<BattleshipController> _logger;

        public BattleshipController(ILogger<BattleshipController> logger, IBattleshipService battleshipService)
        {
            _logger = logger;
            _battleshipService = battleshipService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("Create")]
        public IActionResult Create(string boardId, int size = 10)
        {
            try
            {
                _battleshipService.CreateBoard(boardId, size) ;
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
