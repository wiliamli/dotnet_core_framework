using Jwell.Application.Dtos;
using Jwell.Domain.Entities;
using Jwell.Domian.Entities;
using Jwell.Framework.Paging;
using Jwell.Framework.Service;
using Jwell.Repository.Repositories;

namespace Jwell.Application
{
    public class TestService : ApplicationService, ITestService
    {
        private readonly IStudentRepository _studentRepository;

        private readonly ITeacherRepository _teacherRepository;

        public TestService(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public StudentDto AddStudent(StudentDto dto)
        {
            return _studentRepository.Insert(dto.ToEntity()).ToDto();
        }

        public PageResult<StudentDto> GetStudents(PageParam pageParam)
        {
            return _studentRepository.GetAll().ToDtos().ToPageResult(pageParam);
        }

        public void TransactionTest()
        {
            _studentRepository.Insert(new Student { Name = "张三" });
            _teacherRepository.Insert(new Teacher { Name = "李四" });
        }
    }
}
