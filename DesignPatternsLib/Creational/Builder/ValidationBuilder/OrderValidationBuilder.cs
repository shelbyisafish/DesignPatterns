using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private Regex emailRegex = new Regex("", RegexOptions.IgnoreCase);
        private Regex phoneRegex = new Regex("");
        private Regex nonNumeric = new Regex(@"[^\d]");

        public void SetOrder(Order order)
        {
            this.order = order;
        }

        public void ValidatePayment()
        {
            // In a real-life situation, would need to validate
            // the payment credit card and billing address,
            // probably with some external api.
            return;
        }

        public void ValidatePet()
        {
            if (string.IsNullOrWhiteSpace(order.Pet.Name))
                throw new Exception("Pet name cannot be empty.");
            
            if (string.IsNullOrWhiteSpace(order.Pet.Breed))
                throw new Exception("Pet breed cannot be empty.");

            switch(order.Pet.Sex.ToLower())
            {
                case "m":
                case "male":
                    // set some enum to Male
                    break;
                case "f":
                case "female":
                    // set some enum to Female
                    break;
                default:
                    throw new Exception($"Pet sex was not in a correct format. Pet.Sex: {order.Pet.Sex}");
            }
        }

        public void ValidateUser()
        {
            if (string.IsNullOrWhiteSpace(order.User.Name))
                throw new Exception("User name cannot be empty.");

            if (!emailRegex.IsMatch(order.User.Email))
                throw new Exception($"User email was not in a correct format. User.Email: {order.User.Email}");

            if (!phoneRegex.IsMatch(order.User.Phone))
                throw new Exception($"User phone was not in a correct format. User.Phone: {order.User.Phone}");
            else
            {
                string digitsOnly = nonNumeric.Replace(order.User.Phone, "");
                if (digitsOnly.Count() == 7)
                    order.User.Phone = $"{digitsOnly.Remove(0,3)}-{digitsOnly.Remove(0,4)}";
                else if (digitsOnly.Count() == 10)
                    order.User.Phone = $"({digitsOnly.Remove(0,3)}) {digitsOnly.Remove(0,3)}-{digitsOnly.Remove(0,4)}";
                else if (digitsOnly.Count() == 11 && digitsOnly.First() == 1)
                    order.User.Phone = $"{digitsOnly.Remove(0,1)}-{digitsOnly.Remove(0,3)}-{digitsOnly.Remove(0,3)}-{digitsOnly.Remove(0,4)}";
                else
                    throw new Exception($"User phone was not in a correct format. User.Phone: {order.User.Phone}");
            }
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
