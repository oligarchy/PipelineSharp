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
    public class PipelineStopElementWrapper : IPipelineElement<ISession>, IPipelineStatus
    {
        public PipelineStopElementWrapper
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
                if (this._session == null)
                {
                    return PipelineStatusEnum.Unknown;
                }

                if
                (
                    this._session.Status == SessionStatusEnum.Failure  ||
                    this._session.Status == SessionStatusEnum.Unknown 
                )
                {
                    return PipelineStatusEnum.Failure;
                }

                return PipelineStatusEnum.Success;
            }
        }

        public async Task<ISession> Success(ISession previousResult)
        {
            this._session = await this._action.ExecuteAction(previousResult);
            return this._session;
        }

        public ISession Error(ISession previousResult)
        {
            Console.WriteLine("Reached Stop Element Error Handler:");

            foreach (string historyItem in previousResult.History)
            {
                Console.WriteLine(historyItem);
            }

            return previousResult;
        }
    }
}
