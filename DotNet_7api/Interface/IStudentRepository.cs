using DotNet_7api.Models;

namespace DotNet_7api.Interface
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Task<bool> AddStudent(Student student);
        Task<bool> EditStudent(Student student);
        Task<bool> DeleteStudent(int id);

    }
}
