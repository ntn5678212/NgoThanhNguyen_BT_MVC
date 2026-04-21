namespace NTN_BTMVC.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassSectionId { get; set; }
        public ClassSection ClassSection { get; set; }

        public DateTime EnrollDate { get; set; }
    }
}
