using RailDataEngine.Domain.Services.MessageValidationService;

namespace RailDataEngine.Services.MessageConversion
{
    public class MessageValidationService : IMessageValidationService
    {
        public string ValidateString(string stringToValidate)
        {
            return string.IsNullOrWhiteSpace(stringToValidate) ? null : stringToValidate;
        }

        public int ParseInt(string intToParse)
        {
            return string.IsNullOrWhiteSpace(intToParse) ? 0 : int.Parse(intToParse);
        }

        public bool ValidateBool(string boolToValidate)
        {
            if (string.IsNullOrWhiteSpace(boolToValidate))
                return false;

            return bool.Parse(boolToValidate);
        }
    }
}
