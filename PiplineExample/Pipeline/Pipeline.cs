using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplineExample.Pipeline
{
    public class Pipeline<T> : IPipeline<T> where T : class 
    {
        public Pipeline()
        {
            this._pipeline = new List<IPipelineElement<T>>();
        }

        private List<IPipelineElement<T>> _pipeline;

        public void Add(IPipelineElement<T> anElement)
        {
            this._pipeline.Add(anElement);
        }

        public async Task<bool> Run()
        {
            T result = await this._pipeline[0].Success(default(T));

            for (int i = 0; i < this._pipeline.Count; i++)
            {
                if (this._pipeline[i].PipelineStatus == PipelineStatusEnum.Success)
                {
                    Debug.WriteLine("Success: " + i);

                    if ((i + 1) < this._pipeline.Count)
                    {
                        result = await this._pipeline[i + 1].Success(result);
                    }
                }
                else
                {
                    Debug.WriteLine("Error: " + i);

                    if ((i + 1) < this._pipeline.Count)
                    {
                        result = this._pipeline[i + 1].Error(result);
                    }
                }
            }

            return true;
        }
    }
}
