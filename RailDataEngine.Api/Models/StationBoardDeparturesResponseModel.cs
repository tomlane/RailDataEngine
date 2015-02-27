using System.Collections.Generic;
using RailDataEngine.Domain.Entity.StationBoard;

namespace RailDataEngine.Api.Models
{
    public class StationBoardDeparturesResponseModel
    {
        /// <summary>
        /// List of departures from the station board API.
        /// </summary>
        public List<Departure> Services { get; set; }

        /// <summary>
        /// Name of the station from the CRS code of the request.
        /// </summary>
        public string StationName { get; set; }
    }
}