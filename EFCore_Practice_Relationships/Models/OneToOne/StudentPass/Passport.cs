using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.OneToOne.StudentPass
{
    internal class Passport : Entity
    {
        public string PassNumber {  get; set; }

        public int StudntId { get; set; }
        public Studnt Studnt { get; set; }
    }
}
