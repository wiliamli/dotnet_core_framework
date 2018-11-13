using Jwell.Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jwell.Domain.Entities
{
    [Table("Student")]
    public class Student : Entity<int>
    {
        public string Name { get; set; }
    }
}
