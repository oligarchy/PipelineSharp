using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiplineExample.Session;

namespace PiplineExample.Actions
{
    public class SequentialAction : ISequentialAction
    {
        public SequentialAction
        (
            string nameForHistory    
        )
        {
            this._nameForHistory = nameForHistory;
        }

        private readonly string _nameForHistory;

        public async Task<ISession> ExecuteAction(ISession previous)
        {
            if (previous == null)
            {
                previous = new Session.Session();
            }

            previous.Status = SessionStatusEnum.Success;
            previous.History.Add(this._nameForHistory);

            return previous;
        }
    }
}
