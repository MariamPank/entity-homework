using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.ManyToMany.StdntCourse
{
    internal class Crs : Entity
    {
        public string CrsName { get; set; }
        public string CrsDescription { get; set; }

        public List<StntCrs> StntCrs { get; set; } = new List<StntCrs>();
    }
}
