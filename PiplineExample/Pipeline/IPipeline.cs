using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Pipeline
{
    public interface IPipeline<T> where T : class
    {
        Task<bool> Run();
        void Add(IPipelineElement<T> anElement);
    }
}
