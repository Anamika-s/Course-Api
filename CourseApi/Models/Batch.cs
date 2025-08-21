using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public DateOnly StartDate { get; set; }


        // establishes between two entitues 
        //public int TrainerCode { get; set; }
        //public Trainer? Trainer  { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public Trainer?  Trainer { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
