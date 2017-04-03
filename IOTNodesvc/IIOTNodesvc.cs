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
        List<IOTNodeData> GetIotData();
    }

    //  add composite types to service operations.
    [DataContract]
    public class IOTNodeData
    {
        bool boolValue = true;
        public string strIotNodeId ;
        public string sensorId;
        public string value;

        public IOTNodeData()
        {
            strIotNodeId = new string('c', 20);
            sensorId = new string('c', 20);
            value = new string('c', 20);
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

        [DataMember]
        public string SensorId
        {
            get { return sensorId; }
            set { sensorId = ""; }
        }

        [DataMember]
        public string Value
        {
            get { return value; }
            set { value = ""; }
        }

    }

}

