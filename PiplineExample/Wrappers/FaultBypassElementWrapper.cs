using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PiplineExample.Actions;
using PiplineExample.Pipeline;
using PiplineExample.Session;

namespace PiplineExample.Wrappers
{
    // this wrapper is meant to have a fault tolerant action in it
    // something we should just keep going on with the rest of the pipeline if it fails
    public class FaultBypassElementWrapper : IPipelineElement<ISession>, IPipelineStatus
    {
        public FaultBypassElementWrapper
        (
            ISequentialAction action
        )
        {
            this._action = action;
            this._session = null;
        }

        private readonly ISequentialAction _action;
        private ISession _session;
 
        public PipelineStatusEnum PipelineStatus
        {
            get
            {
                return PipelineStatusEnum.Success;
            }
        }

        public async Task<ISession> Success(ISession previousResult)
        {
            try
            {
                this._session = await this._action.ExecuteAction(previousResult);
                return this._session;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fault bypass: " + ex.ToString());
                return previousResult;
            }
        }

        public ISession Error(ISession previousResult)
        {
            return previousResult;
        }
    }
}
