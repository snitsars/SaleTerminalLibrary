namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// General interface for classes that provide value validation 
    /// </summary>
    public interface IValidationRule
    {
        bool Validate(decimal value);
    }
}