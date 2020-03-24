using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class AdValidate : IBaseValidate<Ad>
    {
        public IReadOnlyCollection<Response> ValidateObject(Ad objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
