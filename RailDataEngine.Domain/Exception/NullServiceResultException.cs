using System;

namespace RailDataEngine.Domain.Exception
{
    public class NullServiceResultException : System.Exception
    {
        public string ServiceName { get; set; }
        public DateTime? Time { get; set; }
        public string RequestDetails { get; set; }

        public NullServiceResultException(string serviceName, string requestDetails)
        {
            ServiceName = serviceName;
            Time = DateTime.Now;
            RequestDetails = requestDetails;
        }
    }
}