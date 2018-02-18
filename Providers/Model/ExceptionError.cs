
using System;

namespace Providers.Model
{
    public class ExceptionError
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime Date { get; set; }
        public string InnerException { get; set; }
        public string Source { get; set; }
    }
}
