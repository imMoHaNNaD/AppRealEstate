using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Message
{
    public class BaseResponse <T>
    {
        public Status status { get; set; }
        public T body { get; set; }
    }
}
