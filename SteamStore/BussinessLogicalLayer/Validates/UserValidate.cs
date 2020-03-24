using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class UserValidate : IBaseValidate<User>
    {
        public IReadOnlyCollection<Response> ValidateObject(User objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
