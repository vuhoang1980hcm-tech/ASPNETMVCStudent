using System.Web.Mvc;

namespace StudentsApp.Models
{
    public class CourseViewModel
    {
        public int SelectedCourseID { get; set; }
        public SelectList Courses { get; set; }
    }

    public class StudentReportRow
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Grade { get; set; }
    }
}