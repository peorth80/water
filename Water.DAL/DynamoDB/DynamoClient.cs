using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Water.DAL.DynamoDB
{
	public class DynamoClient
	{
		private static readonly AmazonDynamoDBClient _amazonDynamoDBClient;
		private static readonly DynamoDBContext _context;

		static DynamoClient()
		{
			//The credentials are stored in the profile
			_amazonDynamoDBClient = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);

			//We set a context to group the tables
			_context = new DynamoDBContext(_amazonDynamoDBClient, new DynamoDBContextConfig
			{
				TableNamePrefix = "rosario_"
			});
		}

		/// <summary>
		/// Returns the data from Dynamo DB
		/// </summary>
		public async static Task<Entities.WaterDAL> GetWater(DateTime dateTime)
		{
			string parsedDateTime = dateTime.ToString("yyyy-MM-dd");

			try
			{
				var dbData = _context.LoadAsync<Entities.WaterDAL>(parsedDateTime);

				return await dbData;
			} 
			catch (Exception ex)
			{
				throw new Exception("Error retrieving information from DynamoDB", ex);
			}
		}
	}
}
