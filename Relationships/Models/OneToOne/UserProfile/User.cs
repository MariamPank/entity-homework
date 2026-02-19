using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_HomeWorks_OneToOne.Core;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.UserProfile
{
    public class User : Entity
    {
        public int UserName { get; set; }

        public UserProfile Profile { get; set; }
    }
}
