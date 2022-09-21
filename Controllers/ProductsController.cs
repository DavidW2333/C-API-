using CS335_A1.Data;
using CS335_A1.Dtos;
using CS335_A1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public ProductsController(IWebAPIRepo repository)
        {
            _repository = repository;
        }
        [HttpGet("GetItems")]
        public ActionResult<IEnumerable<ProductsOutDtos>> GetItems()
        {
            IEnumerable<Products> products = _repository.GetItems();
            IEnumerable<ProductsOutDtos> c = products.Select(e => new ProductsOutDtos { Id = e.Id, Name = e.Name, Description = e.Description, Price = e.Price });
            return Ok(c);
        }

        [HttpGet("GetItems/{NAME}")]
        public ActionResult<IEnumerable<ProductsOutDtos>> GetItems(string name)
        {
            IEnumerable<Products> products = _repository.GetItemsByName(name);
            IEnumerable<ProductsOutDtos> c = products.Select(e => new ProductsOutDtos { Id = e.Id, Name = e.Name, Description = e.Description, Price = e.Price });

            return Ok(c);
        }

        [HttpGet("GetItemPhoto/{ID}")]
        public ActionResult GetItemPhoto(int id )
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "ItemsImages");
            string fileName1 = Path.Combine(imgDir, id + ".png");
            string fileName2 = Path.Combine(imgDir, id + ".jpg");
            string fileName3 = Path.Combine(imgDir, id + ".gif");
            string fileName4 = Path.Combine(imgDir, "default.png");
            string respHeader = "image/png";
            string fileName = fileName4;
            if (System.IO.File.Exists(fileName1))
            {
                respHeader = "image/png";
                fileName = fileName1;
            }
            else if (System.IO.File.Exists(fileName2))
            {
                respHeader = "image/jpeg";
                fileName = fileName2;
            }
            else if (System.IO.File.Exists(fileName3))
            {
                respHeader = "image/gif";
                fileName = fileName3;
            }

            return PhysicalFile(fileName, respHeader);

        }
    }
}
