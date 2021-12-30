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

            lvInstOfExecutionContext.FunctionName = @"FunctionName";
            lvInstOfExecutionContext.InvocationId = @"InvocationId";

            lvInstOfActivityContext.Name = @"Name";
            lvInstOfActivityContext.InstanceId = @"InstanceId";

            lvInstOfOrchestrationContext.Name = @"Name";
            lvInstOfOrchestrationContext.InstanceId = @"InstanceId";
            lvInstOfOrchestrationContext.ParentInstanceId = @"ParentInstanceId";

            string lvOutput  = StaticClass.Render(lvInstOfExecutionContext);
            string lvOutput2 = StaticClass.Render(lvInstOfActivityContext);
            string lvOutput3 = StaticClass.Render(lvInstOfOrchestrationContext);
            string lvOutput4 = StaticClass.Render(lvInstOfExecutionContext, lvInstOfActivityContext);
            string lvOutput5 = StaticClass.Render(lvInstOfOrchestrationContext, lvInstOfExecutionContext);

            Console.WriteLine(lvOutput);  // Output: {FunctionName}(InvocationId:{InvocationId}
            Console.WriteLine(lvOutput2); // Output: {Name}(InstanceId:{InstanceId})
            Console.WriteLine(lvOutput3); // Output: {Name}(InstanceId:{InstanceId}(ParentInstanceId:{ParentInstanceId})
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
            if (pInstOfActiviyContext.Name == null)
            {
                return ("(InstanceId:{" + pInstOfActiviyContext.InstanceId + "})");
            }
            else if (pInstOfActiviyContext.InstanceId == null)
            {
                return ("{" + pInstOfActiviyContext.Name + "}");
            }
            else
            {
                return ("{" + pInstOfActiviyContext.Name + "}(InstanceId:{" + pInstOfActiviyContext.InstanceId + "})");
            }
        }

        public static string Render(OrchestrationContext pInstOfOrchestrationContext)
        {
            if (pInstOfOrchestrationContext.Name == null)
            {
                return ("(InstanceId:{" + pInstOfOrchestrationContext.InstanceId + "}(ParentInstanceId:{" + pInstOfOrchestrationContext.ParentInstanceId + "})");
            } else if (pInstOfOrchestrationContext.InstanceId == null)
            {
                return ("{" + pInstOfOrchestrationContext.Name + "}(ParentInstanceId:{" + pInstOfOrchestrationContext.ParentInstanceId + "})");
            } else if (pInstOfOrchestrationContext.ParentInstanceId == null)
            {
                return ("{" + pInstOfOrchestrationContext.Name + "}(InstanceId:{" + pInstOfOrchestrationContext.InstanceId + "})");
            }else {
                return("{" + pInstOfOrchestrationContext.Name + "}(InstanceId:{" + pInstOfOrchestrationContext.InstanceId + "}(ParentInstanceId:{" + pInstOfOrchestrationContext.ParentInstanceId + "})");
            }
        }

        public static string Render(ExecutionContext pInstOfExecutionContext, ActivityContext pInstOfActiviyContext)
        {
            // if both objects complete : 
            if (pInstOfExecutionContext != null && pInstOfActiviyContext != null)
            {
               return (
                    "{" + pInstOfExecutionContext.FunctionName + "}(InvocationId:{" + pInstOfExecutionContext.InvocationId + "}" + "\n\r" +
                     "{" + pInstOfActiviyContext.Name + "}(InvocationId:{" + pInstOfActiviyContext.InstanceId + "}"
                    );
            } else { return "temp paceholder"; }
        }

        public static string Render(OrchestrationContext pInstOfOrchestrationContext, ExecutionContext pInstOfExecutionContext)
        {
            // if both objects complete : 
            if (pInstOfOrchestrationContext != null && pInstOfExecutionContext != null)
            {
                return (
                     "{" + pInstOfOrchestrationContext.Name + "}(InstanceId:{" + pInstOfOrchestrationContext.InstanceId + "}(ParentInstanceId:{" + pInstOfOrchestrationContext.ParentInstanceId + "})"
                     + "\n\r" + "{" + pInstOfExecutionContext.FunctionName + "}(InvocationId:{" + pInstOfExecutionContext.InvocationId + "}"
                     );
            }
            else { return "temp paceholder"; }
        }

    }

}
