using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IOTNodesvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IIOTNodesvc
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        IOTNodeData GetDataUsingDataContract(IOTNodeData composite);

        // TODO: Add your service operations here
        [OperationContract]
        IOTNodeData GetIotData();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SensorData
    {
        public string sensorId; 
        public string value;
        public SensorData()
        {
            sensorId = new string('c', 20);
            value    = new string('c', 20);
        }
    }


    [DataContract]
    public class IOTNodeData
    {
        bool boolValue = true;
        string strIotNodeId = "iot-node1";
        
        public SensorData [] sensorData;
        public IOTNodeData()
        {
            sensorData = new SensorData[4];
            sensorData[0] = new SensorData();
            sensorData[1] = new SensorData();
            sensorData[2] = new SensorData();
            sensorData[3] = new SensorData();

        }

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StrIotNodeId
        {
            get { return strIotNodeId; }
            set { strIotNodeId = value; }
        }
    }

}

