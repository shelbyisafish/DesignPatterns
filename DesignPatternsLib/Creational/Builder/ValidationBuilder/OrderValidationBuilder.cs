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
        private Order order;
        private bool success;
        private string errorMessages;

        public void SetOrder(Order order)
        {
            this.order = order;
        }

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
            order = null;
            success = false;
            errorMessages = null;
        }

        /// <summary>
        /// Did the validation succeed? Returns a tuple (success?, error messages).
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, string> GetValidationResult()
        {
            if (order != null)
                return new Tuple<bool, string>(success, errorMessages);
            else
                return new Tuple<bool, string>(false, "Validation has not started yet.");
        }

        /// <summary>
        /// Subclasses must define ValidateProducts().
        /// </summary>
        public abstract void ValidateProducts();

        /// <summary>
        /// Subclasses must define ValidateServices().
        /// </summary>
        public abstract void ValidateServices();
    }
}
