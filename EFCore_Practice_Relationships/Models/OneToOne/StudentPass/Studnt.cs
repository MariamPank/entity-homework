using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.OneToOne.StudentPass
{
    internal class Studnt : Entity
    {
        public string Name { get; set; }

        public Passport Passport { get; set; }
    }
}
