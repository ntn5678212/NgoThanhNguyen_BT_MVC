namespace NTN_BTMVC.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<ClassSection> ClassSections { get; set; }
    }
}
