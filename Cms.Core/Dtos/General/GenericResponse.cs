using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Dtos.General
{
    public class GenericResponse<T> : UseCaseResponseMessage
    {
        public T Data {get;}
        public IEnumerable<Error> Errors { get;}
        public GenericResponse(IEnumerable<Error> errors,bool success = false,string message = null) : base(success, message)
        {
            Errors = errors;
        }
        public GenericResponse(T data,bool success = false, string message = null) : base(success, message)
        {
            Data = data;
        }
        public GenericResponse(bool success = false, string message = null) : base(success, message)
        {
            
        }
    }
    public abstract class UseCaseResponseMessage 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        protected UseCaseResponseMessage(bool seccess = false , string message = null) 
        {
            Success = seccess ;
            Message = message;
        }
    }
    public sealed class Error 
    {
        public string Code { get;  }
        public string Description { get; }
        public string Stack {  get;  }
        public Error(string code , string description , string stack = "")
        {
            Code = code ;
            Description = description ;
#if     DEBUG
            Stack = stack ;
#endif        
        }

    }

}
