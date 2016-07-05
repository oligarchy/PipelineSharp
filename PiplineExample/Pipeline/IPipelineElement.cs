using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Pipeline
{
    public interface IPipelineElement<T> 
        where T : class 
    {
        PipelineStatusEnum PipelineStatus { get; }
        Task<T> Success(T previousResult);
        T Error(T previousResult);
    }
}
