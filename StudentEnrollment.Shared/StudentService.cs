using StudentEnrollment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Shared
{
    public class StudentService
    {

        private readonly HttpClient _http;
        public StudentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _http.GetFromJsonAsync<List<Student>>("api/students");
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _http.GetFromJsonAsync<Student>($"api/students/{id}");
        }

        public async Task CreateStudent(Student student)
        {
            await _http.PostAsJsonAsync("api/students", student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _http.PutAsJsonAsync($"api/students/{student.StudentId}", student);
        }

        public async Task DeleteStudent(int id)
        {
            await _http.DeleteAsync($"api/students/{id}");
        }

    }
}
