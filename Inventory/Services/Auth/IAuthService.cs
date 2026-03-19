using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.Auth
{
    internal interface IAuthService
    {
        void Register();
        void Login();
    }
}
