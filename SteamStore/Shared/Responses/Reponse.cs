using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public List<Error> Erros { get; set; }

        public Response()
        {
            Success = true;
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
            return Erros.Count > 0 ? this.Success = false : this.Success = true;
        }
    }
}
