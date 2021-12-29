using System;

namespace TestJan
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: validate properties individually
            MyExecution pMyExecution = new MyExecution();
            //pMyExecution.FunctionName = "fluppe";
            pMyExecution.InvocationId = 12;
            pMyExecution.Render();

            MyActivity pMyActivity = new MyActivity();
            pMyActivity.Name = "MyActivity";
            //pMyActivity.InstanceId = 66;
            pMyActivity.Render();

            MyOrchestration pMyOrchestration = new MyOrchestration();
            //pMyOrchestration.Name = "MyActivity";
            pMyOrchestration.InstanceId = 66;
            pMyOrchestration.ParentInstanceId = 96;
            pMyOrchestration.Render();

            Console.ReadLine();
        }

    }
}
