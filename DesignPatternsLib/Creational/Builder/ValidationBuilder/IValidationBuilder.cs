﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    public interface IValidationBuilder
    {
        void ResetBuilder();
        void ValidatePet();
        void ValidateUser();
        void ValidatePayment();
        void ValidateProduct();
        void ValidateService();
    }
}
