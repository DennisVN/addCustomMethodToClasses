using System;

namespace TestJan
{
    class Program
    {
        static void Main(string[] args)
        {
            MyExecution pMyExecution = new MyExecution();
            pMyExecution.FunctionName = "fluppe";
            pMyExecution.InvocationId = 12;
            pMyExecution.Render();

            MyActivity pMyActivity = new MyActivity();
            pMyActivity.Name = "MyActivity";
            pMyActivity.InstanceId = 66;
            pMyActivity.Render();

            MyOrchestration pMyOrchestration = new MyOrchestration();
            pMyOrchestration.Name = "MyActivity";
            pMyOrchestration.InstanceId = 66;
            pMyOrchestration.ParentInstanceId = 96;
            pMyOrchestration.Render();

            StaticRender(pMyExecution); 

            Console.ReadLine(); 

        }
        static void StaticRender(MyExecution pMyExecution)
        {
            MyExecution myExecution = pMyExecution;
            Console.WriteLine("{" + myExecution.FunctionName + "}(InvocationId:{" + myExecution.InvocationId + "})");
        }

        //static void testMethod(string name, int instanceid)
        //{
        //    Console.WriteLine("{" + name + "}(InstanceId:{" + instanceid + "})");
        //}

        //static void testMethod(string name, int instanceid, int parentinstanceid)
        //{
        //    Console.WriteLine("{" + name + "}(InstanceI{" + instanceid + "}(ParentId{" + parentinstanceid + "})");
        //}
    }
    
}
