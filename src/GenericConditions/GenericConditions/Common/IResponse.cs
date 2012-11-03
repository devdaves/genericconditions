using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConditions.Common
{
    public interface IResponse
    {
        Status Status { get; set; }
    }
}
