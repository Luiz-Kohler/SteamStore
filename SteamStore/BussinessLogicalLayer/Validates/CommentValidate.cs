using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class CommentValidate : IBaseValidate<Comment>
    {
        public IReadOnlyCollection<Response> ValidateObject(Comment objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
