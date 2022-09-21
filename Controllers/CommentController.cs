using CS335_A1.Data;
using CS335_A1.Dtos;
using CS335_A1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public CommentsController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("WriteComment")]
        public ActionResult<CommentsOutDtos> WriteComment(CommentsInDtos comment)
        {
            Comments c = new Comments {  Time = DateTime.Now.ToString("HH:mm:ss-dd/MM/yyyy"), Comment = comment.Comment, Name = comment.Name, IP = Request.HttpContext.Connection.RemoteIpAddress.ToString() };
            Comments addedCustomer = _repository.AddComments(c);
            CommentsOutDtos co = new CommentsOutDtos { Comment = addedCustomer.Comment, Name = addedCustomer.Name };
            return null;     //CreatedAtAction(nameof(Get), new { id = co.Id }, co);
        }
        [HttpGet("GetComments")]
        public ActionResult<IEnumerable<CommentsOutDtos>> GetComments()
        {
            IEnumerable<Comments> com = _repository.GetComments();
            IEnumerable<CommentsOutDtos> c = com.Select(e => new CommentsOutDtos { Comment = e.Comment, Name = e.Name });
            return Ok(c);
        }
    }
}
