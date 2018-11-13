using Jwell.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jwell.Domian.Entities
{
    [Table("Teacher")]
    public class Teacher : Entity<int>
    {
        public string Name { get; set; }
    }
}
