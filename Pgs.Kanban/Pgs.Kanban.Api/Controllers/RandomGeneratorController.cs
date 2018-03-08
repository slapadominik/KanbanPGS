using Microsoft.AspNetCore.Mvc;
using Pgs.Kanban.Domain.Services;


namespace Pgs.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    public class RandomGeneratorController : Controller
    {
        private readonly RandomGeneratorService randomGeneratorService;

        public RandomGeneratorController()
        {
            randomGeneratorService = new RandomGeneratorService();
        }

        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            var number = randomGeneratorService.GenerateRandomNumber();
            return Ok(number);
        }

        [HttpGet]
        [Route("{maxValue}")]
        public IActionResult GetRandomNumberInRange(int maxValue)
        {
            var number = randomGeneratorService.GenerateRandomNumber(maxValue);
            return Ok(number);
        }

        [HttpPost]
        public IActionResult AddNumber([FromBody]int number)
        {
            randomGeneratorService.AddNumberToList(number);
            return NoContent();
        }

        [HttpDelete]
        [Route("{number}")]
        public IActionResult DeleteNumber(int number)
        {
            randomGeneratorService.DeleteNumber(number);
            return NoContent();
        }

        [HttpGet]
        [Route("AllNumbers")]
        public IActionResult GetAllNumbers()
        {
            var numbers = randomGeneratorService.GetAllNumbers();
            return Ok(numbers);
        }
    }
}
