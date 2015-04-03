using System;

namespace RailDataEngine.Domain.Entities.TrainDescriber
{
	public abstract class TrainDescriberEntity
	{
		public DateTime? Timestamp { get; set; }
		public string AreaId { get; set; }
	}
}