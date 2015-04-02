using System;

namespace RailDataEngine.Domain.Entity.TrainDescriber
{
	public abstract class TrainDescriberEntity
	{
		public DateTime? Timestamp { get; set; }
		public string AreaId { get; set; }
	}
}