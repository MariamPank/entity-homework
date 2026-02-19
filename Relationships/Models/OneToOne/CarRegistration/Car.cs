using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.CarRegistration
{
    public class Car : Entity
    {
        public string Model { get; set; }

        public Registration Registration { get; set; }
    }
}
