using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cms.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult CustomOk(object data,string message = "")
        {
            return Ok(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Success
            });
        }
        public ActionResult CustomError(object data = null, string message = "")
        {
            return BadRequest(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Failed
            });
        }
        public class Result
        {
            public object Data { get; set; }
            public Status Status { get; set; }
            public string Message { get; set; }
        }
        public enum Status 
        {
            Success =  1,
            Failed = -1
        }
    }
}
