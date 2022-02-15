using api_banco_geek.Domain.Contracts;
using api_banco_geek.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_banco_geek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly ILogger<FibonacciController> _logger;
        private readonly INumberProcessor _numberProcessor;

        public FibonacciController(ILogger<FibonacciController> logger, INumberProcessor numberProcessor)
        {
            _logger = logger;
            _numberProcessor = numberProcessor;
        }

        [HttpPost]
        public ActionResult ProcessNumbers([FromBody] SumArgs args)
        {
            if (args == null) { return BadRequest(); }

            try
            {
                SumResult result = _numberProcessor.ProcessNumbers(args);

                if (result == null) { return StatusCode(StatusCodes.Status500InternalServerError, "Error procesando números"); }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProcessNumbers, argumentos: {@Args}", args);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error procesando números: {ex.Message}");
            }
        }
    }
}
