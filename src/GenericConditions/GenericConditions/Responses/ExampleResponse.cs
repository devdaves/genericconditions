using GenericConditions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConditions.Responses
{
    public class ExampleResponse : IResponse
    {
        public Status Status { get; set; }
        public string Response { get; set; }
        public bool Condition1Ran { get; set; }
        public bool Condition2Ran { get; set; }
        public bool Condition3Ran { get; set; }
        public bool DoWorkRan { get; set; }
        public bool Condition4Ran { get; set; }
        public bool Condition5Ran { get; set; }
        public bool Condition6Ran { get; set; }
        public bool DoWork2Ran { get; set; }

        public ExampleResponse()
        {
            Status = new Status() { StatusCode = 0, StatusDescription = "OK" };
        }
    }
}
