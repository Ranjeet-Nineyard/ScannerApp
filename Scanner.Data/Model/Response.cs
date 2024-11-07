using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data.Model
{
    public class Response<T> 
    {
        public string IsSuccess { get; set; } 
        public string Message { get; set; } 
        public List<string> Error { get; set; } 
        public T Data { get; set; } 
    }
}
