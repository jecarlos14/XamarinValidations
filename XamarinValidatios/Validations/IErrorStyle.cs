using System;
using Xamarin.Forms;

namespace XamarinValidatios.Validations
{
    public interface IErrorStyle
    {
        void ShowError(View view, string message);
        void RemoveError(View view);
    }
}
