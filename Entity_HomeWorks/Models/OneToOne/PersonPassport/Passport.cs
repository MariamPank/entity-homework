using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.PersonPassport
{
    public class Passport : Entity
    {
        public string PassportNumber { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
