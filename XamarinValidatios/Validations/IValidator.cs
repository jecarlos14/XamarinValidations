using System;
namespace XamarinValidatios.Validations
{
    public interface IValidator
    {
        string Message { get; set; }
        bool Check(string value);
    }
}
