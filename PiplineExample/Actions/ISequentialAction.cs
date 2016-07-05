using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiplineExample.Session;

namespace PiplineExample.Actions
{
    public interface ISequentialAction
    {
        Task<ISession> ExecuteAction(ISession previous);
    }
}
