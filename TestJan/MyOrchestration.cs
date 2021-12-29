using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJan
{
    class MyOrchestration
    {
        // Create fields
        private string name;
        private int instanceId;
        private int parentInstanceId;

        public MyOrchestration()
        {
        }

        public void Render()
        {
            if (this.Name == null)
            {
                Console.WriteLine("MyOrchestration result : (InstanceId:{" + this.InstanceId + "}" +
                "(ParentId:{" + this.ParentInstanceId + "}))");
            } else if (this.InstanceId == null)
            {
                Console.WriteLine("MyOrchestration result : {" + this.Name + "}(ParentId:{" + this.ParentInstanceId + "})");
            } else {
                Console.WriteLine("MyOrchestration result : {" + this.Name + "}(InstanceId:{" + this.InstanceId + "}" +
                "(ParentId:{" + this.ParentInstanceId + "}))");
            }
        }

        // Create properties
        public string Name { get; set; }
        public int? InstanceId { get; set; }
        public int? ParentInstanceId { get; set; }
    }
}
