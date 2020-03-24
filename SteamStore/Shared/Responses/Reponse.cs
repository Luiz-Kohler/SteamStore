using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Responses
{
    public class Response
    {
        public bool Success { get; set; } = true;
        public List<Error> Erros { get; set; }

        public Response()
        {
            Erros = new List<Error>();
        }

        public void AddError(string proprety, string message)
        {
            Erros.Add(new Error { Message = message, Proprety = proprety });
        }

        public void ChangeStateSuccess(bool success)
        {
            this.Success = success;
        }

        public bool HasError()
        {
            return Erros.Count > 0;
        }
    }
}
