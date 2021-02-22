using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    public class ServiceValidationBuilder : OrderValidationBuilder
    {
        /// <summary>
        /// Not implemented - A service order will not have products.
        /// </summary>
        public override void ValidateProducts()
        {
            throw new NotImplementedException();
        }

        public override void ValidateServices()
        {
            throw new NotImplementedException();
        }
    }
}
