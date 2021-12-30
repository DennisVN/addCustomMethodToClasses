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
            Console.WriteLine(lvOutput4); // Output: {FunctionName}(InvocationId:{InvocationId} + {Name}(InvocationId:{InstanceId}
            Console.WriteLine(lvOutput5); // Output: {Name}(InstanceId:{InstanceId}(ParentInstanceId:{ParentInstanceId})+ {FunctionName}(InvocationId:{InvocationId}

            #region Test Results
            //Test ExecutionContext
            //ExecutionContext lvTestContext; // Please give FunctionName or InvocationId to process.
            //lvTestContext = new ExecutionContext();
            //string lvTestOP = StaticClass.Render(lvTestContext);
            //Console.WriteLine(lvTestOP);

            //ExecutionContext lvTestContext2; // InvocationId:{InvocationId}
            //lvTestContext2 = new ExecutionContext();
            //lvTestContext2.InvocationId = @"InvocationId";
            //string lvTestOP2 = StaticClass.Render(lvTestContext2);
            //Console.WriteLine(lvTestOP2);

            //ExecutionContext lvTestContext5; // {FunctionName}
            //lvTestContext5 = new ExecutionContext();
            //lvTestContext5.FunctionName = @"FunctionName";
            //string lvTestOP5 = StaticClass.Render(lvTestContext5);
            //Console.WriteLine(lvTestOP5);

            // Test ActivityContext 
            // ActivityContext lvTestContext3; // {Name}
            //lvTestContext3 = new ActivityContext();
            //lvTestContext3.Name = @"Name";
            //string lvTestOP3 = StaticClass.Render(lvTestContext3);
            //Console.WriteLine(lvTestOP3);

            //ActivityContext lvTestContext4; // (InstanceId:{InstanceId})
            //lvTestContext4 = new ActivityContext();
            //lvTestContext4.InstanceId = @"InstanceId";
            //string lvTestOP4 = StaticClass.Render(lvTestContext4);
            //Console.WriteLine(lvTestOP4);

            //ActivityContext lvTestContext6; // Please give Name or InstanceId to Render
            //lvTestContext6 = new ActivityContext();
            //string lvTestOP6 = StaticClass.Render(lvTestContext6);
            //Console.WriteLine(lvTestOP6);

            // Test OrchestrationContext
            //OrchestrationContext lvTestContext7; // {Name}(ParentInstanceId:{})
            //lvTestContext7 = new OrchestrationContext();
            //lvTestContext7.Name = @"Name";
            //string lvTestOP7 = StaticClass.Render(lvTestContext7);
            //Console.WriteLine(lvTestOP7);

            //OrchestrationContext lvTestContext8; // (InstanceId:{InstanceId}(ParentInstanceId:{})
            //lvTestContext8 = new OrchestrationContext();
            //lvTestContext8.InstanceId = @"InstanceId";
            //string lvTestOP8 = StaticClass.Render(lvTestContext8);
            //Console.WriteLine(lvTestOP8);

            //OrchestrationContext lvTestContext9; // (InstanceId:{}(ParentInstanceId:{ParentInstanceId})
            //lvTestContext9 = new OrchestrationContext();
            //lvTestContext9.ParentInstanceId = @"ParentInstanceId";
            //string lvTestOP9 = StaticClass.Render(lvTestContext9);
            //Console.WriteLine(lvTestOP9);

            //OrchestrationContext lvTestContext10; // All fields are empty, please complete Name, InstanceId and/or ParentInstanceId !
            //lvTestContext10 = new OrchestrationContext();
            //string lvTestOP10 = StaticClass.Render(lvTestContext10);
            //Console.WriteLine(lvTestOP10);

            // Test Execution + Activity chain
            //ExecutionContext lvTestContext11;
            //lvTestContext11 = new ExecutionContext();
            //lvTestContext11.FunctionName = @"FunctionName";
            //lvTestContext11.InvocationId = @"InvocationId";
            //ActivityContext lvTestContext12;
            //lvTestContext12 = new ActivityContext();
            //lvTestContext12.Name = @"Name";
            //lvTestContext12.InstanceId = @"InstanceId";
            //string lvTestOP11 = StaticClass.Render(lvTestContext11, lvTestContext12);
            //Console.WriteLine(lvTestOP11);


            #endregion

            Console.ReadLine();
        }
    }

    static class StaticClass
    {
        public static string Render(ExecutionContext pInstOfExecutionContext)
        {
            if (pInstOfExecutionContext.FunctionName == null && pInstOfExecutionContext.InvocationId == null)
            {
                return ("Please give FunctionName or InvocationId to Render.");
            } 
            else if (pInstOfExecutionContext.InvocationId == null)
            {
                return ("{" + pInstOfExecutionContext.FunctionName.ToString() + "}");
            }
            else if (pInstOfExecutionContext.FunctionName == null ) 
            {
                return ("InvocationId:{"+ pInstOfExecutionContext.InvocationId + "}");
            }
            else { 
                return ("{" + pInstOfExecutionContext.FunctionName +"}(InvocationId:{"+ pInstOfExecutionContext.InvocationId + "}");
            }
        }

        public static string Render(ActivityContext pInstOfActivityContext)
        {
            if(pInstOfActivityContext.Name == null && pInstOfActivityContext.InstanceId == null)
            {
                return ("Please give Name or InstanceId to Render");
            }
            else if (pInstOfActivityContext.Name == null)
            {
                return ("(InstanceId:{" + pInstOfActivityContext.InstanceId + "})");
            }
            else if (pInstOfActivityContext.InstanceId == null)
            {
                return ("{" + pInstOfActivityContext.Name + "}");
            }
            else
            {
                return ("{" + pInstOfActivityContext.Name + "}(InstanceId:{" + pInstOfActivityContext.InstanceId + "})");
            }
        }

        public static string Render(OrchestrationContext pInstOfOrchestrationContext)
        {
            if(pInstOfOrchestrationContext.Name == null && pInstOfOrchestrationContext.InstanceId == null && pInstOfOrchestrationContext.ParentInstanceId == null)
            {
                return "All fields are empty, please complete Name, InstanceId and/or ParentInstanceId ! ";
            }
            else if (pInstOfOrchestrationContext.Name == null)
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

        public static string Render(ExecutionContext pInstOfExecutionContext, ActivityContext pInstOfActivityContext)
        {
            // if both objects complete : 
            if (pInstOfExecutionContext != null && pInstOfActivityContext != null)
            {
               return (
                    "{" + pInstOfExecutionContext.FunctionName + "}(InvocationId:{" + pInstOfExecutionContext.InvocationId + "}" + "\n\r" +
                    "{" + pInstOfActivityContext.Name + "}(InvocationId:{" + pInstOfActivityContext.InstanceId + "}"
                    );
            } else { return "Fields missing"; }
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
            else { return "Fields missing"; }
        }

    }

}
