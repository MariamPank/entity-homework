using SchoolAdmin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.Models
{
    internal class PupilClass : Entity
    {

        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
