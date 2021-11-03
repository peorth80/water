using System;

namespace Water.DAL.Entities
{
	/// <summary>
	/// This class matches what the dynamo db database returns
	/// </summary>
	public class Water
	{
		public DateTime date { get; set; }
		public int glasses { get; set; }
	}
}
