namespace NTN_BTMVC.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CourseName { get; set; }
        public int Credits {  get; set; }

        public ICollection<ClassSection> ClassSections { get; set; }
    }
}
