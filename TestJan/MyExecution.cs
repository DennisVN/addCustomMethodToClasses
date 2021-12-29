using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJan
{
    class MyExecution
    {
        // Create fields
        private string functionName;
        private int invocationId;

        public MyExecution()
        {
        }

        // Create properties
        public string FunctionName { get; set; }
        public int? InvocationId { get; set; }

        // Method for rendering 
        // TODO: validate properties
        public void Render()
        {
            if (this.FunctionName == null)
            {
                string result = "MyExecution result : InvocationId:{" + this.InvocationId + "})";
                //Console.WriteLine(result.Substring(0,7));
            } if (this.InvocationId == null)
            {
                Console.WriteLine("MyExecution result : {" + this.FunctionName + "}");
            }
            else { 
                Console.WriteLine("MyExecution result : {" + this.FunctionName + "}(" +
                    this.InvocationId + ":{" + this.InvocationId + "})"); 
            }
        }

    }


}
