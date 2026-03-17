using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.ManyToMany.StdntCourse
{
    internal class StntCrs : Entity
    {
        public int StntId { get; set; }
        public Stnt Stnt {  get; set; }


        public int CrsId { get; set; }
        public Crs Crs { get; set; }
    }
}
