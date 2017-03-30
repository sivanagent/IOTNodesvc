using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IOTNodesvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class IOTNodesvc : IIOTNodesvc
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IOTNodeData GetDataUsingDataContract(IOTNodeData composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StrIotNodeId += "Suffix";
            }
            return composite;
        }


        public IOTNodeData GetIotData()
        {
            int i = 0;
            IOTNodeData vIOTNodeData = new IOTNodeData();

            vIOTNodeData.StrIotNodeId = "node1";

            while (i<4)
            {
                vIOTNodeData.sensorData[i].sensorId = "snsrId-" + Convert.ToString(i);
                vIOTNodeData.sensorData[i].value = Convert.ToString(i);
                i++;
            }

            return vIOTNodeData;
        }
    }
}

