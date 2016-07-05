using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Session
{
    public interface ISession
    {
        SessionStatusEnum Status { get; set; }
        List<string> History { get; set; }
    }
}
