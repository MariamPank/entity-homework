using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HomeWorks_OneToOne.Models.OneToOne.AccountSettings
{
    public class Settings : Entity
    {
        public bool IsPrivate { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
