using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using RainfallApi.Constants;
using RainfallApi.Enums;
using RainfallApi.Models;
using RainfallApi.Services;
using RainfallApi.Services.Interfaces;
using System.Net;

namespace RainfallApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("rainfall")]
    [ApiController]
    public class RainFallController : ControllerBase
    { 
        private readonly ILogger<RainFallController> _logger;
        private readonly IRainfallReadingService _rainfallReadingService;
        private readonly IErrorHandlingService _errorHandlingService;
        private readonly IValidationService _validationService;

        public RainFallController(ILogger<RainFallController> logger, 
            IRainfallReadingService rainfallReadingService,
            IErrorHandlingService errorHandlingService,
            IValidationService validationService)
        {
            _logger = logger;
            _rainfallReadingService = rainfallReadingService;
            _validationService = validationService;
            _errorHandlingService = errorHandlingService;
        }

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station.</param>
        /// <param name="number">The number of readings to return.</param>
        /// <returns>Rainfall Reading Response.</returns>
        [HttpPost]
        [Route("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRainfall(CancellationToken token, [FromRoute] string stationId, [FromQuery] int number = 10)
        {
            try
            {
                var errorResponse = CreateErrorResponse();

                var validationResponse = _validationService.ValidateInput(stationId, number);
                
                if (validationResponse.HasError) 
                {
                    errorResponse.ErrorDetails?.AddRange(validationResponse.Errors ?? new List<ErrorDetails>());
                    return BadRequest(errorResponse);
                }

                var result = await _rainfallReadingService.GetRainfallReadingAsync(stationId, number, token);

                
                if (result.Items == null)
                {
                    var errorDetail = _errorHandlingService.CreateErrorResponse(ErrorType.InvalidRequest);
                    errorResponse.ErrorDetails?.Add(errorDetail);
                    return BadRequest(errorResponse);
                }

                if (result.Items == null || result.Items.Count < 1)
                {
                    var errorDetail = _errorHandlingService.CreateErrorResponse(ErrorType.NoReadingsFound);
                    errorResponse.ErrorDetails?.Add(errorDetail);
                    return NotFound(errorResponse);
                }

                return Ok(result);
            }
            catch (HttpRequestException)
            {
                var errorResponse = CreateErrorResponse();

                errorResponse.ErrorDetails?.Add(_errorHandlingService.CreateErrorResponse(ErrorType.InternalServerError));

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        private ErrorResponse CreateErrorResponse() 
        {
            return new ErrorResponse();
        }
    }
}