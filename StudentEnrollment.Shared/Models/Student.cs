using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Shared.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public  string StudentSurname { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentIDNumber {  get; set; } = string.Empty;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
