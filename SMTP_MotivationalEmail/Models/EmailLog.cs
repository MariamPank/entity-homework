using SMTP_MotivationalEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_MotivationalEmail.Models
{
    internal class EmailLog : Entity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime SentAt { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
