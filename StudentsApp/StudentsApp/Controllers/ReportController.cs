using System.Linq;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: Report
        public ActionResult Index()
        {
            var model = new CourseViewModel
            {
                Courses = new SelectList(db.Courses, "CourseID", "Title")
            };
            return View(model);
        }

        // POST: Report/Generate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generate(int selectedCourseID, string action)
        {
            var course = db.Courses.Find(selectedCourseID);
            if (course == null)
            {
                return HttpNotFound();
            }

            var students = db.Enrollments
                .Where(e => e.CourseID == selectedCourseID)
                .Select(e => new StudentReportRow
                {
                    StudentID = e.Student.StudentID,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Grade = e.Grade
                }).ToList();

            using (var report = new LocalReport())
            {
                report.ReportPath = Server.MapPath("~/Reports/StudentReport.rdlc");
                report.DataSources.Add(new ReportDataSource("StudentDataSet", students));
                report.SetParameters(new ReportParameter("CourseTitle", course.Title));

                byte[] pdf = report.Render("PDF");

                if (action == "export")
                {
                    return File(pdf, "application/pdf", "StudentReport.pdf");
                }
                return File(pdf, "application/pdf");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}