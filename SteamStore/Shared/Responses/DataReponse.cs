using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Responses
{
    public class DataReponse <T> : Response
    {
        public List<T> Data { get; set; }
    }
}
