using System;

namespace TestJan
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutionContext lvInstOfExecutionContext;
            lvInstOfExecutionContext = new ExecutionContext();
            ActivityContext lvInstOfActivityContext;
            lvInstOfActivityContext = new ActivityContext();
            OrchestrationContext lvInstOfOrchestrationContext;
            lvInstOfOrchestrationContext = new OrchestrationContext();

            //lvInstOfExecutionContext.FunctionName = @"FunctionName";
            lvInstOfExecutionContext.InvocationId = @"InvocationId";

            lvInstOfActivityContext.Name = @"Name";
            lvInstOfActivityContext.InstanceId = @"InstanceId";

            lvInstOfOrchestrationContext.Name = @"Name";
            lvInstOfOrchestrationContext.InstanceId = @"InstanceId";
            lvInstOfOrchestrationContext.ParentInstanceId = @"ParentInstanceId";

            string lvOutput = StaticClass.Render(lvInstOfExecutionContext);
            string lvOutput2 = StaticClass.Render(lvInstOfActivityContext);
            string lvOutput3 = StaticClass.Render(lvInstOfOrchestrationContext);
            string lvOutput4 = StaticClass.Render(lvInstOfExecutionContext, lvInstOfActivityContext);
            string lvOutput5 = StaticClass.Render(lvInstOfOrchestrationContext, lvInstOfExecutionContext);

            Console.WriteLine(lvOutput);  // Output: {FunctionName}(InvocationId:{InvocationId}
            Console.WriteLine(lvOutput2); // Output: TestJan.ActivityContext
            Console.WriteLine(lvOutput3); // Output: TestJan.OrchestrationContext
            Console.WriteLine(lvOutput4); // Output: TestJan.ExecutionContext, TestJan.ActivityContext
            Console.WriteLine(lvOutput5); // Output: TestJan.OrchestrationContext, TestJan.ExecutionContext

            Console.ReadLine();

        }
    }

    static class StaticClass
    {
        public static string Render(ExecutionContext pInstOfExecutionContext)
        {
            if (pInstOfExecutionContext.FunctionName == null)
            {
                return ("InvocationId:{" + pInstOfExecutionContext.InvocationId.ToString() + "}");
            } 
            else if (pInstOfExecutionContext.InvocationId == null)
            {
                return ("{" + pInstOfExecutionContext.FunctionName.ToString() + "}");
            }
            else { 
                return ("{" + pInstOfExecutionContext.FunctionName.ToString() +"}(InvocationId:{"+ pInstOfExecutionContext.InvocationId.ToString() + "}");
            }
        }

        public static string Render(ActivityContext pInstOfActiviyContext)
        {
            return pInstOfActiviyContext.ToString();
        }

        public static string Render(OrchestrationContext pInstOfOrchestrationContext)
        {
            return pInstOfOrchestrationContext.ToString();
        }

        public static string Render(ExecutionContext pInstOfExecutionContext, ActivityContext pInstOfActiviyContext)
        {
            return pInstOfExecutionContext.ToString() + "\n\r" + pInstOfActiviyContext;
        }

        public static string Render(OrchestrationContext pInstOfOrchestrationContext, ExecutionContext pInstOfExecutionContext)
        {
            return pInstOfOrchestrationContext.ToString() + "\n\r" + pInstOfExecutionContext;
        }

    }

}
