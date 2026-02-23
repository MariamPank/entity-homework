using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.ManyToMany.Enrollment
{
    internal class Course : Entity
    {
        public string CourseName { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
