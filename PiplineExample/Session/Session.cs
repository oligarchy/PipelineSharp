using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Session
{
    public class Session : ISession 
    {
        public Session()
        {
            History = new List<string>();
        }

        public SessionStatusEnum Status { get; set; }
        public List<string> History { get; set; }
    }
}
