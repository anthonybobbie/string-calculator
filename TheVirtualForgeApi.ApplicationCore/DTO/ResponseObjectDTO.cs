using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVirtualForgeApi.ApplicationCore.DTO
{
    public class ResponseObjectDTO<T>
    {
        public T Data { get; set; }
        public object Message { get; set; }
        public int StatusCode { get; set; }
    }
}
