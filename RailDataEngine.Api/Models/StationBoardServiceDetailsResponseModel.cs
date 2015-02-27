using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Api.Models
{
    public class StationBoardServiceDetailsResponseModel
    {
        /// <summary>
        /// Details for a specific service.
        /// </summary>
        public ServiceDetails ServiceDetails { get; set; }
    }
}