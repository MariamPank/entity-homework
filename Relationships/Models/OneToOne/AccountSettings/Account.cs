using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.AccountSettings
{
    public class Account : Entity
    {
        public string Email { get; set; }

        public Settings Settings { get; set; }
    }
}
