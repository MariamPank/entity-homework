using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.OneToOne.CompDirector
{
    internal class Company : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
