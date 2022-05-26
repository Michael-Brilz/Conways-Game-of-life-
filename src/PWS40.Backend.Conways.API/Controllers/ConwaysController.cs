using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PWS40.Backend.Conways.Model;

namespace PWS40.Backend.Conways.API.Controllers
{
    [ApiController]
    [Route("api/conways")]
    public class ConwaysController : Controller
    {
        [HttpPost]
        [Route("/nextGeneration/model")]
        public IActionResult NextGenerationModel(GameFieldModel oldGeneration)
        {
            var gameField = new GameField(oldGeneration);
            var nextGeneration = gameField.NextGenerationAsModel();

            return Ok(nextGeneration);
        }

        [HttpPost]
        [Route("/nextGeneration")]
        public IActionResult NextGeneration(string oldGeneration)
        {
            if(GameFieldParser.TryParseGameField(oldGeneration, out GameField oldGameFiled))
            {
                try
                {
                    var nextGeneration = oldGameFiled.NextGeneration();
                    return Ok(nextGeneration.ToGameFieldString());
                }
                catch(Exception ex)
                {
                    return StatusCode(500, $"An unexpected error occurred while processing the requested. \n[Error message]\n{ex.Message}");
                }
            }
            else
            {
                return BadRequest("Could not parse the given gamefield");
            }
        }
    }
}