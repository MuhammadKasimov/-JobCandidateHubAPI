using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Service.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public int Code { get; set; }

        public HttpStatusCodeException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
