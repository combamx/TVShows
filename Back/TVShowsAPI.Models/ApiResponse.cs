using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShowsAPI.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }
        public int Counts { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
