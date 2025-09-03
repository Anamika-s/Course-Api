using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.Models
{
    public class Document
    {
            public int? Id { get; set; }
            public string AadharPath { get; set; }
            
            [NotMapped]
            public IFormFile? Aadhar { get; set; }
            


        }
    }

