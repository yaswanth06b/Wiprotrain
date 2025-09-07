using System.ComponentModel.DataAnnotations;

namespace OLMS.DTO
{
    public class AssignmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseID { get; set; }
        public DateTime DueDate { get; set; }
    }
}

