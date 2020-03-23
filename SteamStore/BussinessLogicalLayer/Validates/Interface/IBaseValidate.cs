using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates.Interface
{
    public interface IBaseValidate <T>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(T objectToValidate);
    }
}
