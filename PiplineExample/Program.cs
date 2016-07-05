using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiplineExample.Actions;
using PiplineExample.Pipeline;
using PiplineExample.Session;
using PiplineExample.Wrappers;

namespace PiplineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // configure out pipeline container
            IPipeline<ISession> pipeline = new Pipeline<ISession>();

            // configure the actions we want our pipeline to execute
            ISequentialAction action1 = new SequentialAction("Action 1");
            ISequentialAction action2 = new SequentialAction("Action 2");
            ISequentialAction action3 = new SequentialAction("Action 3");
            ISequentialAction errActionCont = new ErrorAction("Error Action Cont");
            ISequentialAction errActionStop = new ErrorAction("Error Action Stop");
            ISequentialAction stop = new StopAction();

            // wrap each of the actions in a pipeline element wrapper for execution
            IPipelineElement<ISession> elem1 = new NormalElementWrapper(action1);
            IPipelineElement<ISession> elem2 = new NormalElementWrapper(action2);
            IPipelineElement<ISession> elem3 = new NormalElementWrapper(action3);
            IPipelineElement<ISession> errElemCont = new FaultBypassElementWrapper(errActionCont);
            IPipelineElement<ISession> errElemStop = new NormalElementWrapper(errActionStop);
            IPipelineElement<ISession> stopElem = new PipelineStopElementWrapper(stop);

            // add all element wrappers to our pipeline
            pipeline.Add(elem1);
            
            // uncomment the below line to generate an error but keep executing the pipeline
            //pipeline.Add(errElemCont);

            // uncomment the below line to generate an error that will bypass further items in pipeline
            //pipeline.Add(errElemStop);

            pipeline.Add(elem2);
            pipeline.Add(elem3);
            pipeline.Add(stopElem);
            
            // run the pipeline, execution flow will depend on which handlers are added
            pipeline.Run().Wait();
            
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
