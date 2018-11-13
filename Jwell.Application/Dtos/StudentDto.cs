using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using System.Linq;

namespace Jwell.Application.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }
    }

    public static class StudentDtoExt
    {
        public static IQueryable<StudentDto> ToDtos(this IQueryable<Student> query)
        {
            return from q in query
                   select new StudentDto
                   {
                       Name = q.Name,
                   };
        }

        public static PageResult<StudentDto> ToDtos(this PageResult<Student> query)
        {
            var queryDto = (from q in query.Pager
                            select new StudentDto
                            {
                                Name = q.Name,
                            }).ToList();
            return new PageResult<StudentDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static StudentDto ToDto(this Student student)
        {
            StudentDto dto = null;
            if (student != null)
            {
                dto = new StudentDto
                {
                    Name = student.Name
                };
            }
            return dto;
        }

        public static Student ToEntity(this StudentDto dto)
        {
            Student student = null;
            if (dto != null)
            {
                student = new Student { Name = dto.Name };
            }
            return student;
        }
    }
}
