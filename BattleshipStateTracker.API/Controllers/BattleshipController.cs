using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Exceptions;
using BattleshipStateTracker.Service.Models;

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
        /// Create a new board
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(string boardId, int size = 10)
        {
            try
            {
                _battleshipService.CreateBoard(boardId, size) ;
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Add a battleship to the board
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="startRow"></param>
        /// <param name="startCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        [HttpPut("battleship")]
        public async Task<IActionResult> AddBattleShip(string boardId, int startRow, int startCol, int endRow, int endCol)
        {
            try
            {
                var battleShip = await _battleshipService.AddBattleShip(
                    boardId,
                    new Point(startRow, startCol),
                    new Point(endRow, endCol));

                if (battleShip == null)
                {
                    return BadRequest("Cant add battleship.");
                }
                
                return Ok(battleShip);
            }
            catch (InvalidBattleshipCreateException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Attack
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        [HttpPut("attack")]
        public async Task<IActionResult> Attack(string boardId, int row, int col)
        {
            try
            {
                var response = await _battleshipService.Attack(boardId, new Point(row, col));

                if (response == null)
                {
                    return BadRequest("You can't attack at this position.");
                }
                return Ok(response.ToString());
            }
            catch (InvalidAttackException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
