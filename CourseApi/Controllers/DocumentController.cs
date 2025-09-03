using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using CourseApi.Models;
using Microsoft.AspNetCore.Cors;

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpPost("upload")]
        [EnableCors()]
        public IActionResult Upload([FromForm] Models.Document document)
        {
            document.Id = 10;
            string sFolderPath;

            sFolderPath = "C:/Documents";
            var pathToSave = sFolderPath + "\\user";
            if (Request.Form.Files.Count > 0)
            {
                foreach (var temp in Request.Form.Files)
                {
                    var file = temp;
                    Directory.CreateDirectory(sFolderPath + "\\user");
                    //foreach (var file in certificates)
                    //{
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // }    
                    }
                }

                //_context.Requests.Add(Request);
                //_context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

    }

}