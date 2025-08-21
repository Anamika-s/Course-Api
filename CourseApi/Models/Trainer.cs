using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.Models
{
    //[Table("tblTrainer")]
    public class Trainer
    {
        [Key]
        public int TrainerCode { get; set; }
        [Required]
        [Column("Name")]
        public string TrainerName { get; set; }
        [Required]
        [Range(10, 15)]
        public int Exp { get; set; }
        [Required]
        public string Domain { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }


        public List<Batch>? Batches { get; set; }
    }

}
