using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Water.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WaterController : ControllerBase
	{
		private readonly ILogger<WaterController> _logger;
		private Services.WaterService _service;

		public WaterController(ILogger<WaterController> logger)
		{
			_logger = logger;

			_service = new Services.WaterService();
		}

		/// <summary>
		/// Will return how many glasses of water I had on a given date
		/// </summary>
		/// <param name="date">Format of date: yyyy-mm-dd (max length: 8)</param>
		/// <returns>Number of glasses of water I had that day</returns>
		[HttpGet]
		public ActionResult<Models.WaterModels.WaterModelResponse> Get(string date)
		{
			//If the parameter comes empty, we can asume today. We don't set the date as required because of it
			if (date == null) date = DateTime.Now.ToString("yyyy-MM-dd");

			if (!DateTime.TryParse(date, out DateTime dt))
				return Problem($"The date {date} is not a valid format");

			Models.WaterModels.WaterModelsRequest waterModels = new Models.WaterModels.WaterModelsRequest
			{
				DateTime = dt
			};

			return _service.FetchNumberGlasses(waterModels);
		}
	}
}
