using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
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
        [HttpPost("{boardId}/createBoard")]
        public async Task<IActionResult> Create(string boardId, int size = 10)
        {
            try
            {
                var board = await _battleshipService.CreateBoard(boardId, size);
                if (board == null)
                    return BadRequest("Board can't be created.");
                
                return Ok(board);
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
        [HttpPut("{boardId}/addBattleship")]
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
                    return BadRequest("Can't add battleship to the board.");
                }
                
                return Ok(battleShip);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Attack a cell on the board
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        [HttpPut("{boardId}/attack")]
        public async Task<IActionResult> Attack(string boardId, int row, int col)
        {
            try
            {
                var cell = await _battleshipService.Attack(boardId, new Point(row, col));

                if (cell == null)
                {
                    return BadRequest("You can't attack at this position.");
                }

                var attackResult = new AttackResultModel {AttackResult = cell.Status.ToString()};
                return Ok(attackResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        /// <summary>
        /// Reset battleship board
        /// </summary>
        /// <returns></returns>
        [HttpPost("reset")]
        public async Task<IActionResult> Reset()
        {
            try
            {
                await _battleshipService.Reset();
                return Ok("Battleship State Tracker has been successfully reset.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
