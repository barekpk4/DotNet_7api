using DotNet_7api.Context;
using DotNet_7api.Interface;
using DotNet_7api.Models;
using System.Data;

namespace DotNet_7api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;
         public StudentRepository(AppDbContext context)
         {

            this.appDbContext = context;


         }



        public async Task<bool> AddStudent(Student student)
        {
            int rowAffected = await appDbContext.ExecuteAsync("SP_StudentSave", new {Name=student.Name,Department=student.Department}, commandType: CommandType.StoredProcedure);

            if(rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            int rowAffected = await appDbContext.ExecuteAsync("SP_StudentDelete", new { Id = id }, commandType: CommandType.StoredProcedure);


            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditStudent(Student student)
        {
            int rowAffected = await appDbContext.ExecuteAsync("SP_StudentUpdate", student, commandType: CommandType.StoredProcedure);

            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Student>> GetAllStudent()
        {
            var student = await appDbContext.QueryAsync<Student>("SP_GetallStudent", commandType: CommandType.StoredProcedure);

            return  student.ToList();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await appDbContext.QueryFirstOrDefaultAsync<Student>("SP_StudentById", new {Id=id}, commandType: CommandType.StoredProcedure);

            return student; ;
        }

       
    }
}
