using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Pipeline
{
    public interface IPipelineStatus
    {
        PipelineStatusEnum PipelineStatus { get; }
    }
}
