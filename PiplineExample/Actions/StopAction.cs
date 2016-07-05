using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiplineExample.Session;

namespace PiplineExample.Actions
{
    public class StopAction : ISequentialAction
    {
        public async Task<ISession> ExecuteAction(ISession previous)
        {
            Console.WriteLine("Reached Stop Handler:");

            foreach (string historyItem in previous.History)
            {
                Console.WriteLine(historyItem);
            }

            return previous;
        }
    }
}
