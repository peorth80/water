using System;

namespace Water.Models
{
	public class WaterModels
	{
		public class WaterModelsRequest
		{
			public DateTime DateTime { get; set; }
		}

		public class WaterModelResponse
		{
			public DateTime DateTime { get; set; }
			public int NumberOfGlasses { get; set; }
		}
	}
}
