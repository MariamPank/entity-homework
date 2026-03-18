using SMTP_MotivationalEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_MotivationalEmail.Models
{
    internal class Employee : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public List<EmailLog> EmailLogs { get; set; } = new();
    }
}
