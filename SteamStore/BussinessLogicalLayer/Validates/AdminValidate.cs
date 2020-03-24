using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    class AdminValidate : IBaseValidate<Admin>
    {
        public IReadOnlyCollection<Response> ValidateObject(Admin objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
}
