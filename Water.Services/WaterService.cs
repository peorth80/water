using Amazon.DynamoDBv2;
using System;
using static Water.Models.WaterModels;

namespace Water.Services
{
	public class WaterService
	{
		/// <summary>
		/// This performs the query to the DynamoDB tables
		/// </summary>
		/// <returns>WaterModelResponse with the data</returns>
		public WaterModelResponse FetchNumberGlasses(WaterModelsRequest waterModelsRequest)
		{
			int nrGlasses = 0;
			var data = DAL.DynamoDB.DynamoClient.GetWater(waterModelsRequest.DateTime);
			if (data.Result != null) nrGlasses = data.Result.glasses;

			return new WaterModelResponse
			{
				DateTime = waterModelsRequest.DateTime,
				NumberOfGlasses = nrGlasses
			};
		}
	}
}
