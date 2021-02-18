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
        public override void ValidateProduct()
        {
            throw new NotImplementedException();
        }

        public override void ValidateService()
        {
            throw new NotImplementedException();
        }
    }
}
