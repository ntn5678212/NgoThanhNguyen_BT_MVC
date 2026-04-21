namespace NTN_BTMVC.Models
{
    public class ClassSection
    {
        public int ClassSectionId { get; set; }
        public string ClassName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
