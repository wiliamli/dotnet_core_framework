using Jwell.Application.Dtos;
using Jwell.Framework.Interceptors;
using Jwell.Framework.Paging;
using Jwell.Framework.Service;
using System.Collections.Generic;

namespace Jwell.Application
{
    public interface ITestService : IApplicationService
    {
        [Transaction]
        void TransactionTest();

        [Transaction]
        StudentDto AddStudent(StudentDto dto);

        PageResult<StudentDto> GetStudents(PageParam pageParam);
    }
}
