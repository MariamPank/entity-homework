using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.ManyToMany.StdntCourse
{
    internal class Stnt : Entity
    {
        public string Name { get; set; }
        public int ClassYear { get; set; }

        public List<StntCrs> StntCrs { get; set; } = new List<StntCrs>();
    }
}
