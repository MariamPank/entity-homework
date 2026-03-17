using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.StudentCard
{
    public class StudentR : Entity
    {
        public string Name { get; set; }

        public Card Card { get; set; }
    }
}
