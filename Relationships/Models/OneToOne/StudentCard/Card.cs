using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.StudentCard
{
    public class Card : Entity
    {
        public int CardNumber { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
