using StudentEnrollment.Shared.Models;
using System.Net.Http.Json;

namespace StudentEnrollment.Client.Service
{
    public class CourseService
    {
        private readonly HttpClient _http;
        public CourseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _http.GetFromJsonAsync<List<Course>>("api/courses");
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _http.GetFromJsonAsync<Course>($"api/courses/{id}");
        }

        public async Task CreateCourse(Course course)
        {
            await _http.PostAsJsonAsync("api/courses", course);
        }
        public async Task UpdateCourse(Course course)
        {
            await _http.PutAsJsonAsync($"api/courses/{course.CourseId}", course);
        }

        public async Task DeleteCourse(int id)
        {
            await _http.DeleteAsync($"api/courses/{id}");
        }

    }
}
