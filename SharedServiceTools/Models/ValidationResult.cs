namespace SharedServiceTools
{
    public class ValidationResult
    {
        public ValidationResult(ValidationError error, bool isValid)
        {
            this.Error = error;
            this.IsValid = isValid;
        }

        public ValidationError Error { get; set; }

        public bool IsValid { get; set; }
    }
}
