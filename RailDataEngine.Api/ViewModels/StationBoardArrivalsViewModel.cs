using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Api.ViewModels
{
    public class StationBoardArrivalsViewModel
    {
        /// <summary>
        /// List of arrivals from the station board API.
        /// </summary>
        public List<Arrival> Services { get; set; }

        /// <summary>
        /// Name of the station from the CRS code of the request.
        /// </summary>
        public string StationName { get; set; }
    }
}