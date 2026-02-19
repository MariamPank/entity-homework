using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.UserProfile
{
    public class UserProfile : Entity
    {
        public string Address { get; set; }
        public string Phone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
