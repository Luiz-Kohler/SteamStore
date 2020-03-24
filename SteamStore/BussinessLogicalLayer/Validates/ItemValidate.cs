using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class ItemValidate : IBaseValidate<Item>
    {
        public IReadOnlyCollection<Response> ValidateObject(Item objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
