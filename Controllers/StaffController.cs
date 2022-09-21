using CS335_A1.Data;
using CS335_A1.Dtos;
using CS335_A1.Helper;
using CS335_A1.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public StaffController(IWebAPIRepo repository)
        {
            _repository = repository;
        }
        [HttpGet("GetAllStaff")]
        public ActionResult<IEnumerable<StaffOutDtos>> GetAllStaff()
        {
            IEnumerable<Staff> staff = _repository.GetAllStaff();
            IEnumerable<StaffOutDtos> c = staff.Select(e => new StaffOutDtos { Id = e.Id, LastName = e.LastName, FirstName = e.FirstName, Title = e.Title, Email=e.Email, Tel=e.Tel, Url=e.Url, Research= e.Research  });
            return Ok(c);
        }

        [HttpGet("GetStaffPhoto/{ID}")]
        public ActionResult GetStaffPhoto(int id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
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

        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int id)
        {
            Staff bear = _repository.GetStaffByID(id);
            string path = Directory.GetCurrentDirectory();
            string fileName = Path.Combine(path, "StaffPhotos/" + id + ".png");
            string photoString, photoType;
            ImageFormat imageFormat;
            if (System.IO.File.Exists(fileName))
            {
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else
                return NotFound();
            StaffOutDtos cardOut = new StaffOutDtos();
            //cardOut.Name = bear.Title + " " + bear.FirstName + " " + bear.LastName;
            //cardOut.Id = bear.Id;
            //cardOut.Photo = photoString;
            //cardOut.PhotoType = photoType;
            //cardOut.Categories = Helper.HobbiesFilter.Filter(bear.Hobbies);
            Response.Headers.Add("Content-Type", "text/vcard");
            return Ok(cardOut);
        }
    }
}

        
