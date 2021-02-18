using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    /// <summary>
    /// OrderValidatorBuilder is abstract because there's no such thing as an order that doesn't have products or services.
    /// </summary>
    public abstract class OrderValidationBuilder : IValidationBuilder
    {
        public void ValidatePayment()
        {
            throw new NotImplementedException();
        }

        public void ValidatePet()
        {
            throw new NotImplementedException();
        }

        public void ValidateUser()
        {
            throw new NotImplementedException();
        }

        public void ResetBuilder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subclasses must define ValidateProduct().
        /// </summary>
        public abstract void ValidateProduct();

        /// <summary>
        /// Subclasses must define ValidateService().
        /// </summary>
        public abstract void ValidateService();
    }
}
