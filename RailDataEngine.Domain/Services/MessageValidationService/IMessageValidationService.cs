namespace RailDataEngine.Domain.Services.MessageValidationService
{
    public interface IMessageValidationService
    {
        string ValidateString(string stringToValidate);
        int ParseInt(string intToValidate);
        bool ValidateBool(string boolToValidate);
    }
}
