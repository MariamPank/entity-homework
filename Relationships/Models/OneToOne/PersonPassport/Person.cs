using Entity_HomeWorks_OneToOne.Core;
using Entity_HomeWorks_OneToOne.Models.OneToOne.StudentCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.PersonPassport
{
    public class Person : Entity
    {
        public string Name { get; set; }

        public Passport Passport { get; set; }
    }
}
