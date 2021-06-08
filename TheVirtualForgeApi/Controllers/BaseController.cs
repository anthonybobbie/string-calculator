using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TheVirtualForgeApi.ApplicationCore.DTO;

namespace TheVirtualForgeApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult DataResponse<T>( T item,string actionName="",int statusCode=200)
        {
            switch (statusCode)
            {
                case 201:
                    return CreatedAtAction(actionName, new ResponseObjectDTO<T>()
                    {
                        Data = item,
                        Message = null,
                        StatusCode = 201
                    });
                default:
                    return Ok(new ResponseObjectDTO<T>()
                    {
                        Data = item,
                        Message = null,
                        StatusCode = statusCode
                    });
            }
           
        }
        public ActionResult<ResponseObjectDTO<T>> BadResponse<T>(T item, HttpStatusCode statusCode)
        {
            var response = new ResponseObjectDTO<T>()
            {
                
                Message = null,
                StatusCode = (int)HttpStatusCode.OK
            };
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(new ResponseObjectDTO<T>()

                    {
                        
                        Message = null,
                        StatusCode = (int)HttpStatusCode.BadRequest
                    });
                case HttpStatusCode.Unauthorized:
                  return  Unauthorized(new ResponseObjectDTO<T>()

                  {
                        
                        Message = null,
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    });
                case HttpStatusCode.NotFound:
                    return NotFound(new ResponseObjectDTO<T>()

                    {
                       
                        Message = null,
                        StatusCode = (int)HttpStatusCode.NotFound
                    });
                default:
                    return StatusCode(500);
            }
            
        }
    }
}