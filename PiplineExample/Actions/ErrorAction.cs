using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiplineExample.Session;

namespace PiplineExample.Actions
{
    public class ErrorAction : ISequentialAction 
    {
        public ErrorAction
        (
            string nameForHistory    
        )
        {
            this._nameForHistory = nameForHistory;
        }

        private readonly string _nameForHistory;

        public async Task<ISession> ExecuteAction(ISession previous)
        {
            previous.Status = SessionStatusEnum.Failure;
            previous.History.Add(this._nameForHistory);
            
            return previous;
        }
    }
}
