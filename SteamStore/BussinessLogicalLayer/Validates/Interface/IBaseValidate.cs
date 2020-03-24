using Flunt.Notifications;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates.Interface
{
    public interface IBaseValidate <T>
    {
        public IReadOnlyCollection<Response> ValidateObject(T objectToValidate);
    }
}
