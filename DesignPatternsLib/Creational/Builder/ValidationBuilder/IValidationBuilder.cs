using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    public interface IValidationBuilder
    {
        void ResetBuilder();
        void SetOrder(Order order);
        void ValidatePet();
        void ValidateUser();
        void ValidatePayment();
        void ValidateProducts();
        void ValidateServices();
    }
}
