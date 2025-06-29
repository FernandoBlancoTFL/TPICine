using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class CustomResponse<T>
    {
        public CustomResponse()
        {
            Errors = new List<string>();
        }

        public T Data { get; set; }

        public bool IsValid { get => !Errors.Any(); }

        public List<String> Errors { get; set; }

        public List<T> Data2 { get; set; }
    }
}
