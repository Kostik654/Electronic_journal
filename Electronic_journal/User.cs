using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal
{
    public abstract class User
    {
        protected int status_id;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get => DataWork.Statuses[status_id]; set => status_id = DataWork.Statuses.IndexOf(value); }
    }
}
