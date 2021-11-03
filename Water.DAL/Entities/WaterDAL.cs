using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Water.DAL.Entities
{
	/// <summary>
	/// Class that matches the dynamo db structure
	/// </summary>
	[DynamoDBTable("water")]
	public class WaterDAL
	{
		/// <summary>
		/// Date format: yyyyMMdd
		/// </summary>
		[DynamoDBHashKey]
		public string date { get; set; }

		[DynamoDBProperty(AttributeName = "glasses")]
		public int glasses { get; set; }
	}
}
