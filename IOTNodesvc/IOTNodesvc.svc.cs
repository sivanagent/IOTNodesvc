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
        private iniFileReader mIOTNodeconfig;
        string[] mSensorIdList;
        string[] mIOTNodeIdSection;
        string mIOTNodeId;

        List<IOTNodeData> vIOTNodeData;

        public IOTNodesvc()
        {
            mIOTNodeconfig = new iniFileReader();
            mIOTNodeconfig.IniParser("d:\\iotnodesvcconfig.ini");
            mSensorIdList = mIOTNodeconfig.EnumSection("AttachedSensors");
            mIOTNodeIdSection = mIOTNodeconfig.EnumSection("IOTId");
            mIOTNodeId = new string('x', 20);
            mIOTNodeId = mIOTNodeconfig.GetSetting("IOTId", "iotNodeId");
            

            vIOTNodeData = new List<IOTNodeData>();

            int i = 0;
            while (mSensorIdList.Length > i)
            {
                vIOTNodeData.Add(new IOTNodeData());
                vIOTNodeData[i].StrIotNodeId = mIOTNodeId;
                vIOTNodeData[i].sensorId = mSensorIdList[i];
                i++;
            }


        }

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


        public List<IOTNodeData> GetIotData()
        {
            int i = 0;

            while (vIOTNodeData.Count > i)
            {
                vIOTNodeData[i].value = Convert.ToString(i);
                i++;
            }

            return vIOTNodeData;
        }
    }
}

