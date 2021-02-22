using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.ValidationBuilder
{
    public class ProductValidationBuilder : OrderValidationBuilder
    {
        /// <summary>
        /// Not implemented - a product order will not have services.
        /// </summary>
        public override void ValidateServices()
        {
            throw new NotImplementedException();
        }

        public override void ValidateProducts()
        {
            throw new NotImplementedException();
        }
    }
}
