﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    public class ValidationDirector
    {
        private IValidationBuilder builder;

        public ValidationDirector() { }

        public ValidationDirector(IValidationBuilder builder)
        {
            this.builder = builder;
        }

        public void SetBuilder(IValidationBuilder builder)
        {
            this.builder = builder;
        }

        // Maybe don't validate the builder type in the construction functions?
        // Should be the responsibility of the caller to provide the right builder?

        public void ValidateOrder(Order order)
        {
            builder.ResetBuilder();
            builder.SetOrder(order);
            builder.ValidatePet();
            builder.ValidateUser();
            builder.ValidatePayment();
            builder.ValidateProducts();
            builder.ValidateServices();
        }
    }
}
