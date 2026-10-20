using System.ComponentModel.DataAnnotations;

namespace StudentsApp
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student { }

    public class StudentMetadata
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(InstructorMetadata))]
    public partial class Instructor { }

    public class InstructorMetadata
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime HireDate { get; set; }
    }

    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

    public class DepartmentMetadata
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, Range(0, 100000000)]
        public decimal Budget { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
    }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Courses { }

    public class CourseMetadata
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, Range(1, 10)]
        public int Credits { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }

    public class EnrollmentMetadata
    {
        [Range(0, 4)]
        public decimal? Grade { get; set; }
    }
}