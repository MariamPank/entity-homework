using SchoolAdmin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.Models
{
    internal class Pupil : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public List<PupilClass> Classes { get; set; } = new List<PupilClass>();
    }
}
