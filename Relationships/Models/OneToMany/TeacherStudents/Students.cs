using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.TeacherStudents
{
    internal class Students : Entity
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
