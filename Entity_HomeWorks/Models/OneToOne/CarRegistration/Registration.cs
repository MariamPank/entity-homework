using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.CarRegistration
{
    public class Registration : Entity
    {
        public string RegNumber { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
