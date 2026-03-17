using SchoolAdmin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.Models
{
    internal class Class : Entity
    {
        public string ClassName { get; set; }
        public int Duration { get; set; }

        // Relations
        public List<PupilClass> Pupils{ get; set; } = new List<PupilClass>();
    }
}
