using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJan
{
    class MyActivity
    {
        private string name;
        private int instanceId;

        public MyActivity()
        {
        }

        public void Render()
        {
            if(this.Name == null)
            {
                Console.WriteLine("MyActivity result : (InstanceId:{" + this.InstanceId + "})");
            }else if (this.InstanceId == null)
            {
                Console.WriteLine("MyActivity result : {" + this.Name + "}");
            } else {
                Console.WriteLine("MyActivity result : {" + this.Name + "}(InstanceId:{" + this.InstanceId + "})");
            }
            
        }

        public string Name { get; set; }
        public int? InstanceId { get; set; }
    }
}
