using CoreApiResponse;
using DotNet_7api.Interface;
using DotNet_7api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNet_7api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                return CustomResult("Without shown it status code-okk.",await repository.GetAllStudent());
            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }



        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {

                //bool isSave= await repository.AddStudent(student);
                //if (isSave)
                //{
                //    return CustomResult("Student added successsfully", student);
                //}
                //return CustomResult("Student save failed",HttpStatusCode.BadRequest);
                return CustomResult("Student added successsfully",await repository.AddStudent(student));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPut]
        public async Task<IActionResult> EditStudent(Student student)
        {
            try
            {

                return CustomResult("Student has been modified",await repository.EditStudent(student));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {

                return CustomResult("Student has been deleted",await repository.DeleteStudent(id));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        public async Task<IActionResult> StudentbyId(int id)
        {
            try
            {

                return CustomResult("Student by Id",await repository.GetStudentById(id));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }




    }
}
